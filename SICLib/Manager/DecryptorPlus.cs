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
        private byte[] cryptedBytes;
        private TripleDESCryptoServiceProvider MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

        private PartialByte[] _partialBytes;
        private static Queue<byte[]> pendingKeys = new Queue<byte[]>();
        private string _filePath = @"C:\temp\results.csv";

        private int _iterationsDone = 0;

        private DateTime startTime = DateTime.Now;

        public int IterationsDone
        {
            get { return _iterationsDone; }
        }

        public int PendingKeysCount
        {
            get 
            {
                lock (lockObject)
                {
                    return pendingKeys.Count;
                }
            }
        }

        public DecryptorPlus(PartialByte[] partialBytes, string cryptedText, string outputFolder = null)
        {
            _partialBytes = partialBytes;
            _filePath = @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_results.csv";

            cryptedBytes = Convert.FromBase64String(cryptedText);
            MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            MyTripleDESCryptoService.Clear();
            MyTripleDESCryptoService.Mode = CipherMode.ECB;
            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;
        }

        Task[] tasks = new Task[15];
        public async Task Decrypt()
        {
            //var f = File.Open(_filePath, FileMode.OpenOrCreate);
            //f.Flush();
            //f.Close();
            //using (StreamWriter file = new StreamWriter(_filePath))
            //{
            //    file.WriteLine($"KEY;ASII CHARS;ALPHANUM CHARS;COMMON CHARS;WORDS;HEX REGEX;SpecRemoved Chars;PROCESSED;");
            //    file.Flush();
            //}
            string line;

            line = $";Key Used;Str Processed;Str Alpha;Strn Hex;Str Hex Key;Count Alpha;Count Hex;Count Common;Count WordsProccessed;Count WordsOriginal;Count HexKeys";
            FileManager.WriteLineFile(BitConverter.ToString(cryptedBytes), @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");
            FileManager.WriteLineFile("Ascii", @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");
            FileManager.WriteLineFile(line, @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");

            FileManager.WriteLineFile(BitConverter.ToString(cryptedBytes), @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultDefault.csv");
            FileManager.WriteLineFile("Default", @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultDefault.csv");
            FileManager.WriteLineFile(line, @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultDefault.csv");

            FileManager.WriteLineFile(BitConverter.ToString(cryptedBytes), @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultUtf8.csv");
            FileManager.WriteLineFile("UTF8", @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultUtf8.csv");
            FileManager.WriteLineFile(line, @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultUtf8.csv");

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
            //pendingKeys.Enqueue(); Agrega a la fila
            //pendingKeys.Dequeue(); Saca el primero de la fila
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

        static readonly object lockObject = new object();
        private static byte[] GetNextPendingKey()
        {
            byte[] key;
            lock (lockObject)
            {
                key = pendingKeys.Dequeue();
            }
            return key;
        }
        private static void AddNextPendingKey(byte[] key)
        {
            lock (lockObject)
            {
                pendingKeys.Enqueue(key);
            }
        }

        public SICLib.Models.DecryptedObject TripleDesDecrypt(byte[] key)
        {
            if (key.Length != 24) return null;
            MyTripleDESCryptoService.Key = key;
            var MyCrytpoTransform = MyTripleDESCryptoService.CreateDecryptor();
            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cryptedBytes, 0, cryptedBytes.Length);
            DecryptedObject obj = new DecryptedObject(MyresultArray, key);
            return obj;
        }

        public void ProccessKey()
        {
            var keyBytes = GetNextPendingKey();
            //string decryptedString;
            //string processedString = string.Empty;
            //int asiicChars = 0;
            //int hexChars = 0;
            //int words = 0;
            //int alphaNumeric = 0;
            //int commonLetters = 0;
            //int hexRegex = 0;
            //int specialRemoved = 0;
            bool exception = false;

            DecryptedObject decryptedObject;
            try
            {
                decryptedObject = TripleDesDecrypt(keyBytes);
            }
            catch (Exception)
            {
                //CountNewIteration();
                return;
            }
            if(!exception)
            {
                ProcessAscii(decryptedObject);
                ProcessDefault(decryptedObject);
                ProcessUtf8(decryptedObject);

                //var dDefaultRString= decryptedObject.GetDecodedString(Encoding.Default);
                //var dUtf8RString= decryptedObject.GetDecodedString(Encoding.UTF8);

                //processedString = decryptedString.Replace(Environment.NewLine, "<new-line>"); //removes new lines in string

                ////Count Words in processed string
                //var origLenght = processedString.Length;
                ////processedString = Regex.Replace(processedString, "[\x80-\xFE]|[\x00-\x1F]|[\x21-\x46]|[\x3A-\x40]|[\x5B-\x60]|[\x7B-\x7F]", string.Empty); //Removes Ascii Extendido y Caracteres de control y extras
                //specialRemoved = origLenght - Regex.Replace(processedString, "[\x80-\xFE]|[\x00-\x1F]|[\x21-\x46]|[\x3A-\x40]|[\x5B-\x60]|[\x7B-\x7F]", string.Empty).Length;

                //processedString = Regex.Replace(processedString, "(;)", string.Empty); //Removes Ascii Extendido y Caracteres de control y extras

                //foreach (var c in processedString)
                //{
                //    if (Regex.IsMatch(c.ToString(), "[\x20-\x7E]"))
                //    {
                //        asiicChars++;
                //    }
                //    if (Regex.IsMatch(c.ToString(), "[\x30-\x39]|[\x41-\x46]|[\x61-\x66]"))
                //    {
                //        hexChars++;
                //    }
                //    if (Regex.IsMatch(c.ToString(), "[\x30-\x39]|[\x41-\x5A]|[\x61-\x7A]"))
                //    {
                //        alphaNumeric++;
                //    }
                //    if (Regex.IsMatch(c.ToString(), "(E|A|O|S|R|T)+", RegexOptions.IgnoreCase))
                //    {
                //        commonLetters++;
                //    }
                //}

                ////has hex values
                //hexRegex += Regex.Matches(processedString, @"(?<=Rx\s)([0-f0-9]+)\s([0-f0-9]+\s)+", RegexOptions.IgnoreCase).Count;

                ////counts number of words
                //words = Regex.Matches(processedString, @"([^\W_]+[^\s,]*)").Count;  
            }

            //string line = $"{BitConverter.ToString(keyBytes)};{asiicChars.ToString()};{alphaNumeric.ToString()};{commonLetters.ToString()};{words.ToString()};{hexRegex.ToString()};{specialRemoved.ToString()};{processedString};";
            //FileManager.WriteLineFile(line, _filePath);
            //CountNewIteration();
        }

        private void ProcessAscii(DecryptedObject decryptedObject)
        {
            var sDecryptOrig = decryptedObject.GetDecodedString(Encoding.ASCII);
            var sProcessed = new StringBuilder(sDecryptOrig).RemoveAsciiControllChars().
                RemoveAsciiExtendedChars().RemoveAsciiExtraSimbolsChars().RemoveNewLines().GetString();
            var sKeyUsed = decryptedObject.GetBytesKeyHex();
            var sAlphan = new StringBuilder(sDecryptOrig).RemoveNoneAlphanumericChars().GetString();
            var sHexKey = new StringBuilder(sDecryptOrig).RemoveNoneHexKey().GetString();
            var sHex = new StringBuilder(sDecryptOrig).RemoveNoneHexChars().GetString();

            var cAlpanChars = new StringBuilder(sProcessed).CountAlphanumericChars();
            var cHexChars = new StringBuilder(sProcessed).CountHexadecimalChars();
            var cCommonChars = new StringBuilder(sProcessed).CountCommonChars();
            var cWordsOrig = new StringBuilder(sDecryptOrig).CountWords();
            var cWordsProcessed = new StringBuilder(sProcessed).CountWords();

            var bHexKey = new StringBuilder(sDecryptOrig).CountHexBytes();

            var filePath = @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultAscii.csv";

            string line = $";{sKeyUsed};{sProcessed};{sAlphan};{sHex};{sHexKey};{cAlpanChars};{cHexChars};{cCommonChars};{cWordsProcessed};{cWordsOrig};{bHexKey}";
            FileManager.WriteLineFile(line, @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultAscii.csv");
        }

        private void ProcessDefault(DecryptedObject decryptedObject)
        {
            var sDecryptOrig = decryptedObject.GetDecodedString(Encoding.Default);
            var sProcessed = new StringBuilder(sDecryptOrig).RemoveAsciiControllChars().
                RemoveAsciiExtendedChars().RemoveAsciiExtraSimbolsChars().RemoveNewLines().GetString();
            var sKeyUsed = decryptedObject.GetBytesKeyHex();
            var sAlphan = new StringBuilder(sDecryptOrig).RemoveNoneAlphanumericChars().GetString();
            var sHexKey = new StringBuilder(sDecryptOrig).RemoveNoneHexKey().GetString();
            var sHex = new StringBuilder(sDecryptOrig).RemoveNoneHexChars().GetString();

            var cAlpanChars = new StringBuilder(sProcessed).CountAlphanumericChars();
            var cHexChars = new StringBuilder(sProcessed).CountHexadecimalChars();
            var cCommonChars = new StringBuilder(sProcessed).CountCommonChars();
            var cWordsOrig = new StringBuilder(sDecryptOrig).CountWords();
            var cWordsProcessed = new StringBuilder(sProcessed).CountWords();

            var bHexKey = new StringBuilder(sDecryptOrig).CountHexBytes();

            var filePath = @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultDefault.csv";

            string line = $";{sKeyUsed};{sProcessed};{sAlphan};{sHex};{sHexKey};{cAlpanChars};{cHexChars};{cCommonChars};{cWordsProcessed};{cWordsOrig};{bHexKey}";
            FileManager.WriteLineFile(line, @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultDefault.csv");
        }

        private void ProcessUtf8(DecryptedObject decryptedObject)
        {
            var sDecryptOrig = decryptedObject.GetDecodedString(Encoding.UTF8);
            var sProcessed = new StringBuilder(sDecryptOrig).RemoveAsciiControllChars().
                RemoveAsciiExtendedChars().RemoveAsciiExtraSimbolsChars().RemoveNewLines().GetString();
            var sKeyUsed = decryptedObject.GetBytesKeyHex();
            var sAlphan = new StringBuilder(sDecryptOrig).RemoveNoneAlphanumericChars().GetString();
            var sHexKey = new StringBuilder(sDecryptOrig).RemoveNoneHexKey().GetString();
            var sHex = new StringBuilder(sDecryptOrig).RemoveNoneHexChars().GetString();

            var cAlpanChars = new StringBuilder(sProcessed).CountAlphanumericChars();
            var cHexChars = new StringBuilder(sProcessed).CountHexadecimalChars();
            var cCommonChars = new StringBuilder(sProcessed).CountCommonChars();
            var cWordsOrig = new StringBuilder(sDecryptOrig).CountWords();
            var cWordsProcessed = new StringBuilder(sProcessed).CountWords();

            var bHexKey = new StringBuilder(sDecryptOrig).CountHexBytes();

            var filePath = @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultUtf8.csv";

            string line = $";{sKeyUsed};{sProcessed};{sAlphan};{sHex};{sHexKey};{cAlpanChars};{cHexChars};{cCommonChars};{cWordsProcessed};{cWordsOrig};{bHexKey}";
            FileManager.WriteLineFile(line, @"C:\temp\" + startTime.ToString(@"d_HH_mm") + @"_resultUtf8.csv");
        }

        static readonly object lockIterations = new object();
        private void CountNewIteration()
        {
            lock(lockIterations)
            {
                _iterationsDone++;
            }
        }
    }
}
