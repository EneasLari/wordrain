using Assets.Scripts.PersistentData;
using Assets.Scripts.UserSystem.GlobalData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordClickManager : MonoBehaviour {
    // Use this for initialization


    public Material FalseMaterial;
    private Material PreviousMaterial=null;
    public GameObject MainGameGameObject;
    public Text ScoreText;
    public AudioSource ExplosionAudioSource;
    public AudioClip CorrectClip;
    public AudioClip WrongClip;

    [SerializeField]
    private LayerMask layerMask;
    void Start () {
		
	}

    private DateTime _startTimer = DateTime.MinValue;
    public double GetTimePassed() {
        DateTime starttime = _startTimer;
        //_startTimer = DateTime.MinValue;
        if (_startTimer != DateTime.MinValue) {
            return (DateTime.Now - starttime).TotalSeconds;
        }
        return 0;
    }

    private void OnClickParentWordObject() {
        if (!LettersGame.Inplay) {
            return;
        }
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,1000,layerMask)) {
                Transform parent = hit.transform;
                string word = "";
                if (parent != null) {
                    GameObject wordgenerator = hit.transform.parent.gameObject;
                    FallingParent fallingParent = hit.transform.GetComponent<FallingParent>();

                    for (int i = 0; i < parent.childCount; i++) {
                        word = word + parent.GetChild(i).name[0];
                    }
                    if (fallingParent.isMisspelled && !fallingParent.isClicked) {
                        fallingParent.isClicked = true;
                        //print("You clicked an misspelled word you lose"+ word);
                        if (PreviousMaterial==null) {
                            PreviousMaterial = RenderSettings.skybox;
                        }
                        Camera.main.GetComponent<SkyBoxManager>().setFalseSkyBox();
                        _startTimer = DateTime.Now;
                        wordgenerator.GetComponent<WordsGenerator>().TimeToRespawn -= 0.0005;
                        FallingParent.fallSpeed += 0.5f;
                        //foreach (Transform child in hit.transform.parent) {
                            //GameObject explosionPiecesParent = child.Find("ExplosionPieces").gameObject;
                            //explosionPiecesParent.SetActive(true);
                            //Explode(explosionPiecesParent.transform.Find("ExplotionCenter").gameObject);
                        //}
                        ExplosionAudioSource.clip = WrongClip;
                        ExplosionAudioSource.PlayOneShot(ExplosionAudioSource.clip);

                    } else if(!fallingParent.isClicked) {
                        fallingParent.isClicked = true;
                        UserDetails activeUser = GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType);
                        activeUser.AddtoCollectedWords(new Word(word));
                        activeUser.Score += hit.transform.parent.childCount;
                        FallingParent.fallSpeed += 0.1f;
                        MainGameGameObject.GetComponent<LettersGame>().InGameScore += hit.transform.parent.childCount;
                        ScoreText.GetComponent<Animator>().SetTrigger("triggerscaler");
                        hit.transform.GetComponent<FallingParent>().enabled = false;
                        foreach (Transform child in hit.transform) {                       
                            child.gameObject.GetComponent<MeshRenderer>().enabled = false;
                            GameObject explosionPiecesParent = child.Find("ExplosionPieces").gameObject;
                            explosionPiecesParent.SetActive(true);
                            Explode(explosionPiecesParent.transform.Find("ExplotionCenter").gameObject);
                            ExplosionAudioSource.clip = CorrectClip;
                            ExplosionAudioSource.PlayOneShot(ExplosionAudioSource.clip);
                            Destroy(child.gameObject, 4f);
                            //print("You click a correctly spelled word you take points(and the word makes explosion effect--poooff)===" + word);
                        }                        
                    }
                }
            }
        }
    }

    private float radius = 10.0F;
    private float power = 60.0F;
    private void Explode(GameObject parent) {
        Vector3 explosionPos = parent.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }

	// Update is called once per frame
	void Update () {
        OnClickParentWordObject();
        if (GetTimePassed()>=0.5) {
            Camera.main.GetComponent<SkyBoxManager>().setInGameSkyBox();
            _startTimer = DateTime.MinValue;
        }
    }
}
