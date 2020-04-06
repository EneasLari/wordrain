using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PersistentData {
    class EncryptDecrypt {
        private static string key = "YFpoGQ@$VrUMf64tZ9eg^RiaQSZ^Pw%*";
        public static string Encrypt(string str) {
            AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider();

            byte[] byteBuff;

            try {
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);

                aesCryptoProvider.GenerateIV();
                aesCryptoProvider.IV = aesCryptoProvider.IV;
                byteBuff = Encoding.UTF8.GetBytes(str);

                byte[] encoded = aesCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length);

                string ivHexString = ToHexString(aesCryptoProvider.IV);
                string encodedHexString = ToHexString(encoded);


                return ivHexString + ':' + encodedHexString;

            } catch (Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static string Decrypt(string encodedStr) {
            AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider();

            byte[] byteBuff;

            try {
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);


                string[] textParts = encodedStr.Split(':');
                byte[] iv = FromHexString(textParts[0]);
                aesCryptoProvider.IV = iv;
                byteBuff = FromHexString(textParts[1]);

                string plaintext = Encoding.UTF8.GetString(aesCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));

                return plaintext;

            } catch (Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
        }

        private static  string ToHexString(byte[] str) {
            var sb = new StringBuilder();

            var bytes = str;
            foreach (var t in bytes) {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }

        private static byte[] FromHexString(string hexString) {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++) {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

    }
}
