namespace CkpApp
{
    partial class SuaNhanVien
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.DcTBox = new System.Windows.Forms.TextBox();
            this.SdtTBox = new System.Windows.Forms.TextBox();
            this.CvTBox = new System.Windows.Forms.TextBox();
            this.HtTBox = new System.Windows.Forms.TextBox();
            this.DcLbl = new System.Windows.Forms.Label();
            this.SdtLbl = new System.Windows.Forms.Label();
            this.CvLbl = new System.Windows.Forms.Label();
            this.HtLbl = new System.Windows.Forms.Label();
            this.IdTBox = new System.Windows.Forms.TextBox();
            this.IdLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(191, 207);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 23;
            this.CancelBtn.Text = "Quay lại";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(110, 207);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 22;
            this.OkBtn.Text = "Lưu";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // DcTBox
            // 
            this.DcTBox.Location = new System.Drawing.Point(113, 168);
            this.DcTBox.Name = "DcTBox";
            this.DcTBox.Size = new System.Drawing.Size(221, 20);
            this.DcTBox.TabIndex = 20;
            // 
            // SdtTBox
            // 
            this.SdtTBox.Location = new System.Drawing.Point(113, 134);
            this.SdtTBox.Name = "SdtTBox";
            this.SdtTBox.Size = new System.Drawing.Size(121, 20);
            this.SdtTBox.TabIndex = 19;
            // 
            // CvTBox
            // 
            this.CvTBox.Location = new System.Drawing.Point(113, 97);
            this.CvTBox.Name = "CvTBox";
            this.CvTBox.Size = new System.Drawing.Size(121, 20);
            this.CvTBox.TabIndex = 18;
            // 
            // HtTBox
            // 
            this.HtTBox.Location = new System.Drawing.Point(113, 64);
            this.HtTBox.Name = "HtTBox";
            this.HtTBox.Size = new System.Drawing.Size(221, 20);
            this.HtTBox.TabIndex = 17;
            // 
            // DcLbl
            // 
            this.DcLbl.AutoSize = true;
            this.DcLbl.Location = new System.Drawing.Point(67, 171);
            this.DcLbl.Name = "DcLbl";
            this.DcLbl.Size = new System.Drawing.Size(40, 13);
            this.DcLbl.TabIndex = 15;
            this.DcLbl.Text = "Địa chỉ";
            // 
            // SdtLbl
            // 
            this.SdtLbl.AutoSize = true;
            this.SdtLbl.Location = new System.Drawing.Point(37, 137);
            this.SdtLbl.Name = "SdtLbl";
            this.SdtLbl.Size = new System.Drawing.Size(70, 13);
            this.SdtLbl.TabIndex = 14;
            this.SdtLbl.Text = "Số điện thoại";
            // 
            // CvLbl
            // 
            this.CvLbl.AutoSize = true;
            this.CvLbl.Location = new System.Drawing.Point(60, 100);
            this.CvLbl.Name = "CvLbl";
            this.CvLbl.Size = new System.Drawing.Size(47, 13);
            this.CvLbl.TabIndex = 13;
            this.CvLbl.Text = "Chức vụ";
            // 
            // HtLbl
            // 
            this.HtLbl.AutoSize = true;
            this.HtLbl.Location = new System.Drawing.Point(68, 67);
            this.HtLbl.Name = "HtLbl";
            this.HtLbl.Size = new System.Drawing.Size(39, 13);
            this.HtLbl.TabIndex = 12;
            this.HtLbl.Text = "Họ tên";
            // 
            // IdTBox
            // 
            this.IdTBox.Location = new System.Drawing.Point(113, 28);
            this.IdTBox.Name = "IdTBox";
            this.IdTBox.ReadOnly = true;
            this.IdTBox.Size = new System.Drawing.Size(54, 20);
            this.IdTBox.TabIndex = 25;
            // 
            // IdLbl
            // 
            this.IdLbl.AutoSize = true;
            this.IdLbl.Location = new System.Drawing.Point(35, 31);
            this.IdLbl.Name = "IdLbl";
            this.IdLbl.Size = new System.Drawing.Size(72, 13);
            this.IdLbl.TabIndex = 26;
            this.IdLbl.Text = "Mã nhân viên";
            // 
            // SuaNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 246);
            this.Controls.Add(this.IdLbl);
            this.Controls.Add(this.IdTBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.DcTBox);
            this.Controls.Add(this.SdtTBox);
            this.Controls.Add(this.CvTBox);
            this.Controls.Add(this.HtTBox);
            this.Controls.Add(this.DcLbl);
            this.Controls.Add(this.SdtLbl);
            this.Controls.Add(this.CvLbl);
            this.Controls.Add(this.HtLbl);
            this.Name = "SuaNhanVien";
            this.Text = "Thay đổi thông tin nhân viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox DcTBox;
        private System.Windows.Forms.TextBox SdtTBox;
        private System.Windows.Forms.TextBox CvTBox;
        private System.Windows.Forms.TextBox HtTBox;
        private System.Windows.Forms.Label DcLbl;
        private System.Windows.Forms.Label SdtLbl;
        private System.Windows.Forms.Label CvLbl;
        private System.Windows.Forms.Label HtLbl;
        private System.Windows.Forms.TextBox IdTBox;
        private System.Windows.Forms.Label IdLbl;
    }
}