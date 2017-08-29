namespace CkpApp
{
    partial class ThemNhanVien
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
            this.HtLbl = new System.Windows.Forms.Label();
            this.CvLbl = new System.Windows.Forms.Label();
            this.SdtLbl = new System.Windows.Forms.Label();
            this.DcLbl = new System.Windows.Forms.Label();
            this.HtTBox = new System.Windows.Forms.TextBox();
            this.CvTBox = new System.Windows.Forms.TextBox();
            this.SdtTBox = new System.Windows.Forms.TextBox();
            this.DcTBox = new System.Windows.Forms.TextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HtLbl
            // 
            this.HtLbl.AutoSize = true;
            this.HtLbl.Location = new System.Drawing.Point(65, 20);
            this.HtLbl.Name = "HtLbl";
            this.HtLbl.Size = new System.Drawing.Size(39, 13);
            this.HtLbl.TabIndex = 0;
            this.HtLbl.Text = "Họ tên";
            // 
            // CvLbl
            // 
            this.CvLbl.AutoSize = true;
            this.CvLbl.Location = new System.Drawing.Point(57, 53);
            this.CvLbl.Name = "CvLbl";
            this.CvLbl.Size = new System.Drawing.Size(47, 13);
            this.CvLbl.TabIndex = 1;
            this.CvLbl.Text = "Chức vụ";
            // 
            // SdtLbl
            // 
            this.SdtLbl.AutoSize = true;
            this.SdtLbl.Location = new System.Drawing.Point(34, 90);
            this.SdtLbl.Name = "SdtLbl";
            this.SdtLbl.Size = new System.Drawing.Size(70, 13);
            this.SdtLbl.TabIndex = 2;
            this.SdtLbl.Text = "Số điện thoại";
            // 
            // DcLbl
            // 
            this.DcLbl.AutoSize = true;
            this.DcLbl.Location = new System.Drawing.Point(64, 124);
            this.DcLbl.Name = "DcLbl";
            this.DcLbl.Size = new System.Drawing.Size(40, 13);
            this.DcLbl.TabIndex = 3;
            this.DcLbl.Text = "Địa chỉ";
            // 
            // HtTBox
            // 
            this.HtTBox.Location = new System.Drawing.Point(110, 17);
            this.HtTBox.Name = "HtTBox";
            this.HtTBox.Size = new System.Drawing.Size(221, 20);
            this.HtTBox.TabIndex = 5;
            // 
            // CvTBox
            // 
            this.CvTBox.Location = new System.Drawing.Point(110, 50);
            this.CvTBox.Name = "CvTBox";
            this.CvTBox.Size = new System.Drawing.Size(121, 20);
            this.CvTBox.TabIndex = 6;
            // 
            // SdtTBox
            // 
            this.SdtTBox.Location = new System.Drawing.Point(110, 87);
            this.SdtTBox.Name = "SdtTBox";
            this.SdtTBox.Size = new System.Drawing.Size(121, 20);
            this.SdtTBox.TabIndex = 7;
            // 
            // DcTBox
            // 
            this.DcTBox.Location = new System.Drawing.Point(110, 121);
            this.DcTBox.Name = "DcTBox";
            this.DcTBox.Size = new System.Drawing.Size(221, 20);
            this.DcTBox.TabIndex = 8;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(106, 157);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 10;
            this.OkBtn.Text = "Tạo mới";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(187, 157);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 11;
            this.CancelBtn.Text = "Quay lại";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ThemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 195);
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
            this.Name = "ThemNhanVien";
            this.Text = "Thêm nhân viên mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HtLbl;
        private System.Windows.Forms.Label CvLbl;
        private System.Windows.Forms.Label SdtLbl;
        private System.Windows.Forms.Label DcLbl;
        private System.Windows.Forms.TextBox HtTBox;
        private System.Windows.Forms.TextBox CvTBox;
        private System.Windows.Forms.TextBox SdtTBox;
        private System.Windows.Forms.TextBox DcTBox;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}