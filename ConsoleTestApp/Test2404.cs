using SICLib2.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    public class Test2404 : TestBase
    {
        public override string TestKey(byte[] KeyBytes)
        {
            try
            {
                var response = TripleDesDecrypt(KeyBytes, _cryptedBytes);

                if (response == null) return null;
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return null;

                Console.WriteLine($"{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END>");
                return response;
            }
            catch (Exception){ return null; }
        }


        public string TripleDesDecrypt(byte[] Key, byte[] cypherBytes)
        {
            var des = CreateDes(Key);
            var ct = des.CreateDecryptor();
            //var input = Convert.FromBase64String(cypherText);
            var input = cypherBytes;
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Encoding.UTF8.GetString(output);
        }

        public TripleDES CreateDes(byte[] Key)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            TripleDES des = new TripleDESCryptoServiceProvider();
            //var desKey = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
            des.Key = Key;
            des.IV = new byte[des.BlockSize / 8];
            des.Padding = PaddingMode.None;
            des.Mode = CipherMode.ECB;
            return des;
        }

        public override bool TryToSaveTime()
        {
            int valid = 0;
            string v1, v2;
            byte[] b = StringToByteArray(_partialKeyString + "000000");

            b[21] = 0; b[22] = 0; b[23] = 0;
            v1 = TripleDesDecrypt(b, _cryptedBytes);
            b[21] = 0; b[22] = 0; b[23] = 1;
            v2 = TripleDesDecrypt(b, _cryptedBytes);
            if (v1 != null && v2 != null)
            {
                valid++;
                if (!v1.Equals(v2)) return false;
                Console.WriteLine($"Tests 1: {v1.Substring(0, 10)} === {v2.Substring(0, 10)}");
            }

            b[21] = 0; b[22] = 0; b[23] = 0;
            v1 = TripleDesDecrypt(b, _cryptedBytes);
            b[21] = 0; b[22] = 1; b[23] = 0;
            v2 = TripleDesDecrypt(b, _cryptedBytes);
            if (v1 != null && v2 != null)
            {
                valid++;
                if (!v1.Equals(v2)) return false;
                Console.WriteLine($"Tests 1: {v1.Substring(0, 10)} === {v2.Substring(0, 10)}");
            }

            b[21] = 0; b[22] = 0; b[23] = 0;
            v1 = TripleDesDecrypt(b, _cryptedBytes);
            b[21] = 1; b[22] = 0; b[23] = 0;
            v2 = TripleDesDecrypt(b, _cryptedBytes);
            if (v1 != null && v2 != null)
            {
                valid++;
                if (!v1.Equals(v2)) return false;
                Console.WriteLine($"Tests 1: {v1.Substring(0, 10)} === {v2.Substring(0, 10)}");
            }

            b[21] = 0; b[22] = 0; b[23] = 0;
            v1 = TripleDesDecrypt(b, _cryptedBytes);
            b[21] = 1; b[22] = 0; b[23] = 0;
            v2 = TripleDesDecrypt(b, _cryptedBytes);
            if (v1 != null && v2 != null)
            {
                valid++;
                if (!v1.Equals(v2)) return false;
                Console.WriteLine($"Tests 1: {v1.Substring(0, 10)} === {v2.Substring(0, 10)}");
            }

            if (valid > 0)
                return true;
            return false;
        }
    }

    
}
