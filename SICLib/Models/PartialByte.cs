using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Models
{
    public class PartialByte
    {

        private int _hex1;
        private int _hex2;
        private bool _hex1Complete;
        private bool _hex2Complete;
        private PartialByte _nextByte = null;
        private bool doneFullIteration = false;


        public int hex1Integer
        {
            get { return _hex1; }
        }

        public string hex1HexString
        {
            get { return _hex1.ToString("X"); }
        }

        public int hex2Integer
        {
            get { return _hex2; }
        }

        public string hex2HexString
        {
            get { return _hex2.ToString("X"); }
        }

        public string HexPartialString
        {
            get { 
                return (_hex1Complete ? hex1HexString : "X") + (_hex2Complete ? hex2HexString : "X");
            }
        }

        public string HexString
        {
            get
            {
                return hex1HexString + hex2HexString;
            }
        }

        public bool complete
        {
            get { return (_hex1Complete && _hex2Complete); }
        }
        public bool HasDoneFullIteration
        {
            get { return doneFullIteration; }
        }
        public byte GetByte
        {
            get 
            {
                var hex = hex1HexString + hex2HexString;
                var bytes = StringToByteArrayFastest(hex);
                return bytes[0]; 
            }
        }

        public long Combinations
        {
            get
            {
                return 1 * (_hex1Complete ? 1 : 16) * (_hex2Complete ? 1 : 16);
            }
        }



        public PartialByte(char hex1, char hex2)
        {
            try
            {
                var r = Convert.ToInt32(hex1.ToString(), 16);
                _hex1 = r;
                _hex1Complete = true;
            }
            catch (Exception)
            {
                _hex1 = 0;
                _hex1Complete = false;
            }

            try
            {
                var r = Convert.ToInt32(hex2.ToString(), 16);
                _hex2 = r;
                _hex2Complete = true;
            }
            catch (Exception)
            {
                _hex2 = 0;
                _hex2Complete = false;
            }
        }

        public void LinkNextByte(PartialByte nextByte)
        {
            _nextByte = nextByte;
        }

        public void iterate()
        {
            if(complete)
            {
                //Nothing to iterate;
                iterateNextPartialByte();
                return;
            }
            else
            {
                iterateHex1();
            }
            if (GetByte % 2 != 0)
                iterate();
        }

        private void iterateHex1()
        {
            if(!_hex1Complete)
            {
                if(_hex1 >= 15)
                {
                    _hex1 = 0;
                    iterateHex2();
                }
                else
                {
                    _hex1++;
                }
            }
            else
            {
                iterateHex2();
            }
        }

        private void iterateHex2()
        {
            if (!_hex2Complete)
            {
                if (_hex2 >= 15)
                {
                    _hex2 = 0;
                    iterateNextPartialByte();
                }
                else
                {
                    _hex2++;
                }
            }
            else
            {
                iterateNextPartialByte();
            }
        }

        private void iterateNextPartialByte()
        {
            doneFullIteration = true;
            if (_nextByte != null)
                _nextByte.iterate();
        }

        private static byte[] StringToByteArrayFastest(string hex)
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
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static byte[] GetBytesFromPartialBytes(PartialByte[] bytes)
        {
            byte[] b = new byte[24];
            for (int i = 0; i < 24; i++)
            {
                b[i] = bytes[i].GetByte;
            }
            return b;
        }

    }
}
