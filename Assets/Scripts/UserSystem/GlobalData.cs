using Assets.Scripts.PersistentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UserSystem.GlobalData {
    public class GlobalData {
        private static SerializationType _serialType;
        private static UsersManager _usersManager = null;
        private static Dictionary _sharedDictionary = null;
        public static UsersManager UsersManager {
            get {
                if (_usersManager == null) {
                    if (_serialType == SerializationType.Xml) {
                        _usersManager = UsersManager.GetUsersManagerFromXml();
                    } else if (_serialType == SerializationType.Binary) {
                        _usersManager = UsersManager.GetUsersManagerFromBinary();
                    }
                }
                return _usersManager;
            }
        }


        public static SerializationType SerialType{
            get{return _serialType;}
            set{ _serialType = value; }
        }

        internal static void SerializeAll() {
            UsersManager.Serialize(SerialType);
        }

        public static Dictionary SharedDictionary {
            get {
                if (_sharedDictionary == null) {
                    if (_serialType == SerializationType.Xml) {
                        _sharedDictionary = Dictionary.GetDictionaryFromXml();
                    } else if (_serialType == SerializationType.Binary) {
                        _sharedDictionary = Dictionary.GetDictionaryFromBinary();
                    }
                }
                return _sharedDictionary;
            }
        }
    }
}
