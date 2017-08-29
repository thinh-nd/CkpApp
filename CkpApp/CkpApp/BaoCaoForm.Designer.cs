namespace CkpApp
{
    partial class BaoCaoForm
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
            this.BcCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CtrCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DfromTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtoTb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.VatTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TdTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.GcRtb = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CpTb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NamTb = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BcCb
            // 
            this.BcCb.FormattingEnabled = true;
            this.BcCb.Items.AddRange(new object[] {
            "Báo cáo sản lượng công trình",
            "Báo cáo tổng hợp khối lượng, giá trị tháng",
            "Báo cáo tổng sản lượng năm",
            "Báo cáo khối lượng nhân viên"});
            this.BcCb.Location = new System.Drawing.Point(96, 12);
            this.BcCb.Name = "BcCb";
            this.BcCb.Size = new System.Drawing.Size(295, 21);
            this.BcCb.TabIndex = 1;
            this.BcCb.SelectionChangeCommitted += new System.EventHandler(this.BcCb_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại báo cáo";
            // 
            // CtrCb
            // 
            this.CtrCb.Enabled = false;
            this.CtrCb.FormattingEnabled = true;
            this.CtrCb.Location = new System.Drawing.Point(96, 62);
            this.CtrCb.Name = "CtrCb";
            this.CtrCb.Size = new System.Drawing.Size(282, 21);
            this.CtrCb.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Công trình";
            // 
            // DfromTb
            // 
            this.DfromTb.Enabled = false;
            this.DfromTb.Location = new System.Drawing.Point(96, 89);
            this.DfromTb.Name = "DfromTb";
            this.DfromTb.Size = new System.Drawing.Size(100, 20);
            this.DfromTb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Từ ngày";
            // 
            // DtoTb
            // 
            this.DtoTb.Enabled = false;
            this.DtoTb.Location = new System.Drawing.Point(96, 115);
            this.DtoTb.Name = "DtoTb";
            this.DtoTb.Size = new System.Drawing.Size(100, 20);
            this.DtoTb.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đến ngày";
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(114, 285);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(100, 23);
            this.ExportBtn.TabIndex = 10;
            this.ExportBtn.Text = "Xuất file Excel";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(220, 285);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 11;
            this.CloseBtn.Text = "Đóng";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.VatTb);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TdTb);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.GcRtb);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CpTb);
            this.groupBox2.Location = new System.Drawing.Point(12, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 125);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi phí khác";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(277, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "% VAT";
            // 
            // VatTb
            // 
            this.VatTb.Enabled = false;
            this.VatTb.Location = new System.Drawing.Point(322, 50);
            this.VatTb.Name = "VatTb";
            this.VatTb.Size = new System.Drawing.Size(44, 20);
            this.VatTb.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tiêu đề";
            // 
            // TdTb
            // 
            this.TdTb.Enabled = false;
            this.TdTb.Location = new System.Drawing.Point(64, 24);
            this.TdTb.Name = "TdTb";
            this.TdTb.Size = new System.Drawing.Size(302, 20);
            this.TdTb.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ghi chú";
            // 
            // GcRtb
            // 
            this.GcRtb.Enabled = false;
            this.GcRtb.Location = new System.Drawing.Point(64, 76);
            this.GcRtb.Name = "GcRtb";
            this.GcRtb.Size = new System.Drawing.Size(302, 39);
            this.GcRtb.TabIndex = 5;
            this.GcRtb.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Chi phí";
            // 
            // CpTb
            // 
            this.CpTb.Enabled = false;
            this.CpTb.Location = new System.Drawing.Point(64, 50);
            this.CpTb.Name = "CpTb";
            this.CpTb.Size = new System.Drawing.Size(120, 20);
            this.CpTb.TabIndex = 3;
            this.CpTb.Enter += new System.EventHandler(this.CpTb_Enter);
            this.CpTb.Leave += new System.EventHandler(this.CpTb_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.NamTb);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin báo cáo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Năm";
            // 
            // NamTb
            // 
            this.NamTb.Enabled = false;
            this.NamTb.Location = new System.Drawing.Point(266, 76);
            this.NamTb.Name = "NamTb";
            this.NamTb.Size = new System.Drawing.Size(100, 20);
            this.NamTb.TabIndex = 1;
            // 
            // BaoCaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 326);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtoTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DfromTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CtrCb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BcCb);
            this.Controls.Add(this.groupBox1);
            this.Name = "BaoCaoForm";
            this.Text = "Xuất báo cáo Excel";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BcCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CtrCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DfromTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DtoTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox GcRtb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CpTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TdTb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NamTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox VatTb;
    }
}