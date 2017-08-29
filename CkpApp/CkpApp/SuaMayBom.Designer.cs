namespace CkpApp
{
    partial class SuaMayBom
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
            this.EditBtn = new System.Windows.Forms.Button();
            this.TypeCBox = new System.Windows.Forms.ComboBox();
            this.NameTBox = new System.Windows.Forms.TextBox();
            this.IdTbox = new System.Windows.Forms.TextBox();
            this.TypeLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.IdLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(152, 101);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 19;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Location = new System.Drawing.Point(57, 101);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 23);
            this.EditBtn.TabIndex = 17;
            this.EditBtn.Text = "Thay đổi";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // TypeCBox
            // 
            this.TypeCBox.FormattingEnabled = true;
            this.TypeCBox.Items.AddRange(new object[] {
            "Bơm công ty",
            "Bơm thuê ngoài"});
            this.TypeCBox.Location = new System.Drawing.Point(127, 64);
            this.TypeCBox.Name = "TypeCBox";
            this.TypeCBox.Size = new System.Drawing.Size(100, 21);
            this.TypeCBox.TabIndex = 16;
            // 
            // NameTBox
            // 
            this.NameTBox.Location = new System.Drawing.Point(127, 38);
            this.NameTBox.Name = "NameTBox";
            this.NameTBox.Size = new System.Drawing.Size(100, 20);
            this.NameTBox.TabIndex = 15;
            // 
            // IdTbox
            // 
            this.IdTbox.Location = new System.Drawing.Point(127, 12);
            this.IdTbox.Name = "IdTbox";
            this.IdTbox.ReadOnly = true;
            this.IdTbox.Size = new System.Drawing.Size(100, 20);
            this.IdTbox.TabIndex = 14;
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Location = new System.Drawing.Point(49, 67);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(72, 13);
            this.TypeLbl.TabIndex = 13;
            this.TypeLbl.Text = "Loại máy bơm";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(50, 41);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(71, 13);
            this.NameLbl.TabIndex = 12;
            this.NameLbl.Text = "Tên máy bơm";
            // 
            // IdLbl
            // 
            this.IdLbl.AutoSize = true;
            this.IdLbl.Location = new System.Drawing.Point(54, 15);
            this.IdLbl.Name = "IdLbl";
            this.IdLbl.Size = new System.Drawing.Size(67, 13);
            this.IdLbl.TabIndex = 11;
            this.IdLbl.Text = "Mã máy bơm";
            this.IdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuaMayBom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.TypeCBox);
            this.Controls.Add(this.NameTBox);
            this.Controls.Add(this.IdTbox);
            this.Controls.Add(this.TypeLbl);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.IdLbl);
            this.Name = "SuaMayBom";
            this.Text = "Thay đổi thông tin máy bơm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.ComboBox TypeCBox;
        private System.Windows.Forms.TextBox NameTBox;
        private System.Windows.Forms.TextBox IdTbox;
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.Label IdLbl;

    }
}