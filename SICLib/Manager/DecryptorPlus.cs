using SICLib.Decryptor;
using SICLib.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SICLib.Manager
{
    public class DecryptorPlus
    {

        static readonly object lockIterationsDone = new object();
        public int IterationsDone { get; private set; } = 0;
        private void CountNewIteration()
        {
            lock (lockIterationsDone)
            {
                IterationsDone++;
            }
        }

        public int Keys { get { return PendingKeysCount; } }


        public int Tasks { get { return CalculateTasks(); } }
        private int CalculateTasks()
        {
            int n = 0;
            foreach (var t in tasks)
                if (t != null)
                    n += (t.Status == TaskStatus.Running) ? 1 : 0;
            return n;
        }


        static readonly object lockErrors = new object();
        public int Errors { get; private set; } = 0;
        private void CountNewError()
        {
            lock (lockErrors)
            {
                Errors++;
            }
        }


        static readonly object lockSuccesses = new object();
        public int Successes { get; private set; } = 0;
        private void CountNewSuccess()
        {
            lock (lockSuccesses)
            {
                Successes++;
            }
        }


        static readonly object lockPendingKeys = new object();
        private static Queue<byte[]> pendingKeys = new Queue<byte[]>();
        public int PendingKeysCount
        {
            get
            {
                lock (lockPendingKeys)
                {
                    return pendingKeys.Count;
                }
            }
        }

        public DateTime StartAtTime { get; private set; } = DateTime.Now;
        private byte[] cryptedBytes;
        private PartialByte[] _partialBytes;       



        public DecryptorPlus(PartialByte[] partialBytes, string cryptedText, string outputFolder = null)
        {
            _partialBytes = partialBytes;

            cryptedBytes = Convert.FromBase64String(cryptedText);
        }

        Task[] tasks = new Task[10];
        public async Task Decrypt()
        {
            string line = string.Empty;
            line += $";KEY"; //Llave utilizada
            line += $";O CHARS;P CHARS"; //Numero de Caracteres en String
            line += $";CHAR DIF"; // Diferencia Numercia de Caracteres entre original y procesada
            line += $";O ALPHA;P ALPHA"; //Numero de Caracteres Alphanumericos
            line += $";O N ALPHA;P N ALPHA"; //Numero de Caracteres No Alphanumericos
            line += $";O HEX;P HEX"; //Numero de Caracteres Hexadecimales
            line += $";O N HEX;P N HEX"; //Numero de Caracteres No Hexadecimales

            line += $";PROCESADA"; // String Procesada
            line += $";ORIGINAL CASI"; // String original sin saltos de linea ni ';'

            FileManager.WriteLineFile(BitConverter.ToString(cryptedBytes), @"C:\temp\" + StartAtTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");
            FileManager.WriteLineFile("Decoded With Ascii", @"C:\temp\" + StartAtTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");
            FileManager.WriteLineFile(line, @"C:\temp\" + StartAtTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");


            var keyQueueTask = Task.Run(() => KeepKeyQueueData());
            while (
                keyQueueTask.Status != TaskStatus.RanToCompletion ||
                PendingKeysCount != 0)
            {
                for (int i = 0; i < tasks.Length; i++)
                {
                    if (PendingKeysCount <= 0)
                    {
                        await Task.Delay(5);
                        break;
                    }
                    if (tasks[i] == null || tasks[i].Status == TaskStatus.RanToCompletion)
                        tasks[i] = Task.Run(() => ProccessNextKeyTask(i));
                }
            }

            keyQueueTask.Wait();
        }

        public int getNumTasksRunning()
        {
            int n = 0;
            foreach (var t in tasks)
            {
                if(t != null)
                    n += (t.Status == TaskStatus.Running)? 1 : 0;
            }
            return n;
        }

        public int ProccessNextKeyTask(int key)
        {
            ProccessKey();
            CountNewIteration();
            return key;
        }


        public async void KeepKeyQueueData()
        {
            var completed = false;
            do
            {
                if (PendingKeysCount > 5000)
                {
                    await Task.Delay(100);
                    continue;
                }

                for(int i = 0; i < 1000; i++)
                {
                    byte[] r = GenerateNextKey();
                    if(r == null)
                    {
                        completed = true;
                        break;
                    }
                    AddNextPendingKey(r);
                }

            } while (!completed);

        }

        private byte[] GenerateNextKey()
        {
            if (_partialBytes[_partialBytes.Length - 1].HasDoneFullIteration)
            {
                return null;
            }
            byte[] key = new byte[24];
            for (int i = 0; i < 24; i++)
            {
                key[i] = _partialBytes[i].GetByte;
            }
            _partialBytes[0].iterate();
            return key;
        }

        
        private static byte[] GetNextPendingKey()
        {
            byte[] key;
            lock (lockPendingKeys)
            {
                key = pendingKeys.Dequeue();
            }
            return key;
        }
        private static void AddNextPendingKey(byte[] key)
        {
            lock (lockPendingKeys)
            {
                pendingKeys.Enqueue(key);
            }
        }



        public void ProccessKey()
        {
            var keyBytes = GetNextPendingKey();
            bool exception = false;

            DecryptedObject decryptedObject;
            try
            {
                decryptedObject = new TDesService().Decrypt(keyBytes, cryptedBytes);
            }
            catch (Exception)
            {
                exception = true;
                CountNewError();
                return;
            }
            if(!exception)
            {
                ProcessAscii(decryptedObject);
                CountNewSuccess();
            }

        }

        private void ProcessAscii(DecryptedObject decryptedObject)
        {
            var filePath = @"C:\temp\" + StartAtTime.ToString(@"d_HH_mm") + @"_resultAscii.csv";

            string sDecryptOrig = decryptedObject.GetDecodedString(Encoding.ASCII);
            var sDecyptPrintable = new StringBuilder(sDecryptOrig).RemoveNewLines()
                .RemoveChar(';').RemoveChar('\n').RemoveChar('?').RemoveAsciiControllChars().GetString();

            int cDIsAlpha = new StringBuilder(sDecryptOrig).CountAlphanumericChars(); //Numero de Caracteres Alphanumericos
            int cDNoAlpha = new StringBuilder(sDecryptOrig).CountNoAlphanumericChars(); //Numero de Caracteres No Alphanumericos

            int cDIsHex = new StringBuilder(sDecryptOrig).CountHexadecimalChars(); //Numero de Caracteres Hexadecimales
            int cDNoHex = new StringBuilder(sDecryptOrig).CountNoHexadecimalChars(); //Numero de Caracteres No Hexadecimales

            int cDChars = new StringBuilder(sDecryptOrig).CountChars(); //Numero de Caracteres en String Decriptada


            string sProcessed = new StringBuilder(sDecryptOrig).RemoveNoneAlphanumericChars().GetString();

            int cPIsAlpha = new StringBuilder(sProcessed).CountAlphanumericChars(); //Numero de Caracteres Alphanumericos
            int cPNoAlpha = new StringBuilder(sProcessed).CountNoAlphanumericChars(); //Numero de Caracteres No Alphanumericos

            int cPIsHex = new StringBuilder(sProcessed).CountHexadecimalChars(); //Numero de Caracteres Hexadecimales
            int cPNoHex = new StringBuilder(sProcessed).CountNoHexadecimalChars(); //Numero de Caracteres No Hexadecimales

            int cPChars = new StringBuilder(sProcessed).CountChars(); //Numero de Caracteres en String Procesada



            int cCharDif = cDChars - cPChars; // Diferencia Numercia de Caracteres entre original y procesada


            string line = string.Empty;
            line += $";{decryptedObject.GetBytesKeyHex()}"; //Llave utilizada
            line += $";{cDChars};{cPChars}"; //Numero de Caracteres en String
            line += $";{cCharDif}"; // Diferencia Numercia de Caracteres entre original y procesada
            line += $";{cDIsAlpha};{cPIsAlpha}"; //Numero de Caracteres Alphanumericos
            line += $";{cDNoAlpha};{cPNoAlpha}"; //Numero de Caracteres No Alphanumericos
            line += $";{cDIsHex};{cPIsHex}"; //Numero de Caracteres Hexadecimales
            line += $";{cDNoHex};{cPNoHex}"; //Numero de Caracteres No Hexadecimales

            line += $";{sProcessed}"; // String Procesada
            line += $";{sDecyptPrintable}"; // String original sin saltos de linea ni ';'

            FileManager.WriteLineFile(line, filePath);
        }
    }
}
