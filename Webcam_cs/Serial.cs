using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.IO.Ports;
using System.Threading;

namespace Webcam_cs
{
    class Serial
    {

        SerialPort comport;
        public  void Serial_task()
        {
            comport = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
            Byte[] buffer = new Byte[1];
            buffer[0] = 1;
            if (!comport.IsOpen)
            {
                comport.Open();
            }
            comport.Write(buffer, 0, buffer.Length);
            comport.Close();
        }



    }
}
