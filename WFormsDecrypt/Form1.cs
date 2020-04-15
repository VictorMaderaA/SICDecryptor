using SICLib;
using SICLib.Manager;
using SICLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsDecrypt
{
    public partial class Form1 : Form
    {

        private PartialByte[] partialBytes = new PartialByte[24];
        private string cryptedText = string.Empty;

        long combinations = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void bttn_convertHex_Click(object sender, EventArgs e)
        {
            //Procesar String
            var hexString = textBox_Hex.Text;
            hexString = hexString.Replace(" ", "");
            if(hexString.Length < 48)
            {
                var missing = 48 - hexString.Length;
                hexString += new string('X', missing);
            }
            else
            {
                hexString = hexString.Substring(0, 48);
            }
            textBox_Hex.Text = hexString;


            //Generate Partial Bytes
            for(int ih = 0, ib = 0; ih < 48; ih += 2, ib++)
            {
                var hexVal1 = hexString[ih];
                var hexVal2 = hexString[ih+1];
                partialBytes[ib] = new PartialByte(hexVal1, hexVal2);
            }
            for (int i = 0 ; i < partialBytes.Length-1; i++)
            {
                partialBytes[i].LinkNextByte(partialBytes[i + 1]);
            }



            //Show Bytes in Form
            textBoxRich_Bytes.Clear();
            combinations = 1;
            foreach (var b in partialBytes)
            {
                textBoxRich_Bytes.AppendText(b.HexPartialString + "\n");
                combinations *= b.Combinations;
            }
            lbl_combinations.Text = "Combinaciones posibles: " + combinations.ToString();

        }

        public void print()
        {
            var f = File.Open(@"C:\temp\results.txt", FileMode.OpenOrCreate);
            f.Close();
            using (StreamWriter file = new StreamWriter(@"C:\temp\results.txt"))
            {
                file.Flush();
                while (!partialBytes[partialBytes.Length-1].HasDoneFullIteration)
                {
                    string line = string.Empty;
                    
                    try
                    {
                        foreach (var b in partialBytes)
                        {
                            line += b.HexString + " ";
                        }

                        file.WriteLine(line);
                    }
                    catch (Exception e) { }
                    partialBytes[0].iterate();
                }
            }
        }


        private void bttn_loadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }


        private void bttn_decryptBrute_Click(object sender, EventArgs e)
        {
            bruteDecrypt();
        }

        DateTime startedAt;
        DecryptorPlus decryptor;
        private async void bruteDecrypt()
        {
            bttn_decryptBrute.Enabled = false;
            startedAt = DateTime.Now;
            InitTimer();
            timer1.Start();

            //decryptor = new Decryptor(partialBytes, cryptedText);
            //await Task.Run(() => decryptor.BruteDecryptTripleDes());
            decryptor = new DecryptorPlus(partialBytes, cryptedText);
            await Task.Run(() => decryptor.Decrypt());
            timer1.Stop();
            timer1.Dispose();
            bttn_decryptBrute.Enabled = true;
        }

        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var iterations = decryptor.IterationsDone;
            var seconds = (DateTime.Now - startedAt).TotalSeconds;
            var estimatedSeconds = combinations / (iterations / seconds);
            var remainingSeconds = estimatedSeconds - seconds;


            lbl_iterationsDone.Text = iterations.ToString();
            lbl_secondsPassed.Text = "Transcurrido: " + new TimeSpan(0, 0, (int)seconds).ToString(@"d\.hh\:mm\:ss");
            lbl_estimatedTime.Text = "Restante: " + new TimeSpan(0, 0, (int)remainingSeconds).ToString(@"d\.hh\:mm\:ss");
            lbl_remainingSeconds.Text = "Estimado: " + new TimeSpan(0, 0, (int)estimatedSeconds).ToString(@"d\.hh\:mm\:ss");
            lbl_tasksRunning.Text = $"Tasks: {decryptor.getNumTasksRunning().ToString()}";
            lbl_pendingKeys.Text = $"Keys: {decryptor.PendingKeysCount.ToString()}";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void LoadFile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //Read the contents of the file into a stream
                    var fileCrypted = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileCrypted))
                    {
                        cryptedText = reader.ReadToEnd();
                        textBoxRich_crypted.Text = cryptedText;
                    }
                }
            }


        }
    }
}
