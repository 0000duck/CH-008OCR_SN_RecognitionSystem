namespace Test_Automation
{
    partial class CompactLogixTCP_TAG
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modbusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etherIPClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tb_SOFT_VER = new System.Windows.Forms.ToolStripStatusLabel();
            this.tb_flag = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1s = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lb_test_time = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_ocr_result2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_OK_num = new System.Windows.Forms.Label();
            this.lb_Fail_num = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_plc_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.timer_read_start = new System.Windows.Forms.Timer(this.components);
            this.tb_sn = new System.Windows.Forms.TextBox();
            this.writesntoplc = new System.Windows.Forms.Button();
            this.btn_set_start1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_ocr_result1 = new System.Windows.Forms.Label();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMsg.Location = new System.Drawing.Point(1066, 641);
            this.btnSendMsg.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(177, 41);
            this.btnSendMsg.TabIndex = 0;
            this.btnSendMsg.Text = "识别";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // tb_log
            // 
            this.tb_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_log.Location = new System.Drawing.Point(599, 124);
            this.tb_log.Margin = new System.Windows.Forms.Padding(4);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.Size = new System.Drawing.Size(743, 213);
            this.tb_log.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(402, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 33);
            this.label3.TabIndex = 7;
            this.label3.Text = "OCR序列号识别系统";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "日志";
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.Location = new System.Drawing.Point(1131, 350);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(112, 34);
            this.btn_clear.TabIndex = 15;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.帮助ToolStripMenuItem,
            this.数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1355, 34);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modbusToolStripMenuItem,
            this.etherIPClientToolStripMenuItem,
            this.oPCToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(58, 28);
            this.toolStripMenuItem1.Text = "测试";
            // 
            // modbusToolStripMenuItem
            // 
            this.modbusToolStripMenuItem.Name = "modbusToolStripMenuItem";
            this.modbusToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.modbusToolStripMenuItem.Text = "Modbus";
            this.modbusToolStripMenuItem.Click += new System.EventHandler(this.modbusToolStripMenuItem_Click);
            // 
            // etherIPClientToolStripMenuItem
            // 
            this.etherIPClientToolStripMenuItem.Name = "etherIPClientToolStripMenuItem";
            this.etherIPClientToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.etherIPClientToolStripMenuItem.Text = "ABplc";
            this.etherIPClientToolStripMenuItem.Click += new System.EventHandler(this.etherIPClientToolStripMenuItem_Click);
            // 
            // oPCToolStripMenuItem
            // 
            this.oPCToolStripMenuItem.Name = "oPCToolStripMenuItem";
            this.oPCToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.oPCToolStripMenuItem.Text = "OPC";
            this.oPCToolStripMenuItem.Click += new System.EventHandler(this.oPCToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(128, 30);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tb_SOFT_VER});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1355, 29);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(226, 24);
            this.toolStripStatusLabel1.Text = "四川长虹电器股份有限公司";
            // 
            // tb_SOFT_VER
            // 
            this.tb_SOFT_VER.Name = "tb_SOFT_VER";
            this.tb_SOFT_VER.Size = new System.Drawing.Size(48, 24);
            this.tb_SOFT_VER.Text = "V1.0";
            // 
            // tb_flag
            // 
            this.tb_flag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_flag.Location = new System.Drawing.Point(1213, 392);
            this.tb_flag.Margin = new System.Windows.Forms.Padding(4);
            this.tb_flag.Name = "tb_flag";
            this.tb_flag.Size = new System.Drawing.Size(30, 28);
            this.tb_flag.TabIndex = 21;
            this.tb_flag.Text = "1";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1142, 397);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "flag：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(18, 124);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 558);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // timer1s
            // 
            this.timer1s.Interval = 1000;
            this.timer1s.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(589, 650);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "测试时间";
            // 
            // lb_test_time
            // 
            this.lb_test_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_test_time.AutoSize = true;
            this.lb_test_time.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_test_time.Location = new System.Drawing.Point(700, 630);
            this.lb_test_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_test_time.Name = "lb_test_time";
            this.lb_test_time.Size = new System.Drawing.Size(39, 41);
            this.lb_test_time.TabIndex = 24;
            this.lb_test_time.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(851, 650);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 18);
            this.label11.TabIndex = 25;
            this.label11.Text = "秒";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(589, 419);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 26;
            this.label10.Text = "识别结果";
            // 
            // lb_ocr_result2
            // 
            this.lb_ocr_result2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ocr_result2.AutoSize = true;
            this.lb_ocr_result2.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ocr_result2.ForeColor = System.Drawing.Color.Green;
            this.lb_ocr_result2.Location = new System.Drawing.Point(679, 543);
            this.lb_ocr_result2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ocr_result2.Name = "lb_ocr_result2";
            this.lb_ocr_result2.Size = new System.Drawing.Size(175, 60);
            this.lb_ocr_result2.TabIndex = 27;
            this.lb_ocr_result2.Text = "xxxxx";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 366);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 28;
            this.label1.Text = "已识别数量 ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(744, 366);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "未识别数量";
            // 
            // lb_OK_num
            // 
            this.lb_OK_num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_OK_num.AutoSize = true;
            this.lb_OK_num.Location = new System.Drawing.Point(704, 366);
            this.lb_OK_num.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_OK_num.Name = "lb_OK_num";
            this.lb_OK_num.Size = new System.Drawing.Size(17, 18);
            this.lb_OK_num.TabIndex = 30;
            this.lb_OK_num.Text = "0";
            // 
            // lb_Fail_num
            // 
            this.lb_Fail_num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Fail_num.AutoSize = true;
            this.lb_Fail_num.Location = new System.Drawing.Point(859, 366);
            this.lb_Fail_num.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Fail_num.Name = "lb_Fail_num";
            this.lb_Fail_num.Size = new System.Drawing.Size(17, 18);
            this.lb_Fail_num.TabIndex = 31;
            this.lb_Fail_num.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 32;
            this.label5.Text = "识别图片";
            // 
            // btn_start
            // 
            this.btn_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_start.Location = new System.Drawing.Point(1115, 419);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(177, 35);
            this.btn_start.TabIndex = 33;
            this.btn_start.Text = "自动开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_plc_connect
            // 
            this.btn_plc_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_plc_connect.Location = new System.Drawing.Point(827, 419);
            this.btn_plc_connect.Name = "btn_plc_connect";
            this.btn_plc_connect.Size = new System.Drawing.Size(138, 35);
            this.btn_plc_connect.TabIndex = 34;
            this.btn_plc_connect.Text = "建立PLC连接";
            this.btn_plc_connect.UseVisualStyleBackColor = true;
            this.btn_plc_connect.Click += new System.EventHandler(this.btn_plc_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_disconnect.Location = new System.Drawing.Point(971, 419);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(138, 35);
            this.btn_disconnect.TabIndex = 35;
            this.btn_disconnect.Text = "断开PLC连接";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // timer_read_start
            // 
            this.timer_read_start.Interval = 1000;
            this.timer_read_start.Tick += new System.EventHandler(this.timer_read_start_Tick);
            // 
            // tb_sn
            // 
            this.tb_sn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_sn.Location = new System.Drawing.Point(680, 64);
            this.tb_sn.Name = "tb_sn";
            this.tb_sn.Size = new System.Drawing.Size(201, 28);
            this.tb_sn.TabIndex = 38;
            // 
            // writesntoplc
            // 
            this.writesntoplc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.writesntoplc.Location = new System.Drawing.Point(891, 64);
            this.writesntoplc.Name = "writesntoplc";
            this.writesntoplc.Size = new System.Drawing.Size(148, 28);
            this.writesntoplc.TabIndex = 39;
            this.writesntoplc.Text = "writesntoplc";
            this.writesntoplc.UseVisualStyleBackColor = true;
            this.writesntoplc.Click += new System.EventHandler(this.writesntoplc_Click);
            // 
            // btn_set_start1
            // 
            this.btn_set_start1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_set_start1.Location = new System.Drawing.Point(1092, 59);
            this.btn_set_start1.Name = "btn_set_start1";
            this.btn_set_start1.Size = new System.Drawing.Size(112, 38);
            this.btn_set_start1.TabIndex = 40;
            this.btn_set_start1.Text = "set_start1";
            this.btn_set_start1.UseVisualStyleBackColor = true;
            this.btn_set_start1.Click += new System.EventHandler(this.btn_set_start1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 580);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "修正后：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(596, 482);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "修正前：";
            // 
            // lb_ocr_result1
            // 
            this.lb_ocr_result1.AutoSize = true;
            this.lb_ocr_result1.Location = new System.Drawing.Point(682, 482);
            this.lb_ocr_result1.Name = "lb_ocr_result1";
            this.lb_ocr_result1.Size = new System.Drawing.Size(89, 18);
            this.lb_ocr_result1.TabIndex = 43;
            this.lb_ocr_result1.Text = "xxxxxxxxx";
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.测试数据ToolStripMenuItem});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.数据ToolStripMenuItem.Text = "数据";
            // 
            // 测试数据ToolStripMenuItem
            // 
            this.测试数据ToolStripMenuItem.Name = "测试数据ToolStripMenuItem";
            this.测试数据ToolStripMenuItem.Size = new System.Drawing.Size(210, 30);
            this.测试数据ToolStripMenuItem.Text = "测试数据";
            this.测试数据ToolStripMenuItem.Click += new System.EventHandler(this.测试数据ToolStripMenuItem_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 736);
            this.Controls.Add(this.lb_ocr_result1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_set_start1);
            this.Controls.Add(this.writesntoplc);
            this.Controls.Add(this.tb_sn);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_plc_connect);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_Fail_num);
            this.Controls.Add(this.lb_OK_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_ocr_result2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_test_time);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_flag);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinClientOCR";
            this.Load += new System.EventHandler(this.Form_Comm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tb_SOFT_VER;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox tb_flag;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1s;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_test_time;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem etherIPClientToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_ocr_result2;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_OK_num;
        private System.Windows.Forms.Label lb_Fail_num;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem oPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modbusToolStripMenuItem;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_plc_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Timer timer_read_start;
        private System.Windows.Forms.TextBox tb_sn;
        private System.Windows.Forms.Button writesntoplc;
        private System.Windows.Forms.Button btn_set_start1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_ocr_result1;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试数据ToolStripMenuItem;
    }
}

