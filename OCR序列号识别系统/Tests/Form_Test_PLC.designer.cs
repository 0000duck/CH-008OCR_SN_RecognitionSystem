namespace Test_Automation
{
    partial class Form_Test_PLC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_connect_info = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPLC_station = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPLC_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPLC_ip = new System.Windows.Forms.TextBox();
            this.btn_client_disconnect = new System.Windows.Forms.Button();
            this.btn_client_connect = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ready = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tb_start = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tb_done = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tb_data = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_data_value = new System.Windows.Forms.TextBox();
            this.tb_done_value = new System.Windows.Forms.TextBox();
            this.tb_start_value = new System.Windows.Forms.TextBox();
            this.tb_ready_value = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lb_connect_info
            // 
            this.lb_connect_info.AutoSize = true;
            this.lb_connect_info.Location = new System.Drawing.Point(566, 240);
            this.lb_connect_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_connect_info.Name = "lb_connect_info";
            this.lb_connect_info.Size = new System.Drawing.Size(89, 18);
            this.lb_connect_info.TabIndex = 36;
            this.lb_connect_info.Text = "未连接PLC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 250);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 18);
            this.label6.TabIndex = 35;
            this.label6.Text = "Station：";
            // 
            // tbPLC_station
            // 
            this.tbPLC_station.Location = new System.Drawing.Point(174, 246);
            this.tbPLC_station.Margin = new System.Windows.Forms.Padding(4);
            this.tbPLC_station.Name = "tbPLC_station";
            this.tbPLC_station.Size = new System.Drawing.Size(118, 28);
            this.tbPLC_station.TabIndex = 34;
            this.tbPLC_station.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "Port：";
            // 
            // tbPLC_port
            // 
            this.tbPLC_port.Location = new System.Drawing.Point(174, 200);
            this.tbPLC_port.Margin = new System.Windows.Forms.Padding(4);
            this.tbPLC_port.Name = "tbPLC_port";
            this.tbPLC_port.Size = new System.Drawing.Size(118, 28);
            this.tbPLC_port.TabIndex = 32;
            this.tbPLC_port.Text = "502";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "IP：";
            // 
            // tbPLC_ip
            // 
            this.tbPLC_ip.Location = new System.Drawing.Point(174, 159);
            this.tbPLC_ip.Margin = new System.Windows.Forms.Padding(4);
            this.tbPLC_ip.Name = "tbPLC_ip";
            this.tbPLC_ip.Size = new System.Drawing.Size(150, 28);
            this.tbPLC_ip.TabIndex = 30;
            this.tbPLC_ip.Text = "127.0.0.1";
            // 
            // btn_client_disconnect
            // 
            this.btn_client_disconnect.Enabled = false;
            this.btn_client_disconnect.Location = new System.Drawing.Point(340, 225);
            this.btn_client_disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_client_disconnect.Name = "btn_client_disconnect";
            this.btn_client_disconnect.Size = new System.Drawing.Size(206, 70);
            this.btn_client_disconnect.TabIndex = 20;
            this.btn_client_disconnect.Text = "断开服务端";
            this.btn_client_disconnect.UseVisualStyleBackColor = true;
            this.btn_client_disconnect.Click += new System.EventHandler(this.btn_client_disconnect_Click);
            // 
            // btn_client_connect
            // 
            this.btn_client_connect.Location = new System.Drawing.Point(340, 146);
            this.btn_client_connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_client_connect.Name = "btn_client_connect";
            this.btn_client_connect.Size = new System.Drawing.Size(206, 70);
            this.btn_client_connect.TabIndex = 21;
            this.btn_client_connect.Text = "连接服务端";
            this.btn_client_connect.UseVisualStyleBackColor = true;
            this.btn_client_connect.Click += new System.EventHandler(this.btn_client_connect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(352, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(327, 41);
            this.label7.TabIndex = 82;
            this.label7.Text = "PLC读写控制测试";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 18);
            this.label1.TabIndex = 83;
            this.label1.Text = "识别系统已准备完毕";
            // 
            // tb_ready
            // 
            this.tb_ready.Location = new System.Drawing.Point(194, 323);
            this.tb_ready.Name = "tb_ready";
            this.tb_ready.Size = new System.Drawing.Size(36, 28);
            this.tb_ready.TabIndex = 84;
            this.tb_ready.Text = "2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 85;
            this.button1.Text = "写入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(559, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 86;
            this.button2.Text = "读取";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(944, 532);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 43);
            this.button3.TabIndex = 88;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(559, 373);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 26);
            this.button4.TabIndex = 92;
            this.button4.Text = "读取";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(461, 373);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 26);
            this.button5.TabIndex = 91;
            this.button5.Text = "写入";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(194, 371);
            this.tb_start.Name = "tb_start";
            this.tb_start.Size = new System.Drawing.Size(36, 28);
            this.tb_start.TabIndex = 90;
            this.tb_start.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 377);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 89;
            this.label2.Text = "开始识别";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(559, 419);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 26);
            this.button6.TabIndex = 96;
            this.button6.Text = "读取";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(461, 419);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 26);
            this.button7.TabIndex = 95;
            this.button7.Text = "写入";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tb_done
            // 
            this.tb_done.Location = new System.Drawing.Point(194, 417);
            this.tb_done.Name = "tb_done";
            this.tb_done.Size = new System.Drawing.Size(36, 28);
            this.tb_done.TabIndex = 94;
            this.tb_done.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 93;
            this.label3.Text = "识别完成";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(559, 463);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 26);
            this.button8.TabIndex = 100;
            this.button8.Text = "读取";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(461, 467);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 26);
            this.button9.TabIndex = 99;
            this.button9.Text = "写入";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // tb_data
            // 
            this.tb_data.Location = new System.Drawing.Point(194, 465);
            this.tb_data.Name = "tb_data";
            this.tb_data.Size = new System.Drawing.Size(36, 28);
            this.tb_data.TabIndex = 98;
            this.tb_data.Text = "200";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 471);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 97;
            this.label8.Text = "识别数据";
            // 
            // tb_data_value
            // 
            this.tb_data_value.Location = new System.Drawing.Point(245, 465);
            this.tb_data_value.Name = "tb_data_value";
            this.tb_data_value.Size = new System.Drawing.Size(198, 28);
            this.tb_data_value.TabIndex = 104;
            this.tb_data_value.Text = "abcd";
            // 
            // tb_done_value
            // 
            this.tb_done_value.Location = new System.Drawing.Point(245, 417);
            this.tb_done_value.Name = "tb_done_value";
            this.tb_done_value.Size = new System.Drawing.Size(36, 28);
            this.tb_done_value.TabIndex = 103;
            this.tb_done_value.Text = "1";
            // 
            // tb_start_value
            // 
            this.tb_start_value.Location = new System.Drawing.Point(245, 371);
            this.tb_start_value.Name = "tb_start_value";
            this.tb_start_value.Size = new System.Drawing.Size(36, 28);
            this.tb_start_value.TabIndex = 102;
            this.tb_start_value.Text = "1";
            // 
            // tb_ready_value
            // 
            this.tb_ready_value.Location = new System.Drawing.Point(245, 323);
            this.tb_ready_value.Name = "tb_ready_value";
            this.tb_ready_value.Size = new System.Drawing.Size(36, 28);
            this.tb_ready_value.TabIndex = 101;
            this.tb_ready_value.Text = "1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(673, 67);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(361, 449);
            this.richTextBox1.TabIndex = 105;
            this.richTextBox1.Text = "";
            // 
            // Form_Test_PLC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 587);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tb_data_value);
            this.Controls.Add(this.tb_done_value);
            this.Controls.Add(this.tb_start_value);
            this.Controls.Add(this.tb_ready_value);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.tb_data);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.tb_done);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tb_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_ready);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lb_connect_info);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPLC_station);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPLC_port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPLC_ip);
            this.Controls.Add(this.btn_client_disconnect);
            this.Controls.Add(this.btn_client_connect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Test_PLC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLC测试";
            this.Load += new System.EventHandler(this.Form_PLC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_connect_info;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPLC_station;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPLC_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPLC_ip;
        private System.Windows.Forms.Button btn_client_disconnect;
        private System.Windows.Forms.Button btn_client_connect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ready;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tb_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox tb_done;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox tb_data;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_data_value;
        private System.Windows.Forms.TextBox tb_done_value;
        private System.Windows.Forms.TextBox tb_start_value;
        private System.Windows.Forms.TextBox tb_ready_value;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}