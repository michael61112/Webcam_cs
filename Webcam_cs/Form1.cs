using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

using System.Threading;
using Emgu.CV.VideoSurveillance;
using System.IO.Ports;
namespace Webcam_cs
{

    public partial class Form1 : Form
    {
        SerialPort comport;

        private Capture cap = null;
        //public delegate void mydalegate(Label l);
        //public mydalegate md;
        int valueX = 0, valueY = 0, valueZ = 0;
        
        public Form1()
        {

            SerialPort comLocation;
            comLocation = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            comLocation.Handshake = Handshake.None;
            //comLocation.DataReceived+=new SerialDataReceivedEventHandler(d)
                comLocation.Open();
            InitializeComponent();
            //md = new mydalegate(label_tt);
            this.KeyPreview = true;
            //char key;

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }

            /////////////////////////

            Thread t1 = new Thread(MyBackgroundTask);
            //Thread t2 = new Thread(Serial.Serial_task);
            t1.Start();

            
            try
            {
                cap = new Capture(1);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }


            if (cap != null) //if camera capture has been successfully created
            {
                DIP.initial();
            }
            Point temp = new Point(Location_Map.Location.X + Location_Map.Size.Width / 2, Location_Map.Location.Y + Location_Map.Size.Height / 2);
            Location_Pointer.Location = temp;


            Application.Idle += new EventHandler(Application_Idle);
            Closing += new CancelEventHandler(Form1_Closing);
            Closed += new EventHandler(Form1_Closed);
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        }

        Boolean _stoped = false;
        private Boolean getMyBackgroudShouldbeStopped()
        {
            return _stoped;
        }
        private void setMyBackgroudStop()
        {
            _stoped = true;
        }

        private String getNumberText()
        {
            return label_tt.Text;
        }

        private void setNumberText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                this.textBox1.BeginInvoke((MethodInvoker)delegate () { this.textBox1.Text = text; });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }
        
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "確定退出？", "退出視窗通知", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
                
                //Environment.Exit(Environment.ExitCode);
            }
            else
            {
                if (cap != null)
                {
                    cap.Dispose();
                }
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            
            
        }
        
        private void Form1_Closed(object sender, EventArgs e)
        {
            //this.Close();
            Environment.Exit(Environment.ExitCode);
        }
        

        private void setNumbberText(int i)
        {
            label_tt.Text = i.ToString();
        }
        private  void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            //SerialPort sp = (SerialPort)sender;
            string indata = serialPort1.ReadExisting();//.ReadExisting();
            
            listBoxReceive.Items.Add(indata);
        }
        
        private void KeyPress_Joystick(object sender, KeyPressEventArgs e)
        {
            //string command = e.KeyChar.ToString();
            //listBox1.Items.Add(command);
            //comport.Write("command");
            //if ( e.keycode == Keys.Enter)
            //Point temp = (200);
            if (e.KeyChar == (char)Keys.W && valueX < 255)
            {
                Location_Pointer.Location = new Point(Location_Pointer.Location.X, Location_Pointer.Location.Y - 1);
                valueX++;
                labValueX.Text = "X: " + valueX.ToString();
            }
            else if (e.KeyChar == (char)Keys.X && valueX > -255)
            {
                Location_Pointer.Location = new Point(Location_Pointer.Location.X, Location_Pointer.Location.Y + 1);
                valueX--;
                labValueX.Text = "X: " + valueX.ToString();
            }
            else if (e.KeyChar == (char)Keys.A && valueY >-255)
            {
                Location_Pointer.Location = new Point(Location_Pointer.Location.X - 1, Location_Pointer.Location.Y);
                valueY--;
                labValueY.Text = "Y: " + valueY.ToString();
            }
            else if (e.KeyChar == (char)Keys.D && valueY < 255)
            {
                Location_Pointer.Location = new Point(Location_Pointer.Location.X + 1, Location_Pointer.Location.Y);
                valueY++;
                labValueY.Text = "Y: " + valueY.ToString();
            }
            else if (e.KeyChar == (char)Keys.R && valueZ < 255)
            {
                trackBar1.Value++;
                valueZ++;
                labValueZ.Text = "Z: " + valueZ.ToString();
                if(serialPort1.IsOpen)
                {
                    string temp = "G0 Z" + valueZ.ToString()+"\n";
                    listBoxGcode.Items.Add(temp);
                    serialPort1.Write(temp);
                }
            }
            else if (e.KeyChar == (char)Keys.V && valueZ > 0)
            {
                trackBar1.Value--;
                valueZ--;
                labValueZ.Text = "Z: " + valueZ.ToString();
                if (serialPort1.IsOpen)
                {
                    string temp = "G0 Z" + valueZ.ToString() + "\n";
                    listBoxGcode.Items.Add(temp);
                    serialPort1.Write(temp);
                }
            }

        }

        void MyBackgroundTask()
        {
            while (!getMyBackgroudShouldbeStopped())
            {

                DateTime time_now = DateTime.Now;

                setNumberText(time_now.ToString());
                //setNumberText(hr.ToString()+":"+min.ToString()+":"+sec.ToString());
                //Task.Delay(1000);
                System.Threading.Thread.Sleep(1000);

            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //string c = MousePosition.ToString();//Console.ReadLine();
            //string c = ModifierKeys.ToString();
            //if (c!=null)
            //listBox1.Items.Add(c) ;


            Image<Bgr, Byte> frame = cap.QueryFrame();
            pictureBox1.Image = frame.ToBitmap();

            if (DIPcomboBox.SelectedItem == "FaceDetection")
            {
                Image<Bgr, Byte> frame_facedetection = DIP.FaceDetection(frame);
                pictureBox2.Image = frame_facedetection.ToBitmap();
                DIPlabel.Text = DIPcomboBox.SelectedItem.ToString();
            }

            else if (DIPcomboBox.SelectedItem == "Origin")
            {
                pictureBox2.Image = frame.ToBitmap();
                DIPlabel.Text = DIPcomboBox.SelectedItem.ToString();
            }

            else if (DIPcomboBox.SelectedItem == "SharpDetection")
            {

                Image<Bgr, Byte> frame_sharpdetection = DIP.SharpDetect(frame);
                pictureBox2.Image = frame_sharpdetection.ToBitmap();
                DIPlabel.Text = DIPcomboBox.SelectedItem.ToString();
            }

            else if (DIPcomboBox.SelectedItem == "MotionDetection")
            {
                Image<Bgr, Byte> frame_motiondetection = DIP.MotionDetection(frame);
                pictureBox2.Image = frame_motiondetection.ToBitmap();
                DIPlabel.Text = DIPcomboBox.SelectedItem.ToString();
            }


            else if (DIPcomboBox.SelectedItem == "CannyEdge")
            {
                Image<Gray, Byte> frame_cannyedge = DIP.CannyEdge(frame);
                pictureBox2.Image = frame_cannyedge.ToBitmap();
                DIPlabel.Text = DIPcomboBox.SelectedItem.ToString();
            }
            else if (DIPcomboBox.SelectedItem == "Close")
            {
                pictureBox2.Image = null;
                DIPlabel.Text = "Close";
            }
            else
            {
                pictureBox2.Image = null;// frame.ToBitmap();
                DIPlabel.Text = "Close";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFacedetection_Click(object sender, EventArgs e)
        {

        }

        private void label_tt_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DIPcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            comport = new SerialPort(comboBox1.SelectedItem.ToString(), 9600, Parity.None, 8, StopBits.One);
            if (!comport.IsOpen)
            {
                comport.Open();
            }
            */
            serialPort1 = new SerialPort(comboBox1.SelectedItem.ToString(), 115200, Parity.None, 8, StopBits.One);
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
            btn_serialOpen.Enabled = false;
            btn_serialClose.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            btn_serialOpen.Enabled = true;
            btn_serialClose.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("A");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("B");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_serialOpen.Enabled = true;
            btn_serialClose.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        int aa;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //aa=Console.ReadLine();
            aa++;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxGcode.Items.Add(aa);
        }

        private void btnReflesh_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBoxReceive_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void cancelAsyncButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }


    }

}
