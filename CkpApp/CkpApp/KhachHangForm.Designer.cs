namespace CkpApp
{
    partial class KhachHangForm
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
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.DetailBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.TimKiemGrp = new System.Windows.Forms.GroupBox();
            this.STypeCBox = new System.Windows.Forms.ComboBox();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.KeywordLbl = new System.Windows.Forms.Label();
            this.KhachHangGrid = new System.Windows.Forms.DataGridView();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCongTy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSoThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionGrp.SuspendLayout();
            this.TimKiemGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHangGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.ShowAllBtn);
            this.ActionGrp.Controls.Add(this.DetailBtn);
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Controls.Add(this.AddBtn);
            this.ActionGrp.Location = new System.Drawing.Point(12, 64);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 186);
            this.ActionGrp.TabIndex = 7;
            this.ActionGrp.TabStop = false;
            this.ActionGrp.Text = "Thao tác";
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(6, 144);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(58, 34);
            this.ShowAllBtn.TabIndex = 5;
            this.ShowAllBtn.Text = "Hiện tất cả";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
            // 
            // DetailBtn
            // 
            this.DetailBtn.Location = new System.Drawing.Point(6, 113);
            this.DetailBtn.Name = "DetailBtn";
            this.DetailBtn.Size = new System.Drawing.Size(58, 25);
            this.DetailBtn.TabIndex = 3;
            this.DetailBtn.Text = "Chi tiết";
            this.DetailBtn.UseVisualStyleBackColor = true;
            this.DetailBtn.Click += new System.EventHandler(this.DetailBtn_Click);
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
            // TimKiemGrp
            // 
            this.TimKiemGrp.Controls.Add(this.STypeCBox);
            this.TimKiemGrp.Controls.Add(this.SearchTBox);
            this.TimKiemGrp.Controls.Add(this.SearchBtn);
            this.TimKiemGrp.Controls.Add(this.label2);
            this.TimKiemGrp.Controls.Add(this.KeywordLbl);
            this.TimKiemGrp.Location = new System.Drawing.Point(12, 11);
            this.TimKiemGrp.Name = "TimKiemGrp";
            this.TimKiemGrp.Size = new System.Drawing.Size(628, 47);
            this.TimKiemGrp.TabIndex = 6;
            this.TimKiemGrp.TabStop = false;
            this.TimKiemGrp.Text = "Tìm kiếm";
            // 
            // STypeCBox
            // 
            this.STypeCBox.FormattingEnabled = true;
            this.STypeCBox.Items.AddRange(new object[] {
            "Tất cả",
            "Mã khách hàng",
            "Tên công ty",
            "Địa chỉ",
            "Mã số thuế"});
            this.STypeCBox.Location = new System.Drawing.Point(411, 16);
            this.STypeCBox.Name = "STypeCBox";
            this.STypeCBox.Size = new System.Drawing.Size(127, 21);
            this.STypeCBox.TabIndex = 3;
            // 
            // SearchTBox
            // 
            this.SearchTBox.Location = new System.Drawing.Point(59, 16);
            this.SearchTBox.Name = "SearchTBox";
            this.SearchTBox.Size = new System.Drawing.Size(267, 20);
            this.SearchTBox.TabIndex = 2;
            this.SearchTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTBox_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(544, 14);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "Tìm kiếm";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tìm kiếm theo";
            // 
            // KeywordLbl
            // 
            this.KeywordLbl.AutoSize = true;
            this.KeywordLbl.Location = new System.Drawing.Point(6, 19);
            this.KeywordLbl.Name = "KeywordLbl";
            this.KeywordLbl.Size = new System.Drawing.Size(47, 13);
            this.KeywordLbl.TabIndex = 0;
            this.KeywordLbl.Text = "Từ khóa";
            // 
            // KhachHangGrid
            // 
            this.KhachHangGrid.AllowUserToAddRows = false;
            this.KhachHangGrid.AllowUserToDeleteRows = false;
            this.KhachHangGrid.AllowUserToOrderColumns = true;
            this.KhachHangGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KhachHangGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KhachHangGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhachHang,
            this.TenCongTy,
            this.DiaChi,
            this.MaSoThue});
            this.KhachHangGrid.Location = new System.Drawing.Point(90, 64);
            this.KhachHangGrid.Name = "KhachHangGrid";
            this.KhachHangGrid.Size = new System.Drawing.Size(551, 267);
            this.KhachHangGrid.TabIndex = 8;
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.HeaderText = "Mã KH";
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.ReadOnly = true;
            // 
            // TenCongTy
            // 
            this.TenCongTy.HeaderText = "Tên công ty";
            this.TenCongTy.Name = "TenCongTy";
            this.TenCongTy.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // MaSoThue
            // 
            this.MaSoThue.HeaderText = "Mã số thuế";
            this.MaSoThue.Name = "MaSoThue";
            this.MaSoThue.ReadOnly = true;
            // 
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 343);
            this.Controls.Add(this.KhachHangGrid);
            this.Controls.Add(this.ActionGrp);
            this.Controls.Add(this.TimKiemGrp);
            this.Name = "KhachHangForm";
            this.Text = "Quản lý khách hàng - công trình";
            this.ActionGrp.ResumeLayout(false);
            this.TimKiemGrp.ResumeLayout(false);
            this.TimKiemGrp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KhachHangGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.GroupBox TimKiemGrp;
        private System.Windows.Forms.ComboBox STypeCBox;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label KeywordLbl;
        private System.Windows.Forms.Button DetailBtn;
        private System.Windows.Forms.DataGridView KhachHangGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCongTy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSoThue;
        private System.Windows.Forms.Button ShowAllBtn;
    }
}