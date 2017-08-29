namespace CkpApp
{
    partial class ThemCongTrinh
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
            this.CtrIdLbl = new System.Windows.Forms.Label();
            this.CtrNameLbl = new System.Windows.Forms.Label();
            this.CtrDcLbl = new System.Windows.Forms.Label();
            this.CtrIdTBox = new System.Windows.Forms.TextBox();
            this.CtrNameTBox = new System.Windows.Forms.TextBox();
            this.CtrDcTBox = new System.Windows.Forms.TextBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CtyLbl = new System.Windows.Forms.Label();
            this.CtyTBox = new System.Windows.Forms.TextBox();
            this.SoHdTBox = new System.Windows.Forms.TextBox();
            this.NgayKyTBox = new System.Windows.Forms.TextBox();
            this.NgayThTBox = new System.Windows.Forms.TextBox();
            this.SoHdLbl = new System.Windows.Forms.Label();
            this.NgayKyLbl = new System.Windows.Forms.Label();
            this.NgayThLbl = new System.Windows.Forms.Label();
            this.NptCb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CtrIdLbl
            // 
            this.CtrIdLbl.AutoSize = true;
            this.CtrIdLbl.Location = new System.Drawing.Point(27, 61);
            this.CtrIdLbl.Name = "CtrIdLbl";
            this.CtrIdLbl.Size = new System.Drawing.Size(72, 13);
            this.CtrIdLbl.TabIndex = 0;
            this.CtrIdLbl.Text = "Mã công trình";
            // 
            // CtrNameLbl
            // 
            this.CtrNameLbl.AutoSize = true;
            this.CtrNameLbl.Location = new System.Drawing.Point(23, 87);
            this.CtrNameLbl.Name = "CtrNameLbl";
            this.CtrNameLbl.Size = new System.Drawing.Size(76, 13);
            this.CtrNameLbl.TabIndex = 1;
            this.CtrNameLbl.Text = "Tên công trình";
            // 
            // CtrDcLbl
            // 
            this.CtrDcLbl.AutoSize = true;
            this.CtrDcLbl.Location = new System.Drawing.Point(59, 113);
            this.CtrDcLbl.Name = "CtrDcLbl";
            this.CtrDcLbl.Size = new System.Drawing.Size(40, 13);
            this.CtrDcLbl.TabIndex = 2;
            this.CtrDcLbl.Text = "Địa chỉ";
            // 
            // CtrIdTBox
            // 
            this.CtrIdTBox.Location = new System.Drawing.Point(105, 58);
            this.CtrIdTBox.Name = "CtrIdTBox";
            this.CtrIdTBox.Size = new System.Drawing.Size(123, 20);
            this.CtrIdTBox.TabIndex = 3;
            // 
            // CtrNameTBox
            // 
            this.CtrNameTBox.Location = new System.Drawing.Point(105, 84);
            this.CtrNameTBox.Name = "CtrNameTBox";
            this.CtrNameTBox.Size = new System.Drawing.Size(284, 20);
            this.CtrNameTBox.TabIndex = 4;
            // 
            // CtrDcTBox
            // 
            this.CtrDcTBox.Location = new System.Drawing.Point(105, 110);
            this.CtrDcTBox.Name = "CtrDcTBox";
            this.CtrDcTBox.Size = new System.Drawing.Size(284, 20);
            this.CtrDcTBox.TabIndex = 5;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(138, 267);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Thêm";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(219, 267);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Quay lại";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CtyLbl
            // 
            this.CtyLbl.AutoSize = true;
            this.CtyLbl.Location = new System.Drawing.Point(21, 15);
            this.CtyLbl.Name = "CtyLbl";
            this.CtyLbl.Size = new System.Drawing.Size(64, 13);
            this.CtyLbl.TabIndex = 8;
            this.CtyLbl.Text = "Tên công ty";
            // 
            // CtyTBox
            // 
            this.CtyTBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CtyTBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CtyTBox.Location = new System.Drawing.Point(105, 12);
            this.CtyTBox.Name = "CtyTBox";
            this.CtyTBox.ReadOnly = true;
            this.CtyTBox.Size = new System.Drawing.Size(284, 20);
            this.CtyTBox.TabIndex = 9;
            // 
            // SoHdTBox
            // 
            this.SoHdTBox.Location = new System.Drawing.Point(105, 137);
            this.SoHdTBox.Name = "SoHdTBox";
            this.SoHdTBox.Size = new System.Drawing.Size(177, 20);
            this.SoHdTBox.TabIndex = 10;
            // 
            // NgayKyTBox
            // 
            this.NgayKyTBox.Location = new System.Drawing.Point(105, 192);
            this.NgayKyTBox.Name = "NgayKyTBox";
            this.NgayKyTBox.Size = new System.Drawing.Size(123, 20);
            this.NgayKyTBox.TabIndex = 11;
            // 
            // NgayThTBox
            // 
            this.NgayThTBox.Location = new System.Drawing.Point(105, 219);
            this.NgayThTBox.Name = "NgayThTBox";
            this.NgayThTBox.Size = new System.Drawing.Size(123, 20);
            this.NgayThTBox.TabIndex = 12;
            // 
            // SoHdLbl
            // 
            this.SoHdLbl.AutoSize = true;
            this.SoHdLbl.Location = new System.Drawing.Point(30, 140);
            this.SoHdLbl.Name = "SoHdLbl";
            this.SoHdLbl.Size = new System.Drawing.Size(69, 13);
            this.SoHdLbl.TabIndex = 13;
            this.SoHdLbl.Text = "Số hợp đồng";
            // 
            // NgayKyLbl
            // 
            this.NgayKyLbl.AutoSize = true;
            this.NgayKyLbl.Location = new System.Drawing.Point(34, 195);
            this.NgayKyLbl.Name = "NgayKyLbl";
            this.NgayKyLbl.Size = new System.Drawing.Size(65, 13);
            this.NgayKyLbl.TabIndex = 14;
            this.NgayKyLbl.Text = "Ngày ký HĐ";
            // 
            // NgayThLbl
            // 
            this.NgayThLbl.AutoSize = true;
            this.NgayThLbl.Location = new System.Drawing.Point(20, 222);
            this.NgayThLbl.Name = "NgayThLbl";
            this.NgayThLbl.Size = new System.Drawing.Size(79, 13);
            this.NgayThLbl.TabIndex = 15;
            this.NgayThLbl.Text = "Ngày thực hiện";
            // 
            // NptCb
            // 
            this.NptCb.FormattingEnabled = true;
            this.NptCb.Location = new System.Drawing.Point(105, 164);
            this.NptCb.Name = "NptCb";
            this.NptCb.Size = new System.Drawing.Size(177, 21);
            this.NptCb.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Người phụ trách";
            // 
            // ThemCongTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 302);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NptCb);
            this.Controls.Add(this.NgayThLbl);
            this.Controls.Add(this.NgayKyLbl);
            this.Controls.Add(this.SoHdLbl);
            this.Controls.Add(this.NgayThTBox);
            this.Controls.Add(this.NgayKyTBox);
            this.Controls.Add(this.SoHdTBox);
            this.Controls.Add(this.CtyLbl);
            this.Controls.Add(this.CtyTBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.CtrDcTBox);
            this.Controls.Add(this.CtrNameTBox);
            this.Controls.Add(this.CtrIdTBox);
            this.Controls.Add(this.CtrDcLbl);
            this.Controls.Add(this.CtrNameLbl);
            this.Controls.Add(this.CtrIdLbl);
            this.Name = "ThemCongTrinh";
            this.Text = "Thêm công trình mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CtrIdLbl;
        private System.Windows.Forms.Label CtrNameLbl;
        private System.Windows.Forms.Label CtrDcLbl;
        private System.Windows.Forms.TextBox CtrIdTBox;
        private System.Windows.Forms.TextBox CtrNameTBox;
        private System.Windows.Forms.TextBox CtrDcTBox;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label CtyLbl;
        private System.Windows.Forms.TextBox CtyTBox;
        private System.Windows.Forms.TextBox SoHdTBox;
        private System.Windows.Forms.TextBox NgayKyTBox;
        private System.Windows.Forms.TextBox NgayThTBox;
        private System.Windows.Forms.Label SoHdLbl;
        private System.Windows.Forms.Label NgayKyLbl;
        private System.Windows.Forms.Label NgayThLbl;
        private System.Windows.Forms.ComboBox NptCb;
        private System.Windows.Forms.Label label1;
    }
}