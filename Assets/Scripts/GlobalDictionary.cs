using Assets.Scripts.PersistentData;
using Assets.Scripts.UserSystem.GlobalData;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.PersistentData.Dictionary;

public class GlobalDictionary : MonoBehaviour
{
    //3000 english words
    private static List<Word> englishwords = new List<Word>() { new Word("good", "goodd"), new Word("bad","badd"), new Word("black","blak"), new Word("white","wite"),
                                                                    new Word("abandon","abbandon"), new Word("ability","abiliti"), new Word("able","abble")
                                                                  };

    //private static List<Word> greekwords = new List<Word>() { new Word("παπί","παπη"), new Word("πίτα", "πητα"), new Word("πατάτα", "πατάττα"), new Word("τόπι", "τόπη"), new Word("έλα", "έλλα"), new Word("πανι","πανη"), new Word("παμε","παμαι"),
    //                                                              new Word("εχει",  "εχι"), new Word("οχι","οχη"), new Word("ειναι", "εινε"), new Word("ενα", "εννα"), new Word("μια", "μηα"), new Word("μαμα", "μαμμα"), new Word("και", "κε")};



    private static List<Word> taksi1Enotita1 = new List<Word>() { new Word("παπι", "παπη"), new Word("πιτα", "πητα"), new Word("πατατα", "παταττα"), new Word("τοπι", "τοπη"), new Word("ελα", "ελλα"), new Word("πανι", "πανη"), new Word("παμε", "παμαι") };

    public static bool UseChapter1Unit1 = true;

    private static List<Word> taksi1Enotita2 = new List<Word>() { new Word("εχει",  "εχι"), new Word("οχι","οχη"), new Word("παππούς", "παπούς"), new Word("λίμνη", "λήμνη"), new Word("ειναι", "εινε"), new Word("ενα", "εννα"), new Word("μια", "μηα"),
    new Word("μαμα", "μαμμα"), new Word("και", "κε") };

    public static bool UseChapter1Unit2 = false;

    private static List<Word> taksi1Enotita3 = new List<Word>() { new Word("απο", "απω"), new Word("μύτη", "μήτη"), new Word("γιατί", "γιατή"),new Word("σκηνή", "σκινή"), new Word("μήλο", "μίλω"), new Word("ζύμη", "ζήμη"), new Word("ρινόκερος", "ρινόκαιρος"),
    new Word("κόκορας", "κόκκορας") };

    public static bool UseChapter1Unit3 = false;

    private static List<Word> taksi1Enotita4 = new List<Word>() { new Word("αλεπού", "αλαιπού"), new Word("φώς", "φος"), new Word("φακός", "φακώς"), new Word("ταξίδι", "ταξίδη"), new Word("ψάχνω", "ψάχνο"), new Word("ψιχάλα", "ψηχάλα"), new Word("σκοτάδι", "σκοτάδη"),
    new Word("σωσίβιο", "σωσήβιο") };

    public static bool UseChapter1Unit4 = false;

    private static List<Word> taksi1Enotita5 = new List<Word>() { new Word("μολύβι", "μολύβει"), new Word("ψυγείο", "ψυγίο"), new Word("παιδί", "πεδί"), new Word("ανοίγω", "ανείγω"), new Word("πίνακας", "πείνακας"), new Word("οικόπεδο", "οικόπαιδο"), new Word("ιππόκαμπος", "ιπόκαμπος"),
    new Word("ζωγραφίζω", "ζωγραφήζω") };

    public static bool UseChapter1Unit5 = false;

    private static List<Word> taksi1Enotita6 = new List<Word>() { new Word("χιονάνθρωπος", "χιονάθρωπος"), new Word("παπούτσι", "παπούστι"), new Word("αγκάθι", "αγγάθι"), new Word("κλειδί", "κλοιδί"), new Word("αγγίζω", "αγκοίζω"), new Word("νεράντζι", "νεράτζι"), new Word("τζάκι", "ντζάκι"),
    new Word("αυτοκίνητο", "αυτοκήνιτο"), new Word("αγγελία", "αγκελία"), new Word("ευχή", "εφχη"), new Word("ταχυδομείο", "ταχυδρομίο") };

    public static bool UseChapter1Unit6 = false;

    private static List<Word> taksi1Enotita7 = new List<Word>() { new Word("περιπέτεια", "περιπέτια"), new Word("φωτογραφία", "φοτογραφία"), new Word("γράμμα", "γράμα"), new Word("τύμπανο", "τίμπανο"), new Word("ελευθερία", "ελεφθερία"), new Word("θησαυρός", "θισαυρός"), new Word("συρτάρι", "σιρτάρι"),
    new Word("καΐκι", "καίκι"), new Word("μαϊμού", "μαιμού"), new Word("γαϊδούρι", "γαιδούρι"), new Word("καΐκι", "καίκι"), new Word("συλλογή", "συλογή"), new Word("οδηγίες", "οδηγείες"), new Word("υλικά", "υληκα"), new Word("νησί", "νησή"), new Word("ύφασμα", "ήφασμα"), new Word("πετρώνω", "πετρόνω") };

    public static bool UseChapter1Unit7 = false;

    private static List<Word> taksi1Enotita8 = new List<Word>() { new Word("πολυκατοικία", "ποληκατοικία"), new Word("γείτονα", "γείτωνας"), new Word("ξεφορτώνω", "ξεφορτόνω"), new Word("ποδήλατο", "ποδίλατο"), new Word("επάγγελμα", "επάγκελμα"), new Word("μέλισσα", "μέλισσα"), new Word("μυρίζω", "μυρήζω"),
    new Word("χειμώνας", "χειμόνας"), new Word("άνοιξη", "άνειξη"), new Word("καλοκαίρι", "καλοκέρι"), new Word("κελαηδώ", "κελαϊδώ"), new Word("ζέστη", "ζέστει"), new Word("κρύο", "κρείο") };

    public static bool UseChapter1Unit8 = false;

    private static List<Word> taksi1Enotita9 = new List<Word>() { new Word("φύλακας", "φοίλακας"), new Word("διευθυντής", "διεφθυντής"), new Word("σχολείο", "σχολίο"), new Word("τρόλει", "τρόλεϊ"), new Word("βιβλιοθήκη", "βιβλειοθήκη"), new Word("θάλασσα", "θάλασα"), new Word("συγγραφέας", "συγραφέας"),
    new Word("περιπέτεια", "περιπέτια"), new Word("εξώφυλλο", "εξώφυλο"), new Word("πρόσκληση", "πρόσκλησει"), new Word("λεωφορείο", "λεοφωρείο"), new Word("δρομολόγιο", "δρομολόγειο"), new Word("πληροφορία", "πληροφωρία"), new Word("θόρυβος", "θώρυβος"), new Word("χάνομαι", "χάνωμαι") };

    public static bool UseChapter1Unit9 = false;

    private static List<Word> taksi1Enotita10 = new List<Word>() { new Word("κοχύλι", "κοχίλι"), new Word("σπηλιά", "σποιλιά"), new Word("γεννώ", "γενώ"), new Word("ίχνος", "οίχνος"), new Word("κίνδυνος", "κύνδινος"), new Word("μύθος", "μοίθος"), new Word("ελέφαντας", "ελαίφαντας"), new Word("ιππότης", "ιπότης"),
    new Word("σύννεφο", "σύνεφο"), new Word("φύλλο", "φύλο"), new Word("φωνή", "φονή"),  new Word("ιστορία", "ιστορεία"), new Word("ρινόκερος", "ρινόκαιρος"), new Word("άμμος", "άμος") };

    public static bool UseChapter1Unit10 = false;

    private static List<Word> taksi2Enotita1 = new List<Word>() { new Word("σπίτι", "σπήτι"), new Word("όλοι", "ώλοι"), new Word("πλοίο", "πλείο"), new Word("γύρω", "γείρο"), new Word("έλα", "έλλα"), new Word("αλεπού", "αλαιπού"), new Word("έλικόπτερο", "ελεικόπτερο"), new Word("φύλλο", "φύλο"),
    new Word("φθινόπωρο", "φθοινόπωρο"), new Word("παράθυρο", "παράθοιρο"), new Word("σοκολάτα", "σωκολάτα"), new Word("καράβι", "καράβη"), new Word("ποδήλατο", "ποδάλατω"), new Word("παιχνίδι", "παιχνείδι"), new Word("γράμμα", "γράμα"), new Word("αεροπλάνο", "αερωπλάνο"), new Word("μοτοσυκλέτα", "μοτοσηκλέτα")};

    public static bool UseChapter2Unit1 = false;

    public static bool useSharedDictionary = false;

    public static bool useYourDictionary = false;

    public static List<Word> Vocabulary { get; private set; }
    //public static List<string> MisspelledVocabulary { get; private set; }

    public static void setVocabulary(string language) {
        if (language.Equals("English")) {
            Vocabulary = englishwords;
        } else if (language.Equals("Greek")) {
            Vocabulary = new List<Word>();
            if (UseChapter1Unit1) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita1).ToList();
            }
            if (UseChapter1Unit2) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita2).ToList();
            }
            if (UseChapter1Unit3) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita3).ToList();
            }
            if (UseChapter1Unit4) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita4).ToList();
            }
            if (UseChapter1Unit5) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita5).ToList();
            }
            if (UseChapter1Unit6) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita6).ToList();
            }
            if (UseChapter1Unit7) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita7).ToList();
            }
            if (UseChapter1Unit8) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita8).ToList();
            }
            if (UseChapter1Unit9) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita9).ToList();
            }
            if (UseChapter1Unit10) {
                Vocabulary = Vocabulary.Concat(taksi1Enotita10).ToList();
            }
            if (UseChapter2Unit1) {
                Vocabulary = Vocabulary.Concat(taksi2Enotita1).ToList();
            }
            if (useSharedDictionary) {
                Vocabulary = Vocabulary.Concat(GlobalData.SharedDictionary.DictionaryList).ToList();
            }
            if (useYourDictionary) {
                Vocabulary = Vocabulary.Concat(GlobalData.UsersManager.GetUserDetails(GlobalData.LoggedInUser, GlobalData.SerialType).SavedWordsList).ToList();
            }
            //Vocabulary = greekwords;
        }
        //foreach (Word word in Globals.SharedDictionary.DictionaryList) {
        //    if (word.WordLanguage == Language.English) {
        //        Vocabulary.Add(word);
        //    }
        //    if (word.WordLanguage == Language.Greek) {
        //        Vocabulary.Add(word);
        //    }
        //}
    }
}
