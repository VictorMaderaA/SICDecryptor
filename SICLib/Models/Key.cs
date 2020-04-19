using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Models
{
    public class Key
    {

        public int KeyLenght { get; private set; }
        public PartialByte[] PartialBytes { get; private set; }
        public long KeyCombinations { get; set; }


        public Key(int keyLenght)
        {
            KeyLenght = keyLenght;
        }

        public void LoadKeyFromString(string keyText)
        {
            keyText = keyText.Replace(" ", "");
            if (keyText.Length < KeyLenght * 2)
            {
                var missing = (KeyLenght * 2) - keyText.Length;
                keyText += new string('X', missing);
            }
            else
            {
                keyText = keyText.Substring(0, KeyLenght * 2);
            }

            var bytes = new PartialByte[KeyLenght];
            for (int ih = 0, ib = 0; ih < 48; ih += 2, ib++)
            {
                var hexVal1 = keyText[ih];
                var hexVal2 = keyText[ih + 1];
                bytes[ib] = new PartialByte(hexVal1, hexVal2);
            }
            for (int i = 0; i < bytes.Length - 1; i++)
            {
                bytes[i].LinkNextByte(bytes[i + 1]);
            }
            PartialBytes = bytes;
        }


        public byte[] GetKeyBytes()
        {
            byte[] b = new byte[KeyLenght];
            for (int i = 0; i < KeyLenght; i++)
            {
                b[i] = PartialBytes[i].GetByte;
            }
            return b;
        }

        public string GetKeyHex()
        {
            string key = string.Empty;
            for (int i = 0; i < KeyLenght; i++)
            {
                key += PartialBytes[i].HexPartialString + "-";
            }
            return key;
        }

        public long GetKeyCombinations()
        {
            long combinations = 1;
            foreach (var b in PartialBytes)
            {
                combinations *= b.Combinations;
            }
            return combinations;
        }


    }
}
