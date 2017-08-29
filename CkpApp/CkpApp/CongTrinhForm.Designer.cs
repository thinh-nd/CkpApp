namespace CkpApp
{
    partial class CongTrinhForm
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
            this.KhIdLbl = new System.Windows.Forms.Label();
            this.KhIdTBox = new System.Windows.Forms.TextBox();
            this.CtyLbl = new System.Windows.Forms.Label();
            this.KhGBox = new System.Windows.Forms.GroupBox();
            this.CtyCBox = new System.Windows.Forms.ComboBox();
            this.CtrGBox = new System.Windows.Forms.GroupBox();
            this.CTrGrid = new System.Windows.Forms.DataGridView();
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.MaCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCongTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgPhuTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhGBox.SuspendLayout();
            this.CtrGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CTrGrid)).BeginInit();
            this.ActionGrp.SuspendLayout();
            this.SuspendLayout();
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
            // CtyLbl
            // 
            this.CtyLbl.AutoSize = true;
            this.CtyLbl.Location = new System.Drawing.Point(196, 21);
            this.CtyLbl.Name = "CtyLbl";
            this.CtyLbl.Size = new System.Drawing.Size(64, 13);
            this.CtyLbl.TabIndex = 2;
            this.CtyLbl.Text = "Tên công ty";
            // 
            // KhGBox
            // 
            this.KhGBox.Controls.Add(this.CtyCBox);
            this.KhGBox.Controls.Add(this.CtyLbl);
            this.KhGBox.Controls.Add(this.KhIdTBox);
            this.KhGBox.Controls.Add(this.KhIdLbl);
            this.KhGBox.Location = new System.Drawing.Point(12, 12);
            this.KhGBox.Name = "KhGBox";
            this.KhGBox.Size = new System.Drawing.Size(556, 50);
            this.KhGBox.TabIndex = 15;
            this.KhGBox.TabStop = false;
            this.KhGBox.Text = "Thông tin khách hàng";
            // 
            // CtyCBox
            // 
            this.CtyCBox.FormattingEnabled = true;
            this.CtyCBox.Location = new System.Drawing.Point(266, 17);
            this.CtyCBox.Name = "CtyCBox";
            this.CtyCBox.Size = new System.Drawing.Size(280, 21);
            this.CtyCBox.TabIndex = 5;
            this.CtyCBox.SelectionChangeCommitted += new System.EventHandler(this.CtyCBox_SelectionChangeCommitted);
            // 
            // CtrGBox
            // 
            this.CtrGBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CtrGBox.Controls.Add(this.CTrGrid);
            this.CtrGBox.Location = new System.Drawing.Point(90, 69);
            this.CtrGBox.Name = "CtrGBox";
            this.CtrGBox.Size = new System.Drawing.Size(472, 245);
            this.CtrGBox.TabIndex = 16;
            this.CtrGBox.TabStop = false;
            this.CtrGBox.Text = "Công trình";
            // 
            // CTrGrid
            // 
            this.CTrGrid.AllowUserToAddRows = false;
            this.CTrGrid.AllowUserToDeleteRows = false;
            this.CTrGrid.AllowUserToOrderColumns = true;
            this.CTrGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CTrGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCongTrinh,
            this.TenCongTrinh,
            this.DiaChi,
            this.SoHd,
            this.NgPhuTrach,
            this.NgayKy,
            this.NgayTh});
            this.CTrGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CTrGrid.Location = new System.Drawing.Point(3, 16);
            this.CTrGrid.Name = "CTrGrid";
            this.CTrGrid.ReadOnly = true;
            this.CTrGrid.Size = new System.Drawing.Size(466, 226);
            this.CTrGrid.TabIndex = 0;
            // 
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.ShowAllBtn);
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Controls.Add(this.AddBtn);
            this.ActionGrp.Location = new System.Drawing.Point(12, 69);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 154);
            this.ActionGrp.TabIndex = 17;
            this.ActionGrp.TabStop = false;
            this.ActionGrp.Text = "Thao tác";
            // 
            // ShowAllBtn
            // 
            this.ShowAllBtn.Location = new System.Drawing.Point(6, 113);
            this.ShowAllBtn.Name = "ShowAllBtn";
            this.ShowAllBtn.Size = new System.Drawing.Size(58, 34);
            this.ShowAllBtn.TabIndex = 4;
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
            // MaCongTrinh
            // 
            this.MaCongTrinh.HeaderText = "Mã công trình";
            this.MaCongTrinh.Name = "MaCongTrinh";
            this.MaCongTrinh.ReadOnly = true;
            // 
            // TenCongTrinh
            // 
            this.TenCongTrinh.HeaderText = "Tên công trình";
            this.TenCongTrinh.Name = "TenCongTrinh";
            this.TenCongTrinh.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // SoHd
            // 
            this.SoHd.HeaderText = "Số hợp đồng";
            this.SoHd.Name = "SoHd";
            this.SoHd.ReadOnly = true;
            // 
            // NgPhuTrach
            // 
            this.NgPhuTrach.HeaderText = "Người phụ trách";
            this.NgPhuTrach.Name = "NgPhuTrach";
            this.NgPhuTrach.ReadOnly = true;
            // 
            // NgayKy
            // 
            this.NgayKy.HeaderText = "Ngày ký";
            this.NgayKy.Name = "NgayKy";
            this.NgayKy.ReadOnly = true;
            // 
            // NgayTh
            // 
            this.NgayTh.HeaderText = "Ngày thực hiện";
            this.NgayTh.Name = "NgayTh";
            this.NgayTh.ReadOnly = true;
            // 
            // CongTrinhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 326);
            this.Controls.Add(this.ActionGrp);
            this.Controls.Add(this.CtrGBox);
            this.Controls.Add(this.KhGBox);
            this.Name = "CongTrinhForm";
            this.Text = "Quản lý công trình";
            this.KhGBox.ResumeLayout(false);
            this.KhGBox.PerformLayout();
            this.CtrGBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CTrGrid)).EndInit();
            this.ActionGrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label KhIdLbl;
        private System.Windows.Forms.TextBox KhIdTBox;
        private System.Windows.Forms.Label CtyLbl;
        private System.Windows.Forms.GroupBox KhGBox;
        private System.Windows.Forms.GroupBox CtrGBox;
        private System.Windows.Forms.DataGridView CTrGrid;
        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.ComboBox CtyCBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCongTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHd;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgPhuTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTh;
    }
}