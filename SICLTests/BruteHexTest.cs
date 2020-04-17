using NUnit.Framework;
using SICLib;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SICLTests
{
    public class BruteHexTest
    {

        [Test]
        public void test()
        {
            string line = "Esta linea no contiene clave";
            if (!Regex.Match(line, "[C|c][L|l][A|a][V|v|B|b][E|e]", RegexOptions.IgnoreCase).Success)
                Assert.IsTrue(false);
            Assert.IsTrue(true);

        }

    }

}
