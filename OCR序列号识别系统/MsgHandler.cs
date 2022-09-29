using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace nathan_soft
{
    /// <summary>
    /// Send message handler class.
    /// Call the method "SendMessageToTargetWindow" to send 
    /// the message what we want.
    /// </summary>
    class MsgHandler
    {
        /// <summary>
        /// System defined message
        /// </summary>
        private const int WM_COPYDATA = 0x004A;

        /// <summary>
        /// User defined message
        /// </summary>
        private const int WM_DATA_TRANSFER = 0x0437;

        // FindWindow method, using Windows API
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        // IsWindow method, using Windows API
        [DllImport("User32.dll", EntryPoint = "IsWindow")]
        private static extern bool IsWindow(int hWnd);

        // SendMessage method, using Windows API
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
            int hWnd,                   // handle to destination window
            int Msg,                    // message
            int wParam,                 // first message parameter
            ref COPYDATASTRUCT lParam   // second message parameter
        );

        // SendMessage method, using Windows API
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
            int hWnd,                   // handle to destination window
            int Msg,                    // message
            int wParam,                 // first message parameter
            string lParam               // second message parameter
        );

        /// <summary>
        /// CopyDataStruct
        /// </summary>
        private struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        /// <summary>
        /// Send message to target window
        /// </summary>
        /// <param name="wndName">The window name which we want to found</param>
        /// <param name="msg">The message to be sent, string</param>
        /// <returns>success or not</returns>
        public static bool SendMessageToTargetWindow(string wndName, string msg)
        {
            Debug.WriteLine(string.Format("SendMessageToTargetWindow: Send message to target window {0}: {1}", wndName, msg));

            int iHWnd = FindWindow(null, wndName);
            if (iHWnd == 0)
            {
                //string strError = string.Format("SendMessageToTargetWindow: The target window [{0}] was not found!", wndName);
                //MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Debug.WriteLine(strError);
                return false;
            }
            else
            {
                byte[] bytData = null;
                bytData = Encoding.Default.GetBytes(msg);

                COPYDATASTRUCT cdsBuffer;
                cdsBuffer.dwData = (IntPtr)100;
                cdsBuffer.cbData = bytData.Length;
                cdsBuffer.lpData = Marshal.AllocHGlobal(bytData.Length);
                Marshal.Copy(bytData, 0, cdsBuffer.lpData, bytData.Length);

                // Use system defined message WM_COPYDATA to send message.
                int iReturn = SendMessage(iHWnd, WM_COPYDATA, 0, ref cdsBuffer);
                if (iReturn < 0)
                {
                    string strError = string.Format("SendMessageToTargetWindow: Send message to the target window [{0}] failed!", wndName);
                    MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine(strError);
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Send message to target window
        /// </summary>
        /// <param name="wndName">The window name which we want to found</param>
        /// <param name="wParam">first parameter, integer</param>
        /// <param name="lParam">second parameter, string</param>
        /// <returns>success or not</returns>
        public static bool SendMessageToTargetWindow(string wndName, int wParam, string lParam)
        {
            Debug.WriteLine(string.Format("SendMessageToTargetWindow: Send message to target window {0}: wParam:{1}, lParam:{2}", wndName, wParam, lParam));

            int iHWnd = FindWindow(null, wndName);
            if (iHWnd == 0)
            {
                string strError = string.Format("SendMessageToTargetWindow: The target window [{0}] was not found!", wndName);
                MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine(strError);
                return false;
            }
            else
            {
                // Use our defined message WM_DATA_TRANSFER to send message.
                int iReturn = SendMessage(iHWnd, WM_DATA_TRANSFER, wParam, lParam);
                if (iReturn < 0)
                {
                    string strError = string.Format("SendMessageToTargetWindow: Send message to the target window [{0}] failed!", wndName);
                    MessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine(strError);
                    return false;
                }

                return true;
            }
        }
    }
}


/*
 * 发送消息：
             String sengMsgStr = this.tb_message.Text;
            this.tb_received_msg.AppendText("Send Msg:" + sengMsgStr);
            this.tb_received_msg.AppendText(Environment.NewLine);

            MsgHandler.SendMessageToTargetWindow(tb_win_name.Text, sengMsgStr);
     
     
     */


/*
 接收消息
 以下代码添加到类中：

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
           
            this.tb_received_msg.AppendText(recvMsgStr);
            this.tb_received_msg.AppendText(Environment.NewLine);

            String sengMsgStr ="AutoReply:" + Encoding.Default.GetString(bytesData);
            MsgHandler.SendMessageToTargetWindow(tb_win_name.Text, sengMsgStr);
            this.tb_received_msg.AppendText("Send Msg:" + sengMsgStr);
            this.tb_received_msg.AppendText(Environment.NewLine);


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

     
     */
