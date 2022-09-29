using System;
using System.Windows.Forms;
using UcAsp.Opc;

namespace Test_Automation
{
    public partial class Form_OPC : Form
    {
        OpcClient client;
        public Form_OPC()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            OpcClient client = new OpcClient(new Uri(tb_opcda.Text));
        }

        private void Form_OPC_Load(object sender, EventArgs e)
        {
           // OpcClient client = new OpcClient(new Uri("opc.tcp://127.0.0.1:26543/Workstation.RobotServer"));

        }

        private void btn_read_Click(object sender, EventArgs e)
        {
            if (client.Connect == OpcStatus.Connected)
            {
                //float r = client.Read<float>("Robot1.Axis1");
                float r = client.Read<float>(tb_name.Text);
                lb_readcontent.Text = r.ToString();
            }
        }

        private void btn_write_Click(object sender, EventArgs e)
        {
            if (client.Connect == OpcStatus.Connected)
            {
                // client.Write<float>("Robot1.Axis1", 2.0090f);
                // float r = client.Read<float>("Robot1.Axis1");
                client.Write<float>(tb_name.Text, float.Parse(tb_write_value.Text));
                float r = client.Read<float>(tb_name.Text);
            }
        }

        string msg;
        private void tb_datachanged_Click(object sender, EventArgs e)
        {
            if (client.Connect == OpcStatus.Connected)
            {
                OpcGroup group = client.AddGroup("Test");
                client.AddItems("Test", new string[] { "Robot1.Axis1", "Robot1.Axis2" },out msg);
                group.DataChange += Group_DataChange;
               // Console.WriteLine(group);
            }
        }

        private void Group_DataChange(object sender, ItemDataEventArgs e)
        {
            tb_log.Text += "检测到数据发生变化";
        }

        private void btn_log_clear_Click(object sender, EventArgs e)
        {
            tb_log.Clear();
        }
    }
}
