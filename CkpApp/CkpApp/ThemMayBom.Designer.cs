namespace CkpApp
{
    partial class ThemMayBom
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
            this.IdLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.TypeLbl = new System.Windows.Forms.Label();
            this.IdTBox = new System.Windows.Forms.TextBox();
            this.NameTBox = new System.Windows.Forms.TextBox();
            this.TypeCBox = new System.Windows.Forms.ComboBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IdLbl
            // 
            this.IdLbl.AutoSize = true;
            this.IdLbl.Location = new System.Drawing.Point(51, 15);
            this.IdLbl.Name = "IdLbl";
            this.IdLbl.Size = new System.Drawing.Size(67, 13);
            this.IdLbl.TabIndex = 1;
            this.IdLbl.Text = "Mã máy bơm";
            this.IdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(47, 41);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(71, 13);
            this.NameLbl.TabIndex = 2;
            this.NameLbl.Text = "Tên máy bơm";
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Location = new System.Drawing.Point(46, 67);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(72, 13);
            this.TypeLbl.TabIndex = 3;
            this.TypeLbl.Text = "Loại máy bơm";
            // 
            // IdTBox
            // 
            this.IdTBox.Location = new System.Drawing.Point(124, 12);
            this.IdTBox.Name = "IdTBox";
            this.IdTBox.Size = new System.Drawing.Size(100, 20);
            this.IdTBox.TabIndex = 4;
            // 
            // NameTBox
            // 
            this.NameTBox.Location = new System.Drawing.Point(124, 38);
            this.NameTBox.Name = "NameTBox";
            this.NameTBox.Size = new System.Drawing.Size(100, 20);
            this.NameTBox.TabIndex = 5;
            // 
            // TypeCBox
            // 
            this.TypeCBox.FormattingEnabled = true;
            this.TypeCBox.Items.AddRange(new object[] {
            "Bơm công ty",
            "Bơm thuê ngoài"});
            this.TypeCBox.Location = new System.Drawing.Point(124, 64);
            this.TypeCBox.Name = "TypeCBox";
            this.TypeCBox.Size = new System.Drawing.Size(100, 21);
            this.TypeCBox.TabIndex = 6;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(68, 108);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 7;
            this.OkBtn.Text = "Tạo mới";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(149, 108);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Quay lại";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // ThemMayBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.TypeCBox);
            this.Controls.Add(this.NameTBox);
            this.Controls.Add(this.IdTBox);
            this.Controls.Add(this.TypeLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.IdLbl);
            this.Name = "ThemMayBom";
            this.Text = "Thêm máy bơm mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IdLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.TextBox IdTBox;
        private System.Windows.Forms.TextBox NameTBox;
        private System.Windows.Forms.ComboBox TypeCBox;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}