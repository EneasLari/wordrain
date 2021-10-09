
using SerializationForGameTest.PersistentData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Assets.Scripts.PersistentData {

    /*
        The basic Class for storing user setting data
        Contains all methods for serializing and deserializing user's data in persistent way
    */
    /// <summary>
    /// The basic Class for storing user setting data
    /// Contains all methods for serializing and deserializing user's data in persistent way
    /// </summary>
    /// <remarks>
    /// This class can Serialize and Deserialize(Calling <c>GetUsersManager</c>) UsersManagers.
    /// </remarks>
    [Serializable]
    public class UsersManager {
        private List<string> _usersNames = null;
        [NonSerialized]
        private List<UserDetails> _usersDetails = null;
        private string _loggedInUser = null;

        public List<string> UsersNames {
            get {
                if (_usersNames == null) {
                    _usersNames = new List<string>();
                }
                return _usersNames;
            }
        }

        private List<UserDetails> UsersDetails {
            get {
                if (_usersDetails == null) {
                    _usersDetails = new List<UserDetails>();
                }
                return _usersDetails;
            }
        }

        public string LoggedInUser {
            get {
                if (_loggedInUser == null) {
                    _loggedInUser = (new UserDetails()).Name;// UserDetails
                }
                return _loggedInUser;
            }
            set {
                _loggedInUser = value;
            }
        }

        //public bool AddNewUser(User newuser) {
        //    if (_users.Exists(x => x.Name.Equals(newuser.Name))) {
        //        return false;
        //    } else {
        //        newuser.DateCreated = DateTime.UtcNow; ;
        //        _users.Add(newuser);
        //        return true;
        //    }

        //}

        //public bool DeleteUser(UserDetails existinguser) {
        //    User usertodelete = _users.Find(x => x.Name.Equals(existinguser.Name));
        //    if (usertodelete == null) {
        //        return false;
        //    } else {
        //        return _users.Remove(usertodelete);
        //    }
        //}

        //public User AuthenticateUser(string name, string password) {
        //    User usertoauthenticate = _users.Find(x => x.Name.Equals(name));
        //    if (usertoauthenticate == null) {
        //        return null;
        //    } else {
        //        if (EncryptDecrypt.Decrypt(usertoauthenticate.Password).Equals(password)) {
        //            return usertoauthenticate;
        //        } else {
        //            return null;
        //        }
        //    }
        //}

        public UserDetails GetUserDetails(string filename, SerializationType type) {
            if (UsersNames.Find(x => x.Equals(filename)) == null) {
                return null;
            }
            string filepath = System.IO.Path.Combine(UsersManagerPath, filename);
            UserDetails userDetails = UsersDetails.Find(x => x.Name.Equals(filename));
            if (userDetails == null) {
                if (type == SerializationType.Binary) {
                    userDetails = UserDetails.GetUserDetailsFromBinary(filename);
                }
                if (type == SerializationType.Xml) {
                    userDetails = UserDetails.GetUserDetailsFromXml(filename);
                }
                UsersDetails.Add(userDetails);
            }
            if (!userDetails.Name.Equals(filename)) {
                userDetails.Name = filename;
                UsersDetails.Add(userDetails);
            }
            return userDetails;
        }

        private void SaveDetails(SerializationType type) {
            foreach (UserDetails details in UsersDetails) {
                if (type == SerializationType.Binary) {
                    details.SerializeToBinary(details.Name);
                }
                if (type == SerializationType.Xml) {
                    details.SerializeToXml(details.Name);
                }
            }
        }

        public bool AddNewUser(string username, SerializationType type) {
            bool added = false;
            string name = UsersNames.Find(x => x.Equals(username));
            if (name == null) {
                UserDetails newuserdetails = new UserDetails();
                UsersNames.Add(username);
                newuserdetails.Name = username;
                UsersDetails.Add(newuserdetails);
                added = true;
            }
            return added;
        }

        internal string UsersManagerFileBinary = "UsersManager.dat";
        internal string UsersManagerFileXml = "UsersManager.xml";

        [XmlElement(ElementName = "UsersManagerPath")]
        public string UsersManagerPath {
            get {
                return PathVariables.USERSMANAGERPATH;
            }
        }


        public void Serialize(SerializationType type) {
            if (type == SerializationType.Xml) {
                SerializetoXml();
            } else if (type == SerializationType.Binary) {
                SerializetoBinary();
            }
            SaveDetails(type);

        }

        //save data(variables of a class) to a xml
        private void SerializetoXml() {
            try {
                if (!System.IO.Directory.Exists(UsersManagerPath))
                    System.IO.Directory.CreateDirectory(UsersManagerPath);
                string filename = System.IO.Path.Combine(UsersManagerPath, UsersManagerFileXml);
                XmlSerializer serializer = new XmlSerializer(typeof(UsersManager));
                using (System.IO.TextWriter writer = new System.IO.StreamWriter(filename)) {
                    serializer.Serialize(writer, this);
                }

            } catch (Exception ex) {
                //XtraMessageBox.Show("" + ex, "Error Serializing UserPreferences", MessageBoxButtons.OK, MessageBoxIcon.Error);//TODO
            }
        }

        //retrieve data from xml to initilize object/s
        private void DeserializefromXml() {
            string filename = System.IO.Path.Combine(UsersManagerPath, UsersManagerFileXml);
            if (!System.IO.File.Exists(filename))
                return;
            UsersManager UsersManager;
            XmlSerializer serializer = new XmlSerializer(typeof(UsersManager));
            using (System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open)) {
                UsersManager = (UsersManager)serializer.Deserialize(fileStream);
                this._usersNames = UsersManager._usersNames;
                this._loggedInUser = UsersManager._loggedInUser;
            }
        }


        //save data(variables of a class) to a binaryformat
        private void SerializetoBinary() {
            try {
                if (!System.IO.Directory.Exists(UsersManagerPath))
                    System.IO.Directory.CreateDirectory(UsersManagerPath);
                string filename = Path.Combine(UsersManagerPath, UsersManagerFileBinary);
                BinaryFormatter serializer = new BinaryFormatter();
                using (Stream writer = new FileStream(filename, FileMode.Create, FileAccess.Write)) {
                    serializer.Serialize(writer, this);
                }

            } catch (Exception ex) {
                Console.WriteLine("" + ex, "Error Serializing UserDetails");//TODO
            }
        }

        //retrieve data from binary to initilize object/s
        private void DeserializefromBinary() {
            string filename = System.IO.Path.Combine(UsersManagerPath, UsersManagerFileBinary);
            if (!System.IO.File.Exists(filename))
                return;
            UsersManager sysusers = new UsersManager();
            BinaryFormatter serializer = new BinaryFormatter();
            using (System.IO.FileStream fileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open)) {
                sysusers = (UsersManager)serializer.Deserialize(fileStream);
                this._usersNames = sysusers._usersNames;
                this._loggedInUser = sysusers._loggedInUser;
            }
        }


        /// <summary>
        /// Get an static <c>UsersManager</c> object from a xml file(Deserialize)
        /// </summary>
        public static UsersManager GetUsersManagerFromXml() {
            UsersManager UsersManager = new UsersManager();
            UsersManager.DeserializefromXml();
            if (UsersManager.UsersNames.Count == 0) {
                UsersManager.UsersNames.Add((new UserDetails()).Name);
            }
            return UsersManager;
        }

        public static UsersManager GetUsersManagerFromBinary() {
            UsersManager UsersManager = new UsersManager();
            UsersManager.DeserializefromBinary();
            if (UsersManager.UsersNames.Count == 0) {
                UsersManager.UsersNames.Add((new UserDetails()).Name);
            }
            return UsersManager;
        }

    }
}
