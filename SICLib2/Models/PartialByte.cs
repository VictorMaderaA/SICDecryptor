using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib2.Models
{
    public class PartialByte : AbstractByte
    {
        public PartialByte(bool hex1Set, bool hex2Set)
        {
            Hex1Set = hex1Set;
            Hex2Set = hex2Set;
        }

        public bool Hex1Set { get; protected set; }
        public bool Hex2Set { get; protected set; }
        public bool DoneFullIteration { get; protected set; } = false;
        public PartialByte NextPartialByte { get; set; }


        public void Iterate()
        {
            iterateHex1();
        }

        public void Reset()
        {
            if (!Hex1Set)
                Hex1Value = 0;
            if (!Hex2Set)
                Hex2Value = 0;
            DoneFullIteration = false;
        }



        private void iterateHex1()
        {
            if (!Hex1Set)
            {
                if (Hex1Value >= 15)
                {
                    Hex1Value = 0;
                    iterateHex2();
                }
                else
                {
                    Hex1Value++;
                }
            }
            else
            {
                iterateHex2();
            }
        }

        private void iterateHex2()
        {
            if (!Hex2Set)
            {
                if (Hex2Value >= 15)
                {
                    Hex2Value = 0;
                    iterateNextPartialByte();
                }
                else
                {
                    Hex2Value++;
                }
            }
            else
            {
                iterateNextPartialByte();
            }
        }

        private void iterateNextPartialByte()
        {
            DoneFullIteration = true;
            if (NextPartialByte != null)
                NextPartialByte.Iterate();
        }

    }
}
