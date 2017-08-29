namespace CkpApp
{
    partial class DataManager
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
            this.BackupBtn = new System.Windows.Forms.Button();
            this.RestoreBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BackupBtn
            // 
            this.BackupBtn.Location = new System.Drawing.Point(40, 24);
            this.BackupBtn.Name = "BackupBtn";
            this.BackupBtn.Size = new System.Drawing.Size(102, 43);
            this.BackupBtn.TabIndex = 0;
            this.BackupBtn.Text = "Sao lưu dữ liệu (Backup)";
            this.BackupBtn.UseVisualStyleBackColor = true;
            this.BackupBtn.Click += new System.EventHandler(this.BackupBtn_Click);
            // 
            // RestoreBtn
            // 
            this.RestoreBtn.Location = new System.Drawing.Point(176, 24);
            this.RestoreBtn.Name = "RestoreBtn";
            this.RestoreBtn.Size = new System.Drawing.Size(102, 43);
            this.RestoreBtn.TabIndex = 1;
            this.RestoreBtn.Text = "Khôi phục dữ liệu (Restore)";
            this.RestoreBtn.UseVisualStyleBackColor = true;
            this.RestoreBtn.Click += new System.EventHandler(this.RestoreBtn_Click);
            // 
            // DataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 94);
            this.Controls.Add(this.RestoreBtn);
            this.Controls.Add(this.BackupBtn);
            this.Name = "DataManager";
            this.Text = "Quản lý kho dữ liệu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackupBtn;
        private System.Windows.Forms.Button RestoreBtn;
    }
}