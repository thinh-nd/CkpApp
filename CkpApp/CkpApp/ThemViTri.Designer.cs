namespace CkpApp
{
    partial class ThemViTri
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.ViTriTBox = new System.Windows.Forms.TextBox();
            this.ViTriLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(107, 50);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 16;
            this.OkBtn.Text = "Tạo mới";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // ViTriTBox
            // 
            this.ViTriTBox.Location = new System.Drawing.Point(129, 12);
            this.ViTriTBox.Name = "ViTriTBox";
            this.ViTriTBox.Size = new System.Drawing.Size(109, 20);
            this.ViTriTBox.TabIndex = 14;
            // 
            // ViTriLbl
            // 
            this.ViTriLbl.AutoSize = true;
            this.ViTriLbl.Location = new System.Drawing.Point(50, 15);
            this.ViTriLbl.Name = "ViTriLbl";
            this.ViTriLbl.Size = new System.Drawing.Size(73, 13);
            this.ViTriLbl.TabIndex = 11;
            this.ViTriLbl.Text = "Tên vị trí bơm";
            // 
            // ThemViTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 85);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.ViTriTBox);
            this.Controls.Add(this.ViTriLbl);
            this.Name = "ThemViTri";
            this.Text = "Thêm đơn giá mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.TextBox ViTriTBox;
        private System.Windows.Forms.Label ViTriLbl;
    }
}