namespace CkpApp
{
    partial class ChiTietKhachHang
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
            this.CtyLbl = new System.Windows.Forms.Label();
            this.DcLbl = new System.Windows.Forms.Label();
            this.MstTBox = new System.Windows.Forms.TextBox();
            this.KhIdTBox = new System.Windows.Forms.TextBox();
            this.KhIdLbl = new System.Windows.Forms.Label();
            this.MstLbl = new System.Windows.Forms.Label();
            this.KhGBox = new System.Windows.Forms.GroupBox();
            this.DcTBox = new System.Windows.Forms.TextBox();
            this.CtyTBox = new System.Windows.Forms.TextBox();
            this.NlhGBox = new System.Windows.Forms.GroupBox();
            this.NlhGrid = new System.Windows.Forms.DataGridView();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.KhGBox.SuspendLayout();
            this.NlhGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NlhGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CtyLbl
            // 
            this.CtyLbl.AutoSize = true;
            this.CtyLbl.Location = new System.Drawing.Point(196, 21);
            this.CtyLbl.Name = "CtyLbl";
            this.CtyLbl.Size = new System.Drawing.Size(64, 13);
            this.CtyLbl.TabIndex = 2;
            this.CtyLbl.Text = "Tên công ty";
            // 
            // DcLbl
            // 
            this.DcLbl.AutoSize = true;
            this.DcLbl.Location = new System.Drawing.Point(220, 49);
            this.DcLbl.Name = "DcLbl";
            this.DcLbl.Size = new System.Drawing.Size(40, 13);
            this.DcLbl.TabIndex = 3;
            this.DcLbl.Text = "Địa chỉ";
            // 
            // MstTBox
            // 
            this.MstTBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MstTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MstTBox.Location = new System.Drawing.Point(72, 47);
            this.MstTBox.Name = "MstTBox";
            this.MstTBox.ReadOnly = true;
            this.MstTBox.Size = new System.Drawing.Size(115, 20);
            this.MstTBox.TabIndex = 5;
            // 
            // KhIdTBox
            // 
            this.KhIdTBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.KhIdTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KhIdTBox.Location = new System.Drawing.Point(72, 18);
            this.KhIdTBox.Name = "KhIdTBox";
            this.KhIdTBox.ReadOnly = true;
            this.KhIdTBox.Size = new System.Drawing.Size(115, 20);
            this.KhIdTBox.TabIndex = 4;
            // 
            // KhIdLbl
            // 
            this.KhIdLbl.AutoSize = true;
            this.KhIdLbl.Location = new System.Drawing.Point(12, 21);
            this.KhIdLbl.Name = "KhIdLbl";
            this.KhIdLbl.Size = new System.Drawing.Size(54, 13);
            this.KhIdLbl.TabIndex = 0;
            this.KhIdLbl.Text = "Mã số KH";
            // 
            // MstLbl
            // 
            this.MstLbl.AutoSize = true;
            this.MstLbl.Location = new System.Drawing.Point(6, 49);
            this.MstLbl.Name = "MstLbl";
            this.MstLbl.Size = new System.Drawing.Size(60, 13);
            this.MstLbl.TabIndex = 1;
            this.MstLbl.Text = "Mã số thuế";
            // 
            // KhGBox
            // 
            this.KhGBox.Controls.Add(this.CtyLbl);
            this.KhGBox.Controls.Add(this.DcLbl);
            this.KhGBox.Controls.Add(this.DcTBox);
            this.KhGBox.Controls.Add(this.MstTBox);
            this.KhGBox.Controls.Add(this.CtyTBox);
            this.KhGBox.Controls.Add(this.KhIdTBox);
            this.KhGBox.Controls.Add(this.KhIdLbl);
            this.KhGBox.Controls.Add(this.MstLbl);
            this.KhGBox.Location = new System.Drawing.Point(12, 12);
            this.KhGBox.Name = "KhGBox";
            this.KhGBox.Size = new System.Drawing.Size(556, 84);
            this.KhGBox.TabIndex = 14;
            this.KhGBox.TabStop = false;
            this.KhGBox.Text = "Thông tin khách hàng";
            // 
            // DcTBox
            // 
            this.DcTBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DcTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DcTBox.Location = new System.Drawing.Point(266, 46);
            this.DcTBox.Name = "DcTBox";
            this.DcTBox.ReadOnly = true;
            this.DcTBox.Size = new System.Drawing.Size(284, 20);
            this.DcTBox.TabIndex = 7;
            // 
            // CtyTBox
            // 
            this.CtyTBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CtyTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtyTBox.Location = new System.Drawing.Point(266, 18);
            this.CtyTBox.Name = "CtyTBox";
            this.CtyTBox.ReadOnly = true;
            this.CtyTBox.Size = new System.Drawing.Size(284, 20);
            this.CtyTBox.TabIndex = 6;
            // 
            // NlhGBox
            // 
            this.NlhGBox.Controls.Add(this.NlhGrid);
            this.NlhGBox.Location = new System.Drawing.Point(10, 102);
            this.NlhGBox.Name = "NlhGBox";
            this.NlhGBox.Size = new System.Drawing.Size(558, 163);
            this.NlhGBox.TabIndex = 15;
            this.NlhGBox.TabStop = false;
            this.NlhGBox.Text = "Người liên hệ";
            // 
            // NlhGrid
            // 
            this.NlhGrid.AllowUserToAddRows = false;
            this.NlhGrid.AllowUserToDeleteRows = false;
            this.NlhGrid.AllowUserToOrderColumns = true;
            this.NlhGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NlhGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoTen,
            this.ChucVu,
            this.SoDienThoai,
            this.GhiChu});
            this.NlhGrid.Location = new System.Drawing.Point(6, 19);
            this.NlhGrid.Name = "NlhGrid";
            this.NlhGrid.Size = new System.Drawing.Size(546, 135);
            this.NlhGrid.TabIndex = 0;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // ChucVu
            // 
            this.ChucVu.HeaderText = "Chức vụ";
            this.ChucVu.Name = "ChucVu";
            this.ChucVu.ReadOnly = true;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(249, 271);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 16;
            this.CloseBtn.Text = "Đóng";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ChiTietKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 306);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.NlhGBox);
            this.Controls.Add(this.KhGBox);
            this.Name = "ChiTietKhachHang";
            this.Text = "Chi tiết khách hàng";
            this.KhGBox.ResumeLayout(false);
            this.KhGBox.PerformLayout();
            this.NlhGBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NlhGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CtyLbl;
        private System.Windows.Forms.Label DcLbl;
        private System.Windows.Forms.TextBox MstTBox;
        private System.Windows.Forms.TextBox KhIdTBox;
        private System.Windows.Forms.Label KhIdLbl;
        private System.Windows.Forms.Label MstLbl;
        private System.Windows.Forms.GroupBox KhGBox;
        private System.Windows.Forms.TextBox DcTBox;
        private System.Windows.Forms.TextBox CtyTBox;
        private System.Windows.Forms.GroupBox NlhGBox;
        private System.Windows.Forms.DataGridView NlhGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Button CloseBtn;
    }
}