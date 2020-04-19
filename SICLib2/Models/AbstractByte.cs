using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib2.Models
{
    public class AbstractByte
    {

        public int Hex1Value { get; protected set; }
        public int Hex2Value { get; protected set; }

        public AbstractByte NextByte { get; set; }

        public AbstractByte(int hex1, int hex2)
        {
            Hex1Value = hex1;
            Hex2Value = hex2;
        }


        public byte GetByte()
        {
            return HexToBytes(Hex1Value.ToString("X") + Hex2Value.ToString("X"))[0];
        }

        public string GetHex()
        {
            return Hex1Value.ToString("X") + Hex2Value.ToString("X");
        }

        public static byte[] HexToBytes(string hex)
        {
            if (hex.Length % 2 == 1) throw new Exception("The binary key cannot have an odd number of digits");
            byte[] arr = new byte[hex.Length >> 1];
            for (int i = 0; i < hex.Length >> 1; ++i)
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            return arr;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }




    }
}
