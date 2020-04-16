using SICLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Manager
{
    public class FormDataManager
    {

        public static string FormatKeyInput(string line, int lenght = 48)
        {
            line = line.Replace(" ", "");
            if (line.Length < 48)
            {
                var missing = 48 - line.Length;
                line += new string('X', missing);
            }
            else
            {
                line = line.Substring(0, 48);
            }
            return line;
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
