namespace WFormsDecrypt
{
    partial class form_decryptor1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_key = new System.Windows.Forms.TextBox();
            this.text_hexKey = new System.Windows.Forms.TextBox();
            this.text_mensajeCifrado = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bnt_loadMessage = new System.Windows.Forms.Button();
            this.text_mensaje = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_loadKey = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_DecryptWKey = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_DecryptWForce = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbl_clavesPosibles = new System.Windows.Forms.Label();
            this.lbl_clavesProbadas = new System.Windows.Forms.Label();
            this.lbl_clavesPendientes = new System.Windows.Forms.Label();
            this.lbl_clavesSegundo = new System.Windows.Forms.Label();
            this.lbl_tiempoTranscurrido = new System.Windows.Forms.Label();
            this.lbl_tiempoRestante = new System.Windows.Forms.Label();
            this.lbl_tiempoEstimado = new System.Windows.Forms.Label();
            this.lbl_Keys = new System.Windows.Forms.Label();
            this.lbl_tasks = new System.Windows.Forms.Label();
            this.lbl_errors = new System.Windows.Forms.Label();
            this.lbl_successes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hex Key";
            // 
            // text_key
            // 
            this.text_key.Location = new System.Drawing.Point(12, 38);
            this.text_key.Name = "text_key";
            this.text_key.Size = new System.Drawing.Size(588, 20);
            this.text_key.TabIndex = 2;
            this.text_key.TextChanged += new System.EventHandler(this.text_key_TextChangedAsync);
            // 
            // text_hexKey
            // 
            this.text_hexKey.Enabled = false;
            this.text_hexKey.HideSelection = false;
            this.text_hexKey.Location = new System.Drawing.Point(606, 38);
            this.text_hexKey.Name = "text_hexKey";
            this.text_hexKey.Size = new System.Drawing.Size(566, 20);
            this.text_hexKey.TabIndex = 3;
            // 
            // text_mensajeCifrado
            // 
            this.text_mensajeCifrado.Location = new System.Drawing.Point(12, 93);
            this.text_mensajeCifrado.Name = "text_mensajeCifrado";
            this.text_mensajeCifrado.Size = new System.Drawing.Size(1160, 124);
            this.text_mensajeCifrado.TabIndex = 4;
            this.text_mensajeCifrado.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mensaje Encriptado";
            // 
            // bnt_loadMessage
            // 
            this.bnt_loadMessage.Location = new System.Drawing.Point(119, 64);
            this.bnt_loadMessage.Name = "bnt_loadMessage";
            this.bnt_loadMessage.Size = new System.Drawing.Size(157, 23);
            this.bnt_loadMessage.TabIndex = 6;
            this.bnt_loadMessage.Text = "Cargar Mensaje";
            this.bnt_loadMessage.UseVisualStyleBackColor = true;
            this.bnt_loadMessage.Click += new System.EventHandler(this.bnt_loadMessage_Click);
            // 
            // text_mensaje
            // 
            this.text_mensaje.Location = new System.Drawing.Point(15, 241);
            this.text_mensaje.Name = "text_mensaje";
            this.text_mensaje.Size = new System.Drawing.Size(1157, 124);
            this.text_mensaje.TabIndex = 7;
            this.text_mensaje.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mensaje Desencriptado";
            // 
            // btn_loadKey
            // 
            this.btn_loadKey.Location = new System.Drawing.Point(43, 12);
            this.btn_loadKey.Name = "btn_loadKey";
            this.btn_loadKey.Size = new System.Drawing.Size(157, 23);
            this.btn_loadKey.TabIndex = 9;
            this.btn_loadKey.Text = "Cargar Clave";
            this.btn_loadKey.UseVisualStyleBackColor = true;
            this.btn_loadKey.Click += new System.EventHandler(this.btn_loadKey_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(1078, 462);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "RealTimeData";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_DecryptWKey
            // 
            this.btn_DecryptWKey.Enabled = false;
            this.btn_DecryptWKey.Location = new System.Drawing.Point(15, 384);
            this.btn_DecryptWKey.Name = "btn_DecryptWKey";
            this.btn_DecryptWKey.Size = new System.Drawing.Size(185, 23);
            this.btn_DecryptWKey.TabIndex = 11;
            this.btn_DecryptWKey.Text = "Con clave";
            this.btn_DecryptWKey.UseVisualStyleBackColor = true;
            this.btn_DecryptWKey.Click += new System.EventHandler(this.btn_DecryptWKey_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descifrar";
            // 
            // btn_DecryptWForce
            // 
            this.btn_DecryptWForce.Enabled = false;
            this.btn_DecryptWForce.Location = new System.Drawing.Point(15, 413);
            this.btn_DecryptWForce.Name = "btn_DecryptWForce";
            this.btn_DecryptWForce.Size = new System.Drawing.Size(185, 23);
            this.btn_DecryptWForce.TabIndex = 13;
            this.btn_DecryptWForce.Text = "Con Fuerza Bruta";
            this.btn_DecryptWForce.UseVisualStyleBackColor = true;
            this.btn_DecryptWForce.Click += new System.EventHandler(this.btn_DecryptWForce_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 462);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1060, 23);
            this.progressBar.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_successes);
            this.panel1.Controls.Add(this.lbl_errors);
            this.panel1.Controls.Add(this.lbl_tasks);
            this.panel1.Controls.Add(this.lbl_Keys);
            this.panel1.Controls.Add(this.lbl_tiempoEstimado);
            this.panel1.Controls.Add(this.lbl_tiempoRestante);
            this.panel1.Controls.Add(this.lbl_tiempoTranscurrido);
            this.panel1.Controls.Add(this.lbl_clavesSegundo);
            this.panel1.Controls.Add(this.lbl_clavesPendientes);
            this.panel1.Controls.Add(this.lbl_clavesProbadas);
            this.panel1.Controls.Add(this.lbl_clavesPosibles);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(450, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 85);
            this.panel1.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Posibles Claves:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(514, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Successes:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(539, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Errors:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(537, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Tasks:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(543, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Keys:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Tiempo Restante:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(254, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Tiempo Transcurrido:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tiempo Estimado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Claves Probadas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Claves/s:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Claves Pendientes:";
            // 
            // lbl_clavesPosibles
            // 
            this.lbl_clavesPosibles.AutoSize = true;
            this.lbl_clavesPosibles.Location = new System.Drawing.Point(107, 5);
            this.lbl_clavesPosibles.Name = "lbl_clavesPosibles";
            this.lbl_clavesPosibles.Size = new System.Drawing.Size(13, 13);
            this.lbl_clavesPosibles.TabIndex = 11;
            this.lbl_clavesPosibles.Text = "0";
            // 
            // lbl_clavesProbadas
            // 
            this.lbl_clavesProbadas.AutoSize = true;
            this.lbl_clavesProbadas.Location = new System.Drawing.Point(107, 23);
            this.lbl_clavesProbadas.Name = "lbl_clavesProbadas";
            this.lbl_clavesProbadas.Size = new System.Drawing.Size(13, 13);
            this.lbl_clavesProbadas.TabIndex = 12;
            this.lbl_clavesProbadas.Text = "0";
            // 
            // lbl_clavesPendientes
            // 
            this.lbl_clavesPendientes.AutoSize = true;
            this.lbl_clavesPendientes.Location = new System.Drawing.Point(107, 41);
            this.lbl_clavesPendientes.Name = "lbl_clavesPendientes";
            this.lbl_clavesPendientes.Size = new System.Drawing.Size(13, 13);
            this.lbl_clavesPendientes.TabIndex = 13;
            this.lbl_clavesPendientes.Text = "0";
            // 
            // lbl_clavesSegundo
            // 
            this.lbl_clavesSegundo.AutoSize = true;
            this.lbl_clavesSegundo.Location = new System.Drawing.Point(107, 59);
            this.lbl_clavesSegundo.Name = "lbl_clavesSegundo";
            this.lbl_clavesSegundo.Size = new System.Drawing.Size(13, 13);
            this.lbl_clavesSegundo.TabIndex = 14;
            this.lbl_clavesSegundo.Text = "0";
            // 
            // lbl_tiempoTranscurrido
            // 
            this.lbl_tiempoTranscurrido.AutoSize = true;
            this.lbl_tiempoTranscurrido.Location = new System.Drawing.Point(367, 41);
            this.lbl_tiempoTranscurrido.Name = "lbl_tiempoTranscurrido";
            this.lbl_tiempoTranscurrido.Size = new System.Drawing.Size(13, 13);
            this.lbl_tiempoTranscurrido.TabIndex = 15;
            this.lbl_tiempoTranscurrido.Text = "0";
            // 
            // lbl_tiempoRestante
            // 
            this.lbl_tiempoRestante.AutoSize = true;
            this.lbl_tiempoRestante.Location = new System.Drawing.Point(367, 23);
            this.lbl_tiempoRestante.Name = "lbl_tiempoRestante";
            this.lbl_tiempoRestante.Size = new System.Drawing.Size(13, 13);
            this.lbl_tiempoRestante.TabIndex = 16;
            this.lbl_tiempoRestante.Text = "0";
            // 
            // lbl_tiempoEstimado
            // 
            this.lbl_tiempoEstimado.AutoSize = true;
            this.lbl_tiempoEstimado.Location = new System.Drawing.Point(367, 5);
            this.lbl_tiempoEstimado.Name = "lbl_tiempoEstimado";
            this.lbl_tiempoEstimado.Size = new System.Drawing.Size(13, 13);
            this.lbl_tiempoEstimado.TabIndex = 17;
            this.lbl_tiempoEstimado.Text = "0";
            // 
            // lbl_Keys
            // 
            this.lbl_Keys.AutoSize = true;
            this.lbl_Keys.Location = new System.Drawing.Point(582, 5);
            this.lbl_Keys.Name = "lbl_Keys";
            this.lbl_Keys.Size = new System.Drawing.Size(13, 13);
            this.lbl_Keys.TabIndex = 18;
            this.lbl_Keys.Text = "0";
            // 
            // lbl_tasks
            // 
            this.lbl_tasks.AutoSize = true;
            this.lbl_tasks.Location = new System.Drawing.Point(582, 23);
            this.lbl_tasks.Name = "lbl_tasks";
            this.lbl_tasks.Size = new System.Drawing.Size(13, 13);
            this.lbl_tasks.TabIndex = 19;
            this.lbl_tasks.Text = "0";
            // 
            // lbl_errors
            // 
            this.lbl_errors.AutoSize = true;
            this.lbl_errors.Location = new System.Drawing.Point(582, 41);
            this.lbl_errors.Name = "lbl_errors";
            this.lbl_errors.Size = new System.Drawing.Size(13, 13);
            this.lbl_errors.TabIndex = 20;
            this.lbl_errors.Text = "0";
            // 
            // lbl_successes
            // 
            this.lbl_successes.AutoSize = true;
            this.lbl_successes.Location = new System.Drawing.Point(582, 59);
            this.lbl_successes.Name = "lbl_successes";
            this.lbl_successes.Size = new System.Drawing.Size(13, 13);
            this.lbl_successes.TabIndex = 21;
            this.lbl_successes.Text = "0";
            // 
            // form_decryptor1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 495);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_DecryptWForce);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_DecryptWKey);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_loadKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_mensaje);
            this.Controls.Add(this.bnt_loadMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_mensajeCifrado);
            this.Controls.Add(this.text_hexKey);
            this.Controls.Add(this.text_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "form_decryptor1";
            this.Text = "Decryptor1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_key;
        private System.Windows.Forms.TextBox text_hexKey;
        private System.Windows.Forms.RichTextBox text_mensajeCifrado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnt_loadMessage;
        private System.Windows.Forms.RichTextBox text_mensaje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_loadKey;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_DecryptWKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_DecryptWForce;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_successes;
        private System.Windows.Forms.Label lbl_errors;
        private System.Windows.Forms.Label lbl_tasks;
        private System.Windows.Forms.Label lbl_Keys;
        private System.Windows.Forms.Label lbl_tiempoEstimado;
        private System.Windows.Forms.Label lbl_tiempoRestante;
        private System.Windows.Forms.Label lbl_tiempoTranscurrido;
        private System.Windows.Forms.Label lbl_clavesSegundo;
        private System.Windows.Forms.Label lbl_clavesPendientes;
        private System.Windows.Forms.Label lbl_clavesProbadas;
        private System.Windows.Forms.Label lbl_clavesPosibles;
        private System.Windows.Forms.Label label16;
    }
}