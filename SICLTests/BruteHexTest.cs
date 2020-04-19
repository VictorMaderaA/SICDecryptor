using NUnit.Framework;
using SICLib;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace SICLTests
{
    public class BruteHexTest
    {

        [Test]
        public void test()
        {
            //string line = "Esta linea no contiene clave";
            //if (!Regex.Match(line, "[C|c][L|l][A|a][V|v|B|b][E|e]", RegexOptions.IgnoreCase).Success)
            //    Assert.IsTrue(false);
            //Assert.IsTrue(true);
            var c = new TripleDESCryptoServiceProvider();
            Console.WriteLine(c.BlockSize);
            Console.WriteLine(c.KeySize);

        }

        [Test]
        public void test2()
        {
            string line = "esto no es una ya sabes que jaja pero esta noclaveno ultima si lo es";
            Console.WriteLine((Regex.Match(line, "[Cc][Ll][Aa][VvBb][Ee]", RegexOptions.IgnoreCase).Success)? 1 : 0);
        }

    }

}
