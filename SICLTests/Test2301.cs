using NUnit.Framework;
using SICLib2.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SICLTests
{
    public class Test2301
    {

        [Test]
        public void test()
        {
            string partialKey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000";
            var b = StringToByteArray(partialKey);

            Console.WriteLine(DateTime.Now.ToString(@"d_HH_mm"));

            FileManager fm = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + "_TestResults", "csv", "");

            string regex = "CLA[VB]E|ALGOR|CRIPTO|PISTA|SIMETRI|SNOW|RABBIT|E0|RC4";
            string FileName = @"C:\Users\megag\source\repos\SICLib\WFormsDecrypt\Resources\DOCUMENTO1.DAT";
            using (FileStream fStream = File.Open(FileName, FileMode.Open))
            {
                for (int b1 = 0; b1 < 256;
                    b1 += 2)
                {
                    for (int b2 = 0; b2 < 256; b2 += 2)
                        for (int b3 = 0; b3 < 256; b3 += 2)
                        {
                            b[23] = (byte)b3;
                            b[22] = (byte)b2;
                            b[21] = (byte)b1;

                            var response = Decrypt(fStream, b);
                            if (response == null) continue;
                            bool flag = false;
                            if (Regex.Match(response, regex, RegexOptions.IgnoreCase).Success)
                            {
                                Console.WriteLine("Encontrado");
                                Console.WriteLine($"{b1}-{b2}-{b3}\n{response}");
                                Console.WriteLine($"");
                                flag = true;
                            }
                            fm.ConcatNewLine($"<START>;{b1}-{b2}-{b3};{flag};{response};<END>");
                        }
                    Console.WriteLine($"{b1}-00-00");
                }
                fStream.Close();
            };



        }





        public string Decrypt(FileStream fStream, byte[] Key)
        {
            try
            {
                var tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = Key;
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(fStream, tdes.CreateDecryptor(), CryptoStreamMode.Read);

                // Create a StreamReader using the CryptoStream.
                StreamReader sReader = new StreamReader(cStream);

                // Read the data from the stream 
                // to decrypt it.
                string val = sReader.ReadLine();

                // Close the streams and
                // close the file.
                sReader.Close();
                cStream.Close();

                // Return the string. 
                return val;
            }
            catch (Exception)
            {
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
