namespace CkpApp
{
    partial class NhanVienForm
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
            this.TimKiemGrp = new System.Windows.Forms.GroupBox();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.KeywordLbl = new System.Windows.Forms.Label();
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.NvGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimKiemGrp.SuspendLayout();
            this.ActionGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TimKiemGrp
            // 
            this.TimKiemGrp.Controls.Add(this.SearchTBox);
            this.TimKiemGrp.Controls.Add(this.SearchBtn);
            this.TimKiemGrp.Controls.Add(this.KeywordLbl);
            this.TimKiemGrp.Location = new System.Drawing.Point(12, 12);
            this.TimKiemGrp.Name = "TimKiemGrp";
            this.TimKiemGrp.Size = new System.Drawing.Size(468, 47);
            this.TimKiemGrp.TabIndex = 3;
            this.TimKiemGrp.TabStop = false;
            this.TimKiemGrp.Text = "Tìm kiếm";
            // 
            // SearchTBox
            // 
            this.SearchTBox.Location = new System.Drawing.Point(59, 16);
            this.SearchTBox.Name = "SearchTBox";
            this.SearchTBox.Size = new System.Drawing.Size(320, 20);
            this.SearchTBox.TabIndex = 2;
            this.SearchTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTBox_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(385, 14);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "Tìm kiếm";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
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
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.ShowAllBtn);
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Controls.Add(this.AddBtn);
            this.ActionGrp.Location = new System.Drawing.Point(12, 65);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 155);
            this.ActionGrp.TabIndex = 4;
            this.ActionGrp.TabStop = false;
            this.ActionGrp.Text = "Thao tác";
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(6, 113);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(58, 34);
            this.ShowAllBtn.TabIndex = 3;
            this.ShowAllBtn.Text = "Hiện tất cả";
            this.ShowAllBtn.UseVisualStyleBackColor = true;
            this.ShowAllBtn.Click += new System.EventHandler(this.ShowAllBtn_Click);
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
            // NvGrid
            // 
            this.NvGrid.AllowUserToAddRows = false;
            this.NvGrid.AllowUserToDeleteRows = false;
            this.NvGrid.AllowUserToOrderColumns = true;
            this.NvGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NvGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.HoTen,
            this.ChucVu,
            this.SoDienThoai,
            this.DiaChi});
            this.NvGrid.Location = new System.Drawing.Point(91, 66);
            this.NvGrid.Name = "NvGrid";
            this.NvGrid.ReadOnly = true;
            this.NvGrid.Size = new System.Drawing.Size(390, 229);
            this.NvGrid.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ tên";
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
            this.SoDienThoai.HeaderText = "Sđt";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 307);
            this.Controls.Add(this.NvGrid);
            this.Controls.Add(this.ActionGrp);
            this.Controls.Add(this.TimKiemGrp);
            this.Name = "NhanVienForm";
            this.Text = "Quản lý nhân viên";
            this.TimKiemGrp.ResumeLayout(false);
            this.TimKiemGrp.PerformLayout();
            this.ActionGrp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NvGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox TimKiemGrp;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label KeywordLbl;
        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridView NvGrid;
        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
    }
}