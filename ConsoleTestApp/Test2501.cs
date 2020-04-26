using SICLib.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    public class Test2501 : TestBase
    {
        private FileManager response1;
        private FileManager response2;

        public override void PreConfig()
        {
            response1 = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + $"_{GetType().Name}Responses1", "txt", "");
            response2 = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + $"_{GetType().Name}Responses2", "csv", "");
        }

        public override void OnCicle()
        {
            response1.WriteBuilderToFile();
            response2.WriteBuilderToFile();
        }

        public override string TestKey(byte[] KeyBytes)
        {

            var a = MultiTest1(KeyBytes);
            var b = MultiTest2(KeyBytes);
            var c = MultiTest3(KeyBytes);
            var d = MultiTest4(KeyBytes);
            var e = MultiTest5(KeyBytes);
            var f = MultiTest6(KeyBytes);
            var g = MultiTest7(KeyBytes);
            var h = MultiTest8(KeyBytes);
            if (string.IsNullOrWhiteSpace(a + b + c + d + e + f + g + h))
                return null;
            string line1 = $"{a}<div> --- </div>{b}<div> --- </div>{c}<div> --- </div>{d}<div> --- </div>{e}<div> --- </div>{f}<div> --- </div>{g}<div> --- </div>{h}";
            string line2 = $"{string.IsNullOrWhiteSpace(a)};{string.IsNullOrWhiteSpace(b)};{string.IsNullOrWhiteSpace(c)};{string.IsNullOrWhiteSpace(d)};{string.IsNullOrWhiteSpace(e)};{string.IsNullOrWhiteSpace(f)};{string.IsNullOrWhiteSpace(g)};{string.IsNullOrWhiteSpace(h)}";
            response1.ConcatNewLine(line1);
            response2.ConcatNewLine(line2);
            return line1; 

        }

        private string MultiTest1(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt1(_cryptedString, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 150)) return response.Substring(0,5);

                Console.WriteLine($"MultiTest1:{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest1>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest1>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string MultiTest2(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt2(_cryptedString, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest2;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest2>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest2>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string MultiTest3(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt3(_cryptedString, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest3;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest3>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest3>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string MultiTest4(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt4(_cryptedString, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest4;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest4>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest4>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string MultiTest5(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt5(_cryptedBytes,KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest5;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest5>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest5>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string MultiTest6(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt6(_cryptedBytes, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest6;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest6>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest6>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }


        private string MultiTest7(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt7(_cryptedBytes, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest7;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest7>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest7>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }


        private string MultiTest8(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt8(_cryptedBytes, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 100)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest8;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest8>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest8>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }


        public static string Decrypt1(string encodedText, byte[] key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(key);
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            var x = desCryptoProvider.CreateDecryptor();
            var y = x.TransformFinalBlock(byteBuff, 0, byteBuff.Length);
            string plaintext = Encoding.UTF8.GetString(y);
            return plaintext;
        }

        public static string Decrypt2(string encodedText, byte[] key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = key;
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            var x = desCryptoProvider.CreateDecryptor();
            var y = x.TransformFinalBlock(byteBuff, 0, byteBuff.Length);
            string plaintext = Encoding.UTF8.GetString(y);
            return plaintext;
        }

        public static string Decrypt3(string encodedText, byte[] key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(key);
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            desCryptoProvider.Padding = PaddingMode.None; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            var x = desCryptoProvider.CreateDecryptor();
            var y = x.TransformFinalBlock(byteBuff, 0, byteBuff.Length);
            string plaintext = Encoding.UTF8.GetString(y);
            return plaintext;
        }

        public static string Decrypt4(string encodedText, byte[] key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = key;
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            desCryptoProvider.Padding = PaddingMode.None; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            var x = desCryptoProvider.CreateDecryptor();
            var y = x.TransformFinalBlock(byteBuff, 0, byteBuff.Length);
            string plaintext = Encoding.UTF8.GetString(y);
            return plaintext;
        }





        private string Decrypt5(byte[] Data, byte[] Key)
        {
            byte[] key1 = new byte[8], key2 = new byte[8], key3 = new byte[8];
            Array.Copy(Key, 0, key1, 0, 8);
            Array.Copy(Key, 8, key2, 0, 8);
            Array.Copy(Key, 16, key3, 0, 8);
            return UTF8Encoding.UTF8.GetString(Decrypt5DesDecrypt(Decrypt5DesEncrypt(Decrypt5DesDecrypt(Data, key3), key2), key1));
        }


        private DES Decrypt5CreateDes(byte[] key)
        {
            DES des = new DESCryptoServiceProvider();
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.None;
            return des;
        }

        public byte[] Decrypt5DesEncrypt(byte[] inBlock, byte[] key)
        {
            var symAlg = Decrypt5CreateDes(key);
            ICryptoTransform xfrm = symAlg.CreateEncryptor();
            return xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);
        }

        public byte[] Decrypt5DesDecrypt(byte[] inBytes, byte[] key)
        {
            var symAlg = Decrypt5CreateDes(key);
            ICryptoTransform xfrm = symAlg.CreateDecryptor();
            return xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);
        }





        private string Decrypt6(byte[] Data, byte[] Key)
        {
            // Create a new MemoryStream using the passed 
            // array of encrypted data.
            MemoryStream msDecrypt = new MemoryStream(Data);

            // Create a new TripleDES object.
            TripleDES tripleDESalg = TripleDES.Create();
            tripleDESalg.Key = Key;
            tripleDESalg.Padding = PaddingMode.PKCS7;

            // Create a CryptoStream using the MemoryStream 
            // and the passed key and initialization vector (IV).
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                tripleDESalg.CreateDecryptor(), CryptoStreamMode.Read);

            // Create buffer to hold the decrypted data.
            byte[] fromEncrypt = new byte[Data.Length];

            // Read the decrypted data out of the crypto stream
            // and place it into the temporary buffer.
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            //Convert the buffer into a string and return it.
            return UTF8Encoding.UTF8.GetString(fromEncrypt);
        }

        private string Decrypt7(byte[] Data, byte[] Key)
        {
            // Create a new MemoryStream using the passed 
            // array of encrypted data.
            MemoryStream msDecrypt = new MemoryStream(Data);

            // Create a new TripleDES object.
            TripleDES tripleDESalg = TripleDES.Create();
            tripleDESalg.Key = Key;
            tripleDESalg.Padding = PaddingMode.None;

            // Create a CryptoStream using the MemoryStream 
            // and the passed key and initialization vector (IV).
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                tripleDESalg.CreateDecryptor(), CryptoStreamMode.Read);

            // Create buffer to hold the decrypted data.
            byte[] fromEncrypt = new byte[Data.Length];

            // Read the decrypted data out of the crypto stream
            // and place it into the temporary buffer.
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            //Convert the buffer into a string and return it.
            return UTF8Encoding.UTF8.GetString(fromEncrypt);
        }

        private string Decrypt8(byte[] Data, byte[] Key)
        {
            byte[] key1 = new byte[8], key2 = new byte[8], key3 = new byte[8];
            Array.Copy(Key, 0, key1, 0, 8);
            Array.Copy(Key, 8, key2, 0, 8);
            Array.Copy(Key, 16, key3, 0, 8);
            return UTF8Encoding.UTF8.GetString(Decrypt8DesDecrypt(Decrypt8DesEncrypt(Decrypt8DesDecrypt(Data, key3), key2), key1));
        }


        private DES Decrypt8CreateDes(byte[] key)
        {
            DES des = new DESCryptoServiceProvider();
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            return des;
        }

        public byte[] Decrypt8DesEncrypt(byte[] inBlock, byte[] key)
        {
            var symAlg = Decrypt8CreateDes(key);
            ICryptoTransform xfrm = symAlg.CreateEncryptor();
            return xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);
        }

        public byte[] Decrypt8DesDecrypt(byte[] inBytes, byte[] key)
        {
            var symAlg = Decrypt8CreateDes(key);
            ICryptoTransform xfrm = symAlg.CreateDecryptor();
            return xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);
        }




    }
}
