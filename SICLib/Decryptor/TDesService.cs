using SICLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Decryptor
{
    public class TDesService
    {

        private TripleDESCryptoServiceProvider CryptoService;

        public TDesService()
        {
            CryptoService = new TripleDESCryptoServiceProvider();
            //We choose ECB(Electronic code Book)
            CryptoService.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            CryptoService.Padding = PaddingMode.PKCS7;
        }

        public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        {
            if (key.Length != 24) return null;
            CryptoService.Key = key;
            var MyCrytpoTransform = CryptoService.CreateDecryptor();
            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cryptedBytes, 0, cryptedBytes.Length);
            DecryptedObject obj = new DecryptedObject(MyresultArray, key);
            CryptoService.Clear();
            return obj;
        }

    }
}
