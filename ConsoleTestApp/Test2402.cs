﻿using SICLib.Manager;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ConsoleTestApp
{
    public class Test2402
    {
        //FileManager errorsFM = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + "_ERRORS", "txt", "");
        public void test()
        {
            Console.WriteLine("2402 Test");
            string partialKey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000";
            var b = StringToByteArray(partialKey);

            string cryptedTextBase64 = @"7iuYS0z/aIp/f+dNjJCkLULBY+3K5F3B4BYBSNoKEc0g8M3lcFFECqHMb2E9rv12sUCjJA/ve1uCxGNL/feZjEFBpANh0tAs/5+97+L+kuL0wZI78Ux40XhEbyTSIoEfGY4GsM7uce7PzZ1sYSb9Kql/0j6Qu9RGWXqJMPF9XYYv5FxgNLJ8y8bzoGcZVf6h7k95a5YoX6KP9T20TMPJcqUf+nEYTo2Y54K6vU8pAUC0UxTnLlxakzCT+QBIhXl0SRS6/36rbkSppNYd0GLq5HRN+/BEFvGF+0p9fRZQ5hyqEmy8OEFqFtSBeA0LotyszSHq1ZqJA56rqXjoSZZm6ljcITolbx101eNH7x0S1zjzNv1dovIsaONQfbt6ZUlldxFDSVrQrTrsso32LIO8JWGsUCp6mc8VhL5hAA8xY7d8cwSoDzlm7+46fqP6pEnL/dArS9As+vE6ZWh+JYmDQJ5pEs2KDEVTQb5o4rFB79QE8EmmysvsC23baZXsO5Qa1GqeMcUZ2mORTHUs1GTKhqY1DpOGtXbykpXs+0RlmNzvIEASf5yOqOnHOvhzxGGzjvrEiAc61t6DB/frmGlokVZEuZcziwcb883jCRwXOb21R/AtCaf4A1VHbVq/xoeS/XRExgOle6xZGibNMUHrvprtnj9Hhdwz4H0p6m6T3sR6GAzhzAl12MzMdG4VM6QFJsSND5nNQRlHByYTZ5ebWTupKbSIDPCaOu4FydZuJj4=";
            byte[] cryptedTextBytes = Convert.FromBase64String(cryptedTextBase64);

            FileManager fm = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + "_2402Results", "csv", "");

            string regex = "CLA[VB]E|ALGORITMO|CRIPTO|PISTA|SIMETRI|SNOW|RABBIT|RC4";
                for (int b1 = 0; b1 < 256;
                    b1 += 1)
                {
                    for (int b2 = 0; b2 < 256; b2 += 1)
                        for (int b3 = 0; b3 < 256; b3 += 1)
                        {
                            b[23] = (byte)b3;
                            b[22] = (byte)b2;
                            b[21] = (byte)b1;

                            var response = Decrypt(cryptedTextBytes, b);
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
                    fm.WriteBuilderToFile();
                    //errorsFM.WriteBuilderToFile();
                    Console.WriteLine($"{b1}-00-00");
                }
        }



        public static string Decrypt(byte[] decodedData, byte[] Key)
        {
            string decryptString = "";
            TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
            //MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            try
            {
                //byte[] decodedData = Convert.FromBase64String(value);
                tDESalg.Mode = CipherMode.ECB;
                tDESalg.Padding = PaddingMode.None;//According to MS, same as PKCS5PADDING

                //byte[] Key = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(decryptionKey));//BAD
                //byte[] Key = Encoding.UTF8.GetBytes(decryptionKey.Substring(0, 24));

                //byte[] IV = tDESalg.IV;
                byte[] IV = new byte[tDESalg.BlockSize / 8]; //The size of the IV property must be the same as the BlockSize property divided by 8

                var memoryStream = new MemoryStream(decodedData);
                var cryptoStream = new CryptoStream(memoryStream, tDESalg.CreateDecryptor(Key, IV), CryptoStreamMode.Read);
                var reader = new StreamReader(cryptoStream);
                decryptString = reader.ReadToEnd();

                return decryptString;
                byte[] decryptData = Convert.FromBase64String(decryptString);
                decryptString = System.Text.UTF8Encoding.UTF8.GetString(decryptData);
                //decryptString = BitConverter.ToString(decryptData);
            }
            catch (Exception e)
            {
                return null;
            }
            return decryptString;
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
