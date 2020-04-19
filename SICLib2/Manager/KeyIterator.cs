using SICLib2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SICLib2.Manager
{
    class KeyIterator
    {

        public Key KeyUsed { get; private set; }

        public KeyIterator(Key key)
        {
            KeyUsed = key;
        }

    }
}
