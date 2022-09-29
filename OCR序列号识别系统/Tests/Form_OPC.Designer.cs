namespace Test_Automation
{
    partial class Form_OPC
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
            this.btn_da_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_opcda = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ua_connect = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_write = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_readcontent = new System.Windows.Forms.Label();
            this.tb_write_value = new System.Windows.Forms.TextBox();
            this.tb_datachanged = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.btn_log_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_da_connect
            // 
            this.btn_da_connect.Location = new System.Drawing.Point(484, 162);
            this.btn_da_connect.Name = "btn_da_connect";
            this.btn_da_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_da_connect.TabIndex = 0;
            this.btn_da_connect.Text = "连接";
            this.btn_da_connect.UseVisualStyleBackColor = true;
            this.btn_da_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "连接地址DA：";
            // 
            // tb_opcda
            // 
            this.tb_opcda.Location = new System.Drawing.Point(130, 164);
            this.tb_opcda.Name = "tb_opcda";
            this.tb_opcda.Size = new System.Drawing.Size(338, 21);
            this.tb_opcda.TabIndex = 2;
            this.tb_opcda.Text = "opcda://127.0.0.1/ocr_opc";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(130, 191);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(338, 21);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "opc.tcp://127.0.0.1:26543/Workstation.RobotServer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "连接地址UA：";
            // 
            // btn_ua_connect
            // 
            this.btn_ua_connect.Location = new System.Drawing.Point(484, 189);
            this.btn_ua_connect.Name = "btn_ua_connect";
            this.btn_ua_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_ua_connect.TabIndex = 3;
            this.btn_ua_connect.Text = "连接";
            this.btn_ua_connect.UseVisualStyleBackColor = true;
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(265, 267);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 6;
            this.btn_read.Text = "读";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(151, 268);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(100, 21);
            this.tb_name.TabIndex = 7;
            this.tb_name.Text = "Robot1.Axis1";
            // 
            // btn_write
            // 
            this.btn_write.Location = new System.Drawing.Point(348, 298);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(75, 23);
            this.btn_write.TabIndex = 8;
            this.btn_write.Text = "写";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "标签：";
            // 
            // lb_readcontent
            // 
            this.lb_readcontent.AutoSize = true;
            this.lb_readcontent.Location = new System.Drawing.Point(346, 272);
            this.lb_readcontent.Name = "lb_readcontent";
            this.lb_readcontent.Size = new System.Drawing.Size(53, 12);
            this.lb_readcontent.TabIndex = 10;
            this.lb_readcontent.Text = "读出内容";
            // 
            // tb_write_value
            // 
            this.tb_write_value.Location = new System.Drawing.Point(265, 299);
            this.tb_write_value.Name = "tb_write_value";
            this.tb_write_value.Size = new System.Drawing.Size(77, 21);
            this.tb_write_value.TabIndex = 11;
            // 
            // tb_datachanged
            // 
            this.tb_datachanged.Location = new System.Drawing.Point(289, 358);
            this.tb_datachanged.Name = "tb_datachanged";
            this.tb_datachanged.Size = new System.Drawing.Size(75, 23);
            this.tb_datachanged.TabIndex = 12;
            this.tb_datachanged.Text = "数据变更检测";
            this.tb_datachanged.UseVisualStyleBackColor = true;
            this.tb_datachanged.Click += new System.EventHandler(this.tb_datachanged_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(587, 91);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(341, 422);
            this.tb_log.TabIndex = 13;
            // 
            // btn_log_clear
            // 
            this.btn_log_clear.Location = new System.Drawing.Point(853, 538);
            this.btn_log_clear.Name = "btn_log_clear";
            this.btn_log_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_log_clear.TabIndex = 14;
            this.btn_log_clear.Text = "清空";
            this.btn_log_clear.UseVisualStyleBackColor = true;
            this.btn_log_clear.Click += new System.EventHandler(this.btn_log_clear_Click);
            // 
            // Form_OPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 588);
            this.Controls.Add(this.btn_log_clear);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.tb_datachanged);
            this.Controls.Add(this.tb_write_value);
            this.Controls.Add(this.lb_readcontent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.btn_read);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ua_connect);
            this.Controls.Add(this.tb_opcda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_da_connect);
            this.Name = "Form_OPC";
            this.Text = "Form_OPC";
            this.Load += new System.EventHandler(this.Form_OPC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_da_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_opcda;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ua_connect;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_readcontent;
        private System.Windows.Forms.TextBox tb_write_value;
        private System.Windows.Forms.Button tb_datachanged;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button btn_log_clear;
    }
}