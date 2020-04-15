using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SICLib.Manager
{
    public static class FileManager
    {

        static ReaderWriterLock locker = new ReaderWriterLock();
        public static void WriteLineFile(this string text, string path)
        {
            try
            {
                locker.AcquireWriterLock(int.MaxValue); //You might wanna change timeout value 
                File.AppendAllLines(path, new[] { text });
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }

    }
}
