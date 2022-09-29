using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using nathan_soft;

namespace Test_Automation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
         


        }
        /////////////////
        /// <summary>
        /// System defined message
        /// </summary>
        private const int WM_COPYDATA = 0x004A;

        /// <summary>
        /// User defined message
        /// </summary>
        private const int WM_DATA_TRANSFER = 0x0437;

        /// <summary>
        /// CopyDataStruct
        /// </summary>
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        /// <summary>
        /// Override the DefWndProc function, in order to receive the message through it.
        /// </summary>
        /// <param name="m">message</param>
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                // Here, we use WM_COPYDATA message to receive the COPYDATASTRUCT
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = new COPYDATASTRUCT();
                    cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                    byte[] bytData = new byte[cds.cbData];
                    Marshal.Copy(cds.lpData, bytData, 0, bytData.Length);
                    this.ProcessIncomingData(bytData);
                    break;

                // Here, we use our defined message WM_DATA_TRANSFER to receive the
                // normal data, such as integer, string.
                // We had try to use our defined message to receive the COPYDATASTRUCT,
                // but it didn't work!! It told us that we try to access the protected 
                // memory, it usually means that other memory has been broken.
                case WM_DATA_TRANSFER:
                    int iWParam = (int)m.WParam;
                    string sLParam = m.LParam.ToString();
                    this.ProcessIncomingData(iWParam, sLParam);
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Process the incoming data
        /// </summary>
        /// <param name="data">incoming data</param>
        private void ProcessIncomingData(byte[] bytesData)
        {
            string recvMsgStr = "Recv Msg: " + Encoding.Default.GetString(bytesData);

            this.textBox1.AppendText(recvMsgStr);
            this.textBox1.AppendText(Environment.NewLine);

          //  String sengMsgStr = Encoding.Default.GetString(bytesData) + " =Recv";
           // MsgHandler.SendMessageToTargetWindow("Form1", sengMsgStr);
          //  this.textBox1.AppendText("Send Msg:" + sengMsgStr);
          //  this.textBox1.AppendText(Environment.NewLine);


        }

        /// <summary>
        /// Process the incoming data
        /// </summary>
        /// <param name="iWParam">a integer parameter</param>
        /// <param name="sLParam">a string parameter</param>
        private void ProcessIncomingData(int iWParam, string sLParam)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("wParam: ");
            strBuilder.Append(iWParam.ToString());
            strBuilder.Append(", lParam: ");
            strBuilder.Append(sLParam);

            Console.WriteLine(strBuilder.ToString());
            //lstReceivedMsg.Items.Add(strBuilder.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSendMsg_Click_1(object sender, EventArgs e)
        {
            String sengMsgStr = this.textBox2.Text;
            this.textBox1.AppendText("Send Msg:" + sengMsgStr);
            this.textBox1.AppendText(Environment.NewLine);

            MsgHandler.SendMessageToTargetWindow(tb_winname.Text, sengMsgStr);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
