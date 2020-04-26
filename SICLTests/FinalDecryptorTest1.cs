using NUnit.Framework;
using SICLib.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SICLTests
{
    public class FinalDecryptorTest1
    {

        [Test]
        public void test()
        {
            string date = DateTime.Now.ToString(@"d_HH_mm");
            string partialKeyHex = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000";
            byte[] partialKeyBytes = StringToByteArray(partialKeyHex);

            string cryptedTextBase64 = @"7iuYS0z/aIp/f+dNjJCkLULBY+3K5F3B4BYBSNoKEc0g8M3lcFFECqHMb2E9rv12sUCjJA/ve1uCxGNL/feZjEFBpANh0tAs/5+97+L+kuL0wZI78Ux40XhEbyTSIoEfGY4GsM7uce7PzZ1sYSb9Kql/0j6Qu9RGWXqJMPF9XYYv5FxgNLJ8y8bzoGcZVf6h7k95a5YoX6KP9T20TMPJcqUf+nEYTo2Y54K6vU8pAUC0UxTnLlxakzCT+QBIhXl0SRS6/36rbkSppNYd0GLq5HRN+/BEFvGF+0p9fRZQ5hyqEmy8OEFqFtSBeA0LotyszSHq1ZqJA56rqXjoSZZm6ljcITolbx101eNH7x0S1zjzNv1dovIsaONQfbt6ZUlldxFDSVrQrTrsso32LIO8JWGsUCp6mc8VhL5hAA8xY7d8cwSoDzlm7+46fqP6pEnL/dArS9As+vE6ZWh+JYmDQJ5pEs2KDEVTQb5o4rFB79QE8EmmysvsC23baZXsO5Qa1GqeMcUZ2mORTHUs1GTKhqY1DpOGtXbykpXs+0RlmNzvIEASf5yOqOnHOvhzxGGzjvrEiAc61t6DB/frmGlokVZEuZcziwcb883jCRwXOb21R/AtCaf4A1VHbVq/xoeS/XRExgOle6xZGibNMUHrvprtnj9Hhdwz4H0p6m6T3sR6GAzhzAl12MzMdG4VM6QFJsSND5nNQRlHByYTZ5ebWTupKbSIDPCaOu4FydZuJj4=";
            byte[] cryptedTextBytes = Convert.FromBase64String(cryptedTextBase64);


            long linesWriten = 0;
            int fileNumber = 0;
            Console.WriteLine("Empezando");
            for (int b1 = 15; b1 < 256;
                b1++)
                for (int b2 = 40; b2 < 256; b2++)
                    for (int b3 = 0; b3 < 256; b3++)
                    {
                        partialKeyBytes[23] = (byte)b3;
                        partialKeyBytes[22] = (byte)b2;
                        partialKeyBytes[21] = (byte)b1;

                        var decryptedText = DecryptTDES1(cryptedTextBytes, partialKeyBytes);
                        var processedText = new SICLib.Manager.StringBuilder(decryptedText).RemoveNoneAlphanumericChars().GetString();
                        //FileManager.WriteLineFile($"<Start{b1}-{b2}-{b3}>{ processedText }<End>", @"C:\temp\" + date + @"_resultTest");

                        if (Regex.Match(processedText, "[Cc][Ll][Aa][VvBb][Ee]", RegexOptions.IgnoreCase).Success)
                        {
                            Console.WriteLine("Encontrado");
                            Console.WriteLine($"{b1}-{b2}-{b3}");
                            //FileManager.WriteLineFile($"<FOUND>{b1}-{b2}-{b3}<>{decryptedText}<FOUND>", @"C:\temp\" + date + @"_resultTest_" + fileNumber);
                        }
                        if(linesWriten++ > 250000)
                        {
                            linesWriten = 0;
                            fileNumber++;
                        }

                    }
            Console.WriteLine("Terminando");
        }


        public static string DecryptTDES1(byte[] encryptedBytes, byte[] keyBytes)
        {
            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = keyBytes;
            MyTripleDESCryptoService.Mode = CipherMode.ECB;
            MyTripleDESCryptoService.Padding = PaddingMode.None;

            var MyCrytpoTransform = MyTripleDESCryptoService.CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            MyTripleDESCryptoService.Clear();

            return ASCIIEncoding.ASCII.GetString(MyresultArray);
        }

        private static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1) throw new Exception("The binary key cannot have an odd number of digits");
            byte[] arr = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            return arr;
        }

        private static int GetHexVal(char hex)
        {
            int val = (int)hex;
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

    }
}
