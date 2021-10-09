using Assets.Scripts.PersistentData;
using Assets.Scripts.UserSystem.GlobalData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject LosePanel;
    public GameObject InGamePanel;
    public GameObject DictionaryOptionsPanel;


    public Text CollectedWordDisplay;
    public Text SharedSavedWordDisplay;
    public Text UserSavedWordDisplay;
    public Text NumberOfCollectedWordsDisplay;
    public Text Score;
    public Text CurrentScore;
    public Text HighestScore;
    public Text CorrectWordYouMissed;
    public Text LoggedInUser;
    public Text LoggedInUser2;

    public InputField CorrectWordInput;
    public InputField MisspelledWordInput;
    public Dropdown LanguageDropDown;
    public Toggle IsSharedWord;
    public InputField UserNameInput;
    public GameObject RainWordsGameObject;

    private UserDetails _activeuser;
    // Start is called before the first frame update
    void Awake() {
        RefreshDetails();
        InitializeUsersGlobalDictionary();
        InitializeDictionaryOptions();
        LoggedInUserDisplay();
    }

    void Start() {
        
    }

    private void InitializeUsersGlobalDictionary() {
        UserDetails userdetails = GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType);
        GlobalDictionary.UseChapter1Unit1= userdetails.Chapters.Chapter1Unit1;
        GlobalDictionary.UseChapter1Unit2= userdetails.Chapters.Chapter1Unit2;
        GlobalDictionary.UseChapter1Unit3= userdetails.Chapters.Chapter1Unit3;
        GlobalDictionary.UseChapter1Unit4= userdetails.Chapters.Chapter1Unit4;
        GlobalDictionary.UseChapter1Unit5= userdetails.Chapters.Chapter1Unit5;
        GlobalDictionary.UseChapter1Unit6= userdetails.Chapters.Chapter1Unit6;
        GlobalDictionary.UseChapter1Unit7= userdetails.Chapters.Chapter1Unit7;
        GlobalDictionary.UseChapter1Unit8= userdetails.Chapters.Chapter1Unit8;
        GlobalDictionary.UseChapter1Unit9= userdetails.Chapters.Chapter1Unit9;
        GlobalDictionary.UseChapter1Unit10=userdetails.Chapters.Chapter1Unit10;
        GlobalDictionary.UseChapter2Unit1= userdetails.Chapters.Chapter2Unit1;
        GlobalDictionary.useSharedDictionary = userdetails.UseSharedDictionary;
        GlobalDictionary.useYourDictionary = userdetails.UseYourDictionary;
    }

    private void UpdateUsersGlobalDictionary() {
        UserDetails userdetails = GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType);
        userdetails.Chapters.Chapter1Unit1=GlobalDictionary.UseChapter1Unit1;
        userdetails.Chapters.Chapter1Unit2=GlobalDictionary.UseChapter1Unit2;
        userdetails.Chapters.Chapter1Unit3=GlobalDictionary.UseChapter1Unit3;
        userdetails.Chapters.Chapter1Unit4=GlobalDictionary.UseChapter1Unit4;
        userdetails.Chapters.Chapter1Unit5=GlobalDictionary.UseChapter1Unit5;
        userdetails.Chapters.Chapter1Unit6=GlobalDictionary.UseChapter1Unit6;
        userdetails.Chapters.Chapter1Unit7=GlobalDictionary.UseChapter1Unit7;
        userdetails.Chapters.Chapter1Unit8=GlobalDictionary.UseChapter1Unit8;
        userdetails.Chapters.Chapter1Unit9=GlobalDictionary.UseChapter1Unit9;
        userdetails.Chapters.Chapter1Unit10 = GlobalDictionary.UseChapter1Unit1;
        userdetails.Chapters.Chapter2Unit1= GlobalDictionary.UseChapter2Unit1;
        userdetails.UseSharedDictionary = GlobalDictionary.useSharedDictionary;
        userdetails.UseYourDictionary = GlobalDictionary.useYourDictionary;
    }

    public void InitializeDictionaryOptions(){
        DictionaryOptionsPanel.transform.Find("Chapter1Unit1").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit1;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit2").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit2;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit3").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit3;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit4").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit4;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit5").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit5;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit6").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit6;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit7").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit7;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit8").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit8;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit9").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter1Unit9;
        DictionaryOptionsPanel.transform.Find("Chapter1Unit10").GetComponent<Toggle>().isOn =GlobalDictionary.UseChapter1Unit10;
        DictionaryOptionsPanel.transform.Find("Chapter2Unit1").GetComponent<Toggle>().isOn = GlobalDictionary.UseChapter2Unit1;
        DictionaryOptionsPanel.transform.Find("SharedDictionary").GetComponent<Toggle>().isOn= GlobalDictionary.useSharedDictionary;
        DictionaryOptionsPanel.transform.Find("UserDictionary").GetComponent<Toggle>().isOn= GlobalDictionary.useYourDictionary;
    }

    public void SubmitDictionaryOptions() {
        GlobalDictionary.UseChapter1Unit1  = DictionaryOptionsPanel.transform.Find("Chapter1Unit1").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit2  = DictionaryOptionsPanel.transform.Find("Chapter1Unit2").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit3  = DictionaryOptionsPanel.transform.Find("Chapter1Unit3").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit4  = DictionaryOptionsPanel.transform.Find("Chapter1Unit4").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit5  = DictionaryOptionsPanel.transform.Find("Chapter1Unit5").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit6  = DictionaryOptionsPanel.transform.Find("Chapter1Unit6").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit7  = DictionaryOptionsPanel.transform.Find("Chapter1Unit7").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit8  = DictionaryOptionsPanel.transform.Find("Chapter1Unit8").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit9  = DictionaryOptionsPanel.transform.Find("Chapter1Unit9").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter1Unit10  = DictionaryOptionsPanel.transform.Find("Chapter1Unit10").GetComponent<Toggle>().isOn;
        GlobalDictionary.UseChapter2Unit1 = DictionaryOptionsPanel.transform.Find("Chapter2Unit1").GetComponent<Toggle>().isOn;
        GlobalDictionary.useSharedDictionary=DictionaryOptionsPanel.transform.Find("SharedDictionary").GetComponent<Toggle>().isOn;
        GlobalDictionary.useYourDictionary= DictionaryOptionsPanel.transform.Find("UserDictionary").GetComponent<Toggle>().isOn;
        GlobalDictionary.setVocabulary("Greek");
        UpdateUsersGlobalDictionary();
    }

    public void DeleteSharedSavedWord() {
        string wordtodelete = SharedSavedWordDisplay.GetComponent<Text>().text;
        List<Word> list = GlobalData.SharedDictionary.DictionaryList;
        list.Remove(list.Find(x => x.Wordstr.Equals(wordtodelete.Split('-')[0].Trim()) && x.MisspelledWordstr.Equals(wordtodelete.Split('-')[1].Trim())));
        InitializeSharedSavedWords();
        GlobalData.SharedDictionary.Serialize();
    }

    public void DeleteUserSavedWord() {
        string wordtodelete = UserSavedWordDisplay.GetComponent<Text>().text;
        List<Word> list = GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser,GlobalData.SerialType).SavedWordsList;
        list.Remove(list.Find(x => x.Wordstr.Equals(wordtodelete.Split('-')[0].Trim()) && x.MisspelledWordstr.Equals(wordtodelete.Split('-')[1].Trim())));
        InitializeUserSavedWords();
    }

    public void InitializelanguageDropDown() {
        if (LanguageDropDown.options.Count != 0) {
            return;
        }
        Dropdown.OptionData optiondata;
        foreach (Language language in Enum.GetValues(typeof(Language))) {
            optiondata = new Dropdown.OptionData();
            optiondata.text = language.ToString();
            LanguageDropDown.options.Add(optiondata);
        }
    }

    public void InitiliazeCollectedWords() {
        LoadWordsCollectedList();
        LoadFirstCollectedword();
        LoadNumOfWordsCollected();
    }

    public void InitializeSharedSavedWords() {
        LoadSharedSavedWordsList();
        LoadFirstSharedSavedword();
    }

    public void InitializeUserSavedWords() {
        LoadUserSavedWordsList();
        LoadFirstUserSavedword();
    }

    public void OnLose(string correctword) {
        if (!LosePanel.activeSelf) {
            CorrectWordYouMissed.text = "Η λέξη <<"+correctword+">> ήταν σωστή";
            LosePanel.SetActive(true);
            InGamePanel.SetActive(false);
        }
    }

    public void SubmitSavedWord() {
        if (IsSharedWord.isOn) {
            SubmitSharedSavedWord();
            InitializeSharedSavedWords();
        } else {
            SubmitUserSavedWord();
        }

    }

    private void SubmitUserSavedWord() {
        Word userword = new Word(CorrectWordInput.text, MisspelledWordInput.text);
        userword.WordLanguage =Enums.LanguageFromString(LanguageDropDown.options[LanguageDropDown.value].text);
        UsersManager userManager = GlobalData.UsersManager;
        List<Word> userSavedWordsList =userManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType).SavedWordsList;
        userSavedWordsList.Add(userword);
        userManager.Serialize(GlobalData.SerialType);
        GlobalDictionary.setVocabulary(userword.WordLanguage.ToString());
        CorrectWordInput.text = "";
        MisspelledWordInput.text = "";
    }

    private void SubmitSharedSavedWord() {
        Word sharedword = new Word(CorrectWordInput.text, MisspelledWordInput.text);
        sharedword.WordLanguage = Enums.LanguageFromString(LanguageDropDown.options[LanguageDropDown.value].text);

        List<Word> sharedWordsList = GlobalData.SharedDictionary.DictionaryList;
        sharedWordsList.Add(sharedword);
        GlobalData.SharedDictionary.Serialize();
        GlobalDictionary.setVocabulary(sharedword.WordLanguage + "");
        CorrectWordInput.text = "";
        MisspelledWordInput.text = "";
    }

    private List<Word> WordsCollectedList = new List<Word>();
    private int curentIndex = 0;
    public void SelectNextCollectedWord() {
        if (WordsCollectedList.Count - 1 > curentIndex) {
            curentIndex++;
        } else {
            curentIndex = 0;
        }
        CollectedWordDisplay.text = WordsCollectedList.Count == 0 ? CollectedWordDisplay.text + "" : curentIndex+1+")"+ WordsCollectedList[curentIndex].Wordstr;
    }

    public void SelectPreviousCollectedWord() {
        if (curentIndex > 0) {
            curentIndex--;
        } else {
            curentIndex = WordsCollectedList.Count - 1;
        }
        CollectedWordDisplay.text = WordsCollectedList.Count == 0 ? CollectedWordDisplay.text + "" : curentIndex+1 + ")" + WordsCollectedList[curentIndex].Wordstr;
    }

    private void LoadFirstCollectedword() {
        if (WordsCollectedList == null || WordsCollectedList.Count == 0) {
            CollectedWordDisplay.text = "No words found yet";
        } else {
            CollectedWordDisplay.text =1+")"+ WordsCollectedList[0].Wordstr;
        }

    }

    private void LoadWordsCollectedList() {
        List<Word> templist = GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType).CollectedWordsList;
        if (templist != null || templist.Count != 0) {
            WordsCollectedList = templist;
        } else {
            Word noword = new Word();
            noword.Wordstr = "No words found yet";
            WordsCollectedList.Add(noword);
        }
    }
    private int curentIndex2 = 0;
    private List<Word> SharedSavedWordsList = new List<Word>();

    public void SelectNextSavedWord() {
        if (SharedSavedWordsList.Count != 2) {

        }
        if (SharedSavedWordsList.Count - 1 > curentIndex2) {
            curentIndex2++;
        } else {
            curentIndex2 = 0;
        }
        SharedSavedWordDisplay.text = SharedSavedWordsList.Count == 0 ? SharedSavedWordDisplay.text + "" : SharedSavedWordsList[curentIndex2].Wordstr + " - " + SharedSavedWordsList[curentIndex2].MisspelledWordstr;
    }

    public void SelectPreviousSavedWord() {
        if (curentIndex2 > 0) {
            curentIndex2--;
        } else {
            curentIndex2 = SharedSavedWordsList.Count - 1;
        }
        SharedSavedWordDisplay.text = SharedSavedWordsList.Count == 0 ? SharedSavedWordDisplay.text + "" : SharedSavedWordsList[curentIndex2].Wordstr + " - " + SharedSavedWordsList[curentIndex2].MisspelledWordstr;
    }

    private void LoadSharedSavedWordsList() {
        List<Word> templist = GlobalData.SharedDictionary.DictionaryList;
        Language selectedlang = GlobalData.SharedDictionary.SelectedLanguage;
        List<Word> wordsofselectedlanguage = new List<Word>();
        for (int i = 0; i < templist.Count; i++) {
            if (templist[i].WordLanguage == selectedlang) {
                wordsofselectedlanguage.Add(templist[i]);
            }
        }
        if (wordsofselectedlanguage != null || wordsofselectedlanguage.Count != 0) {
            SharedSavedWordsList = wordsofselectedlanguage;
        } else {
            Word noword = new Word();
            noword.Wordstr = "No words found yet";
            SharedSavedWordsList.Add(noword);
        }
    }

    private void LoadFirstSharedSavedword() {
        if (SharedSavedWordsList == null || SharedSavedWordsList.Count == 0) {
            SharedSavedWordDisplay.text = "No words found yet";
        } else {
            SharedSavedWordDisplay.text = SharedSavedWordsList[0].Wordstr + " - " + SharedSavedWordsList[0].MisspelledWordstr;
        }

    }



    private int curentIndex3 = 0;
    private List<Word> UserSavedWordsList = new List<Word>();

    public void SelectNextUserSavedWord() {
        if (UserSavedWordsList.Count != 2) {

        }
        if (UserSavedWordsList.Count - 1 > curentIndex3) {
            curentIndex3++;
        } else {
            curentIndex3 = 0;
        }
        UserSavedWordDisplay.text = UserSavedWordsList.Count == 0 ? UserSavedWordDisplay.text + "" : UserSavedWordsList[curentIndex3].Wordstr + " - " + UserSavedWordsList[curentIndex3].MisspelledWordstr;
    }

    public void SelectPreviousUserSavedWord() {
        if (curentIndex3 > 0) {
            curentIndex3--;
        } else {
            curentIndex3 = UserSavedWordsList.Count - 1;
        }
        UserSavedWordDisplay.text = UserSavedWordsList.Count == 0 ? UserSavedWordDisplay.text + "" : UserSavedWordsList[curentIndex3].Wordstr + " - " + UserSavedWordsList[curentIndex3].MisspelledWordstr;
    }

    private void LoadUserSavedWordsList() {
        List<Word> templist = GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType).SavedWordsList;
        //Language selectedlang = Globals.SharedDictionary.SelectedLanguage;
        //List<Word> wordsofselectedlanguage = new List<Word>();
        //for (int i = 0; i < templist.Count; i++) {
        //    if (templist[i].WordLanguage == selectedlang) {
        //        wordsofselectedlanguage.Add(templist[i]);
        //    }
        //}
        if (templist != null || templist.Count != 0) {
            UserSavedWordsList = templist;
        } else {
            Word noword = new Word();
            noword.Wordstr = "No words found yet";
            UserSavedWordsList.Add(noword);
        }
    }

    private void LoadFirstUserSavedword() {
        if (UserSavedWordsList == null || UserSavedWordsList.Count == 0) {
            UserSavedWordDisplay.text = "No words found yet";
        } else {
            UserSavedWordDisplay.text = UserSavedWordsList[0].Wordstr + " - " + UserSavedWordsList[0].MisspelledWordstr;
        }

    }

    private void LoadNumOfWordsCollected() {
        if (WordsCollectedList == null || WordsCollectedList.Count == 0) {
            NumberOfCollectedWordsDisplay.text = "0";
        } else {
            NumberOfCollectedWordsDisplay.text = WordsCollectedList.Count + "";
        }

    }

    public void RefreshDetails() {
        if (_activeuser == null || !GlobalData.UsersManager.LoggedInUser.Equals(_activeuser.Name)) {
            UsersManager uu = GlobalData.UsersManager;
            _activeuser = uu.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType);

        }
        Score.text = "Πόντοι :" + _activeuser.Score + "";
        HighestScore.text = "Ρεκορ :" + _activeuser.HighestScore + "";
    }

    public void RefreshCurrentScore(int score) {
        if (_activeuser == null) {
            _activeuser= GlobalData.UsersManager.GetUserDetails(GlobalData.UsersManager.LoggedInUser, GlobalData.SerialType);
        }
        CurrentScore.text = "Πόντοι:" + score + "";
        if (_activeuser.HighestScore < score) {
            _activeuser.HighestScore = score;
        }
    }

    public void CreateNewUser() {
        bool added = GlobalData.UsersManager.AddNewUser(UserNameInput.text,GlobalData.SerialType);
        if (!added) {
            print("USER NOT ADED");
            return;
        }

        string newuseradded = GlobalData.UsersManager.UsersNames.Find(x => x.Equals(UserNameInput.text));
        if (newuseradded == null) {
            print("PROBLEMAS");
            return;
        }
        GlobalData.UsersManager.LoggedInUser = newuseradded;
        RefreshDetails();
        LoggedInUserDisplay();
    }

    public void LoggedInUserDisplay() {
        LoggedInUser.text = GlobalData.UsersManager.LoggedInUser;
        LoggedInUser2.text = GlobalData.UsersManager.LoggedInUser;
    }

    public void NextUser() {
        for (int i=0;i< GlobalData.UsersManager.UsersNames.Count;i++) {
            if (GlobalData.UsersManager.UsersNames[i].Equals(GlobalData.UsersManager.LoggedInUser)) {
                if(i== GlobalData.UsersManager.UsersNames.Count-1)
                    GlobalData.UsersManager.LoggedInUser = GlobalData.UsersManager.UsersNames[0];
                else
                    GlobalData.UsersManager.LoggedInUser = GlobalData.UsersManager.UsersNames[i + 1];
                break;
            }
        }

        RefreshDetails();
        LoggedInUserDisplay();
        InitializeUsersGlobalDictionary();
        InitializeDictionaryOptions();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
