using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingParent : MonoBehaviour
{

    public static float fallSpeed = 1.0f;
    public bool isMisspelled = false;
    public bool isClicked=false;
    public CanvasManager Canvas;
    public LettersGame MainGameObject;



    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        if (Camera.main.WorldToScreenPoint(gameObject.transform.position).y<=0) {
            if (!isMisspelled && LettersGame.Inplay) {
                string correctword="";
                foreach (Transform letter in gameObject.transform) {
                    correctword = correctword + letter.name[0];
                }
                Canvas.OnLose(correctword);
                gameObject.transform.parent.gameObject.GetComponent<WordsGenerator>().enabled = false;
                MainGameObject.UnTriggerPlaying();
                fallSpeed = 1.0f;
                print("YOU LOSE! YOU LET CORRECT LETTER!");
            }
            Destroy(gameObject);
        }
    }
    public void PauseGame() {
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    }
}
