using SICLib.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    public abstract class TestBase
    {

        protected FileManager fileManager;

        protected string _partialKeyString { get; private set; }
        protected string _cryptedString { get; private set; }
        protected byte[] _cryptedBytes { get; private set; }
        protected string _cryptedFilePath { get; private set; }
        private int _byteJump = 1;

        public TestBase()
        {
            _partialKeyString = @"9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23"; //le faltan 6 chars hex
            _cryptedString = @"7iuYS0z/aIp/f+dNjJCkLULBY+3K5F3B4BYBSNoKEc0g8M3lcFFECqHMb2E9rv12sUCjJA/ve1uCxGNL/feZjEFBpANh0tAs/5+97+L+kuL0wZI78Ux40XhEbyTSIoEfGY4GsM7uce7PzZ1sYSb9Kql/0j6Qu9RGWXqJMPF9XYYv5FxgNLJ8y8bzoGcZVf6h7k95a5YoX6KP9T20TMPJcqUf+nEYTo2Y54K6vU8pAUC0UxTnLlxakzCT+QBIhXl0SRS6/36rbkSppNYd0GLq5HRN+/BEFvGF+0p9fRZQ5hyqEmy8OEFqFtSBeA0LotyszSHq1ZqJA56rqXjoSZZm6ljcITolbx101eNH7x0S1zjzNv1dovIsaONQfbt6ZUlldxFDSVrQrTrsso32LIO8JWGsUCp6mc8VhL5hAA8xY7d8cwSoDzlm7+46fqP6pEnL/dArS9As+vE6ZWh+JYmDQJ5pEs2KDEVTQb5o4rFB79QE8EmmysvsC23baZXsO5Qa1GqeMcUZ2mORTHUs1GTKhqY1DpOGtXbykpXs+0RlmNzvIEASf5yOqOnHOvhzxGGzjvrEiAc61t6DB/frmGlokVZEuZcziwcb883jCRwXOb21R/AtCaf4A1VHbVq/xoeS/XRExgOle6xZGibNMUHrvprtnj9Hhdwz4H0p6m6T3sR6GAzhzAl12MzMdG4VM6QFJsSND5nNQRlHByYTZ5ebWTupKbSIDPCaOu4FydZuJj4=";
            _cryptedBytes = Convert.FromBase64String(_cryptedString);
            _cryptedFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Resources\DOCUMENTO1.DAT";

            PreConfig();

            Console.WriteLine($"{DateTime.Now.ToString()} - Running {GetType().Name}");
            fileManager = new FileManager(@"C:\temp", DateTime.Now.ToString(@"d_HH_mm") + $"_{GetType().Name}Results", "csv", "");
            if (TryToSaveTime())
            {
                Console.WriteLine("SAVED TIME LSB ");
                _byteJump = 2;
            }
            Run();
            Console.WriteLine($"{DateTime.Now.ToString()} - Finished {GetType().Name}");
        }

        private void Run()
        {
            byte[] b = StringToByteArray(_partialKeyString + "000000");
            for (int b1 = 0; b1 < 256;b1 += _byteJump)
            {
                Console.WriteLine($"{b1}-00-00");
                b[21] = (byte)b1;
                for (int b2 = 0; b2 < 256; b2 += _byteJump)
                {
                    b[22] = (byte)b2;
                    for (int b3 = 0; b3 < 256; b3 += _byteJump)
                    {
                        b[23] = (byte)b3;
                        TestKey(b);
                    }
                }
                fileManager.ConcatNewLine($"{b1}-00-00 TESTED");
                fileManager.WriteBuilderToFile();
                OnCicle();
            }
        }


        public virtual bool TryToSaveTime()
        {
            return false;
        }

        public virtual void OnCicle()
        {

        }

        public virtual void PreConfig()
        {

        }

        public abstract string TestKey(byte[] KeyBytes);







        protected static byte[] StringToByteArray(string hex)
        {
            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }

        private static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }



    }
}
