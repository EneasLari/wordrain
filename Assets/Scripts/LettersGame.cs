using Assets.Scripts.PersistentData;
using Assets.Scripts.UserSystem.GlobalData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LettersGame : MonoBehaviour
{
    public CanvasManager canvasManager;
    public string CurrentWord;
    public int InGameScore = 0;

    public Language SelectedLanguage;

    public LetterCase SelectedLetterCase;
    public TextMeshProUGUI coinsText;

    public static bool Inplay = false;
    // Start is called before the first frame update
    void Start() {
        if (SelectedLanguage == Language.English) {
            GlobalDictionary.setVocabulary("English");
        }
        else if (SelectedLanguage == Language.Greek) {
            GlobalDictionary.setVocabulary("Greek");
        }
        getNextWord();
    }

    void OnApplicationQuit() {
        GlobalData.SerializeAll();
    }

    public bool getNextWord() {
        bool ismisspelled = false;
        float randbool = Random.Range(0f, 2f);
        if (randbool > 1) {
            int index = Random.Range(0, GlobalDictionary.Vocabulary.Count);
            CurrentWord = GlobalDictionary.Vocabulary[index].MisspelledWordstr;
            ismisspelled = true;
        } else {
            int index = Random.Range(0, GlobalDictionary.Vocabulary.Count);
            CurrentWord = GlobalDictionary.Vocabulary[index].Wordstr;
        }
        if (SelectedLetterCase == LetterCase.LowerCase) {
            CurrentWord = CurrentWord.ToLower();
        } else if (SelectedLetterCase == LetterCase.LowerCase) {
            CurrentWord = CurrentWord.ToUpper();
        } else if (SelectedLetterCase==LetterCase.Capitalize) {
            CurrentWord.Trim();
            char firstLetter = CurrentWord[0];
            CurrentWord=CurrentWord.Substring(1);//Substring of the initial string without the first character
            CurrentWord = firstLetter.ToString().ToUpper()+CurrentWord;
        }
        return ismisspelled;
    }

    public void TriggerPlaying() {
        Inplay = true;
        Camera.main.GetComponent<SkyBoxManager>().setInGameSkyBox();
    }

    public void UnTriggerPlaying() {   
        Inplay = false;
        GlobalData.UsersManager.Serialize(GlobalData.SerialType);
        GlobalData.SharedDictionary.Serialize();
        Camera.main.GetComponent<SkyBoxManager>().setMainMenuSkyBox();
    }

    public void ReplayLevel() {
        Time.timeScale = 1;
        InGameScore = 0;
    }
    public void MainLevel() {
        Time.timeScale = 1;
        InGameScore = 0;
        Inplay = false;    
    }

    public void ContinueGame() {
        Time.timeScale = 1;
    }

    void Update() {
        canvasManager.RefreshCurrentScore(InGameScore);
    }
}
