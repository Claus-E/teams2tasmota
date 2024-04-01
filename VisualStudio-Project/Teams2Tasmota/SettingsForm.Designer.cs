namespace Teams2Tasmota
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.cmbSerialPorts = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.minimize_checkBox = new System.Windows.Forms.CheckBox();
            this.notification_checkBox = new System.Windows.Forms.CheckBox();
            this.chat_checkBox = new System.Windows.Forms.CheckBox();
            this.call_checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.webPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbmSerialBaudrate = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.new_teams_checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbSerialPorts
            // 
            this.cmbSerialPorts.FormattingEnabled = true;
            this.cmbSerialPorts.Location = new System.Drawing.Point(127, 202);
            this.cmbSerialPorts.Name = "cmbSerialPorts";
            this.cmbSerialPorts.Size = new System.Drawing.Size(565, 24);
            this.cmbSerialPorts.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(617, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "URL";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 286);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(565, 22);
            this.textBox1.TabIndex = 4;
            // 
            // minimize_checkBox
            // 
            this.minimize_checkBox.AutoSize = true;
            this.minimize_checkBox.Location = new System.Drawing.Point(12, 49);
            this.minimize_checkBox.Name = "minimize_checkBox";
            this.minimize_checkBox.Size = new System.Drawing.Size(185, 20);
            this.minimize_checkBox.TabIndex = 5;
            this.minimize_checkBox.Text = "minimize to Tray after Start";
            this.minimize_checkBox.UseVisualStyleBackColor = true;
            // 
            // notification_checkBox
            // 
            this.notification_checkBox.AutoSize = true;
            this.notification_checkBox.Location = new System.Drawing.Point(12, 76);
            this.notification_checkBox.Name = "notification_checkBox";
            this.notification_checkBox.Size = new System.Drawing.Size(149, 20);
            this.notification_checkBox.TabIndex = 6;
            this.notification_checkBox.Text = "Flash on Notification";
            this.notification_checkBox.UseVisualStyleBackColor = true;
            // 
            // chat_checkBox
            // 
            this.chat_checkBox.AutoSize = true;
            this.chat_checkBox.Location = new System.Drawing.Point(12, 103);
            this.chat_checkBox.Name = "chat_checkBox";
            this.chat_checkBox.Size = new System.Drawing.Size(179, 20);
            this.chat_checkBox.TabIndex = 6;
            this.chat_checkBox.Text = "Flash on Chat Notification";
            this.chat_checkBox.UseVisualStyleBackColor = true;
            // 
            // call_checkBox
            // 
            this.call_checkBox.AutoSize = true;
            this.call_checkBox.Location = new System.Drawing.Point(12, 130);
            this.call_checkBox.Name = "call_checkBox";
            this.call_checkBox.Size = new System.Drawing.Size(175, 20);
            this.call_checkBox.TabIndex = 6;
            this.call_checkBox.Text = "Flash on Call Notification";
            this.call_checkBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 326);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Web Password";
            // 
            // webPasswordTextBox
            // 
            this.webPasswordTextBox.Location = new System.Drawing.Point(127, 323);
            this.webPasswordTextBox.Name = "webPasswordTextBox";
            this.webPasswordTextBox.Size = new System.Drawing.Size(214, 22);
            this.webPasswordTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 326);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "(leave empty for do not use)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Serial baudrate";
            // 
            // cbmSerialBaudrate
            // 
            this.cbmSerialBaudrate.FormattingEnabled = true;
            this.cbmSerialBaudrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "56000",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.cbmSerialBaudrate.Location = new System.Drawing.Point(127, 242);
            this.cbmSerialBaudrate.Name = "cbmSerialBaudrate";
            this.cbmSerialBaudrate.Size = new System.Drawing.Size(214, 24);
            this.cbmSerialBaudrate.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "(tasmota default is 115200)";
            // 
            // new_teams_checkBox
            // 
            this.new_teams_checkBox.AutoSize = true;
            this.new_teams_checkBox.Location = new System.Drawing.Point(12, 12);
            this.new_teams_checkBox.Name = "new_teams_checkBox";
            this.new_teams_checkBox.Size = new System.Drawing.Size(130, 20);
            this.new_teams_checkBox.TabIndex = 5;
            this.new_teams_checkBox.Text = "use \'new Teams\'";
            this.new_teams_checkBox.UseVisualStyleBackColor = true;
            this.new_teams_checkBox.CheckedChanged += new System.EventHandler(this.new_teams_checkBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 455);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.webPasswordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.call_checkBox);
            this.Controls.Add(this.chat_checkBox);
            this.Controls.Add(this.notification_checkBox);
            this.Controls.Add(this.new_teams_checkBox);
            this.Controls.Add(this.minimize_checkBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbmSerialBaudrate);
            this.Controls.Add(this.cmbSerialPorts);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSerialPorts;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox minimize_checkBox;
        private System.Windows.Forms.CheckBox notification_checkBox;
        private System.Windows.Forms.CheckBox chat_checkBox;
        private System.Windows.Forms.CheckBox call_checkBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox webPasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbmSerialBaudrate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox new_teams_checkBox;
    }
}