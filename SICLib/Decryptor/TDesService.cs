using SICLib.Models;
using System.Security.Cryptography;

namespace SICLib.Decryptor
{
    public class TDesService
    {

        private SymmetricAlgorithm CryptoService;
        private CipherMode CipherMode;
        private PaddingMode PaddingMode;

        public TDesService(CipherMode cipher = CipherMode.ECB, PaddingMode padding = PaddingMode.Zeros)
        {
            CryptoService = new TripleDESCryptoServiceProvider();
            CipherMode = cipher;
            PaddingMode = padding;
        }

        public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        {
            if (key.Length != 24) return null;
            CryptoService.Mode = CipherMode;
            CryptoService.Padding = PaddingMode;
            var MyCrytpoTransform = CryptoService.CreateDecryptor(key, key);
            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cryptedBytes, 0, cryptedBytes.Length);
            CryptoService.Clear();
            return new DecryptedObject(MyresultArray, key);
        }


    }
}
