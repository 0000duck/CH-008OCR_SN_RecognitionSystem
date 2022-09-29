using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OCR序列号识别系统注册机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();

            // Determines whether the data is in a format you can use.
            if (iData.GetDataPresent(DataFormats.Text))
            {
                // Yes it is, so display it in a text box.
                textBox1.Text = (String)iData.GetData(DataFormats.Text);
            }
            else
            {
                // No it is not.
                MessageBox.Show("剪贴板上无文本内容");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
          textBox2.Text=    Encrypt.Class_DES.DesEncrypt(Class_SoftRegister. CreatSerialNumber(textBox1.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ts1.Text = "1.0.0.0";
        }
    }
}
