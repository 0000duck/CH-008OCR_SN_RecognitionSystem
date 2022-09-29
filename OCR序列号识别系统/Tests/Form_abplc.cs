using DataAccess.EthernetIPFunc;
using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_abplc : Form
    {
        private EthernetIPClient _eip_plc = null;
        public Form_abplc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_eip_plc == null)
            {
                _eip_plc = new EthernetIPClient(textBox1.Text, int.Parse(textBox2.Text));
            }
            //已经连接成功
            if (_eip_plc.F_EIPIsConnected) return;
            if (!_eip_plc.StartClient())
            {
                MessageBox.Show(this, "无法连接plc！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_eip_plc.SendSession())
            {
                _eip_plc.Dispose();
                MessageBox.Show(this, "连接plc失败！(SendSession failed.)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (_eip_plc.SendFwdOpen())
            {
                MessageBox.Show(this, "成功连接plc！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _eip_plc.SendUnloadSession();
                _eip_plc.Dispose();
                MessageBox.Show(this, "连接plc失败！(SendFwdOpen failed.)", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected)) return;
            _eip_plc.SendFwdClose();
            _eip_plc.SendUnloadSession();
            _eip_plc.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))
            {
                MessageBox.Show(this, "请先建立与plc的连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool flag = _eip_plc.SendTagName(textBox3.Text, int.Parse(textBox4.Text));
            if (!flag)
            {
                MessageBox.Show(this, $"读取变量{textBox3.Text}失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string s = "";
            foreach(byte b in _eip_plc.galRecvBytesResult)
            {
                //s += b.ToString("X2") + " ";
                s += b.ToString() + " ";
            }
            ListViewItem item = new ListViewItem(DateTime.Now.ToString("MMdd HH:mm:ss"));
            item.SubItems.Add(s);
            listView1.Items.Insert(0, item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_eip_plc == null || (!_eip_plc.F_EIPIsConnected))
            {
                MessageBox.Show(this, "请先建立与plc的连接！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool flag = _eip_plc.WriteTagData(textBox3.Text, int.Parse(textBox4.Text), System.Text.Encoding.Default.GetBytes(tb_towrite.Text),WriteDataType.WRITE_DINT);
           
            if (!flag)
            {
                MessageBox.Show(this, $"写入失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
