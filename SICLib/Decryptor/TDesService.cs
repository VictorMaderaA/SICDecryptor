using SICLib.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SICLib.Decryptor
{
    public class TDesService
    {

        private SymmetricAlgorithm CryptoService;
        private CipherMode CipherMode;
        private PaddingMode PaddingMode;

        public TDesService(CipherMode cipher = CipherMode.ECB, PaddingMode padding = PaddingMode.None)
        {
            CryptoService = new TripleDESCryptoServiceProvider();
            CipherMode = cipher;
            PaddingMode = padding;
        }

        //public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        //{
        //    if (key.Length != 24) throw new System.Exception("Wrong Size");
        //    CryptoService.Mode = CipherMode;
        //    CryptoService.Padding = PaddingMode;
        //    CryptoService.KeySize = 192;
        //    CryptoService.BlockSize = 64;
        //    var MyCrytpoTransform = CryptoService.CreateDecryptor(key, key);
        //    byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cryptedBytes, 0, cryptedBytes.Length);
        //    CryptoService.Clear();
        //    return new DecryptedObject(MyresultArray, key);
        //}

        //public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        //{
        //    var CryptoService = new TripleDESCryptoServiceProvider();

        //    CryptoService.Key = key;
        //    CryptoService.Mode = CipherMode;
        //    CryptoService.Padding = PaddingMode;

        //    var MyCrytpoTransform = CryptoService.CreateDecryptor();

        //    byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cryptedBytes, 0, cryptedBytes.Length);

        //    CryptoService.Clear();

        //    return new DecryptedObject(MyresultArray, key);
        //}

        ////public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        ////{
        ////    var response = TripleDesDecrypt(cryptedBytes, key);
        ////    return new DecryptedObject(response, key);
        ////}

        ////private byte[] TripleDesDecrypt(byte[] cipherBytes, byte[] key)
        ////{
        ////    var des = CreateTDes(key);
        ////    var ct = des.CreateDecryptor();
        ////    var output = ct.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
        ////    return output;
        ////}

        ////private TripleDES CreateTDes(byte[] key)
        ////{
        ////    MD5 md5 = new MD5CryptoServiceProvider();
        ////    TripleDES des = new TripleDESCryptoServiceProvider();
        ////    var desKey = md5.ComputeHash(key);
        ////    des.Key = desKey;
        ////    des.Padding = PaddingMode.None;
        ////    des.Mode = CipherMode.ECB;
        ////    return des;
        ////}


        public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        {
            byte[] key1 = new byte[8], key2 = new byte[8], key3 = new byte[8];
            Array.Copy(key, 0, key1, 0, 8);
            Array.Copy(key, 8, key2, 0, 8);
            Array.Copy(key, 16, key3, 0, 8);
            var response = DesDecrypt(DesEncrypt(DesDecrypt(cryptedBytes, key3), key2), key1);
            return new DecryptedObject(response, key);
        }

        private DES CreateDes(byte[] key)
        {
            //MD5 md5 = new MD5CryptoServiceProvider();
            DES des = new DESCryptoServiceProvider();
            //var desKey = md5.ComputeHash(key);
            des.Key = key;
            des.Padding = PaddingMode.None;
            des.Mode = CipherMode.ECB;
            return des;
        }

        public byte[] DesEncrypt(byte[] inBlock, byte[] key)
        {
            var symAlg = CreateDes(key);
            ICryptoTransform xfrm = symAlg.CreateEncryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);

            return outBlock;
        }

        public byte[] DesDecrypt(byte[] inBytes, byte[] key)
        {
            var symAlg = CreateDes(key);
            ICryptoTransform xfrm = symAlg.CreateDecryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);

            return outBlock;
        }


    }
}
