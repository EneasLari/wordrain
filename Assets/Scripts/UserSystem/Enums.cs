using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Assets.Scripts.PersistentData {

    public enum Language {Greek, English, None};
    public enum LetterCase { None, LowerCase, UpperCase, Capitalize };

    public enum SerializationType { Xml, Binary};
    public class Enums {
        public static Language LanguageFromString(string stringenum) {
            if (stringenum.Equals(Language.Greek.ToString())) {
                return Language.Greek;
            } else if (stringenum.Equals(Language.English.ToString())) {
                return Language.English;
            } else {
                return Language.None;
            }
        }

    }
}
