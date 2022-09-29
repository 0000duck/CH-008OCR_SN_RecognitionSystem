using DataAccess.EthernetIPFunc;
using Microsoft.VisualBasic;
using nathan_soft;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Test_Automation
{

    //ProcessIncomingData

    public partial class CompactLogixTCP_TAG : Form
    {
        public CompactLogixTCP_TAG()
        {
            InitializeComponent();
        }
        DateTime starttime;
        private void btnSendMsg_Click(object sender, EventArgs e)
        {

            starttime = DateTime.Now;
           // timer1s.Enabled = true;
            //flag 值为 1 的时候返回 的图片带检测框，flag 值为 0 返回的图片为原始图片， flag 默认值为 0

            String sengMsgStr =DateTime.Now.ToString("yyyyMMddHHmmss")+";"+ config_json.cmd_get_ocr_result+";"+config_json.form_client_name+";"+tb_flag.Text;
            this.tb_log.AppendText("发送消息:" + sengMsgStr+"\r\n");

           MsgHandler.SendMessageToTargetWindow(config_json.form_server_name, sengMsgStr);

        }

        Int64 pass_num;
        Int64 ng_num;
        OCR_Data data;
        private void ProcessIncomingData(byte[] bytesData)
        {
            //20200914150334;13121078811551;I:\加西贝拉\WinServer_OCR_20200909_OK/ocr_vis.png

            string recvMsgStr = Encoding.Default.GetString(bytesData);

            this.tb_log.AppendText("收到回复: " + recvMsgStr);
            this.tb_log.AppendText(Environment.NewLine);

            string[] str = recvMsgStr.Split(';');
           lb_ocr_result1.Text= ocr_result = str[1];

            if (config_json.pre_strings != "") {
                //todo 字符修正
                ocr_result = config_json.pre_strings + ocr_result.Substring(config_json.pre_strings.Length);
            }


            lb_ocr_result2.Text = ocr_result;

            this.pictureBox1.Load(str[2]);

            TimeSpan span = DateTime.Now - starttime;

            addmemo("用时：" + Convert.ToString((span.TotalMilliseconds)) + "ms"); //只显示整数 秒

            lb_test_time.Text = Convert.ToString(Math.Round(span.TotalMilliseconds) / 1000);

            if (str[1].Length >= config_json.length_min && str[1].Length <= config_json.length_max) {
                pass_num++;
            }else
            {
                ng_num++;
            }

            lb_OK_num.Text = pass_num.ToString();
            lb_Fail_num.Text = ng_num.ToString();

            data = new OCR_Data();
            data.WORKSTATIONID = config_json.WORKSTATIONID;
            data.SOFT_VER = tb_SOFT_VER.Text;
            data.SN = lb_ocr_result1.Text;
            data.SN2 = lb_ocr_result2.Text;
            data.testseconds = lb_test_time.Text;
            Class_Mysql.InsertData(data);


            Write_SN_toPLC();
        }

        int tag_type = 0;  //0 Controller Tags 1 Program Tags
        int data_type = 1; //int16
        string ocr_result = "";
        object[] wd = null;

        /// <summary>
        /// todo Write_SN_toPLC
        /// </summary>
        private void Write_SN_toPLC()
        {
            if (!PlcLink)
            {
                addmemo("还未与PLC建立联接！");
                return;
            }
            //wd = new object[] { ocr_result };
            wd = StringToAsc(ocr_result);
            data_type = 3;
            re = PLC.WriteArray(Handle1, tag_type, config_json.tag_data, data_type, Convert.ToInt32(0), wd.Length, ref wd);

            addmemo("写入SN到PLC:"+ ocr_result);
            if (re == 0)
            {
                addmemo("写入成功！");
                timer_read_start.Enabled = true;
                plc_write_done();
                addmemo("开启定时器，等待下一台就位");
            }
            else
            {
                addmemo("写入失败！");
            }
        }

        private void plc_write_done()
        {
            addmemo("set done=1");
            plc_write(config_json.tag_done, 3, "1");
        }

        public static string[] StringToAsc(string str)
        {
            string[] result = new string[str.Length];
            //字符串转换为ASCII码
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                result[i]=((int)chars[i]).ToString();
            }
            return result;
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
        //string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "param/config.ini");//在当前程序路径创建
        private void Form_Comm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            tb_SOFT_VER.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
           addmemo(Class_Mysql. check_mysql());
            config_json.ReadAll();
            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("param");
            //if (!di.Exists) di.Create();

            //System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
            //if (!fi.Exists) fi.Create();

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tb_log.Text = "";
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - starttime;
            lb_test_time.Text = Convert.ToString(Math.Round(span.TotalSeconds)); //只显示整数 秒
        }

        private void etherIPClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_abplc fther = new Form_abplc();
            fther.Show();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_setup fsetup = new Form_setup(this);
            //fsetup.ShowDialog();
        }

        private void oPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_Opcserver fopc = new Form_Opcserver();
           // fopc.ShowDialog();
        }

        private void modbusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Test_PLC fplc = new Form_Test_PLC();
            fplc.Show();
        }

        int Handle1 = 0;
        bool PlcLink = false;
        int re = 0;

        global::CompactLogixTCP_TAG.PlcClient PLC = new global::CompactLogixTCP_TAG.PlcClient();

        [DllImport("winmm.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern UInt32 timeGetTime();
       

        private void btn_plc_connect_Click(object sender, EventArgs e)
        {
            int re = 0;
            string restr = "";
            Handle1 = 0;
            re = PLC.EntLink(config_json.LocalIP, Convert.ToUInt16(0), config_json.RemoteIP, Convert.ToInt32(config_json.RemotePort), "DEMO", ref Handle1);
            addmemo("e:"+re.ToString());
            if (re == 0)
            {
                PlcLink = true;
                addmemo("PLC联接成功!");
            }
            else
            {
                PlcLink = false;
                addmemo("PLC联接失败: " + restr);
            }
        }
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            re = PLC.DeLink(Handle1);
            if (re == 0)
            {
                PlcLink = false;
                addmemo("PLC断开成功!");
            }
            else
            {
                PlcLink = true;
                addmemo("PLC断开失败！");
            }
        }

        /// <summary>
        /// todo addmemo
        /// </summary>
        /// <param name="memo"></param>
        private void addmemo(string memo)
        {
            memo = DateTime.Now.ToString("[yyyy-M-d HH:mm:ss.fff] ") + memo + Environment.NewLine;
            tb_log.AppendText(memo);
            tb_log.ScrollToCaret();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (write_ready()) {
                //启用定时器读取plc start的值
                addmemo("启用定时器读取plc start的值");
                timer_read_start.Enabled = true;
            }
            //发送ready
            //cmbDataType.Items.Clear();
            //cmbDataType.Items.Add("BOOL1");
            //cmbDataType.Items.Add("INT16");
            //cmbDataType.Items.Add("UINT16");
            //cmbDataType.Items.Add("DINT32");
            //cmbDataType.Items.Add("HEX32");
            //cmbDataType.Items.Add("REAL32");
            //cmbDataType.Items.Add("BIN16");
            //cmbDataType.Items.Add("BYTE8");
            //0 BOOL1 1 INT16 2 UINT16 3 DINT32 4 HEX32 5 REAL32 6 BIN16 7 BYTE8

            //object[] wd = null;
            //int tagcnt = 0;
            //string[] tags = null;
            //int[] valtype = null;
            //tags = new string[] { config_json.tag_ready};
            //valtype = new int[] { 3};   //0 BOOL1 1 INT16 2 UINT16 3 DINT32 4 HEX32 5 REAL32 6 BIN16 7 BYTE8
            //wd = new object[] { "1"};
            //re = PLC.CmdWrite(Handle1, 0, 1, ref tags, ref valtype, ref wd);

            //if (re == 0)
            //{
            //    addmemo("写入ready：1 成功" );
            //    //启用定时器读取plc start的值
            //    timer_read_start.Enabled = true;
            //}
            //else {
            //    addmemo("写入ready失败");
            //}
       }

        bool write_ready() {
            data_type = 3;
            addmemo(config_json.tag_ready+"写入1");
            re = PLC.CmdWrite(Handle1, 0, config_json.tag_ready, ref data_type, "1");
            addmemo("e:" + re.ToString());
            if (re == 0)
            {
                addmemo("写入成功");
                return true;
            }
            else
            {
                addmemo("写入失败");
                return false;
            }
        }

        bool clear_start()
        {
            data_type = 3;
            addmemo(config_json.tag_start + "写入0");
            re = PLC.CmdWrite(Handle1, 0, config_json.tag_start, ref data_type, "0");
            addmemo("e:" + re.ToString());
            if (re == 0)
            {
                addmemo("写入成功");
                return true;
            }
            else
            {
                addmemo("写入失败");
                return false;
            }
        }


        private void timer_read_start_Tick(object sender, EventArgs e)
        {
            timer_read_start.Enabled = false;

            object[] rd = null;
            string[] tags = null;
            int[] valtype = null;
            tags = new string[] { config_json.tag_start };
            valtype = new int[] { 3};   
            //addmemo("读取"+config_json.tag_start );

            re = PLC.CmdRead(Handle1, 0, 1, ref tags, ref valtype, ref rd);
            //addmemo("re:" + re.ToString());
            if (re == 0)
            {
                try
                {
                    //addmemo(config_json.tag_start + "=" + rd[0].ToString());
                    if (rd[0].ToString() == "1")
                    {
                        addmemo("set start=0");
                        clear_start();
                        addmemo("启动识别");
                        Do_OCR();
                    }
                       
                    else
                        timer_read_start.Enabled = true;
                }
                catch (Exception ex) {
                    addmemo("接收到的数据有误");
                }
            }
            else
            {
                addmemo("读start失败");
            }
        }

        void Do_OCR()
        {
            btnSendMsg_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data_type = 3;
            re = PLC.CmdWrite(Handle1, 0, "z", ref data_type, "8");
            addmemo("e:" + re.ToString());
            if (re == 0)
            {
                addmemo("写入成功");
            }
            else
            {
                addmemo("写入失败");
            }
        }

        bool plc_write(string tag_name,int data_type,string value) {
            addmemo("write tag：" + tag_name + "=" + value + " datatype=" + data_type.ToString());
            string[] tags = null;
            int[] valtype = null;
            tags = new string[] { tag_name };
            valtype = new int[] { data_type };   //Dint32
            wd = new object[] { value };
            try
            {
                re = PLC.CmdWrite(Handle1, 0, 1, ref tags, ref valtype, ref wd);
                if (re == 0)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch  {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object[] wd = null;
            int tagcnt = 1;
            string[] tags = null;
            int[] valtype = null;
            tags = new string[] { "z" };
            valtype = new int[] { 3};   //Dint32
            wd = new object[] { "1" };
            re = PLC.CmdWrite(Handle1, 0, tagcnt, ref tags, ref valtype, ref wd);

            //70534127 
            //0 
            //1 
            //string[1]
            //int[1] 
            //string[1]

            if (re == 0)
            {
                addmemo("写入z：" + re.ToString());
                //启用定时器读取plc start的值
                //timer_read_start.Enabled = true;
            }
            else
            {
                addmemo("写入z失败");
            }
        }

        private void writesntoplc_Click(object sender, EventArgs e)
        {
            ocr_result = tb_sn.Text;
            Write_SN_toPLC();
        }

        private void btn_set_start1_Click(object sender, EventArgs e)
        {
            plc_write("x", 3, "1");
        }

        private void 测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Mysql_TestData fmysqltest = new Form_Mysql_TestData();
            fmysqltest.Show();
        }
    }
    public enum DataType : int
    {
        //0 BOOL1 1 INT16 2 UINT16 3 DINT32 4 HEX32 5 REAL32 6 BIN16 7 BYTE8
        BOOL1,
        INT16,
        UINT16,
        DINT32,
        HEX32,
        REAL32,
        BIN16,
        BYTE8
    }
}
