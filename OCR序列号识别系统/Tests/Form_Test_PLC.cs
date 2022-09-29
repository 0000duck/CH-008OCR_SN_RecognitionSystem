using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_Test_PLC : Form
    {
        public Form_Test_PLC()
        {
        　　//参考网址 https://www.cnblogs.com/dathlin/p/7782315.html
     　　　 //在Visual Studio 中的NuGet管理器中可以下载安装，
            //也可以直接在NuGet控制台输入下面的指令安装：Install-Package HslCommunication
            InitializeComponent();
        }
        private void Form_PLC_Load(object sender, EventArgs e)
        {
            tbPLC_ip.Text = config_json.PLC_IP;
            tbPLC_port.Text = config_json.PLC_Port;
            tbPLC_station.Text = config_json.PLC_Station;
           // btn_client_connect_Click(null, null);
        }

        private HslCommunication.ModBus.ModbusTcpNet PLC;
        private bool connected=false;
 

        string plc_write(string addr, string value)
        {
            if (connected == false) btn_client_connect_Click(null, null);

            addmemo("PLC 写入" + addr + "=" + value);
            string str = "";
            HslCommunication.OperateResult opr = PLC.Write(addr, Convert.ToInt16(value));
            if (opr.IsSuccess)
            {
                addmemo("PLC写入OK", 0);
            }
            else
            {
                addmemo("PLC写入失败，再次写入", 3);
                addmemo("PLC 写入" + addr + "=" + value);
                HslCommunication.OperateResult opr2 = PLC.Write(addr, Convert.ToInt16(value));
                if (opr2.IsSuccess)
                {
                    addmemo("PLC写入OK", 0);
                }
                else
                {
                    addmemo("PLC再次写入失败", 3);
                }
            }
            return str;
        }

        private void addmemo(string memo)
        {
            memo = DateTime.Now.ToString("[yyyy-M-d HH:mm:ss.fff] ") + memo + Environment.NewLine;
            richTextBox1.SelectionColor = System.Drawing.Color.Black;

            richTextBox1.AppendText(memo);
            richTextBox1.ScrollToCaret();

            //string path = logdird + "\\" + logfile;
            //if (!System.IO.File.Exists(path))
            //{
            //    FileStream stream = System.IO.File.Create(path);
            //    stream.Close();
            //    stream.Dispose();
            //}
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.Write(memo);
            //    writer.Close();
            //}

        }
        /// <summary>
        /// 0 green 1black 2yellow 3red
        /// </summary>
        /// <param name="memo"></param>
        /// <param name="i"></param>
        private void addmemo(string memo, int i)
        {
            memo = DateTime.Now.ToString("[yyyy-M-d HH:mm:ss.fff] ") + memo + Environment.NewLine;
            if (i == 0)
            {
                richTextBox1.SelectionColor = System.Drawing.Color.DarkGreen;
                richTextBox1.SelectionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (i == 1) richTextBox1.SelectionColor = System.Drawing.Color.Black;
            if (i == 2) richTextBox1.SelectionColor = System.Drawing.Color.Yellow;
            if (i == 3)
            {
                richTextBox1.SelectionColor = System.Drawing.Color.Red;
                richTextBox1.SelectionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }

            richTextBox1.AppendText(memo);
            richTextBox1.ScrollToCaret();

            //string path = logdird + "\\" + logfile;
            //if (!System.IO.File.Exists(path))
            //{
            //    FileStream stream = System.IO.File.Create(path);
            //    stream.Close();
            //    stream.Dispose();
            //}
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    writer.Write(memo);
            //    writer.Close();
            //}

        }

        private void btn_client_connect_Click(object sender, EventArgs e)
        {
            PLC = new HslCommunication.ModBus.ModbusTcpNet(tbPLC_ip.Text, Convert.ToInt16(tbPLC_port.Text), Convert.ToByte(tbPLC_station.Text));   // 站号1
            PLC.AddressStartWithZero = false;
            HslCommunication.OperateResult resut = PLC.ConnectServer();
            if (resut.IsSuccess)
            {
                lb_connect_info.Text = "已成功连接PLC";
                btn_client_connect.Enabled = false;
                btn_client_disconnect.Enabled = true;
                connected = true;
            }
            else
            {
                lb_connect_info.Text = "连接PLC失败";
            }
        }
        string plc_read(string register)
        {
            if (connected == false) btn_client_connect_Click(null, null);

            HslCommunication.OperateResult<byte[]> read = PLC.Read(register, 1);
            if (read.IsSuccess)
            {
                short value1 = PLC.ByteTransform.TransInt16(read.Content, 0);
                return value1.ToString();
            }
            else
            {
                return "";
            }
        }
        private void btn_client_disconnect_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            addmemo("写入ready");
            plc_write(tb_ready.Text, tb_ready_value.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            addmemo("ready read value:" + plc_read(tb_ready.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addmemo("写入start");
            plc_write(tb_start.Text, tb_start_value.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addmemo("写入done");
            plc_write(tb_done.Text, tb_done_value.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addmemo("写入data:"+tb_data_value.Text);
           
           PLC.Write(tb_data.Text, tb_data_value.Text);
         //  PLC.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addmemo("ready begin value:" + plc_read(tb_start.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            addmemo("ready done value:" + plc_read(tb_done.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addmemo("ready data value:" + PLC.ReadString(tb_data.Text,20).Content.ToString());
        }
    }
}
