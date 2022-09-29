namespace Test_Automation
{
    partial class Form_Mysql_TestData
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_toexcel = new System.Windows.Forms.Button();
            this.btn_readall = new System.Windows.Forms.Button();
            this.btn100 = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_today = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_phpmyadmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(816, 572);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_toexcel
            // 
            this.btn_toexcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_toexcel.Location = new System.Drawing.Point(904, 289);
            this.btn_toexcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_toexcel.Name = "btn_toexcel";
            this.btn_toexcel.Size = new System.Drawing.Size(166, 51);
            this.btn_toexcel.TabIndex = 57;
            this.btn_toexcel.Text = "导出成电子表格";
            this.btn_toexcel.UseVisualStyleBackColor = true;
            this.btn_toexcel.Click += new System.EventHandler(this.btn_toexcel_Click);
            // 
            // btn_readall
            // 
            this.btn_readall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_readall.Location = new System.Drawing.Point(901, 221);
            this.btn_readall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_readall.Name = "btn_readall";
            this.btn_readall.Size = new System.Drawing.Size(170, 51);
            this.btn_readall.TabIndex = 56;
            this.btn_readall.Text = "读取全部";
            this.btn_readall.UseVisualStyleBackColor = true;
            this.btn_readall.Click += new System.EventHandler(this.btn_readall_Click);
            // 
            // btn100
            // 
            this.btn100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn100.Location = new System.Drawing.Point(904, 18);
            this.btn100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(170, 51);
            this.btn100.TabIndex = 55;
            this.btn100.Text = "读取最近100";
            this.btn100.UseVisualStyleBackColor = true;
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(982, 465);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(112, 34);
            this.btn_search.TabIndex = 58;
            this.btn_search.Text = "查找\r\n";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(886, 366);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 36);
            this.label1.TabIndex = 59;
            this.label1.Text = "输入SN\r\n(可输入部分进行模糊查找)";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(886, 429);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 28);
            this.textBox1.TabIndex = 60;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btn_today
            // 
            this.btn_today.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_today.Location = new System.Drawing.Point(904, 87);
            this.btn_today.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_today.Name = "btn_today";
            this.btn_today.Size = new System.Drawing.Size(166, 51);
            this.btn_today.TabIndex = 61;
            this.btn_today.Text = "读取今日数据 ";
            this.btn_today.UseVisualStyleBackColor = true;
            this.btn_today.Click += new System.EventHandler(this.btn_today_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(901, 154);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 51);
            this.button2.TabIndex = 62;
            this.button2.Text = "读取全部NG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_phpmyadmin
            // 
            this.btn_phpmyadmin.Location = new System.Drawing.Point(982, 528);
            this.btn_phpmyadmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_phpmyadmin.Name = "btn_phpmyadmin";
            this.btn_phpmyadmin.Size = new System.Drawing.Size(112, 60);
            this.btn_phpmyadmin.TabIndex = 63;
            this.btn_phpmyadmin.Text = "phpmyadmin数据管理";
            this.btn_phpmyadmin.UseVisualStyleBackColor = true;
            this.btn_phpmyadmin.Click += new System.EventHandler(this.btn_phpmyadmin_Click);
            // 
            // Form_Mysql_TestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 603);
            this.Controls.Add(this.btn_phpmyadmin);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_today);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_toexcel);
            this.Controls.Add(this.btn_readall);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Mysql_TestData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "测试数据";
            this.Load += new System.EventHandler(this.Form_Mysql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_toexcel;
        private System.Windows.Forms.Button btn_readall;
        private System.Windows.Forms.Button btn100;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_today;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_phpmyadmin;
    }
}