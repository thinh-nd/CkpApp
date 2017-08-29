namespace CkpApp
{
    partial class DonGiaForm
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
            this.DonGiaGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGiaVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinBomCan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinBomTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CC1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackPtCC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TienBackCC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetCC2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DcTBox = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.KhTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CtrCb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ActionGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // DonGiaGrid
            // 
            this.DonGiaGrid.AllowUserToAddRows = false;
            this.DonGiaGrid.AllowUserToDeleteRows = false;
            this.DonGiaGrid.AllowUserToOrderColumns = true;
            this.DonGiaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DonGiaGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Ten,
            this.DonGia,
            this.DonGiaVAT,
            this.MinBomCan,
            this.MinBomTinh,
            this.CC1,
            this.TongCC2,
            this.BackPtCC2,
            this.TienBackCC2,
            this.NetCC2,
            this.TongTienVAT,
            this.TongVAT,
            this.TongTien,
            this.TongCC,
            this.CongThuc,
            this.GhiChu});
            this.DonGiaGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DonGiaGrid.Location = new System.Drawing.Point(3, 16);
            this.DonGiaGrid.Name = "DonGiaGrid";
            this.DonGiaGrid.ReadOnly = true;
            this.DonGiaGrid.Size = new System.Drawing.Size(775, 225);
            this.DonGiaGrid.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Ten
            // 
            this.Ten.HeaderText = "Tên đơn giá";
            this.Ten.Name = "Ten";
            this.Ten.ReadOnly = true;
            // 
            // DonGia
            // 
            this.DonGia.HeaderText = "Đơn giá (chưa VAT)";
            this.DonGia.Name = "DonGia";
            this.DonGia.ReadOnly = true;
            // 
            // DonGiaVAT
            // 
            this.DonGiaVAT.HeaderText = "Đơn giá (có VAT)";
            this.DonGiaVAT.Name = "DonGiaVAT";
            this.DonGiaVAT.ReadOnly = true;
            // 
            // MinBomCan
            // 
            this.MinBomCan.HeaderText = "KL tối thiểu (bơm cần)";
            this.MinBomCan.Name = "MinBomCan";
            this.MinBomCan.ReadOnly = true;
            // 
            // MinBomTinh
            // 
            this.MinBomTinh.HeaderText = "KL tối thiểu (bơm tĩnh)";
            this.MinBomTinh.Name = "MinBomTinh";
            this.MinBomTinh.ReadOnly = true;
            // 
            // CC1
            // 
            this.CC1.HeaderText = "Tiền CC1";
            this.CC1.Name = "CC1";
            this.CC1.ReadOnly = true;
            // 
            // TongCC2
            // 
            this.TongCC2.HeaderText = "Tổng CC2";
            this.TongCC2.Name = "TongCC2";
            this.TongCC2.ReadOnly = true;
            // 
            // BackPtCC2
            // 
            this.BackPtCC2.HeaderText = "Back % CC2";
            this.BackPtCC2.Name = "BackPtCC2";
            this.BackPtCC2.ReadOnly = true;
            // 
            // TienBackCC2
            // 
            this.TienBackCC2.HeaderText = "Tiền back CC2";
            this.TienBackCC2.Name = "TienBackCC2";
            this.TienBackCC2.ReadOnly = true;
            // 
            // NetCC2
            // 
            this.NetCC2.HeaderText = "Net CC2";
            this.NetCC2.Name = "NetCC2";
            this.NetCC2.ReadOnly = true;
            // 
            // TongTienVAT
            // 
            this.TongTienVAT.HeaderText = "Tổng thu có VAT";
            this.TongTienVAT.Name = "TongTienVAT";
            this.TongTienVAT.ReadOnly = true;
            // 
            // TongVAT
            // 
            this.TongVAT.HeaderText = "Tổng VAT";
            this.TongVAT.Name = "TongVAT";
            this.TongVAT.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng thu chưa VAT";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // TongCC
            // 
            this.TongCC.HeaderText = "Tổng CC (Net)";
            this.TongCC.Name = "TongCC";
            this.TongCC.ReadOnly = true;
            // 
            // CongThuc
            // 
            this.CongThuc.HeaderText = "Công thức";
            this.CongThuc.Name = "CongThuc";
            this.CongThuc.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên công trình";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Địa chỉ";
            // 
            // DcTBox
            // 
            this.DcTBox.Location = new System.Drawing.Point(95, 41);
            this.DcTBox.Name = "DcTBox";
            this.DcTBox.ReadOnly = true;
            this.DcTBox.Size = new System.Drawing.Size(367, 20);
            this.DcTBox.TabIndex = 4;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(788, 343);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Đóng";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // KhTBox
            // 
            this.KhTBox.Location = new System.Drawing.Point(95, 67);
            this.KhTBox.Name = "KhTBox";
            this.KhTBox.ReadOnly = true;
            this.KhTBox.Size = new System.Drawing.Size(367, 20);
            this.KhTBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Khách hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DonGiaGrid);
            this.groupBox1.Location = new System.Drawing.Point(85, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 244);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đơn giá";
            // 
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Controls.Add(this.AddBtn);
            this.ActionGrp.Location = new System.Drawing.Point(7, 93);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 115);
            this.ActionGrp.TabIndex = 18;
            this.ActionGrp.TabStop = false;
            this.ActionGrp.Text = "Thao tác";
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(6, 82);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(58, 25);
            this.DelBtn.TabIndex = 2;
            this.DelBtn.Text = "Xóa";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(7, 51);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(58, 25);
            this.EditBtn.TabIndex = 1;
            this.EditBtn.Text = "Sửa";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(7, 20);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(58, 25);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Thêm";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CtrCb
            // 
            this.CtrCb.FormattingEnabled = true;
            this.CtrCb.Location = new System.Drawing.Point(95, 14);
            this.CtrCb.Name = "CtrCb";
            this.CtrCb.Size = new System.Drawing.Size(367, 21);
            this.CtrCb.TabIndex = 19;
            this.CtrCb.SelectionChangeCommitted += new System.EventHandler(this.CtrCb_SelectionChangeCommitted);
            // 
            // DonGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 378);
            this.Controls.Add(this.CtrCb);
            this.Controls.Add(this.ActionGrp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.KhTBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.DcTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "DonGiaForm";
            this.Text = "Quản lý đơn giá";
            ((System.ComponentModel.ISupportInitialize)(this.DonGiaGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ActionGrp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DonGiaGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DcTBox;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox KhTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ten;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGiaVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinBomCan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinBomTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn CC1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BackPtCC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TienBackCC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetCC2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CongThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.ComboBox CtrCb;
    }
}