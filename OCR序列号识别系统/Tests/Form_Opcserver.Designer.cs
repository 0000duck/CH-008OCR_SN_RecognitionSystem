namespace Test_Automation
{
    partial class Form_Opcserver
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
            this.btnSetGroupPro = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtWriteTagValue = new System.Windows.Forms.TextBox();
            this.txtRemoteServerIP = new System.Windows.Forms.TextBox();
            this.txtTagValue = new System.Windows.Forms.TextBox();
            this.txtQualities = new System.Windows.Forms.TextBox();
            this.txtTimeStamps = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblState = new System.Windows.Forms.Label();
            this.tsslServerState = new System.Windows.Forms.StatusStrip();
            this.tsslServerStartTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslversion = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtGroupIsActive = new System.Windows.Forms.TextBox();
            this.txtGroupDeadband = new System.Windows.Forms.TextBox();
            this.txtUpdateRate = new System.Windows.Forms.TextBox();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.txtIsSubscribed = new System.Windows.Forms.TextBox();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.btnConnServer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tsslServerState.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetGroupPro
            // 
            this.btnSetGroupPro.Location = new System.Drawing.Point(777, 30);
            this.btnSetGroupPro.Name = "btnSetGroupPro";
            this.btnSetGroupPro.Size = new System.Drawing.Size(171, 38);
            this.btnSetGroupPro.TabIndex = 0;
            this.btnSetGroupPro.Text = "btnSetGroupPro";
            this.btnSetGroupPro.UseVisualStyleBackColor = true;
            this.btnSetGroupPro.Click += new System.EventHandler(this.btnSetGroupPro_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(934, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "btnConnLocalServer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "btnWrite";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtWriteTagValue
            // 
            this.txtWriteTagValue.Location = new System.Drawing.Point(628, 260);
            this.txtWriteTagValue.Name = "txtWriteTagValue";
            this.txtWriteTagValue.Size = new System.Drawing.Size(100, 28);
            this.txtWriteTagValue.TabIndex = 3;
            // 
            // txtRemoteServerIP
            // 
            this.txtRemoteServerIP.Location = new System.Drawing.Point(503, 173);
            this.txtRemoteServerIP.Name = "txtRemoteServerIP";
            this.txtRemoteServerIP.Size = new System.Drawing.Size(158, 28);
            this.txtRemoteServerIP.TabIndex = 4;
            this.txtRemoteServerIP.Text = "192.168.3.230";
            // 
            // txtTagValue
            // 
            this.txtTagValue.Location = new System.Drawing.Point(585, 355);
            this.txtTagValue.Name = "txtTagValue";
            this.txtTagValue.Size = new System.Drawing.Size(100, 28);
            this.txtTagValue.TabIndex = 6;
            // 
            // txtQualities
            // 
            this.txtQualities.Location = new System.Drawing.Point(585, 389);
            this.txtQualities.Name = "txtQualities";
            this.txtQualities.Size = new System.Drawing.Size(100, 28);
            this.txtQualities.TabIndex = 7;
            // 
            // txtTimeStamps
            // 
            this.txtTimeStamps.Location = new System.Drawing.Point(585, 423);
            this.txtTimeStamps.Name = "txtTimeStamps";
            this.txtTimeStamps.Size = new System.Drawing.Size(100, 28);
            this.txtTimeStamps.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(42, 37);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(258, 454);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(848, 106);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(80, 18);
            this.lblState.TabIndex = 10;
            this.lblState.Text = "lblState";
            // 
            // tsslServerState
            // 
            this.tsslServerState.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsslServerState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslServerStartTime,
            this.tsslversion});
            this.tsslServerState.Location = new System.Drawing.Point(0, 489);
            this.tsslServerState.Name = "tsslServerState";
            this.tsslServerState.Size = new System.Drawing.Size(1441, 29);
            this.tsslServerState.TabIndex = 11;
            this.tsslServerState.Text = "tsslServerState";
            // 
            // tsslServerStartTime
            // 
            this.tsslServerStartTime.Name = "tsslServerStartTime";
            this.tsslServerStartTime.Size = new System.Drawing.Size(195, 24);
            this.tsslServerStartTime.Text = "toolStripStatusLabel1";
            // 
            // tsslversion
            // 
            this.tsslversion.Name = "tsslversion";
            this.tsslversion.Size = new System.Drawing.Size(195, 24);
            this.tsslversion.Text = "toolStripStatusLabel1";
            // 
            // txtGroupIsActive
            // 
            this.txtGroupIsActive.Location = new System.Drawing.Point(1087, 243);
            this.txtGroupIsActive.Name = "txtGroupIsActive";
            this.txtGroupIsActive.Size = new System.Drawing.Size(100, 28);
            this.txtGroupIsActive.TabIndex = 12;
            // 
            // txtGroupDeadband
            // 
            this.txtGroupDeadband.Location = new System.Drawing.Point(1087, 289);
            this.txtGroupDeadband.Name = "txtGroupDeadband";
            this.txtGroupDeadband.Size = new System.Drawing.Size(100, 28);
            this.txtGroupDeadband.TabIndex = 13;
            // 
            // txtUpdateRate
            // 
            this.txtUpdateRate.Location = new System.Drawing.Point(1087, 337);
            this.txtUpdateRate.Name = "txtUpdateRate";
            this.txtUpdateRate.Size = new System.Drawing.Size(100, 28);
            this.txtUpdateRate.TabIndex = 14;
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(1087, 386);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(100, 28);
            this.txtIsActive.TabIndex = 15;
            // 
            // txtIsSubscribed
            // 
            this.txtIsSubscribed.Location = new System.Drawing.Point(1087, 435);
            this.txtIsSubscribed.Name = "txtIsSubscribed";
            this.txtIsSubscribed.Size = new System.Drawing.Size(100, 28);
            this.txtIsSubscribed.TabIndex = 16;
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(667, 170);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(261, 26);
            this.cmbServerName.TabIndex = 17;
            // 
            // btnConnServer
            // 
            this.btnConnServer.Location = new System.Drawing.Point(972, 37);
            this.btnConnServer.Name = "btnConnServer";
            this.btnConnServer.Size = new System.Drawing.Size(175, 47);
            this.btnConnServer.TabIndex = 18;
            this.btnConnServer.Text = "btnConnServer";
            this.btnConnServer.UseVisualStyleBackColor = true;
            this.btnConnServer.Click += new System.EventHandler(this.btnConnServer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "txtRemoteServerIP";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(461, 263);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(152, 18);
            this.lb1.TabIndex = 20;
            this.lb1.Text = "txtWriteTagValue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "TagValue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "Qualities";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "TimeStamps";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(956, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "GroupIsActive";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(959, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "GroupDeadband";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(959, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "UpdateRate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(977, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 18);
            this.label8.TabIndex = 27;
            this.label8.Text = "sActive";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(959, 435);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "IsSubscribed";
            // 
            // Form_Opcserver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 518);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnServer);
            this.Controls.Add(this.cmbServerName);
            this.Controls.Add(this.txtIsSubscribed);
            this.Controls.Add(this.txtIsActive);
            this.Controls.Add(this.txtUpdateRate);
            this.Controls.Add(this.txtGroupDeadband);
            this.Controls.Add(this.txtGroupIsActive);
            this.Controls.Add(this.tsslServerState);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtTimeStamps);
            this.Controls.Add(this.txtQualities);
            this.Controls.Add(this.txtTagValue);
            this.Controls.Add(this.txtRemoteServerIP);
            this.Controls.Add(this.txtWriteTagValue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSetGroupPro);
            this.Name = "Form_Opcserver";
            this.Text = "Form_Opcserver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Opcserver_FormClosing);
            this.Load += new System.EventHandler(this.Form_Opcserver_Load);
            this.tsslServerState.ResumeLayout(false);
            this.tsslServerState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetGroupPro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtWriteTagValue;
        private System.Windows.Forms.TextBox txtRemoteServerIP;
        private System.Windows.Forms.TextBox txtTagValue;
        private System.Windows.Forms.TextBox txtQualities;
        private System.Windows.Forms.TextBox txtTimeStamps;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.StatusStrip tsslServerState;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerStartTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslversion;
        private System.Windows.Forms.TextBox txtGroupIsActive;
        private System.Windows.Forms.TextBox txtGroupDeadband;
        private System.Windows.Forms.TextBox txtUpdateRate;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.TextBox txtIsSubscribed;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnConnServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}