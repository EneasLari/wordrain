using Assets.Scripts.PersistentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LicenseManager {
    class SerialNumber {
        public string _serialNumberRegistered;

        public string SerialNumberRegistered {
            get { return _serialNumberRegistered; }
            set { _serialNumberRegistered = EncryptDecrypt.Encrypt(value); }
        }
    }
}
