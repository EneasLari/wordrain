using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Assets.Scripts.PersistentData {
        [Serializable]
        public class Word {
            private Language _wordLanguage;
            private string _word =null;
            private string _misspelledword = null;
            private bool _isMisspelled = false;

            public Word() {

            }

            public Word(string word) {
                _word = word;
            }

            public Word(string correctword,string misspelledword) {
                _word = correctword;
                _misspelledword = misspelledword;
                if (!_word.Equals(_misspelledword)) {
                    _isMisspelled = true;
                }
            }

            public Language WordLanguage { 
                get { return _wordLanguage; } 
                set { _wordLanguage = value; } 
            }
            public string Wordstr { 
                get {
                    if (_word == null) {
                        _word = "";
                    }
                    return _word; 
                } 
                set { _word = value; } 
            }

            public string MisspelledWordstr {
                get {
                    if (_misspelledword == null) {
                        _misspelledword = "";
                    }
                    return _misspelledword;
                }
                set { _misspelledword = value; }
            }

            public bool IsMissepelled {
                get { return _isMisspelled; }
                set { _isMisspelled = value; }
            }

        }
}
