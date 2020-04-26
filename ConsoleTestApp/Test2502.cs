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
    class Test2502 : TestBase
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
            var a = MultiTest9(KeyBytes);
            var b = MultiTest10(KeyBytes);
            if (string.IsNullOrWhiteSpace(a + b))
                return null;
            string line1 = $"{a}<div> --- </div>{b}<div> --- </div>";
            string line2 = $"{string.IsNullOrWhiteSpace(a)};{string.IsNullOrWhiteSpace(b)}";
            response1.ConcatNewLine(line1);
            response2.ConcatNewLine(line2);
            return line1;

        }

        private string MultiTest9(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt9(_cryptedBytes, KeyBytes);

                if (response == null) return "";
                if (new SICLib.Manager.StringBuilder(response).CountChar("[�]", 150)) return response.Substring(0, 5);

                Console.WriteLine($"MultiTest1:{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]}\n{response}");
                fileManager.ConcatNewLine($"<START MultiTest1>;{KeyBytes[21]}-{KeyBytes[22]}-{KeyBytes[23]};{response};<END MultiTest1>");
                return response;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string MultiTest10(byte[] KeyBytes)
        {
            try
            {
                var response = Decrypt10(_cryptedBytes, KeyBytes);

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

        private string Decrypt9(byte[] Data, byte[] Key)
        {
            // Create a new MemoryStream using the passed 
            // array of encrypted data.
            MemoryStream msDecrypt = new MemoryStream(Data);

            // Create a new TripleDES object.
            TripleDES tripleDESalg = TripleDES.Create();
            tripleDESalg.Key = Key;
            tripleDESalg.Padding = PaddingMode.PKCS7;
            tripleDESalg.Mode = CipherMode.ECB;

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

        private string Decrypt10(byte[] Data, byte[] Key)
        {
            // Create a new MemoryStream using the passed 
            // array of encrypted data.
            MemoryStream msDecrypt = new MemoryStream(Data);

            // Create a new TripleDES object.
            TripleDES tripleDESalg = TripleDES.Create();
            tripleDESalg.Key = Key;
            tripleDESalg.Padding = PaddingMode.None;
            tripleDESalg.Mode = CipherMode.ECB;

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


    }
}
