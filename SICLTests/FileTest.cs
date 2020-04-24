using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLTests
{
    public class FileTest
    {

        [Test]
        public void test()
        {

            string FileName = @"C:\Users\megag\source\repos\SICLib\WFormsDecrypt\Resources\DOCUMENTO1.DAT";
            var str = File.ReadAllText(FileName);

            var byte1 = File.ReadAllBytes(FileName);
            var byte2 = Convert.FromBase64String(str);

            Console.WriteLine(byte1.Length + " " +byte2.Length);
        }
    }
}
