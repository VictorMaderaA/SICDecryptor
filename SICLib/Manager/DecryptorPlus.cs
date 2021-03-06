﻿using SICLib.Decryptor;
using SICLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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


        private FileManager MyFileManager { get; set; }
        private FileManager MyFileManagerSuccesses { get; set; }
        private FileManager MyFileManagerBad { get; set; }
        public DecryptorPlus(PartialByte[] partialBytes, string cryptedText, string outputFolder = null)
        {
            string folder = @"C:\temp";
            if(outputFolder != null)
            {
                folder = outputFolder;
            }

            _partialBytes = partialBytes;

            cryptedBytes = Convert.FromBase64String(cryptedText);

            string line = string.Empty;
            line += $"; KEY"; //Llave utilizada
            line += $";O CHARS;P CHARS"; //Numero de Caracteres en String
            line += $";CHAR DIF"; // Diferencia Numercia de Caracteres entre original y procesada
            line += $";O ALPHA;P ALPHA"; //Numero de Caracteres Alphanumericos
            line += $";O N ALPHA;P N ALPHA"; //Numero de Caracteres No Alphanumericos
            line += $";O HEX;P HEX"; //Numero de Caracteres Hexadecimales
            line += $";O N HEX;P N HEX"; //Numero de Caracteres No Hexadecimales

            line += $";PROCESADA"; // String Procesada
            line += $";ORIGINAL CASI"; // String original sin saltos de linea ni ';'

            MyFileManager = new FileManager(folder, StartAtTime.ToString(@"d_HH_mm") + "_Results", "csv", line);
            MyFileManager.ConcatNewLine(BitConverter.ToString(cryptedBytes));

            MyFileManagerSuccesses = new FileManager(folder, StartAtTime.ToString(@"d_HH_mm") + "_ResultsSuccesses", "csv", line);
            MyFileManagerSuccesses.ConcatNewLine(BitConverter.ToString(cryptedBytes));

            MyFileManagerBad = new FileManager(folder, StartAtTime.ToString(@"d_HH_mm") + "_ResultsBad", "csv", line);
            MyFileManagerBad.ConcatNewLine(BitConverter.ToString(cryptedBytes));
        }

        Task[] tasks = new Task[15];
        public async Task Decrypt()
        {
            var keyQueueTask = Task.Run(() => KeepKeyQueueData());
            while (
                keyQueueTask.Status != TaskStatus.RanToCompletion ||
                PendingKeysCount != 0)
            {
                for (int i = 0; i < tasks.Length; i++)
                {
                    if (PendingKeysCount <= 0)
                    {
                        await Task.Delay(1);
                        break;
                    }
                    if (tasks[i] == null || tasks[i].Status == TaskStatus.RanToCompletion)
                        tasks[i] = Task.Run(() => ProccessNextKeyTask(i));
                }
            }

            keyQueueTask.Wait();
            MyFileManager.WriteBuilderToFile();
            MyFileManagerSuccesses.WriteBuilderToFile();
            MyFileManagerBad.WriteBuilderToFile();
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
                if (PendingKeysCount > 15000)
                {
                    await Task.Delay(250);
                    continue;
                }

                for(int i = 0; i < 10000; i++)
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


        TDesService decryptor = new TDesService();
        public void ProccessKey()
        {
            var keyBytes = GetNextPendingKey();
            DecryptedObject decryptedObject;
            try
            {
                decryptedObject = decryptor.Decrypt(keyBytes, cryptedBytes);
            }
            catch (Exception)
            {
                CountNewError();
                return;
            }
            ProcessAscii(decryptedObject);
            CountNewSuccess();

        }


        string regex = "CLA[VB]E|ALGOR|CRIPTO|PISTA|SIMETRI|SNOW|RABBIT|E0|RC4";
        private void ProcessAscii(DecryptedObject decryptedObject)
        {
            bool foundSomething = false;
            
            string sDecryptOrig = decryptedObject.GetDecodedString(Encoding.UTF8);

            var sDecyptPrintable = new StringBuilder(sDecryptOrig).RemoveAsciiControllChars().RemoveNewLines().RemoveChar(';').GetString();
            if (new StringBuilder(sDecryptOrig).CountChar("[½|¿]") > 100)
            {
                string ln = $";{decryptedObject.GetBytesKeyHex()};;;;;;;;;;;;;{sDecyptPrintable}";
                MyFileManagerBad.ConcatNewLine(ln);
                return;
            }
            string sProcessed = new StringBuilder(sDecryptOrig).RemoveNoneAlphanumericChars().GetString();


            int cDChars = new StringBuilder(sDecryptOrig).CountChars(); //Numero de Caracteres en String Decriptada
            int cPChars = new StringBuilder(sProcessed).CountChars(); //Numero de Caracteres en String Procesada
            int cCharDif = cDChars - cPChars; // Diferencia Numercia de Caracteres entre original y procesada

            

            if (Regex.Match(sDecryptOrig, regex, RegexOptions.IgnoreCase).Success)
                foundSomething = true;


            //var sDecyptPrintable = new StringBuilder(sDecryptOrig).RemoveNewLines()
            //    .RemoveChar(';').RemoveChar('\n').RemoveChar('?').RemoveAsciiControllChars().GetString();

            int cDIsAlpha = new StringBuilder(sDecryptOrig).CountAlphanumericChars(); //Numero de Caracteres Alphanumericos
            int cDNoAlpha = new StringBuilder(sDecryptOrig).CountNoAlphanumericChars(); //Numero de Caracteres No Alphanumericos

            int cDIsHex = new StringBuilder(sDecryptOrig).CountHexadecimalChars(); //Numero de Caracteres Hexadecimales
            int cDNoHex = new StringBuilder(sDecryptOrig).CountNoHexadecimalChars(); //Numero de Caracteres No Hexadecimales


            //int cPIsAlpha = new StringBuilder(sProcessed).CountAlphanumericChars(); //Numero de Caracteres Alphanumericos
            int cPNoAlpha = new StringBuilder(sProcessed).CountNoAlphanumericChars(); //Numero de Caracteres No Alphanumericos

            //int cPIsHex = new StringBuilder(sProcessed).CountHexadecimalChars(); //Numero de Caracteres Hexadecimales
            int cPNoHex = new StringBuilder(sProcessed).CountNoHexadecimalChars(); //Numero de Caracteres No Hexadecimales


            string line = $"{foundSomething}";
            line += $";{decryptedObject.GetBytesKeyHex()}"; //Llave utilizada
            line += $";{cDChars};{cPChars}"; //Numero de Caracteres en la String
            line += $";{cCharDif}"; // Diferencia Numercia de Caracteres entre original y procesada

            //cPIsAlpha
            line += $";{cDIsAlpha};"; //Numero de Caracteres Alphanumericos original y procesada

            line += $";{cDNoAlpha};{cPNoAlpha}"; //Numero de Caracteres No Alphanumericos original y procesada

            //cPIsHex
            line += $";{cDIsHex};"; //Numero de Caracteres Hexadecimales original y procesada

            line += $";{cDNoHex};{cPNoHex}"; //Numero de Caracteres No Hexadecimales original y procesada

            line += $";{sProcessed}"; // String Procesada
            line += $";{sDecyptPrintable}"; // String original sin saltos de linea ni ';'

            if (foundSomething == true)
                MyFileManagerSuccesses.ConcatNewLine(line);

            MyFileManager.ConcatNewLine(line);
        }
    }
}
