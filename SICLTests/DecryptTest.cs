using NUnit.Framework;
using SICLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SICLTests
{
    public class DecryptTest
    {

        [Test]
        public void decrypt()
        {


            string partialKey = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000";
            string criptedString = @"7iuYS0z/aIp/f+dNjJCkLULBY+3K5F3B4BYBSNoKEc0g8M3lcFFECqHMb2E9rv12sUCjJA/ve1uCxGNL/feZjEFBpANh0tAs/5+97+L+kuL0wZI78Ux40XhEbyTSIoEfGY4GsM7uce7PzZ1sYSb9Kql/0j6Qu9RGWXqJMPF9XYYv5FxgNLJ8y8bzoGcZVf6h7k95a5YoX6KP9T20TMPJcqUf+nEYTo2Y54K6vU8pAUC0UxTnLlxakzCT+QBIhXl0SRS6/36rbkSppNYd0GLq5HRN+/BEFvGF+0p9fRZQ5hyqEmy8OEFqFtSBeA0LotyszSHq1ZqJA56rqXjoSZZm6ljcITolbx101eNH7x0S1zjzNv1dovIsaONQfbt6ZUlldxFDSVrQrTrsso32LIO8JWGsUCp6mc8VhL5hAA8xY7d8cwSoDzlm7+46fqP6pEnL/dArS9As+vE6ZWh+JYmDQJ5pEs2KDEVTQb5o4rFB79QE8EmmysvsC23baZXsO5Qa1GqeMcUZ2mORTHUs1GTKhqY1DpOGtXbykpXs+0RlmNzvIEASf5yOqOnHOvhzxGGzjvrEiAc61t6DB/frmGlokVZEuZcziwcb883jCRwXOb21R/AtCaf4A1VHbVq/xoeS/XRExgOle6xZGibNMUHrvprtnj9Hhdwz4H0p6m6T3sR6GAzhzAl12MzMdG4VM6QFJsSND5nNQRlHByYTZ5ebWTupKbSIDPCaOu4FydZuJj4=";
            //string criptedString = @"6jTT5bXT5TAea+qqkFK/Vs8DYIhfjWBl0UvjE8+ImP1eXI4efHGOnOSwbyAaIF1SXyHP0LWpWF3EcbKkKXyecPukYp0XIlhGdL8yAVUtstloCcpJL2C1bZYb3782WrlnldLtTgCpG0wGN4hCdTX196f0ioUGvGfrDSPhbcU1sXxODjBmrukCOfYk4rwYR2DJ";
            byte[] cripted = Convert.FromBase64String(criptedString);

            var b = StringToByteArray(partialKey);
            Console.WriteLine(1);


            for (int b1 = 0; b1 < 256;
                b1++)
                for (int b2 = 0; b2 < 256; b2++)
                    for (int b3 = 0; b3 < 256; b3++)
                    {
                        b[23] = (byte)b3;
                        b[22] = (byte)b2;
                        b[21] = (byte)b1;

                        var response = Decrypt(b, cripted);
                        var str = response.GetDecodedString(Encoding.ASCII);
                        if(str.Contains("clave"))
                        {
                            Console.WriteLine("Encontrado");
                            Console.WriteLine($"{b1}-{b2}-{b3}");
                        }

                    }

        }


        [Test]
        public void testED1()
        {
            string clave = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23FFFFFF";
            string texto = @"This is the answer to your problems";

            var cripted = EncryptTDES1(texto, clave);
            var decripted = DecryptTDES1(cripted, clave);

            Console.WriteLine(1);

        }

        private SymmetricAlgorithm CryptoService = new TripleDESCryptoServiceProvider();

        public DecryptedObject Decrypt(byte[] key, byte[] cryptedBytes)
        {
            CryptoService.Padding = PaddingMode.None;
            CryptoService.KeySize = 192;
            CryptoService.BlockSize = 64;
            var MyCrytpoTransform = CryptoService.CreateDecryptor(key, key);
            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cryptedBytes, 0, cryptedBytes.Length);
            CryptoService.Clear();
            return new DecryptedObject(MyresultArray, key);
        }


        public static string EncryptTDES1(string TextToEncrypt, string TextKey)
        {

            byte[] keyBytes = StringToByteArray(TextKey);

            byte[] textBytes = StringToByteArray(AsciiToHex(TextToEncrypt));



            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = keyBytes;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.Zeros;

            var MyCrytpoTransform = MyTripleDESCryptoService.CreateEncryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(textBytes, 0,
               textBytes.Length);

            MyTripleDESCryptoService.Clear();

            return Convert.ToBase64String(MyresultArray, 0,
               MyresultArray.Length);
        }



        public static string DecryptTDES1(string TextToDecrypt, string TextKey)
        {

            byte[] keyBytes = StringToByteArray(TextKey);

            byte[] encryptedBytes = Convert.FromBase64String(TextToDecrypt);

            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            MyTripleDESCryptoService.Key = keyBytes;

            MyTripleDESCryptoService.Mode = CipherMode.ECB;

            MyTripleDESCryptoService.Padding = PaddingMode.Zeros;

            var MyCrytpoTransform = MyTripleDESCryptoService.CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform
               .TransformFinalBlock(encryptedBytes, 0,
               encryptedBytes.Length);

            MyTripleDESCryptoService.Clear();

            return ASCIIEncoding.ASCII.GetString(MyresultArray);
        }


        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

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

        public static string AsciiToHex(string asciiString)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in asciiString)
            {
                builder.Append(Convert.ToInt32(c).ToString("X"));
            }
            return builder.ToString();
        }



    }
}
