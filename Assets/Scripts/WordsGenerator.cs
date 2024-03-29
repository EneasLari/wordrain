﻿using Assets.Scripts.PersistentData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsGenerator : MonoBehaviour {

    public LettersGame LettersgameGameobject;
    public float spaceBetweenLetters = 0.03f;
    public GameObject EmptyGameObject;

    public Camera MainCamera;

    private GameObject[] _lettersArray = null;
    private double _timetorepawn = 3;
    private DateTime _startTimer = DateTime.MinValue;

    public void StartTimer() {
        _startTimer = DateTime.Now;
    }

    // Start is called before the first frame update
    void Start() {
        SpawnWord(0);
        StartTimer();
    }

    // Update is called once per frame
    void Update() {
        if (GetTimePassed() >= TimeToRespawn) {
            SpawnWord(0);
            StartTimer();
        }
    }

    public double GetTimePassed() {
        DateTime starttime = _startTimer;
        //_startTimer = DateTime.MinValue;
        if (_startTimer != DateTime.MinValue) {
            return (DateTime.Now - starttime).TotalSeconds;
        }
        return 0;
    }

    public double TimeToRespawn { 
        get {
            return _timetorepawn;
        } set {
            _timetorepawn = value;
        } 
    }

    public GameObject[] LettersArray {
        get {
            if (_lettersArray == null) {
                InitializeLettersArray();
            }
            return _lettersArray;
        }
        private set { _lettersArray = value; }
    }

    private void InitializeLettersArray() {
        Transform LettersParent = transform.Find("LettersParent");
        if (LettersgameGameobject.SelectedLanguage == Language.English) {
            LettersParent = LettersParent.Find("English");
        } else if (LettersgameGameobject.SelectedLanguage == Language.Greek) {
            LettersParent = LettersParent.Find("Greek");
        }
        if (LettersParent != null) {
            if (LettersgameGameobject.SelectedLetterCase == LetterCase.LowerCase) {
                LettersParent = LettersParent.Find("LowerCase");
            } else if (LettersgameGameobject.SelectedLetterCase == LetterCase.UpperCase) {
                LettersParent = LettersParent.Find("UpperCase");
            }
            if (LettersParent != null) {
                _lettersArray = new GameObject[LettersParent.childCount];
                for (int i = 0; i < LettersParent.childCount; i++) {
                    _lettersArray[i] = LettersParent.GetChild(i).gameObject;
                }
            }
        }

    }
    
    private void SpawnWord(float offsetatX) {
        bool ismisspelled = LettersgameGameobject.getNextWord();
        string word = LettersgameGameobject.CurrentWord;
        int count = 0;
        GameObject inst = null;
        GameObject wordParent = null;
        Vector3 sizeofletter = Vector3.zero;
        foreach (char c in word) {
            count++;
            Vector3 pos = new Vector3(gameObject.transform.position.x + offsetatX, gameObject.transform.position.y, gameObject.transform.position.z);
            inst = Instantiate(getPrefabFromLetter(c + ""), pos, getPrefabFromLetter(c + "").transform.rotation);
            inst.transform.Rotate(0, 180, 0);
            sizeofletter = inst.GetComponent<Renderer>().bounds.size;
            Vector3 sizeofrenderer= inst.GetComponent<MeshRenderer>().bounds.size;
            Vector3 sizeofrenderer2 = inst.GetComponent<MeshFilter>().mesh.bounds.size;
            if (wordParent == null) {
                wordParent = Instantiate(EmptyGameObject, pos, inst.transform.rotation);
                wordParent.SetActive(true);
                wordParent.transform.SetParent(gameObject.transform);
                wordParent.name = "FallingParent";
                wordParent.AddComponent<BoxCollider>();
                wordParent.GetComponent<BoxCollider>().size = sizeofletter;
            }
            inst.transform.SetParent(wordParent.transform);
            if (!ismisspelled) {
                GameObject explosionpieces = Instantiate(wordParent.transform.Find("ExplosionPieces").gameObject);
                explosionpieces.name = "ExplosionPieces";
                explosionpieces.transform.SetParent(inst.transform);
                explosionpieces.transform.position = inst.transform.position;
            }

            inst.transform.parent.gameObject.GetComponent<FallingParent>().isMisspelled = ismisspelled;

            if (count < word.Length)
            {
                offsetatX = offsetatX + sizeofletter.x + spaceBetweenLetters;
            }
            else {
                offsetatX = offsetatX + sizeofletter.x;
            }
            
            wordParent.GetComponent<BoxCollider>().size = new Vector3(offsetatX,sizeofletter.y,sizeofletter.z);
        }
        
        Vector3 wordParentSize = wordParent.GetComponent<BoxCollider>().size;
        float extrasizeforbetterclick = 0.5f;
        wordParent.GetComponent<BoxCollider>().size += new Vector3(extrasizeforbetterclick,extrasizeforbetterclick, 0);
        wordParent.GetComponent<BoxCollider>().center = new Vector3(-(wordParentSize.x/2),wordParentSize.y/2,0);
        Transform lastLetter = null;
        float deltaX = 0;
        if (inst!=null) {
            lastLetter = inst.transform;
            deltaX = lastLetter.position.x - wordParent.transform.position.x;
        }
        Destroy(wordParent.transform.Find("ExplosionPieces").gameObject);
        Vector3 parentPosition = wordParent.transform.position;
        Vector3 worldtoscreenpos = MainCamera.WorldToScreenPoint(parentPosition);
        Vector3 screentoworldpos1 = MainCamera.ViewportToWorldPoint(new Vector3(0, worldtoscreenpos.y, worldtoscreenpos.z));
        Vector3 screentoworldpos2 = MainCamera.ViewportToWorldPoint(new Vector3(1, worldtoscreenpos.y, worldtoscreenpos.z));
        float positionX = UnityEngine.Random.Range(screentoworldpos1.x, screentoworldpos2.x - (deltaX + 2));
        wordParent.transform.position = new Vector3(positionX, parentPosition.y, parentPosition.z);
        //Debug.Log("Parent of the word is between " + screentoworldpos1.x + " and " + screentoworldpos2.x + " pixels from the left");
    }

    public GameObject getPrefabFromLetter(string ch) {
        GameObject gm = null;
        for (int i = 0; i < LettersArray.Length; i++) {
            if (LettersArray[i].name.Equals(ch)) {
                gm = LettersArray[i];
            }
        }
        return gm;
    }

}
