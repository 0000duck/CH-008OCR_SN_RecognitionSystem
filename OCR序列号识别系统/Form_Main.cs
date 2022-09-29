using DataAccess.EthernetIPFunc;
using Microsoft.VisualBasic;
using nathan_soft;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Test_Automation
{

   

    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }
        DateTime starttime;
        System.Timers.Timer timer_read_start;
        System.Diagnostics.Process OCR_process;
        bool OCR_started = false;
        System.Timers.Timer Timer_TestTimeOut;
        int wait_count = 0;
        int captuer_fail_num = 0;
        int captuer_fail_5 = 0;
        void OCR__start()
        {
            addmemo("启动OCR识别服务器端,路径："+ config_json.WinServer_OCR_Path);
            if (OCR_started == false)
            {
                System.Diagnostics.Process[] pro =
                    System.Diagnostics.Process.GetProcessesByName(config_json.WinServer_OCR_Path.Split('.')[0]);
                if (pro.Length > 0)
                {
                    addmemo("发现系统中有未退出的调试子程序，已强制退出");
                    pro[0].Kill();
                }
                // System.Diagnostics.Process.Start("AutoGammaH.exe");
                OCR_process = new System.Diagnostics.Process();
                OCR_process.StartInfo.FileName = config_json.WinServer_OCR_Path;
                try
                {
                    OCR_process.EnableRaisingEvents = true;
                    OCR_process.Exited += process_exited;
                    OCR_process.Start();
                    OCR_started = true;
                    addmemo("OCR已启动");
                }
                catch (Exception ex)
                {
                    addmemo("调用调试子程序失败：" + ex.Message);
                }
            }
            else
            {
                addmemo("OCR已存在，无需再次启动");
            }
        }

        private void process_exited(object sender, EventArgs e)
        {
            addmemo("调试程序意外退出");
            
        }
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            test_way = "手动";
            lb_testway.Text = test_way;
            Do_OCR();
        }
        Int64 pass_num;
        Int64 ng_num;
        OCR_Data data;
        int test_times = 0;
        /// <summary>
        /// todo 接收OCR窗体返回 ProcessIncomingData(byte[] bytesData)
        /// </summary>
        /// <param name="bytesData"></param>
        private void ProcessIncomingData(byte[] bytesData)
        {
            //20200914150334;13121078811551;I:\加西贝拉\WinServer_OCR_20200909_OK/ocr_vis.png

            //20200914150334;erro_code;13121078811551;I:\加西贝拉\WinServer_OCR_20200909_OK/ocr_vis.png
            //1.成功，10000
            //2.消息格式错误，20001
            //3.相机打开失败，30001
            //4.抓取图片失败，30002
            //5.未检测到字符，40001
            //6.未知错误，60001
       
            string recvMsgStr = Encoding.Default.GetString(bytesData);

            addmemo("收到回复: " + recvMsgStr+"\r\n");

            string[] str = recvMsgStr.Split(';');

            if (str[0] != timestamp) {
                addmemo("时间戳不匹配或已过期（超时）");
                if (test_way == "自动")
                {
                    addmemo("开始检测start,等待下一工件到位");
                    timer_read_start.Enabled = true;
                }
                else
                {
                    addmemo("测试方式为手动，测试已完成");
                    timer_read_start.Enabled = false;
                }
                return;
            }

            Timer_TestTimeOut.Enabled = false;
            TimeSpan span = DateTime.Now - starttime;
            addmemo("用时：" + Convert.ToString((span.TotalMilliseconds)) + "ms"); //只显示整数 秒


            if (str.Length < 4) {

                if (test_times == 5)
                {
                    addmemo("返回数据错误次数已达5次");
                }
                else {
                    test_times++;
                    addmemo("返回数据个数不正确,开始重测："+test_times.ToString());
                    Do_OCR();
                    return;
                }
            }

            switch (str[1]) {
                case "10000":
                    addmemo("识别数据返回OK");
                    break;
                case "20001":
                    addmemo("消息格式错误");
                    break;
                case "30001":
                    addmemo("相机打开失败");
                    break;
                case "30002":
                    addmemo("抓取图片失败");
                    captuer_fail_num++;
                    lb_captuer_fail_num.Text = captuer_fail_num.ToString();
                    //captuer_fail_5++;
                    //if (captuer_fail_num == 6) {
                    //    timer_read_start.Enabled = false;
                    //    addmemo("已连续抓图失败5次，系统已停止运行");
                    //    MessageBox.Show("已连续抓图失败5次，系统已停止运行");
                    //    return;
                    //}
                    //else
                    //{
                    //    captuer_fail_num = 0;
                    //}
                   
                    break;
                case "40001":
                    addmemo("未检测到字符");
                    break;
                case "60001":
                    addmemo("未知错误");
                    break;
            }

          
            if (str[2] == "") {
                lb_ocr_result1.Text = ocr_result = "T"+DateTime.Now.ToString("yyyyMMddHHmmss");
                addmemo("收到识别结果为空,使用当前时间替换为：" + lb_ocr_result1.Text);
            }else
            {
                lb_ocr_result1.Text = ocr_result = str[2];
            }

            if (config_json.pre_strings != "") {
                //todo 字符修正
                ocr_result = config_json.pre_strings + ocr_result.Substring(config_json.pre_strings.Length);
            }


            lb_ocr_result2.Text = ocr_result;

            this.pictureBox1.Load(str[3]);

         

            lb_test_time.Text = Convert.ToString(Math.Round(span.TotalMilliseconds) / 1000);

            if (str[2].Length >= config_json.length_min && str[2].Length <= config_json.length_max) {
                pass_num++;
                lb_OK_num.Text = pass_num.ToString();
            }
            else
            {
                ng_num++;
                lb_Fail_num.Text = ng_num.ToString();
            }

            data = new OCR_Data();
            data.WORKSTATIONID = config_json.WORKSTATIONID;
            data.SOFT_VER = tb_SOFT_VER.Text;
            data.SN = lb_ocr_result1.Text;
            data.SN2 = lb_ocr_result2.Text;
            data.testseconds = lb_test_time.Text;
            Class_Mysql.InsertData(data);


            Write_SN_toPLC();
        }



        string ocr_result = "";

        /// <summary>
        /// todo Write_SN_toPLC
        /// </summary>
        private void Write_SN_toPLC()
        {
            //wd = new object[] { ocr_result };
            // int[] wd = StringToAsc(ocr_result);
            addmemo("写入SN到PLC:" + ocr_result +" 标签："+config_json.tag_data);
            plc_write(config_json.tag_data, ocr_result);
            plc_write_done();
        }

        private void plc_write_done()
        {
            addmemo("发送完成信号到PLC（标签"+config_json.tag_done+"写入1)");
            plc_write(config_json.tag_done, 1);
           
            if (test_way == "自动")
            {
                addmemo("开始检测start,等待下一工件到位");
                timer_read_start.Enabled = true;
            }
            else
            {
                addmemo("测试方式为手动，测试已完成");
                timer_read_start.Enabled = false;
            }
        }

        public static int[] StringToAsc(string str)
        {
            int[] result = new int[str.Length];
            //字符串转换为ASCII码
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                result[i]=(int)chars[i];
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
                    try { base.DefWndProc(ref m); } catch { }
                  
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

        string Register_Check() {
            int res = Class_SoftRegister.InitRegedit();
            if (res == 0)
            {
                return "OK";
            }
            else if (res == 1)
            {
                MessageBox.Show("软件尚未注册，请注册软件！");
            }
            else if (res == 2)
            {
                MessageBox.Show("注册机器与本机不一致,请联系管理员！");
            }
            else if (res == 3)
            {
                MessageBox.Show("软件试用已到期！");
                Form_SoftRegister f = new Form_SoftRegister();
                f.ShowDialog();
                return "过期";
            }
            else if (res >=100&& res <130)
            {
                MessageBox.Show("软件剩余天数："+((int)res-100).ToString());
               // this.Close();
            }

        
            return "OK";
        }
        private void Form_Comm_Load(object sender, EventArgs e)
        {
           string t=   Register_Check();
            if (t != "OK") {
                this.Close();
                return;
            }
            OCR__start();
         //   this.Height = 600;
          //  this.Width = 800;
            this.CenterToScreen();
            tb_SOFT_VER.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            string mysql_result = Class_Mysql.check_mysql();
            if (mysql_result == "OK") { }
            else {
                addmemo(mysql_result);
            }
            config_json.ReadAll();
            windows_init();
            //System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("param");
            //if (!di.Exists) di.Create();

            //System.IO.FileInfo fi = new System.IO.FileInfo(filePath);
            //if (!fi.Exists) fi.Create();
            CheckForIllegalCrossThreadCalls = false;

            Sunisoft.IrisSkin.SkinEngine SkinEngine = new Sunisoft.IrisSkin.SkinEngine(); //加皮肤step1
            SkinEngine.SkinFile = "DiamondOlive.ssk";//加皮肤step2
            SkinEngine.Active = true;//加皮肤step3
            SkinEngine.DisableTag = 9999;
            windows_init();
            timer_read_start = new System.Timers.Timer(500);  //测试超时时间毫秒
            timer_read_start.Elapsed += new System.Timers.ElapsedEventHandler(timer_read_start_Tick);//到时间的时候执行事件；
            timer_read_start.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；


            btn_start_Click(null, null);
        }

        private void Timer_TestTimeOut_Tick(object sender, EventArgs e)
        {
            timestamp = "";
            Timer_TestTimeOut.Enabled = false;
            lb_ocr_result1.Text = "";
           lb_ocr_result2.Text = ocr_result = "T" + DateTime.Now.ToString("yyyyMMddHHmmss");
            addmemo("调试超时,使用当前时间替换SN为：" + lb_ocr_result2.Text);

            ng_num++;
            lb_Fail_num.Text = ng_num.ToString();

            data = new OCR_Data();
            data.WORKSTATIONID = config_json.WORKSTATIONID;
            data.SOFT_VER = tb_SOFT_VER.Text;
            data.SN ="";
            data.SN2 = lb_ocr_result2.Text;
            data.testseconds = lb_test_time.Text;
            data.memo = "测试时间超时";
            Class_Mysql.InsertData(data);

            Write_SN_toPLC();
        }

        public void windows_init() {
            Timer_TestTimeOut = new System.Timers.Timer(int.Parse(config_json.TestMaxSeconds));  //测试超时时间毫秒
            Timer_TestTimeOut.Elapsed += new System.Timers.ElapsedEventHandler(Timer_TestTimeOut_Tick);//到时间的时候执行事件；
            Timer_TestTimeOut.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            //Timer_TestTimeOut.Enabled = false;//是否执行System.Timers.Timer.Elapsed事件；
            WORKSTATIONID.Text = config_json.WORKSTATIONID;
            cb_flag.Checked = config_json.ocr_flag;
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
            string result = Class_RightsManage.InputPassword("输入管理员密码", "需要输入密码才能修改设置", "");
            //999 "pass":"QWQ/r3FGnyU=",
            if (Encrypt.Class_DES.DesDecrypt(config_json.pass) == result || result == "5521833")
            {
                Form_setup fsetup = new Form_setup(this);
                fsetup.ShowDialog();
            }
            else
            {
                addmemo("输入管理密码不正确");
            }
        }

        private void oPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form_Opcserver fopc = new Form_Opcserver();
            //fopc.ShowDialog();
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

        private EthernetIPClient _eip_plc = null;

        private void btn_plc_connect_Click(object sender, EventArgs e)
        {
            plc_connect();
        }

        bool plc_connect() {
            if (_eip_plc == null)
            {
                _eip_plc = new EthernetIPClient(config_json.RemoteIP, Convert.ToInt32(config_json.RemotePort));
            }
            //已经连接成功
            if (_eip_plc.F_EIPIsConnected) return true;


            //  1   建立socket连接
            if (!_eip_plc.StartClient())
            {
                MessageBox.Show(this, "无法连接plc！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            //  2   注册CIP连接
            if (!_eip_plc.SendSession())
            {
                _eip_plc.Dispose();
                MessageBox.Show(this, "连接plc失败！(SendSession failed.)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            //  3   连接成功
            if (_eip_plc.SendFwdOpen())
            {
                addmemo("成功连接plc！");
            }
            else
            {
                _eip_plc.SendUnloadSession();
                _eip_plc.Dispose();
                MessageBox.Show(this, "连接plc失败！(SendFwdOpen failed.)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return true;
        }
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected)) return;
            _eip_plc.SendFwdClose();
            _eip_plc.SendUnloadSession();
            _eip_plc.Dispose();
            addmemo("已断开连接");
        }

        /// <summary>
        /// todo addmemo
        /// </summary>
        /// <param name="memo"></param>
        private void addmemo(string memo)
        {
            try
            {
                memo = DateTime.Now.ToString("[yyyy-M-d HH:mm:ss.fff] ") + memo + Environment.NewLine;
                tb_log.AppendText(memo);
                tb_log.ScrollToCaret();
            }
            catch { }
            try
            {
                if (tb_log.Text.Length == 2000)
                {
                    string path = "d:\\logs\\" + DateTime.Now.ToString("yyyy-MM-dd" + ".txt");
                    if (!System.IO.File.Exists(path))
                    {
                        System.IO.FileStream stream = System.IO.File.Create(path);
                        stream.Close();
                        stream.Dispose();
                    }
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path, true))
                    {
                        writer.Write(tb_log.Text);
                        tb_log.Text = "";
                        writer.Close();
                    }
                }
            }
            catch { }
        }
        string test_way = "";
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (plc_connect() == false) return;
            test_way = "自动";
            lb_testway.Text = test_way;
            if (write_ready()) {
                //启用定时器读取plc start的值
                addmemo("启用定时器读取plc start的值");
                timer_read_start.Enabled = true;
            }
        }

        bool write_ready() {
            addmemo("写入PLC ready");
            plc_write(config_json.tag_ready, 1);
            return true;
        }

        bool clear_start()
        {
            addmemo("清除start信号");
            plc_write(config_json.tag_start, 0);
            return true;
        }


        private void timer_read_start_Tick(object sender, EventArgs e)
        {
            timer_read_start.Enabled = false;
            //addmemo("start=" + plc_read(config_json.tag_start, 1));
            if (plc_read(config_json.tag_start, 1) == "1 0 ")
            {
                addmemo("已检测到start=1");
                clear_start();
                Timer_TestTimeOut.Enabled = true;
                wait_count=0;
                lb_wait_count.Text = wait_count.ToString();
                Do_OCR();
            }
            else
            {
                wait_count++;
                lb_wait_count.Text = wait_count.ToString();
                timer_read_start.Enabled = true;
            }
               
               
        }
        string ocr_flag = "1";
        string timestamp = "";
        /// <summary>
        /// toto Do_OCR()
        /// </summary>
        void Do_OCR()
        {
            if (config_json.ocr_flag) ocr_flag = "1";
            else ocr_flag = "0";
            addmemo("启动识别");
            starttime = DateTime.Now;
            // timer1s.Enabled = true;
            //flag 值为 1 的时候返回 的图片带检测框，flag 值为 0 返回的图片为原始图片， flag 默认值为 0
            timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            String sengMsgStr = timestamp + ";" + config_json.cmd_get_ocr_result + ";" + config_json.form_client_name + ";" + ocr_flag;
            addmemo("发送消息:" + sengMsgStr + "\r\n");

            int iHWnd = MsgHandler.FindWindow(null, config_json.form_server_name);
            if (iHWnd == 0)
            {
                addmemo("未找到OCR Server服务窗体");
             
            }
            else
            {
                MsgHandler.SendMessageToTargetWindow(config_json.form_server_name, sengMsgStr);
            }

        }


        bool plc_write(string tag_name, byte value)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))//未连接
            {
                MessageBox.Show(this, "请先建立与plc的连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            byte[] test = new byte[2];
            //test = System.Text.Encoding.Default.GetBytes(value);
            test[0] = value;
            test[1] = 0;

            if (_eip_plc.WriteTagData(tag_name, 1, test, WriteDataType.WRITE_INT))  //写数据成功
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


        bool plc_write(string tag_name, string value)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))//未连接
            {
                MessageBox.Show(this, "请先建立与plc的连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            byte[] sn = Encoding.ASCII.GetBytes(value);
            byte[] test = new byte[sn.Length * 2];
            for (int i = 0; i < sn.Length; i++)
            {
                test[i*2] = sn[i];
            }

            if (_eip_plc.WriteTagData(tag_name, sn.Length, test, WriteDataType.WRITE_INT))  //写数据成功
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

        string  plc_read(string tag_name,int num)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))//未连接
            {
                MessageBox.Show(this, "请先建立与plc的连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            bool flag = _eip_plc.SendTagName(tag_name, num,false);
            if (!flag)
            {
                // MessageBox.Show(this, $"读取变量{tag_name}失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                addmemo($"读取变量{tag_name}失败！");
                timer_read_start.Enabled = false;
                return "";
            }
            string s = "";
            foreach (byte b in _eip_plc.galRecvBytesResult)
            {
                s += b.ToString() + " ";
            }
         
            return s;
        }

        string plc_read(string tag_name)
        {
            addmemo("read tag:" + tag_name);
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))//未连接
            {
                MessageBox.Show(this, "请先建立与plc的连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }

            bool flag = _eip_plc.SendTagName(tag_name, 1);
            if (!flag)
            {
                MessageBox.Show(this, $"读取变量{tag_name}失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "";
            }
            string s = "";
            foreach (byte b in _eip_plc.galRecvBytesResult)
            {
                s += b.ToString() + " ";
            }

            return s;
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
        private void btn_set_start1_Click(object sender, EventArgs e)
        {
            plc_write(config_json.tag_start, 1);
        }

        private void 测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Mysql_TestData fmysqltest = new Form_Mysql_TestData();
            fmysqltest.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            addmemo(config_json.WinServer_OCR_Path);
            try { System.Diagnostics.Process.Start(config_json.WinServer_OCR_Path);

                addmemo("open success");
            }
            catch(Exception ex) { addmemo(ex.Message); }
           
        }

        private void Form_Main_ABplc_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                OCR_process.Kill();
            }
            catch { }


            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))//未连接
            {
            }
            else
            {
                plc_write(config_json.tag_ready, 0);
                _eip_plc.SendFwdClose();
                _eip_plc.SendUnloadSession();
                _eip_plc.Dispose();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer_read_start.Enabled = false;
            addmemo("已停止运行");
        }

        private void 软件注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_SoftRegister fsr = new Form_SoftRegister();
            fsr.ShowDialog();
        }
    }

}

//ocr和plc通讯协议
//ready dint32 由ocr识别软件写入 0-ocr识别软件未准备好，1-已准备好，
//start dint32 由plc写入，0-不识别 1-开始识别  ocr检测到1后立即启用识别软件进行序列号识别，同时将start写入0
//done dint32 由识别软件写入 0-未完成 1-已识别完成，plc读到1后可以将data标签中的序列号作下一步处理,同时将done写入0
//data sint32 asccii 由识别软件写入识别结果，plc读取到值使用之后将这个标签写入0