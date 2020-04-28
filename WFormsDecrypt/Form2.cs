using SICLib.Decryptor;
using SICLib.Manager;
using SICLib.Models;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsDecrypt
{
    public partial class form_decryptor1 : Form
    {

        DecryptorPlus decryptor = null;
        private Timer ProcessTimer;
        private long PosibleKeys = 0;

        private PartialByte[] PartialBytesArray;



        public form_decryptor1()
        {
            InitializeComponent();
        }

        private async void text_key_TextChangedAsync(object sender, EventArgs e)
        {
            OnKeyTextChanged();
        }

        private void OnKeyTextChanged()
        {
            btn_DecryptWForce.Enabled = false;
            btn_DecryptWKey.Enabled = false;
            PartialBytesArray = null;
            text_hexKey.Clear();
            if (string.IsNullOrWhiteSpace(text_key.Text))
                return;
            var formatedKey = FormDataManager.FormatKeyInput(text_key.Text, 48);
            PartialBytesArray = FormDataManager.GetPartialBytesKeyString(formatedKey);
            if (PartialBytesArray == null || PartialBytesArray.Length <= 0)
                return;

            foreach (var item in PartialBytesArray)
                item.SkipLSB = checkBox_SkipLsb.Checked;

            text_hexKey.Text = formatedKey;
            if (string.IsNullOrEmpty(text_hexKey.Text))
                return;
            ShowHexKeyaFromPartialBytes(PartialBytesArray);

            if (!direcotorioSeleccionado)
                return;
            btn_DecryptWForce.Enabled = true;
            btn_DecryptWKey.Enabled = true;
        }

        private void btn_loadKey_Click(object sender, EventArgs e)
        {
            var correct = LoadFile(out string path, out string contents);
            if (!correct)
                return;
            text_key.Text = contents;
        }

        private void bnt_loadMessage_Click(object sender, EventArgs e)
        {
            var correct = LoadFile(out string path, out string contents);
            if (!correct)
                return;
            text_mensajeCifrado.Text = contents;
        }

        private void btn_DecryptWKey_Click(object sender, EventArgs e)
        {
            string text;
            try
            {
                var keyBytes = PartialByte.GetBytesFromPartialBytes(PartialBytesArray);
                var textoCifrado = Convert.FromBase64String(text_mensajeCifrado.Text);
                var decryptedObj = new TDesService().Decrypt(keyBytes, textoCifrado);
                text = decryptedObj.GetDecodedString(UTF8Encoding.UTF8);
            }
            catch (Exception ex)
            {
                text = $"{DateTime.Now.TimeOfDay}Error {ex.Message}";
            }
            text_mensaje.Text = text;
        }

        private void btn_DecryptWForce_Click(object sender, EventArgs e)
        {
            if (PartialBytesArray == null || PartialBytesArray.Length <= 0)
                return;
            if (string.IsNullOrWhiteSpace(text_mensajeCifrado.Text) || string.IsNullOrEmpty(text_mensajeCifrado.Text))
                return;
            OnKeyTextChanged();

            BruteDecrypt();

        }

        private async void BruteDecrypt()
        {
            decryptor = new DecryptorPlus(PartialBytesArray, text_mensajeCifrado.Text, lbl_directorio.Text);
            BruteDecryptorStarted();
            await Task.Run(() => decryptor.Decrypt());
            BruteFinished();

        }



        private void BruteDecryptorStarted()
        {
            btn_DecryptWForce.Enabled = false;
            btn_DecryptWKey.Enabled = false;
            checkBox_SkipLsb.Enabled = false;
            InitProcessTimer();
            ProcessTimer.Start();
        }

        private void BruteFinished()
        {
            ProcessTimer.Stop();
            ProcessTick(this, null);
            lbl_Keys.Text = "0";
            lbl_tasks.Text = "0";
            if(decryptor != null)
                lbl_tiempoTranscurrido.Text = new TimeSpan(0, 0, (int)(DateTime.Now - decryptor.StartAtTime).TotalSeconds).ToString(@"d\.hh\:mm\:ss");
            decryptor = null;
            progressBar.Value = 100;

            btn_DecryptWForce.Enabled = true;
            btn_DecryptWKey.Enabled = true;
            checkBox_SkipLsb.Enabled = true;
        }


        private void InitProcessTimer()
        {
            ProcessTimer = new Timer();
            ProcessTimer.Tick += new EventHandler(ProcessTick);
            ProcessTimer.Interval = 1000; // in miliseconds
        }

        private void ProcessTick(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                return;

            var iterations = decryptor.IterationsDone;
            var seconds = (DateTime.Now - decryptor.StartAtTime).TotalSeconds;
            var keyPerSecond = iterations / seconds;
            var estimatedSeconds = PosibleKeys / keyPerSecond;
            var remainingSeconds = estimatedSeconds - seconds;
            var pendingKeys = PosibleKeys - iterations;


            lbl_Keys.Text = decryptor.Keys.ToString();
            lbl_tasks.Text = decryptor.Tasks.ToString();
            lbl_errors.Text = decryptor.Errors.ToString();
            lbl_successes.Text = decryptor.Successes.ToString();

            lbl_tiempoEstimado.Text = new TimeSpan(0, 0, (int)estimatedSeconds).ToString(@"d\.hh\:mm\:ss");
            lbl_tiempoTranscurrido.Text = new TimeSpan(0, 0, (int)seconds).ToString(@"d\.hh\:mm\:ss");
            lbl_tiempoRestante.Text = new TimeSpan(0, 0, (int)remainingSeconds).ToString(@"d\.hh\:mm\:ss");

            lbl_clavesSegundo.Text = keyPerSecond.ToString();
            lbl_clavesPendientes.Text = pendingKeys.ToString();
            lbl_clavesProbadas.Text = iterations.ToString();

            progressBar.Value = (int)((iterations * 100) / PosibleKeys);
        }




        private void ShowHexKeyaFromPartialBytes(PartialByte[] bytes)
        {
            text_hexKey.Clear();
            long combinations = 1;
            foreach (var b in bytes)
            {
                text_hexKey.AppendText(b.HexPartialString + "-");
                combinations *= b.Combinations;
            }
            PosibleKeys = (checkBox_SkipLsb.Checked)? combinations / 8 : combinations;
            lbl_clavesPosibles.Text = PosibleKeys.ToString();
        }

        private bool LoadFile(out string path, out string contents)
        {
            path = string.Empty;
            contents = string.Empty;
            var flag = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.CurrentDirectory+ @"\Resources";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    var fileCrypted = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileCrypted))
                    {
                        contents = reader.ReadToEnd();
                    }
                    flag = true;
                }
            }
            return flag;
        }

        private void checkBox_SkipLsb_CheckedChanged(object sender, EventArgs e)
        {
            if (PartialBytesArray == null) return;
            foreach (var item in PartialBytesArray)
                item.SkipLSB = checkBox_SkipLsb.Checked;
            ShowHexKeyaFromPartialBytes(PartialBytesArray);
        }

        private bool direcotorioSeleccionado = false;
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                lbl_directorio.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                direcotorioSeleccionado = true;
                OnKeyTextChanged();
            }
        }
    }
}
