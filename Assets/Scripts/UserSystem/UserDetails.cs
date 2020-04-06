using SerializationForGameTest.PersistentData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static Assets.Scripts.PersistentData.Dictionary;

namespace Assets.Scripts.PersistentData {
    [Serializable]
    public class UserDetails {
        private string _name=null;
        private string _password = null;
        private int _score=0;
        private int _highestscore = 0;
        private int _coins = 0;
        private string _skinSelected =null;
        private string _sceneSelected = null;
        private List<String> _skinsUnlocked = null;
        private List<String> _scenesUnlocked = null;
        private float _timePlaying=0;
        private List<Word> _collectedWordsList = new List<Word>();
        private List<Word> _savedWordsList= new List<Word>();
        private DateTime _startTimer= DateTime.MinValue;
        private DateTime _dateCreated = DateTime.MinValue;

        public string Name {
            get {
                if (_name==null) {
                    _name = "Μικρός Ήρωας";//"Default";
                }
                return _name; }
            set { _name = value; }
        }

        public string Password {
            get { return _password; }
            set { _password = EncryptDecrypt.Encrypt(value); }
        }

        public int Score {
            get { return _score; }
            set { _score = value; }
        }

        public int HighestScore {
            get { return _highestscore; }
            set { _highestscore = value; }
        }

        public int Coins {
            get { return _coins; }
            set { _coins = value; }
        }

        public string SkinSelected {
            get {
                if (_skinSelected==null) {
                    _skinSelected = "Default";
                }
                return _skinSelected; }
            set { _skinSelected = value; }
        }

        public string SceneSelected { 
            get {
                if (_sceneSelected == null) {
                    _sceneSelected = "Default";
                }
                return _sceneSelected; } 
            set { _sceneSelected = value; } 
        }

        public List<String> SkinsUnlocked {
            get { return _skinsUnlocked; }
            set { _skinsUnlocked = value; }
        }

        public List<String> ScenesUnlocked {
            get { return _scenesUnlocked; }
            set { _scenesUnlocked = value; }
        }

        public float TimePlaying {
            get { return _timePlaying; }
            set { _timePlaying = value; }
        }
        public DateTime DateCreated {
            get {
                if (_dateCreated == DateTime.MinValue) {
                    _dateCreated = DateTime.UtcNow;
                }
                return _dateCreated; 
            }
            set { 
                _dateCreated = value; 
            }
        }

        public List<Word> CollectedWordsList { 
            get { return _collectedWordsList; }
            set { _collectedWordsList = value; }
        }

        public List<Word> SavedWordsList {
            get { return _savedWordsList; }
            set { _savedWordsList = value; }
        }

        public bool AddtoCollectedWords(Word newWord) {
            if (_collectedWordsList.Exists(x => x.Wordstr.Equals(newWord.Wordstr))) {
                return false;
            } else {
                _collectedWordsList.Add(newWord);
                return true;
            }
        }

        public bool AddtoSavedWords(Word newWord) {
            if (_savedWordsList.Exists(x => x.Wordstr.Equals(newWord.Wordstr))) {
                return false;
            } else {
                _savedWordsList.Add(newWord);
                return true;
            }
        }

        public void StartTimer() {
            _startTimer = DateTime.Now;
        }

        public double GetTimePassed() {
            DateTime starttime=_startTimer;
            _startTimer = DateTime.MinValue;
            if (_startTimer!=DateTime.MinValue) {
                return (DateTime.Now - starttime).TotalSeconds;
            }
            return 0;
        }
        [XmlElement(ElementName = "UserDetails")]
        public string UserDetailsPath {
            get {
                return PathVariables.USERSMANAGERPATH;
            }
        }

        //save data(variables of a class) to a xml
        public void SerializeToBinary(string filenamestr) {
            try {
                if (!System.IO.Directory.Exists(UserDetailsPath))
                    System.IO.Directory.CreateDirectory(UserDetailsPath);
                string filename = Path.Combine(UserDetailsPath, filenamestr);
                BinaryFormatter serializer = new BinaryFormatter();
                using (Stream writer = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
                    serializer.Serialize(writer, this);
                }
                
            } catch (Exception ex) {

                Console.WriteLine("" + ex, "Error Serializing UserDetails");//TODO
            }
        }

        //retrieve data from xml to initilize object/s
        private void DeserializeFromBinary(string filenamestr) {
            string filename = System.IO.Path.Combine(UserDetailsPath, filenamestr);
            if (!System.IO.File.Exists(filename))
                return;
            UserDetails userdetails = new UserDetails();
            BinaryFormatter serializer = new BinaryFormatter();
            using (System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open)) {
                userdetails = (UserDetails)serializer.Deserialize(fileStream);
                this._name = userdetails._name;
                this._password = userdetails._password;
                this._score = userdetails._score;
                this._highestscore = userdetails._highestscore;
                this._coins = userdetails._coins;
                this._dateCreated = userdetails._dateCreated;
                this._collectedWordsList = userdetails._collectedWordsList;
                this._savedWordsList = userdetails._savedWordsList;
                this._sceneSelected = userdetails._sceneSelected;
                this._timePlaying = userdetails._timePlaying;
                this._scenesUnlocked = userdetails._scenesUnlocked;
                this._skinsUnlocked = userdetails._skinsUnlocked;
            }
            
        }


        //save data(variables of a class) to a xml
        public void SerializeToXml(string filenamestr) {
            try {
                if (!System.IO.Directory.Exists(UserDetailsPath))
                    System.IO.Directory.CreateDirectory(UserDetailsPath);
                string filename = Path.Combine(UserDetailsPath, filenamestr);
                XmlSerializer serializer = new XmlSerializer(typeof(UserDetails));
                using (TextWriter writer = new StreamWriter(filename)) {
                    serializer.Serialize(writer, this);
                }

            } catch (Exception ex) {

                Console.WriteLine("" + ex, "Error Serializing UserDetails");//TODO
            }
        }

        //retrieve data from xml to initilize object/s
        private void DeserializeFromXml(string filenamestr) {
            string filename = System.IO.Path.Combine(UserDetailsPath, filenamestr);
            if (!System.IO.File.Exists(filename))
                return;
            UserDetails userdetails = new UserDetails();
            XmlSerializer serializer = new XmlSerializer(typeof(UserDetails));
            using (System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open)) {
                userdetails = (UserDetails)serializer.Deserialize(fileStream);
                this._name = userdetails._name;
                this._password = userdetails._password;
                this._score = userdetails._score;
                this._highestscore = userdetails._highestscore;
                this._coins = userdetails._coins;
                this._dateCreated = userdetails._dateCreated;
                this._collectedWordsList = userdetails._collectedWordsList;
                this._savedWordsList = userdetails._savedWordsList;
                this._sceneSelected = userdetails._sceneSelected;
                this._timePlaying = userdetails._timePlaying;
                this._scenesUnlocked = userdetails._scenesUnlocked;
                this._skinsUnlocked = userdetails._skinsUnlocked;
            }

        }

        /// <summary>
        /// Get an static <c>UsersManager</c> object from a xml file(Deserialize)
        /// </summary>
        public static UserDetails GetUserDetailsFromXml(string filenamestr) {
            UserDetails userdetails = new UserDetails();
            userdetails.DeserializeFromXml(filenamestr);
            return userdetails;
        }
        public static UserDetails GetUserDetailsFromBinary(string filenamestr) {
            UserDetails userdetails = new UserDetails();
            userdetails.DeserializeFromXml(filenamestr);
            return userdetails;
        }

    }
}
