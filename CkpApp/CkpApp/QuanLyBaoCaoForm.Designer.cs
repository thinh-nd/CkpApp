namespace CkpApp
{
    partial class QuanLyBaoCaoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DateTb = new System.Windows.Forms.TextBox();
            this.NvCb = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MbCb = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DtoTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DfromTb = new System.Windows.Forms.TextBox();
            this.KhCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CtrCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.BaoCaoGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MayBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiBaoCao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySuaCuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.ActionGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DateTb);
            this.groupBox1.Controls.Add(this.NvCb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.MbCb);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ResetBtn);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DtoTb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DfromTb);
            this.groupBox1.Controls.Add(this.KhCb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CtrCb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(491, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Vào ngày";
            // 
            // DateTb
            // 
            this.DateTb.Location = new System.Drawing.Point(549, 14);
            this.DateTb.Name = "DateTb";
            this.DateTb.Size = new System.Drawing.Size(100, 20);
            this.DateTb.TabIndex = 14;
            // 
            // NvCb
            // 
            this.NvCb.FormattingEnabled = true;
            this.NvCb.Location = new System.Drawing.Point(267, 67);
            this.NvCb.Name = "NvCb";
            this.NvCb.Size = new System.Drawing.Size(216, 21);
            this.NvCb.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nhân viên";
            // 
            // MbCb
            // 
            this.MbCb.FormattingEnabled = true;
            this.MbCb.Location = new System.Drawing.Point(78, 67);
            this.MbCb.Name = "MbCb";
            this.MbCb.Size = new System.Drawing.Size(121, 21);
            this.MbCb.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tổ bơm";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(655, 17);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(74, 32);
            this.ResetBtn.TabIndex = 12;
            this.ResetBtn.Text = "Nhập lại";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(655, 57);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(74, 32);
            this.SearchBtn.TabIndex = 13;
            this.SearchBtn.Text = "Tìm kiếm";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Đến ngày";
            // 
            // DtoTb
            // 
            this.DtoTb.Location = new System.Drawing.Point(549, 69);
            this.DtoTb.Name = "DtoTb";
            this.DtoTb.Size = new System.Drawing.Size(100, 20);
            this.DtoTb.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(497, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Từ ngày";
            // 
            // DfromTb
            // 
            this.DfromTb.Location = new System.Drawing.Point(549, 43);
            this.DfromTb.Name = "DfromTb";
            this.DfromTb.Size = new System.Drawing.Size(100, 20);
            this.DfromTb.TabIndex = 9;
            // 
            // KhCb
            // 
            this.KhCb.FormattingEnabled = true;
            this.KhCb.Location = new System.Drawing.Point(77, 40);
            this.KhCb.Name = "KhCb";
            this.KhCb.Size = new System.Drawing.Size(406, 21);
            this.KhCb.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Khách hàng";
            // 
            // CtrCb
            // 
            this.CtrCb.FormattingEnabled = true;
            this.CtrCb.Location = new System.Drawing.Point(77, 12);
            this.CtrCb.Name = "CtrCb";
            this.CtrCb.Size = new System.Drawing.Size(406, 21);
            this.CtrCb.TabIndex = 1;
            this.CtrCb.SelectionChangeCommitted += new System.EventHandler(this.CtrCb_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Công trình";
            // 
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Location = new System.Drawing.Point(13, 118);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 83);
            this.ActionGrp.TabIndex = 2;
            this.ActionGrp.TabStop = false;
            this.ActionGrp.Text = "Thao tác";
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(6, 50);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(58, 25);
            this.DelBtn.TabIndex = 1;
            this.DelBtn.Text = "Xóa";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(6, 19);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(58, 25);
            this.EditBtn.TabIndex = 0;
            this.EditBtn.Text = "Sửa";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // BaoCaoGrid
            // 
            this.BaoCaoGrid.AllowUserToAddRows = false;
            this.BaoCaoGrid.AllowUserToDeleteRows = false;
            this.BaoCaoGrid.AllowUserToOrderColumns = true;
            this.BaoCaoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaoCaoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BaoCaoGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Ngay,
            this.TenCongTrinh,
            this.KhachHang,
            this.MayBom,
            this.NguoiBaoCao,
            this.NgayTao,
            this.NgaySuaCuoi});
            this.BaoCaoGrid.Location = new System.Drawing.Point(91, 118);
            this.BaoCaoGrid.Name = "BaoCaoGrid";
            this.BaoCaoGrid.ReadOnly = true;
            this.BaoCaoGrid.Size = new System.Drawing.Size(933, 364);
            this.BaoCaoGrid.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Ngay
            // 
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            // 
            // TenCongTrinh
            // 
            this.TenCongTrinh.HeaderText = "Tên công trình";
            this.TenCongTrinh.Name = "TenCongTrinh";
            this.TenCongTrinh.ReadOnly = true;
            // 
            // KhachHang
            // 
            this.KhachHang.HeaderText = "Công ty";
            this.KhachHang.Name = "KhachHang";
            this.KhachHang.ReadOnly = true;
            // 
            // MayBom
            // 
            this.MayBom.HeaderText = "Máy bơm";
            this.MayBom.Name = "MayBom";
            this.MayBom.ReadOnly = true;
            // 
            // NguoiBaoCao
            // 
            this.NguoiBaoCao.HeaderText = "Người báo cáo";
            this.NguoiBaoCao.Name = "NguoiBaoCao";
            this.NguoiBaoCao.ReadOnly = true;
            // 
            // NgayTao
            // 
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.ReadOnly = true;
            // 
            // NgaySuaCuoi
            // 
            this.NgaySuaCuoi.HeaderText = "Ngày sửa cuối";
            this.NgaySuaCuoi.Name = "NgaySuaCuoi";
            this.NgaySuaCuoi.ReadOnly = true;
            // 
            // QuanLyBaoCaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 494);
            this.Controls.Add(this.BaoCaoGrid);
            this.Controls.Add(this.ActionGrp);
            this.Controls.Add(this.groupBox1);
            this.Name = "QuanLyBaoCaoForm";
            this.Text = "Quản lý báo cáo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ActionGrp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DtoTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DfromTb;
        private System.Windows.Forms.ComboBox KhCb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CtrCb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.DataGridView BaoCaoGrid;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.ComboBox NvCb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox MbCb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DateTb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MayBom;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiBaoCao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySuaCuoi;
    }
}