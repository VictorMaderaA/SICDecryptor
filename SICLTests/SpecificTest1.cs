﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SICLTests
{
    public class SpecificTest1
    {

        [Test]
        public void Test1()
        {
            const string _keyString = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23FBB8CE";
            const string _cryptedString = @"7iuYS0z/aIp/f+dNjJCkLULBY+3K5F3B4BYBSNoKEc0g8M3lcFFECqHMb2E9rv12sUCjJA/ve1uCxGNL/feZjEFBpANh0tAs/5+97+L+kuL0wZI78Ux40XhEbyTSIoEfGY4GsM7uce7PzZ1sYSb9Kql/0j6Qu9RGWXqJMPF9XYYv5FxgNLJ8y8bzoGcZVf6h7k95a5YoX6KP9T20TMPJcqUf+nEYTo2Y54K6vU8pAUC0UxTnLlxakzCT+QBIhXl0SRS6/36rbkSppNYd0GLq5HRN+/BEFvGF+0p9fRZQ5hyqEmy8OEFqFtSBeA0LotyszSHq1ZqJA56rqXjoSZZm6ljcITolbx101eNH7x0S1zjzNv1dovIsaONQfbt6ZUlldxFDSVrQrTrsso32LIO8JWGsUCp6mc8VhL5hAA8xY7d8cwSoDzlm7+46fqP6pEnL/dArS9As+vE6ZWh+JYmDQJ5pEs2KDEVTQb5o4rFB79QE8EmmysvsC23baZXsO5Qa1GqeMcUZ2mORTHUs1GTKhqY1DpOGtXbykpXs+0RlmNzvIEASf5yOqOnHOvhzxGGzjvrEiAc61t6DB/frmGlokVZEuZcziwcb883jCRwXOb21R/AtCaf4A1VHbVq/xoeS/XRExgOle6xZGibNMUHrvprtnj9Hhdwz4H0p6m6T3sR6GAzhzAl12MzMdG4VM6QFJsSND5nNQRlHByYTZ5ebWTupKbSIDPCaOu4FydZuJj4=";


            var MD5 = new MD5CryptoServiceProvider();

            byte[] hash = Encoding.UTF8.GetBytes(_keyString);
            byte[] securityKey = MD5.ComputeHash(hash);

            byte[] ciferedData = Convert.FromBase64String(_cryptedString);

            string result;

            result = Decrypt1(ciferedData, securityKey);

            Console.WriteLine(result);

        }


        public string Decrypt1(byte[] ciferedData, byte[] key)
        {
            try
            {
                var tdes = new TripleDESCryptoServiceProvider()
                {
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7,
                    Key = key
                };

                var decryptor = tdes.CreateDecryptor();

                var result = decryptor.TransformFinalBlock(ciferedData, 0, ciferedData.Length);

                return Encoding.UTF8.GetString(result);
            }
            catch (Exception)
            {
                Console.WriteLine("EXCEPTION");
                return null;
            }
        }
    }
}
