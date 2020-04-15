namespace WFormsDecrypt
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Hex = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.textBoxRich_Bytes = new System.Windows.Forms.RichTextBox();
            this.textBoxRich_crypted = new System.Windows.Forms.RichTextBox();
            this.textBoxRich_decrypted = new System.Windows.Forms.RichTextBox();
            this.bttn_convertHex = new System.Windows.Forms.Button();
            this.bttn_loadFile = new System.Windows.Forms.Button();
            this.bttn_decryptBrute = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_combinations = new System.Windows.Forms.Label();
            this.lbl_iterationsDone = new System.Windows.Forms.Label();
            this.lbl_secondsPassed = new System.Windows.Forms.Label();
            this.lbl_remainingSeconds = new System.Windows.Forms.Label();
            this.lbl_estimatedTime = new System.Windows.Forms.Label();
            this.lbl_tasksRunning = new System.Windows.Forms.Label();
            this.lbl_pendingKeys = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Hex
            // 
            this.textBox_Hex.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Hex.Location = new System.Drawing.Point(213, 68);
            this.textBox_Hex.Name = "textBox_Hex";
            this.textBox_Hex.Size = new System.Drawing.Size(716, 31);
            this.textBox_Hex.TabIndex = 0;
            this.textBox_Hex.Text = "9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23";
            // 
            // textBoxRich_Bytes
            // 
            this.textBoxRich_Bytes.Font = new System.Drawing.Font("Microsoft Uighur", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRich_Bytes.Location = new System.Drawing.Point(44, 132);
            this.textBoxRich_Bytes.Name = "textBoxRich_Bytes";
            this.textBoxRich_Bytes.Size = new System.Drawing.Size(163, 570);
            this.textBoxRich_Bytes.TabIndex = 1;
            this.textBoxRich_Bytes.Text = "";
            // 
            // textBoxRich_crypted
            // 
            this.textBoxRich_crypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRich_crypted.Location = new System.Drawing.Point(213, 132);
            this.textBoxRich_crypted.Name = "textBoxRich_crypted";
            this.textBoxRich_crypted.Size = new System.Drawing.Size(716, 217);
            this.textBoxRich_crypted.TabIndex = 2;
            this.textBoxRich_crypted.Text = "";
            // 
            // textBoxRich_decrypted
            // 
            this.textBoxRich_decrypted.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRich_decrypted.Location = new System.Drawing.Point(213, 355);
            this.textBoxRich_decrypted.Name = "textBoxRich_decrypted";
            this.textBoxRich_decrypted.Size = new System.Drawing.Size(716, 254);
            this.textBoxRich_decrypted.TabIndex = 3;
            this.textBoxRich_decrypted.Text = "";
            // 
            // bttn_convertHex
            // 
            this.bttn_convertHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_convertHex.Location = new System.Drawing.Point(44, 44);
            this.bttn_convertHex.Name = "bttn_convertHex";
            this.bttn_convertHex.Size = new System.Drawing.Size(163, 82);
            this.bttn_convertHex.TabIndex = 4;
            this.bttn_convertHex.Text = "Convert to Bytes";
            this.bttn_convertHex.UseVisualStyleBackColor = true;
            this.bttn_convertHex.Click += new System.EventHandler(this.bttn_convertHex_Click);
            // 
            // bttn_loadFile
            // 
            this.bttn_loadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_loadFile.Location = new System.Drawing.Point(213, 686);
            this.bttn_loadFile.Name = "bttn_loadFile";
            this.bttn_loadFile.Size = new System.Drawing.Size(163, 52);
            this.bttn_loadFile.TabIndex = 5;
            this.bttn_loadFile.Text = "Load File";
            this.bttn_loadFile.UseVisualStyleBackColor = true;
            this.bttn_loadFile.Click += new System.EventHandler(this.bttn_loadFile_Click);
            // 
            // bttn_decryptBrute
            // 
            this.bttn_decryptBrute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_decryptBrute.Location = new System.Drawing.Point(382, 686);
            this.bttn_decryptBrute.Name = "bttn_decryptBrute";
            this.bttn_decryptBrute.Size = new System.Drawing.Size(163, 52);
            this.bttn_decryptBrute.TabIndex = 6;
            this.bttn_decryptBrute.Text = "Brute Decrypt";
            this.bttn_decryptBrute.UseVisualStyleBackColor = true;
            this.bttn_decryptBrute.Click += new System.EventHandler(this.bttn_decryptBrute_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(551, 686);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 52);
            this.button1.TabIndex = 7;
            this.button1.Text = "Decrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_combinations
            // 
            this.lbl_combinations.AutoSize = true;
            this.lbl_combinations.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_combinations.Location = new System.Drawing.Point(213, 104);
            this.lbl_combinations.Name = "lbl_combinations";
            this.lbl_combinations.Size = new System.Drawing.Size(272, 25);
            this.lbl_combinations.TabIndex = 8;
            this.lbl_combinations.Text = "Combinaciones posibles: --";
            // 
            // lbl_iterationsDone
            // 
            this.lbl_iterationsDone.AutoSize = true;
            this.lbl_iterationsDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iterationsDone.Location = new System.Drawing.Point(213, 612);
            this.lbl_iterationsDone.Name = "lbl_iterationsDone";
            this.lbl_iterationsDone.Size = new System.Drawing.Size(222, 25);
            this.lbl_iterationsDone.TabIndex = 9;
            this.lbl_iterationsDone.Text = "iteraciones realizadas";
            // 
            // lbl_secondsPassed
            // 
            this.lbl_secondsPassed.AutoSize = true;
            this.lbl_secondsPassed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_secondsPassed.Location = new System.Drawing.Point(462, 612);
            this.lbl_secondsPassed.Name = "lbl_secondsPassed";
            this.lbl_secondsPassed.Size = new System.Drawing.Size(237, 25);
            this.lbl_secondsPassed.TabIndex = 10;
            this.lbl_secondsPassed.Text = "segundos transcurridos";
            // 
            // lbl_remainingSeconds
            // 
            this.lbl_remainingSeconds.AutoSize = true;
            this.lbl_remainingSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_remainingSeconds.Location = new System.Drawing.Point(720, 612);
            this.lbl_remainingSeconds.Name = "lbl_remainingSeconds";
            this.lbl_remainingSeconds.Size = new System.Drawing.Size(209, 25);
            this.lbl_remainingSeconds.TabIndex = 11;
            this.lbl_remainingSeconds.Text = "segundos Restantes";
            // 
            // lbl_estimatedTime
            // 
            this.lbl_estimatedTime.AutoSize = true;
            this.lbl_estimatedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estimatedTime.Location = new System.Drawing.Point(462, 637);
            this.lbl_estimatedTime.Name = "lbl_estimatedTime";
            this.lbl_estimatedTime.Size = new System.Drawing.Size(212, 25);
            this.lbl_estimatedTime.TabIndex = 12;
            this.lbl_estimatedTime.Text = "segundos Estimados";
            // 
            // lbl_tasksRunning
            // 
            this.lbl_tasksRunning.AutoSize = true;
            this.lbl_tasksRunning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tasksRunning.Location = new System.Drawing.Point(12, 705);
            this.lbl_tasksRunning.Name = "lbl_tasksRunning";
            this.lbl_tasksRunning.Size = new System.Drawing.Size(82, 16);
            this.lbl_tasksRunning.TabIndex = 13;
            this.lbl_tasksRunning.Text = "taskRunning";
            // 
            // lbl_pendingKeys
            // 
            this.lbl_pendingKeys.AutoSize = true;
            this.lbl_pendingKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pendingKeys.Location = new System.Drawing.Point(12, 725);
            this.lbl_pendingKeys.Name = "lbl_pendingKeys";
            this.lbl_pendingKeys.Size = new System.Drawing.Size(69, 16);
            this.lbl_pendingKeys.TabIndex = 14;
            this.lbl_pendingKeys.Text = "pendKeys";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 750);
            this.Controls.Add(this.lbl_pendingKeys);
            this.Controls.Add(this.lbl_tasksRunning);
            this.Controls.Add(this.lbl_estimatedTime);
            this.Controls.Add(this.lbl_remainingSeconds);
            this.Controls.Add(this.lbl_secondsPassed);
            this.Controls.Add(this.lbl_iterationsDone);
            this.Controls.Add(this.lbl_combinations);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bttn_decryptBrute);
            this.Controls.Add(this.bttn_loadFile);
            this.Controls.Add(this.bttn_convertHex);
            this.Controls.Add(this.textBoxRich_decrypted);
            this.Controls.Add(this.textBoxRich_crypted);
            this.Controls.Add(this.textBoxRich_Bytes);
            this.Controls.Add(this.textBox_Hex);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Hex;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.RichTextBox textBoxRich_Bytes;
        private System.Windows.Forms.RichTextBox textBoxRich_crypted;
        private System.Windows.Forms.RichTextBox textBoxRich_decrypted;
        private System.Windows.Forms.Button bttn_convertHex;
        private System.Windows.Forms.Button bttn_loadFile;
        private System.Windows.Forms.Button bttn_decryptBrute;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_combinations;
        private System.Windows.Forms.Label lbl_iterationsDone;
        private System.Windows.Forms.Label lbl_secondsPassed;
        private System.Windows.Forms.Label lbl_remainingSeconds;
        private System.Windows.Forms.Label lbl_estimatedTime;
        private System.Windows.Forms.Label lbl_tasksRunning;
        private System.Windows.Forms.Label lbl_pendingKeys;
    }
}

