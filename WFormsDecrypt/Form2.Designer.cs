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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_decryptor1));
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
            this.lbl_successes = new System.Windows.Forms.Label();
            this.lbl_errors = new System.Windows.Forms.Label();
            this.lbl_tasks = new System.Windows.Forms.Label();
            this.lbl_Keys = new System.Windows.Forms.Label();
            this.lbl_tiempoEstimado = new System.Windows.Forms.Label();
            this.lbl_tiempoRestante = new System.Windows.Forms.Label();
            this.lbl_tiempoTranscurrido = new System.Windows.Forms.Label();
            this.lbl_clavesSegundo = new System.Windows.Forms.Label();
            this.lbl_clavesPendientes = new System.Windows.Forms.Label();
            this.lbl_clavesProbadas = new System.Windows.Forms.Label();
            this.lbl_clavesPosibles = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
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
            this.checkBox_SkipLsb = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_directorio = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.input_exponent = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.input_modulus = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.input_q = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.input_p = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.input_d = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.input_inverseq = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.input_dq = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.input_dp = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.input_criptedFrase1 = new System.Windows.Forms.RichTextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.output_Frase1 = new System.Windows.Forms.RichTextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.output_Frase2 = new System.Windows.Forms.RichTextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.input_criptedFrase2 = new System.Windows.Forms.RichTextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.output_Frase3 = new System.Windows.Forms.RichTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.input_criptedFrase3 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hex Key";
            // 
            // text_key
            // 
            this.text_key.Location = new System.Drawing.Point(12, 61);
            this.text_key.Name = "text_key";
            this.text_key.Size = new System.Drawing.Size(588, 20);
            this.text_key.TabIndex = 2;
            this.text_key.Text = "9D2AEA59EC1C7B5AD91687BF6C825862F76B8E9F23     FB B8 CE";
            this.text_key.TextChanged += new System.EventHandler(this.text_key_TextChangedAsync);
            // 
            // text_hexKey
            // 
            this.text_hexKey.Enabled = false;
            this.text_hexKey.HideSelection = false;
            this.text_hexKey.Location = new System.Drawing.Point(606, 61);
            this.text_hexKey.Name = "text_hexKey";
            this.text_hexKey.Size = new System.Drawing.Size(566, 20);
            this.text_hexKey.TabIndex = 3;
            // 
            // text_mensajeCifrado
            // 
            this.text_mensajeCifrado.Location = new System.Drawing.Point(12, 116);
            this.text_mensajeCifrado.Name = "text_mensajeCifrado";
            this.text_mensajeCifrado.Size = new System.Drawing.Size(1160, 81);
            this.text_mensajeCifrado.TabIndex = 4;
            this.text_mensajeCifrado.Text = resources.GetString("text_mensajeCifrado.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mensaje Encriptado";
            // 
            // bnt_loadMessage
            // 
            this.bnt_loadMessage.Location = new System.Drawing.Point(119, 87);
            this.bnt_loadMessage.Name = "bnt_loadMessage";
            this.bnt_loadMessage.Size = new System.Drawing.Size(157, 23);
            this.bnt_loadMessage.TabIndex = 6;
            this.bnt_loadMessage.Text = "Cargar Mensaje";
            this.bnt_loadMessage.UseVisualStyleBackColor = true;
            this.bnt_loadMessage.Click += new System.EventHandler(this.bnt_loadMessage_Click);
            // 
            // text_mensaje
            // 
            this.text_mensaje.Location = new System.Drawing.Point(15, 214);
            this.text_mensaje.Name = "text_mensaje";
            this.text_mensaje.Size = new System.Drawing.Size(1157, 83);
            this.text_mensaje.TabIndex = 7;
            this.text_mensaje.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mensaje Desencriptado";
            // 
            // btn_loadKey
            // 
            this.btn_loadKey.Location = new System.Drawing.Point(43, 35);
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
            this.checkBox1.Location = new System.Drawing.Point(1078, 400);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "RealTimeData";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_DecryptWKey
            // 
            this.btn_DecryptWKey.Enabled = false;
            this.btn_DecryptWKey.Location = new System.Drawing.Point(15, 322);
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
            this.label5.Location = new System.Drawing.Point(82, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descifrar";
            // 
            // btn_DecryptWForce
            // 
            this.btn_DecryptWForce.Enabled = false;
            this.btn_DecryptWForce.Location = new System.Drawing.Point(15, 351);
            this.btn_DecryptWForce.Name = "btn_DecryptWForce";
            this.btn_DecryptWForce.Size = new System.Drawing.Size(185, 23);
            this.btn_DecryptWForce.TabIndex = 13;
            this.btn_DecryptWForce.Text = "Con Fuerza Bruta";
            this.btn_DecryptWForce.UseVisualStyleBackColor = true;
            this.btn_DecryptWForce.Click += new System.EventHandler(this.btn_DecryptWForce_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 400);
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
            this.panel1.Location = new System.Drawing.Point(450, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 85);
            this.panel1.TabIndex = 15;
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
            // lbl_errors
            // 
            this.lbl_errors.AutoSize = true;
            this.lbl_errors.Location = new System.Drawing.Point(582, 41);
            this.lbl_errors.Name = "lbl_errors";
            this.lbl_errors.Size = new System.Drawing.Size(13, 13);
            this.lbl_errors.TabIndex = 20;
            this.lbl_errors.Text = "0";
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
            // lbl_Keys
            // 
            this.lbl_Keys.AutoSize = true;
            this.lbl_Keys.Location = new System.Drawing.Point(582, 5);
            this.lbl_Keys.Name = "lbl_Keys";
            this.lbl_Keys.Size = new System.Drawing.Size(13, 13);
            this.lbl_Keys.TabIndex = 18;
            this.lbl_Keys.Text = "0";
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
            // lbl_tiempoRestante
            // 
            this.lbl_tiempoRestante.AutoSize = true;
            this.lbl_tiempoRestante.Location = new System.Drawing.Point(367, 23);
            this.lbl_tiempoRestante.Name = "lbl_tiempoRestante";
            this.lbl_tiempoRestante.Size = new System.Drawing.Size(13, 13);
            this.lbl_tiempoRestante.TabIndex = 16;
            this.lbl_tiempoRestante.Text = "0";
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
            // lbl_clavesSegundo
            // 
            this.lbl_clavesSegundo.AutoSize = true;
            this.lbl_clavesSegundo.Location = new System.Drawing.Point(107, 59);
            this.lbl_clavesSegundo.Name = "lbl_clavesSegundo";
            this.lbl_clavesSegundo.Size = new System.Drawing.Size(13, 13);
            this.lbl_clavesSegundo.TabIndex = 14;
            this.lbl_clavesSegundo.Text = "0";
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
            // lbl_clavesProbadas
            // 
            this.lbl_clavesProbadas.AutoSize = true;
            this.lbl_clavesProbadas.Location = new System.Drawing.Point(107, 23);
            this.lbl_clavesProbadas.Name = "lbl_clavesProbadas";
            this.lbl_clavesProbadas.Size = new System.Drawing.Size(13, 13);
            this.lbl_clavesProbadas.TabIndex = 12;
            this.lbl_clavesProbadas.Text = "0";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 13);
            this.label16.TabIndex = 10;
            this.label16.Text = "Claves Pendientes:";
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
            // checkBox_SkipLsb
            // 
            this.checkBox_SkipLsb.AutoSize = true;
            this.checkBox_SkipLsb.Location = new System.Drawing.Point(374, 314);
            this.checkBox_SkipLsb.Name = "checkBox_SkipLsb";
            this.checkBox_SkipLsb.Size = new System.Drawing.Size(70, 17);
            this.checkBox_SkipLsb.TabIndex = 16;
            this.checkBox_SkipLsb.Text = "Skip LSB";
            this.checkBox_SkipLsb.UseVisualStyleBackColor = true;
            this.checkBox_SkipLsb.CheckedChanged += new System.EventHandler(this.checkBox_SkipLsb_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(206, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "CarpetaSalida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 381);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "Directorio:";
            // 
            // lbl_directorio
            // 
            this.lbl_directorio.AutoSize = true;
            this.lbl_directorio.Location = new System.Drawing.Point(83, 381);
            this.lbl_directorio.Name = "lbl_directorio";
            this.lbl_directorio.Size = new System.Drawing.Size(45, 13);
            this.lbl_directorio.TabIndex = 23;
            this.lbl_directorio.Text = "ninguno";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 1);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(175, 31);
            this.label18.TabIndex = 24;
            this.label18.Text = "Documento 1";
            // 
            // input_exponent
            // 
            this.input_exponent.Location = new System.Drawing.Point(12, 471);
            this.input_exponent.Name = "input_exponent";
            this.input_exponent.Size = new System.Drawing.Size(558, 20);
            this.input_exponent.TabIndex = 26;
            this.input_exponent.Text = "AQAB";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 457);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "Exponent";
            // 
            // input_modulus
            // 
            this.input_modulus.Location = new System.Drawing.Point(613, 471);
            this.input_modulus.Name = "input_modulus";
            this.input_modulus.Size = new System.Drawing.Size(559, 20);
            this.input_modulus.TabIndex = 28;
            this.input_modulus.Text = "qggvlMT/9aYVgBz71c4PjQF+gd/d7xMcHWhJssU7t98/ypMYTMTq7D2nsbM0ZEBkoMPrYC6cZARcLVZ1k" +
    "OQvLQ==";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(610, 457);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Modulus";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 426);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(175, 31);
            this.label21.TabIndex = 29;
            this.label21.Text = "Documento 2";
            // 
            // input_q
            // 
            this.input_q.Location = new System.Drawing.Point(613, 505);
            this.input_q.Name = "input_q";
            this.input_q.Size = new System.Drawing.Size(559, 20);
            this.input_q.TabIndex = 33;
            this.input_q.Text = "2xM7OVPF9aCLkNZX489+wfxMWpBaGdtB8ay5YijxKvc=";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(610, 491);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 13);
            this.label22.TabIndex = 32;
            this.label22.Text = "Q";
            // 
            // input_p
            // 
            this.input_p.Location = new System.Drawing.Point(12, 505);
            this.input_p.Name = "input_p";
            this.input_p.Size = new System.Drawing.Size(558, 20);
            this.input_p.TabIndex = 31;
            this.input_p.Text = "xrDQpgmWRhhtganNdBszHpsRm8t7WCJfOet6qZr+qfs=";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 491);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "P";
            // 
            // input_d
            // 
            this.input_d.Location = new System.Drawing.Point(613, 573);
            this.input_d.Name = "input_d";
            this.input_d.Size = new System.Drawing.Size(559, 20);
            this.input_d.TabIndex = 41;
            this.input_d.Text = "I7m4lZ+W0DxnRBXS7CdxqQTpWcx5yyPOwncJFSDP3WAZNfHvio4KUdFVL6ZI7tl88KSViKZbfEvXB17Fs" +
    "CSfWQ==";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(610, 559);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(15, 13);
            this.label24.TabIndex = 40;
            this.label24.Text = "D";
            // 
            // input_inverseq
            // 
            this.input_inverseq.Location = new System.Drawing.Point(12, 573);
            this.input_inverseq.Name = "input_inverseq";
            this.input_inverseq.Size = new System.Drawing.Size(558, 20);
            this.input_inverseq.TabIndex = 39;
            this.input_inverseq.Text = "HQpFONw9FgB9o+dDWOCH+9qUzDTUT/Q7d9o+59WQ1GA=";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 559);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 13);
            this.label25.TabIndex = 38;
            this.label25.Text = "InverseQ";
            // 
            // input_dq
            // 
            this.input_dq.Location = new System.Drawing.Point(613, 539);
            this.input_dq.Name = "input_dq";
            this.input_dq.Size = new System.Drawing.Size(559, 20);
            this.input_dq.TabIndex = 37;
            this.input_dq.Text = "rp3EjewdFKxTsi12voksAtjjzyfR+VwPUt+WoAv8Nn8=";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(610, 525);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 13);
            this.label26.TabIndex = 36;
            this.label26.Text = "DQ";
            // 
            // input_dp
            // 
            this.input_dp.Location = new System.Drawing.Point(12, 539);
            this.input_dp.Name = "input_dp";
            this.input_dp.Size = new System.Drawing.Size(558, 20);
            this.input_dp.TabIndex = 35;
            this.input_dp.Text = "xQzuoPy5EGOBlyq0HAYtuJjJ6dzwQwQztNmZGUQidKk=";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 525);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(22, 13);
            this.label27.TabIndex = 34;
            this.label27.Text = "DP";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 602);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 13);
            this.label28.TabIndex = 43;
            this.label28.Text = "Frase 1 Encriptado";
            // 
            // input_criptedFrase1
            // 
            this.input_criptedFrase1.Location = new System.Drawing.Point(12, 614);
            this.input_criptedFrase1.Name = "input_criptedFrase1";
            this.input_criptedFrase1.Size = new System.Drawing.Size(558, 30);
            this.input_criptedFrase1.TabIndex = 42;
            this.input_criptedFrase1.Text = "IlmhPFKroDuK4AUtBGfaf5J6791DzMenkUBEXfRwZ7rmBHswHTf02LAba/Hs+rsh3wL6dpMQlEhlaIAVH" +
    "aZZsw==";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(614, 602);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(96, 13);
            this.label29.TabIndex = 45;
            this.label29.Text = "Frase 1 Descifrada";
            // 
            // output_Frase1
            // 
            this.output_Frase1.Location = new System.Drawing.Point(614, 614);
            this.output_Frase1.Name = "output_Frase1";
            this.output_Frase1.Size = new System.Drawing.Size(558, 30);
            this.output_Frase1.TabIndex = 44;
            this.output_Frase1.Text = "";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(613, 642);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(96, 13);
            this.label30.TabIndex = 49;
            this.label30.Text = "Frase 2 Descifrada";
            // 
            // output_Frase2
            // 
            this.output_Frase2.Location = new System.Drawing.Point(613, 655);
            this.output_Frase2.Name = "output_Frase2";
            this.output_Frase2.Size = new System.Drawing.Size(558, 27);
            this.output_Frase2.TabIndex = 48;
            this.output_Frase2.Text = "";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 642);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 13);
            this.label31.TabIndex = 47;
            this.label31.Text = "Frase 2 Encriptado";
            // 
            // input_criptedFrase2
            // 
            this.input_criptedFrase2.Location = new System.Drawing.Point(11, 655);
            this.input_criptedFrase2.Name = "input_criptedFrase2";
            this.input_criptedFrase2.Size = new System.Drawing.Size(558, 27);
            this.input_criptedFrase2.TabIndex = 46;
            this.input_criptedFrase2.Text = "AMbsYR1pq9WYUj3mdqKvJj7tMznqBAcZLxM2C6WzNEUOqKD/qdEE76bNJPmYFKwVei2rhuHFsxh7nUzXm" +
    "VKRdw==";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(613, 678);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 13);
            this.label32.TabIndex = 53;
            this.label32.Text = "Frase 3 Descifrada";
            // 
            // output_Frase3
            // 
            this.output_Frase3.Location = new System.Drawing.Point(613, 691);
            this.output_Frase3.Name = "output_Frase3";
            this.output_Frase3.Size = new System.Drawing.Size(558, 27);
            this.output_Frase3.TabIndex = 52;
            this.output_Frase3.Text = "";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(11, 678);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(96, 13);
            this.label33.TabIndex = 51;
            this.label33.Text = "Frase 3 Encriptado";
            // 
            // input_criptedFrase3
            // 
            this.input_criptedFrase3.Location = new System.Drawing.Point(11, 691);
            this.input_criptedFrase3.Name = "input_criptedFrase3";
            this.input_criptedFrase3.Size = new System.Drawing.Size(558, 27);
            this.input_criptedFrase3.TabIndex = 50;
            this.input_criptedFrase3.Text = "J1jnq551phV+W4MVzE5caXIHqM3E0gz/t9PVtorqvDVqfne8CCF9UQiEk33Rssi1IEz6JH8Fd8ZAvnX3U" +
    "We5Vw==";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(550, 724);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 54;
            this.button2.Text = "Decifrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // form_decryptor1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 771);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.output_Frase3);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.input_criptedFrase3);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.output_Frase2);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.input_criptedFrase2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.output_Frase1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.input_criptedFrase1);
            this.Controls.Add(this.input_d);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.input_inverseq);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.input_dq);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.input_dp);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.input_q);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.input_p);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.input_modulus);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.input_exponent);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lbl_directorio);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_SkipLsb);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "form_decryptor1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
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
        private System.Windows.Forms.CheckBox checkBox_SkipLsb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_directorio;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox input_exponent;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox input_modulus;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox input_q;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox input_p;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox input_d;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox input_inverseq;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox input_dq;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox input_dp;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.RichTextBox input_criptedFrase1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.RichTextBox output_Frase1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.RichTextBox output_Frase2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.RichTextBox input_criptedFrase2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.RichTextBox output_Frase3;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.RichTextBox input_criptedFrase3;
        private System.Windows.Forms.Button button2;
    }
}