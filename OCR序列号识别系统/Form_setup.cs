using System;
using System.Windows.Forms;

namespace Test_Automation
{
    public partial class Form_setup : Form
    {
        Form_Main fmain1;
        public Form_setup(Form_Main fmain)
        {
            fmain1 = fmain;
            InitializeComponent();
        }

        private void Form_setup_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            WORKSTATIONID.Text = config_json.WORKSTATIONID;
            form_server_name.Text = config_json.form_server_name;
            form_client_name.Text = config_json.form_client_name;
            cmd_get_ocr_result.Text = config_json.cmd_get_ocr_result;
            cb_flag.Checked = config_json.ocr_flag;
            length_min.Text = config_json.length_min.ToString();
            length_max.Text = config_json.length_max.ToString();
            pass.Text = Encrypt.Class_DES.DesDecrypt(config_json.pass);

            tag_ready.Text=config_json.tag_ready;
            tag_start.Text = config_json.tag_start;
            tag_done.Text = config_json.tag_done;
            tag_data.Text = config_json.tag_data;
            LocalIP.Text = config_json.LocalIP;
            RemoteIP.Text = config_json.RemoteIP;
            RemotePort.Text = config_json.RemotePort;
            pre_strings.Text = config_json.pre_strings;

            TestMaxSeconds.Text = config_json.TestMaxSeconds;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(config_json.config_file_path))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("d:\\软件配置");
                if (di.Exists == false) di.Create();

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(config_json.config_file_path, true))
                {
                    writer.WriteLine("{}");
                    writer.Close();
                }
            }

            string json = System.IO.File.ReadAllText(config_json.config_file_path);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);


            jsonObj["WORKSTATIONID"] = WORKSTATIONID.Text;
            jsonObj["form_server_name"] = form_server_name.Text;
            jsonObj["form_client_name"] = form_client_name.Text;
            jsonObj["cmd_get_ocr_result"] = cmd_get_ocr_result.Text;
            jsonObj["ocr_flag"] = cb_flag.Checked.ToString();

            jsonObj["length_min"] = length_min.Text;
            jsonObj["length_max"] = length_max.Text;

            jsonObj["pass"] = Encrypt.Class_DES.DesEncrypt(pass.Text);

            jsonObj["tag_ready"] = tag_ready.Text;
            jsonObj["tag_start"] = tag_start.Text;
            jsonObj["tag_done"] = tag_done.Text;
            jsonObj["tag_data"] = tag_data.Text;
            jsonObj["LocalIP"] = LocalIP.Text;
            jsonObj["RemoteIP"] = RemoteIP.Text;
            jsonObj["RemotePort"] = RemotePort.Text;
            jsonObj["pre_strings"] = pre_strings.Text;

            jsonObj["TestMaxSeconds"] = TestMaxSeconds.Text;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(config_json.config_file_path, output);
            config_json.ReadAll();
            fmain1.windows_init();
            MessageBox.Show("保存成功！");
        }
    }
}
