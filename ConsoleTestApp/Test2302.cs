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
    public class Test2302
    {
        FileManager errorsFM = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + "_ERRORS", "txt", "");
        public void test()
        {
            string partialKey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000";
            var b = StringToByteArray(partialKey);

            Console.WriteLine(DateTime.Now.ToString(@"d_HH_mm"));

            FileManager fm = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + "_TestResults", "csv", "");

            string regex = "CLA[VB]E|ALGOR|CRIPTO|PISTA|SIMETRI|SNOW|RABBIT|E0|RC4";
            string FileName = @"C:\Users\megag\source\repos\SICLib\WFormsDecrypt\Resources\DOCUMENTO1.DAT";
            //using (FileStream fStream = File.Open(FileName, FileMode.Open))
            //{
            //    for (int b1 = 0; b1 < 256;
            //        b1 += 2)
            //    {
            //        for (int b2 = 0; b2 < 256; b2 += 2)
            //            for (int b3 = 0; b3 < 256; b3 += 2)
            //            {
            //                b[23] = (byte)b3;
            //                b[22] = (byte)b2;
            //                b[21] = (byte)b1;

            //                var response = Decrypt(fStream, b);
            //                if (response == null) continue;
            //                bool flag = false;
            //                if (Regex.Match(response, regex, RegexOptions.IgnoreCase).Success)
            //                {
            //                    Console.WriteLine("Encontrado");
            //                    Console.WriteLine($"{b1}-{b2}-{b3}\n{response}");
            //                    Console.WriteLine($"");
            //                    flag = true;
            //                }
            //                fm.ConcatNewLine($"<START>;{b1}-{b2}-{b3};{flag};{response};<END>");
            //            }
            //        fm.WriteBuilderToFile();
            //        errorsFM.WriteBuilderToFile();
            //        Console.WriteLine($"{b1}-00-00");
            //    }
            //    fStream.Close();
            //};



        }





        public string Decrypt(byte[] Data, byte[] Key)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                var tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = Key;


                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdes.CreateDecryptor(),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return new UTF8Encoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
        }






        public static byte[] StringToByteArray(string hex)
        {
            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }


    }
}
