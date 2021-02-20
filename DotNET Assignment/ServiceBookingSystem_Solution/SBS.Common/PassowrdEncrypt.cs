using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Common
{
    public class PassowrdEncrypt
    {
        // Encryption Key used to encrypt password
        private static readonly string EncryptionKey = "Encryption@123:]";

        public static byte[] Encrypt(string password)
        {
            var key = GetKey(EncryptionKey);

            using (var aes = Aes.Create())
            using (var encryptor = aes.CreateEncryptor(key, key))
            {
                var plainText = Encoding.UTF8.GetBytes(password);
                return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
            }
        }

        // converts key into 128 bit hash
        public static byte[] GetKey(string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(keyBytes);
            }
        }
    }
}
