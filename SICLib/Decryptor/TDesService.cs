using SICLib.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SICLib.Decryptor
{
    public class TDesService
    {

        public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        {
            var response = DecryptFinal(cryptedBytes, key);
            return new DecryptedObject(response, key);
        }

        private string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }


        private byte[] DecryptFinal(byte[] Data, byte[] Key)
        {
            var MD5 = new MD5CryptoServiceProvider();
            Key = MD5.ComputeHash(Encoding.UTF8.GetBytes(ByteArrayToString(Key)));
            var tdes = new TripleDESCryptoServiceProvider()
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7,
                Key = Key
            };
            var decryptor = tdes.CreateDecryptor();
            return decryptor.TransformFinalBlock(Data, 0, Data.Length);
        }

    }
}
