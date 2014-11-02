using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SixtyNineDegrees.MiteDesk.Core.Infrastructure
{

    public class EncryptionService : IEncryptionService
    {

        public string EncryptString(string clearText, string password)
        {
            if (string.IsNullOrEmpty(clearText)) 
                return clearText;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = EncryptString(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        private static byte[] EncryptString(byte[] clearText, byte[] key, byte[] iv)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = key;
            alg.IV = iv;
            using (CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearText, 0, clearText.Length);
            }
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        public string DecryptString(string cipherText, string password)
        {
            if (string.IsNullOrEmpty(cipherText)) 
                return null;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = DecryptString(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Encoding.Unicode.GetString(decryptedData);
        }

        private static byte[] DecryptString(byte[] cipherData, byte[] key, byte[] iv)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = key;
            alg.IV = iv;
            using (CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cipherData, 0, cipherData.Length);
            }
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

    }

}
