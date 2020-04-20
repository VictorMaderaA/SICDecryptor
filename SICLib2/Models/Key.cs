using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib2.Models
{
    public class Key
    {

        public int Lenght { get; protected set; }

        protected AbstractByte[] BytesArray { get; set; }


        public Key(int lenght)
        {
            Lenght = lenght;

        }



        public void LoadKeyFromString(string keyString)
        {
            keyString = FormatStringInput(keyString);
        }

        private string FormatStringInput(string line)
        {
            line = line.Replace(" ", "");
            if (line.Length < (Lenght * 2))
            {
                var missing = (Lenght * 2) - line.Length;
                line += new string('X', missing);
            }
            else
            {
                line = line.Substring(0, Lenght * 2);
            }
            return line;
        }

        private string SetBytesArray(string keyString)
        {
            //AbstractByte[] bytes = new AbstractByte[Lenght];
            //for (int ih = 0, ib = 0; ih < 48; ih += 2, ib++)
            //{
            //    var hexVal1 = keyString[ih];
            //    var hexVal2 = keyString[ih + 1];
            //    bytes[ib] = new PartialByte();
            //}
            return null;
        }

    }
}
