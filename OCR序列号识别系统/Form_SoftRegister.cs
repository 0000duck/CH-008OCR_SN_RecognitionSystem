using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_SoftRegister : Form
    {
        public Form_SoftRegister()
        {
            InitializeComponent();
        }

        private void Form_SoftRegister_Load(object sender, EventArgs e)
        {
          textBox1.Text=   Class_SoftRegister.GetCpuId();

            string SericalNumber = Class_SoftRegister.ReadSetting("", "SerialNumber", "-1");
            string cpuid = Class_SoftRegister. GetSoftEndDateAllCpuId(0, SericalNumber);
            TimeSpan ts = Convert.ToDateTime(Class_SoftRegister.GetSoftEndDateAllCpuId(0, SericalNumber)) - DateTime.Now;
            ts1.Text = "软件使用到期时间：" + Class_SoftRegister.GetSoftEndDateAllCpuId(0, SericalNumber);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string SericalNumber = Encrypt.Class_DES.DesDecrypt(textBox2.Text);
                textBox3.Text += SericalNumber + "\r\n";

                string cpuid1 = Class_SoftRegister.GetSoftEndDateAllCpuId(1, SericalNumber);
                textBox3.Text += cpuid1 + "\r\n";
                string cpuid2 = Class_SoftRegister.GetCpuId();
                textBox3.Text += cpuid2 + "\r\n";
                if (cpuid1 == cpuid2)
                {
                    MessageBox.Show("注册码输入正确");
                    Class_SoftRegister.WriteSetting("", "SerialNumber", textBox2.Text);
                    ts1.Text = "软件使用到期时间：2099-01-01";
                }
                else
                {
                    MessageBox.Show("注册码输入错误");
                }
            }
            catch { MessageBox.Show("注册码输入不正确！"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBox1.Text);
            MessageBox.Show("机器码已复制到剪贴板");
        }
    }
}
