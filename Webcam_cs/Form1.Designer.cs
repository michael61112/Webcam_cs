namespace Webcam_cs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DIPcomboBox = new System.Windows.Forms.ComboBox();
            this.DIPlabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_serialOpen = new System.Windows.Forms.Button();
            this.btn_serialClose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_tt = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.listBoxGcode = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Location_Map = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.Location_Pointer = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labValueY = new System.Windows.Forms.Label();
            this.labValueX = new System.Windows.Forms.Label();
            this.labValueZ = new System.Windows.Forms.Label();
            this.btnReflesh = new System.Windows.Forms.Button();
            this.listBoxReceive = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Location_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_Pointer)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 63);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1286, 733);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(4, 63);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1286, 733);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Olive;
            this.panel1.Controls.Add(this.DIPcomboBox);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.DIPlabel);
            this.panel1.Location = new System.Drawing.Point(1312, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 867);
            this.panel1.TabIndex = 2;
            // 
            // DIPcomboBox
            // 
            this.DIPcomboBox.FormattingEnabled = true;
            this.DIPcomboBox.Items.AddRange(new object[] {
            "Origin",
            "FaceDetection",
            "MotionDetection",
            "SharpDetection",
            "CannyEdge",
            "Close"});
            this.DIPcomboBox.Location = new System.Drawing.Point(29, 813);
            this.DIPcomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DIPcomboBox.Name = "DIPcomboBox";
            this.DIPcomboBox.Size = new System.Drawing.Size(173, 32);
            this.DIPcomboBox.TabIndex = 2;
            this.DIPcomboBox.SelectedIndexChanged += new System.EventHandler(this.DIPcomboBox_SelectedIndexChanged);
            // 
            // DIPlabel
            // 
            this.DIPlabel.AutoSize = true;
            this.DIPlabel.Font = new System.Drawing.Font("PMingLiU", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DIPlabel.Location = new System.Drawing.Point(523, 9);
            this.DIPlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DIPlabel.Name = "DIPlabel";
            this.DIPlabel.Size = new System.Drawing.Size(331, 54);
            this.DIPlabel.TabIndex = 3;
            this.DIPlabel.Text = "FaceDetection";
            this.DIPlabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Olive;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1300, 867);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(521, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 54);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origin Image";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1759, 895);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(419, 161);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_serialOpen
            // 
            this.btn_serialOpen.Enabled = false;
            this.btn_serialOpen.Location = new System.Drawing.Point(216, 127);
            this.btn_serialOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btn_serialOpen.Name = "btn_serialOpen";
            this.btn_serialOpen.Size = new System.Drawing.Size(108, 57);
            this.btn_serialOpen.TabIndex = 0;
            this.btn_serialOpen.Text = "Open";
            this.btn_serialOpen.UseVisualStyleBackColor = true;
            this.btn_serialOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_serialClose
            // 
            this.btn_serialClose.Enabled = false;
            this.btn_serialClose.Location = new System.Drawing.Point(350, 124);
            this.btn_serialClose.Margin = new System.Windows.Forms.Padding(4);
            this.btn_serialClose.Name = "btn_serialClose";
            this.btn_serialClose.Size = new System.Drawing.Size(108, 57);
            this.btn_serialClose.TabIndex = 1;
            this.btn_serialClose.Text = "Close";
            this.btn_serialClose.UseVisualStyleBackColor = true;
            this.btn_serialClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(26, 66);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 32);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.listBoxReceive);
            this.panel3.Controls.Add(this.btnReflesh);
            this.panel3.Controls.Add(this.label_tt);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.listBoxGcode);
            this.panel3.Controls.Add(this.btn_serialClose);
            this.panel3.Controls.Add(this.btn_serialOpen);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Location = new System.Drawing.Point(869, 897);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(882, 461);
            this.panel3.TabIndex = 8;
            // 
            // label_tt
            // 
            this.label_tt.AutoSize = true;
            this.label_tt.Font = new System.Drawing.Font("PMingLiU", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_tt.Location = new System.Drawing.Point(15, 3);
            this.label_tt.Name = "label_tt";
            this.label_tt.Size = new System.Drawing.Size(250, 43);
            this.label_tt.TabIndex = 3;
            this.label_tt.Text = "Serial Setting";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(711, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 35);
            this.button4.TabIndex = 10;
            this.button4.Text = "B";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(511, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 35);
            this.button3.TabIndex = 9;
            this.button3.Text = "A";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBoxGcode
            // 
            this.listBoxGcode.FormattingEnabled = true;
            this.listBoxGcode.ItemHeight = 24;
            this.listBoxGcode.Location = new System.Drawing.Point(51, 269);
            this.listBoxGcode.Name = "listBoxGcode";
            this.listBoxGcode.ScrollAlwaysVisible = true;
            this.listBoxGcode.Size = new System.Drawing.Size(353, 172);
            this.listBoxGcode.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(2066, 1081);
            this.textBox2.MaxLength = 1;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 36);
            this.textBox2.TabIndex = 1;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Joystick);
            // 
            // Location_Map
            // 
            this.Location_Map.Image = ((System.Drawing.Image)(resources.GetObject("Location_Map.Image")));
            this.Location_Map.Location = new System.Drawing.Point(18, 18);
            this.Location_Map.Name = "Location_Map";
            this.Location_Map.Size = new System.Drawing.Size(237, 213);
            this.Location_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Location_Map.TabIndex = 12;
            this.Location_Map.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(730, 86);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(90, 285);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // Location_Pointer
            // 
            this.Location_Pointer.Image = ((System.Drawing.Image)(resources.GetObject("Location_Pointer.Image")));
            this.Location_Pointer.Location = new System.Drawing.Point(443, 193);
            this.Location_Pointer.Name = "Location_Pointer";
            this.Location_Pointer.Size = new System.Drawing.Size(11, 11);
            this.Location_Pointer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Location_Pointer.TabIndex = 17;
            this.Location_Pointer.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel4.Controls.Add(this.labValueY);
            this.panel4.Controls.Add(this.labValueX);
            this.panel4.Controls.Add(this.labValueZ);
            this.panel4.Controls.Add(this.Location_Pointer);
            this.panel4.Controls.Add(this.trackBar1);
            this.panel4.Controls.Add(this.Location_Map);
            this.panel4.Location = new System.Drawing.Point(7, 895);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(823, 374);
            this.panel4.TabIndex = 20;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // labValueY
            // 
            this.labValueY.AutoSize = true;
            this.labValueY.Location = new System.Drawing.Point(656, 21);
            this.labValueY.Name = "labValueY";
            this.labValueY.Size = new System.Drawing.Size(49, 24);
            this.labValueY.TabIndex = 20;
            this.labValueY.Text = "Y: 0";
            // 
            // labValueX
            // 
            this.labValueX.AutoSize = true;
            this.labValueX.Location = new System.Drawing.Point(565, 21);
            this.labValueX.Name = "labValueX";
            this.labValueX.Size = new System.Drawing.Size(49, 24);
            this.labValueX.TabIndex = 19;
            this.labValueX.Text = "X: 0";
            // 
            // labValueZ
            // 
            this.labValueZ.AutoSize = true;
            this.labValueZ.Location = new System.Drawing.Point(753, 21);
            this.labValueZ.Name = "labValueZ";
            this.labValueZ.Size = new System.Drawing.Size(47, 24);
            this.labValueZ.TabIndex = 18;
            this.labValueZ.Text = "Z: 0";
            // 
            // btnReflesh
            // 
            this.btnReflesh.Location = new System.Drawing.Point(272, 58);
            this.btnReflesh.Margin = new System.Windows.Forms.Padding(4);
            this.btnReflesh.Name = "btnReflesh";
            this.btnReflesh.Size = new System.Drawing.Size(108, 40);
            this.btnReflesh.TabIndex = 11;
            this.btnReflesh.Text = "Reflesh";
            this.btnReflesh.UseVisualStyleBackColor = true;
            this.btnReflesh.Click += new System.EventHandler(this.btnReflesh_Click);
            // 
            // listBoxReceive
            // 
            this.listBoxReceive.FormattingEnabled = true;
            this.listBoxReceive.ItemHeight = 24;
            this.listBoxReceive.Location = new System.Drawing.Point(472, 269);
            this.listBoxReceive.Name = "listBoxReceive";
            this.listBoxReceive.ScrollAlwaysVisible = true;
            this.listBoxReceive.Size = new System.Drawing.Size(353, 172);
            this.listBoxReceive.TabIndex = 21;
            this.listBoxReceive.SelectedIndexChanged += new System.EventHandler(this.listBoxReceive_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(85, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 43);
            this.label1.TabIndex = 22;
            this.label1.Text = "Transmit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(493, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 43);
            this.label3.TabIndex = 23;
            this.label3.Text = "Receive";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2191, 1371);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Location_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Location_Pointer)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DIPlabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox DIPcomboBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_serialOpen;
        private System.Windows.Forms.Button btn_serialClose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label_tt;
        private System.Windows.Forms.ListBox listBoxGcode;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox Location_Map;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox Location_Pointer;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labValueY;
        private System.Windows.Forms.Label labValueX;
        private System.Windows.Forms.Label labValueZ;
        private System.Windows.Forms.Button btnReflesh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxReceive;
    }
}

