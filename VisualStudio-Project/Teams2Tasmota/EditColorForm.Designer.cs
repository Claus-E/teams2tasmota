namespace Teams2Tasmota
{
    partial class EditColorForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonOk = new System.Windows.Forms.Button();
            this.noCommandButton = new System.Windows.Forms.Button();
            this.dimmerTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimmerTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 80);
            this.panel1.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 97);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(982, 56);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Location = new System.Drawing.Point(12, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(982, 80);
            this.panel2.TabIndex = 2;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(12, 241);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(982, 56);
            this.trackBar2.TabIndex = 3;
            this.trackBar2.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.panel3.Location = new System.Drawing.Point(12, 303);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(982, 80);
            this.panel3.TabIndex = 4;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(12, 388);
            this.trackBar3.Maximum = 255;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(982, 56);
            this.trackBar3.TabIndex = 5;
            this.trackBar3.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(398, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Color 000000";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(12, 565);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(982, 100);
            this.panel4.TabIndex = 7;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(844, 691);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(150, 50);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // noCommandButton
            // 
            this.noCommandButton.Location = new System.Drawing.Point(12, 691);
            this.noCommandButton.Name = "noCommandButton";
            this.noCommandButton.Size = new System.Drawing.Size(150, 50);
            this.noCommandButton.TabIndex = 10;
            this.noCommandButton.Text = "No Command";
            this.noCommandButton.UseVisualStyleBackColor = true;
            this.noCommandButton.Click += new System.EventHandler(this.noCommandButton_Click);
            // 
            // dimmerTrackBar
            // 
            this.dimmerTrackBar.Location = new System.Drawing.Point(6, 21);
            this.dimmerTrackBar.Maximum = 100;
            this.dimmerTrackBar.Name = "dimmerTrackBar";
            this.dimmerTrackBar.Size = new System.Drawing.Size(970, 56);
            this.dimmerTrackBar.TabIndex = 5;
            this.dimmerTrackBar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dimmerTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 83);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimmer value";
            // 
            // EditColorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 753);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.noCommandButton);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditColorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Color";
            this.Load += new System.EventHandler(this.EditColorForm_Load);
            this.Shown += new System.EventHandler(this.EditColorForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dimmerTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button noCommandButton;
        private System.Windows.Forms.TrackBar dimmerTrackBar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}