using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.GPU;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV.VideoSurveillance;
using System;
using System.Threading;

namespace Webcam_cs
{
      class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        //[STAThread]
        static void Main()
        {
            //if (!IsPlaformCompatable()) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1());
            
        }

        

        /*
        

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        

        static bool IsPlaformCompatable()
        {
            int clrBitness = Marshal.SizeOf(typeof(IntPtr)) * 8;
            if (clrBitness != CvInvoke.UnmanagedCodeBitness)
            {
                MessageBox.Show(String.Format("Platform mismatched: CLR is {0} bit, C++ code is {1} bit."
                   + " Please consider recompiling the executable with the same platform target as C++ code.",
                   clrBitness, CvInvoke.UnmanagedCodeBitness));
                return false;
            }
            return true;
        }

        */
    }
    


}
