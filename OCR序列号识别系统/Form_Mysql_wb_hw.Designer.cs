namespace Test_Automation
{
    partial class Form_Mysql_wb_hw
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1227, 673);
            this.dataGridView1.TabIndex = 1;
            // 
            // btn_toexcel
            // 
            this.btn_toexcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_toexcel.Location = new System.Drawing.Point(881, 737);
            this.btn_toexcel.Name = "btn_toexcel";
            this.btn_toexcel.Size = new System.Drawing.Size(111, 34);
            this.btn_toexcel.TabIndex = 57;
            this.btn_toexcel.Text = "导出成电子表格";
            this.btn_toexcel.UseVisualStyleBackColor = true;
            this.btn_toexcel.Click += new System.EventHandler(this.btn_toexcel_Click);
            // 
            // btn_readall
            // 
            this.btn_readall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_readall.Location = new System.Drawing.Point(669, 737);
            this.btn_readall.Name = "btn_readall";
            this.btn_readall.Size = new System.Drawing.Size(113, 34);
            this.btn_readall.TabIndex = 56;
            this.btn_readall.Text = "读取全部";
            this.btn_readall.UseVisualStyleBackColor = true;
            this.btn_readall.Click += new System.EventHandler(this.btn_readall_Click);
            // 
            // btn100
            // 
            this.btn100.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn100.Location = new System.Drawing.Point(463, 737);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(113, 34);
            this.btn100.TabIndex = 55;
            this.btn100.Text = "读取最近100";
            this.btn100.UseVisualStyleBackColor = true;
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // Form_Mysql_wb_hw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 794);
            this.Controls.Add(this.btn_toexcel);
            this.Controls.Add(this.btn_readall);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_Mysql_wb_hw";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GAMMA测试数据";
            this.Load += new System.EventHandler(this.Form_Mysql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_toexcel;
        private System.Windows.Forms.Button btn_readall;
        private System.Windows.Forms.Button btn100;
    }
}