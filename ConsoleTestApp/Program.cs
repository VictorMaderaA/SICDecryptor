using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString(@"d_HH_mm"));
            var cls = new Test2303();
            cls.test();
            Console.WriteLine("Terminado");
            Console.ReadLine();
        }
    }
}
