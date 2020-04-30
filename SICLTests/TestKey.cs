using NUnit.Framework;
using SICLib.Manager;
using SICLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SICLTests
{
    public class TestKey
    {
        private string _partialKeyString = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000"; //le faltan 6 chars hex

        [Test]
        public void test()
        {
            var tp1 = UTF8Encoding.UTF8.GetBytes(@"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23000000");
            var tp2 = UTF8Encoding.UTF8.GetBytes(@"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23");
            var byte1 = new MD5CryptoServiceProvider().ComputeHash(tp1);
            var byte3 = new MD5CryptoServiceProvider().ComputeHash(tp2);
            var pb = FormDataManager.GetPartialBytesKeyString(_partialKeyString);
            var byte2 = PartialByte.GetBytesFromPartialBytes(pb);

            Console.WriteLine(byte1 + "" +  byte2);

        }

        public static PartialByte[] GetPartialBytesKeyString(string key)
        {
            if (key.Length % 2 == 0)
                key += "X";
            var bytes = new PartialByte[key.Length / 2];
            for (int ih = 0, ib = 0; ih < 48; ih += 2, ib++)
            {
                var hexVal1 = key[ih];
                var hexVal2 = key[ih + 1];
                bytes[ib] = new PartialByte(hexVal1, hexVal2);
            }
            for (int i = 0; i < bytes.Length - 1; i++)
            {
                bytes[i].LinkNextByte(bytes[i + 1]);
            }
            return bytes;
        }

    }
}
