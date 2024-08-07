namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows

        /// <summary>
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.COM = new System.Windows.Forms.Label();
            this.button30 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMac = new System.Windows.Forms.TextBox();
            this.textBoxLocalIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMask = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDistinIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDistinPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxDHCP = new System.Windows.Forms.CheckBox();
            this.checkBoxDNS = new System.Windows.Forms.CheckBox();
            this.textBoxDNS = new System.Windows.Forms.TextBox();
            this.textBoxHeartTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxRSSI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.textBoxGate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1",
            "COM2"});
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.comboBox1.Location = new System.Drawing.Point(47, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 142);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "WriteTag";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 258);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(430, 130);
            this.textBox1.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 21);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(83, 38);
            this.button6.TabIndex = 0;
            this.button6.Text = "Reading";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(111, 21);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 38);
            this.button11.TabIndex = 10;
            this.button11.Text = "Stop";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.COM);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 145);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connection";
            // 
            // COM
            // 
            this.COM.AutoSize = true;
            this.COM.Location = new System.Drawing.Point(15, 19);
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(23, 12);
            this.COM.TabIndex = 3;
            this.COM.Text = "USB";
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(26, 94);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(83, 38);
            this.button30.TabIndex = 4;
            this.button30.Text = "ScanUSB";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Location = new System.Drawing.Point(8, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 66);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ActiveMode";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Location = new System.Drawing.Point(219, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 66);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AnswerMode";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(55, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(83, 38);
            this.button7.TabIndex = 0;
            this.button7.Text = "Read";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(341, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 38);
            this.button4.TabIndex = 24;
            this.button4.Text = "ReadRFPower";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(341, 51);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 38);
            this.button5.TabIndex = 25;
            this.button5.Text = "SetRFPower";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(251, 98);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(83, 38);
            this.button8.TabIndex = 26;
            this.button8.Text = "RelayOn";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(341, 98);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(83, 38);
            this.button9.TabIndex = 27;
            this.button9.Text = "RelayOff";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.comboBox2.Location = new System.Drawing.Point(251, 10);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(69, 27);
            this.comboBox2.TabIndex = 28;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "Mac";
            // 
            // textBoxMac
            // 
            this.textBoxMac.Location = new System.Drawing.Point(511, 13);
            this.textBoxMac.Name = "textBoxMac";
            this.textBoxMac.Size = new System.Drawing.Size(100, 21);
            this.textBoxMac.TabIndex = 30;
            // 
            // textBoxLocalIP
            // 
            this.textBoxLocalIP.Location = new System.Drawing.Point(511, 40);
            this.textBoxLocalIP.Name = "textBoxLocalIP";
            this.textBoxLocalIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxLocalIP.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "IP";
            // 
            // textBoxMask
            // 
            this.textBoxMask.Location = new System.Drawing.Point(511, 67);
            this.textBoxMask.Name = "textBoxMask";
            this.textBoxMask.Size = new System.Drawing.Size(100, 21);
            this.textBoxMask.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "Mask";
            // 
            // textBoxDistinIP
            // 
            this.textBoxDistinIP.Location = new System.Drawing.Point(511, 117);
            this.textBoxDistinIP.Name = "textBoxDistinIP";
            this.textBoxDistinIP.Size = new System.Drawing.Size(100, 21);
            this.textBoxDistinIP.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(458, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "DistinIP";
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Location = new System.Drawing.Point(682, 40);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(74, 21);
            this.textBoxLocalPort.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(616, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "LocalPort";
            // 
            // textBoxDistinPort
            // 
            this.textBoxDistinPort.Location = new System.Drawing.Point(682, 115);
            this.textBoxDistinPort.Name = "textBoxDistinPort";
            this.textBoxDistinPort.Size = new System.Drawing.Size(74, 21);
            this.textBoxDistinPort.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(616, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "DistinPort";
            // 
            // checkBoxDHCP
            // 
            this.checkBoxDHCP.AutoSize = true;
            this.checkBoxDHCP.Location = new System.Drawing.Point(461, 140);
            this.checkBoxDHCP.Name = "checkBoxDHCP";
            this.checkBoxDHCP.Size = new System.Drawing.Size(48, 16);
            this.checkBoxDHCP.TabIndex = 41;
            this.checkBoxDHCP.Text = "DHCP";
            this.checkBoxDHCP.UseVisualStyleBackColor = true;
            // 
            // checkBoxDNS
            // 
            this.checkBoxDNS.AutoSize = true;
            this.checkBoxDNS.Location = new System.Drawing.Point(461, 164);
            this.checkBoxDNS.Name = "checkBoxDNS";
            this.checkBoxDNS.Size = new System.Drawing.Size(42, 16);
            this.checkBoxDNS.TabIndex = 42;
            this.checkBoxDNS.Text = "DNS";
            this.checkBoxDNS.UseVisualStyleBackColor = true;
            // 
            // textBoxDNS
            // 
            this.textBoxDNS.Location = new System.Drawing.Point(511, 159);
            this.textBoxDNS.Name = "textBoxDNS";
            this.textBoxDNS.Size = new System.Drawing.Size(245, 21);
            this.textBoxDNS.TabIndex = 43;
            // 
            // textBoxHeartTime
            // 
            this.textBoxHeartTime.Location = new System.Drawing.Point(523, 186);
            this.textBoxHeartTime.Name = "textBoxHeartTime";
            this.textBoxHeartTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxHeartTime.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(458, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 44;
            this.label7.Text = "HeartTime";
            // 
            // textBoxRSSI
            // 
            this.textBoxRSSI.Location = new System.Drawing.Point(523, 222);
            this.textBoxRSSI.Name = "textBoxRSSI";
            this.textBoxRSSI.Size = new System.Drawing.Size(100, 21);
            this.textBoxRSSI.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 46;
            this.label8.Text = "WIFIRssi";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(523, 249);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(100, 21);
            this.textBoxPass.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(463, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 48;
            this.label9.Text = "WIFIPass";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(497, 296);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 50;
            this.button10.Text = "Read";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(600, 296);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 51;
            this.button12.Text = "Set";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(497, 338);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 52;
            this.button13.Text = "Default";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // textBoxGate
            // 
            this.textBoxGate.Location = new System.Drawing.Point(511, 92);
            this.textBoxGate.Name = "textBoxGate";
            this.textBoxGate.Size = new System.Drawing.Size(100, 21);
            this.textBoxGate.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 53;
            this.label10.Text = "Gate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 389);
            this.Controls.Add(this.textBoxGate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxRSSI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxHeartTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxDNS);
            this.Controls.Add(this.checkBoxDNS);
            this.Controls.Add(this.checkBoxDHCP);
            this.Controls.Add(this.textBoxDistinPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxLocalPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxDistinIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMask);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLocalIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "USB";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label COM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMac;
        private System.Windows.Forms.TextBox textBoxLocalIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDistinIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLocalPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDistinPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxDHCP;
        private System.Windows.Forms.CheckBox checkBoxDNS;
        private System.Windows.Forms.TextBox textBoxDNS;
        private System.Windows.Forms.TextBox textBoxHeartTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRSSI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox textBoxGate;
        private System.Windows.Forms.Label label10;
    }
}

