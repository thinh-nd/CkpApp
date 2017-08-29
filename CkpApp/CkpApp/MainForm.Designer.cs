namespace CkpApp
{
    partial class MainForm
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
            this.MayBomBtn = new System.Windows.Forms.Button();
            this.ProgramLabel = new System.Windows.Forms.Label();
            this.FeatureGroup = new System.Windows.Forms.GroupBox();
            this.CongTrinhBtn = new System.Windows.Forms.Button();
            this.NhanSuBtn = new System.Windows.Forms.Button();
            this.ViTriBtn = new System.Windows.Forms.Button();
            this.KhachHangBtn = new System.Windows.Forms.Button();
            this.BaoCaoNgayBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QlyBaoCaoBtn = new System.Windows.Forms.Button();
            this.DataMgmtBtn = new System.Windows.Forms.Button();
            this.XuatBaoCaoBtn = new System.Windows.Forms.Button();
            this.DonGiaBtn = new System.Windows.Forms.Button();
            this.FeatureGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MayBomBtn
            // 
            this.MayBomBtn.Location = new System.Drawing.Point(6, 19);
            this.MayBomBtn.Name = "MayBomBtn";
            this.MayBomBtn.Size = new System.Drawing.Size(76, 68);
            this.MayBomBtn.TabIndex = 0;
            this.MayBomBtn.Text = "Máy bơm";
            this.MayBomBtn.UseVisualStyleBackColor = true;
            this.MayBomBtn.Click += new System.EventHandler(this.MayBomBtn_Click);
            // 
            // ProgramLabel
            // 
            this.ProgramLabel.AutoSize = true;
            this.ProgramLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramLabel.Location = new System.Drawing.Point(93, 9);
            this.ProgramLabel.Name = "ProgramLabel";
            this.ProgramLabel.Size = new System.Drawing.Size(277, 20);
            this.ProgramLabel.TabIndex = 1;
            this.ProgramLabel.Text = "Phần mềm quản lý sản lượng CKP";
            // 
            // FeatureGroup
            // 
            this.FeatureGroup.Controls.Add(this.DonGiaBtn);
            this.FeatureGroup.Controls.Add(this.CongTrinhBtn);
            this.FeatureGroup.Controls.Add(this.NhanSuBtn);
            this.FeatureGroup.Controls.Add(this.ViTriBtn);
            this.FeatureGroup.Controls.Add(this.KhachHangBtn);
            this.FeatureGroup.Controls.Add(this.MayBomBtn);
            this.FeatureGroup.Location = new System.Drawing.Point(12, 32);
            this.FeatureGroup.Name = "FeatureGroup";
            this.FeatureGroup.Size = new System.Drawing.Size(257, 169);
            this.FeatureGroup.TabIndex = 2;
            this.FeatureGroup.TabStop = false;
            this.FeatureGroup.Text = "Quản lý";
            // 
            // CongTrinhBtn
            // 
            this.CongTrinhBtn.Location = new System.Drawing.Point(170, 19);
            this.CongTrinhBtn.Name = "CongTrinhBtn";
            this.CongTrinhBtn.Size = new System.Drawing.Size(76, 68);
            this.CongTrinhBtn.TabIndex = 4;
            this.CongTrinhBtn.Text = "Công trình";
            this.CongTrinhBtn.UseVisualStyleBackColor = true;
            this.CongTrinhBtn.Click += new System.EventHandler(this.CongTrinhBtn_Click);
            // 
            // NhanSuBtn
            // 
            this.NhanSuBtn.Location = new System.Drawing.Point(6, 93);
            this.NhanSuBtn.Name = "NhanSuBtn";
            this.NhanSuBtn.Size = new System.Drawing.Size(76, 68);
            this.NhanSuBtn.TabIndex = 3;
            this.NhanSuBtn.Text = "Nhân sự";
            this.NhanSuBtn.UseVisualStyleBackColor = true;
            this.NhanSuBtn.Click += new System.EventHandler(this.NhanSuBtn_Click);
            // 
            // ViTriBtn
            // 
            this.ViTriBtn.Location = new System.Drawing.Point(88, 93);
            this.ViTriBtn.Name = "ViTriBtn";
            this.ViTriBtn.Size = new System.Drawing.Size(76, 68);
            this.ViTriBtn.TabIndex = 2;
            this.ViTriBtn.Text = "Vị trí bơm";
            this.ViTriBtn.UseVisualStyleBackColor = true;
            this.ViTriBtn.Click += new System.EventHandler(this.ViTriBtn_Click);
            // 
            // KhachHangBtn
            // 
            this.KhachHangBtn.Location = new System.Drawing.Point(88, 19);
            this.KhachHangBtn.Name = "KhachHangBtn";
            this.KhachHangBtn.Size = new System.Drawing.Size(76, 68);
            this.KhachHangBtn.TabIndex = 1;
            this.KhachHangBtn.Text = "Khách hàng";
            this.KhachHangBtn.UseVisualStyleBackColor = true;
            this.KhachHangBtn.Click += new System.EventHandler(this.KhachHangBtn_Click);
            // 
            // BaoCaoNgayBtn
            // 
            this.BaoCaoNgayBtn.Location = new System.Drawing.Point(11, 19);
            this.BaoCaoNgayBtn.Name = "BaoCaoNgayBtn";
            this.BaoCaoNgayBtn.Size = new System.Drawing.Size(76, 68);
            this.BaoCaoNgayBtn.TabIndex = 5;
            this.BaoCaoNgayBtn.Text = "Báo cáo ngày";
            this.BaoCaoNgayBtn.UseVisualStyleBackColor = true;
            this.BaoCaoNgayBtn.Click += new System.EventHandler(this.BaoCaoNgayBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataMgmtBtn);
            this.groupBox1.Controls.Add(this.XuatBaoCaoBtn);
            this.groupBox1.Controls.Add(this.QlyBaoCaoBtn);
            this.groupBox1.Controls.Add(this.BaoCaoNgayBtn);
            this.groupBox1.Location = new System.Drawing.Point(275, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 169);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo cáo - thống kê sản lượng";
            // 
            // QlyBaoCaoBtn
            // 
            this.QlyBaoCaoBtn.Location = new System.Drawing.Point(93, 19);
            this.QlyBaoCaoBtn.Name = "QlyBaoCaoBtn";
            this.QlyBaoCaoBtn.Size = new System.Drawing.Size(76, 68);
            this.QlyBaoCaoBtn.TabIndex = 6;
            this.QlyBaoCaoBtn.Text = "Quản lý báo cáo";
            this.QlyBaoCaoBtn.UseVisualStyleBackColor = true;
            this.QlyBaoCaoBtn.Click += new System.EventHandler(this.QlyBaoCaoBtn_Click);
            // 
            // DataMgmtBtn
            // 
            this.DataMgmtBtn.Location = new System.Drawing.Point(93, 93);
            this.DataMgmtBtn.Name = "DataMgmtBtn";
            this.DataMgmtBtn.Size = new System.Drawing.Size(76, 68);
            this.DataMgmtBtn.TabIndex = 8;
            this.DataMgmtBtn.Text = "Quản lý kho dữ liệu";
            this.DataMgmtBtn.UseVisualStyleBackColor = true;
            this.DataMgmtBtn.Click += new System.EventHandler(this.DataMgmtBtn_Click);
            // 
            // XuatBaoCaoBtn
            // 
            this.XuatBaoCaoBtn.Location = new System.Drawing.Point(11, 93);
            this.XuatBaoCaoBtn.Name = "XuatBaoCaoBtn";
            this.XuatBaoCaoBtn.Size = new System.Drawing.Size(76, 68);
            this.XuatBaoCaoBtn.TabIndex = 7;
            this.XuatBaoCaoBtn.Text = "Xuất báo cáo Excel";
            this.XuatBaoCaoBtn.UseVisualStyleBackColor = true;
            this.XuatBaoCaoBtn.Click += new System.EventHandler(this.XuatBaoCaoBtn_Click);
            // 
            // DonGiaBtn
            // 
            this.DonGiaBtn.Location = new System.Drawing.Point(170, 93);
            this.DonGiaBtn.Name = "DonGiaBtn";
            this.DonGiaBtn.Size = new System.Drawing.Size(76, 68);
            this.DonGiaBtn.TabIndex = 5;
            this.DonGiaBtn.Text = "Đơn giá công trình";
            this.DonGiaBtn.UseVisualStyleBackColor = true;
            this.DonGiaBtn.Click += new System.EventHandler(this.DonGiaBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FeatureGroup);
            this.Controls.Add(this.ProgramLabel);
            this.Name = "MainForm";
            this.Text = "CKP Application";
            this.FeatureGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MayBomBtn;
        private System.Windows.Forms.Label ProgramLabel;
        private System.Windows.Forms.GroupBox FeatureGroup;
        private System.Windows.Forms.Button NhanSuBtn;
        private System.Windows.Forms.Button ViTriBtn;
        private System.Windows.Forms.Button KhachHangBtn;
        private System.Windows.Forms.Button BaoCaoNgayBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button QlyBaoCaoBtn;
        private System.Windows.Forms.Button CongTrinhBtn;
        private System.Windows.Forms.Button DonGiaBtn;
        private System.Windows.Forms.Button DataMgmtBtn;
        private System.Windows.Forms.Button XuatBaoCaoBtn;

    }
}

