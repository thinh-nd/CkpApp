namespace CkpApp
{
    partial class ViTriForm
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
            this.ViTriGrid = new System.Windows.Forms.DataGridView();
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ViTriGrid)).BeginInit();
            this.ActionGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViTriGrid
            // 
            this.ViTriGrid.AllowUserToAddRows = false;
            this.ViTriGrid.AllowUserToDeleteRows = false;
            this.ViTriGrid.AllowUserToOrderColumns = true;
            this.ViTriGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViTriGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ViTri});
            this.ViTriGrid.Location = new System.Drawing.Point(90, 12);
            this.ViTriGrid.Name = "ViTriGrid";
            this.ViTriGrid.ReadOnly = true;
            this.ViTriGrid.Size = new System.Drawing.Size(140, 205);
            this.ViTriGrid.TabIndex = 8;
            // 
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Controls.Add(this.AddBtn);
            this.ActionGrp.Location = new System.Drawing.Point(12, 12);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 115);
            this.ActionGrp.TabIndex = 7;
            this.ActionGrp.TabStop = false;
            this.ActionGrp.Text = "Thao tác";
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
            // ViTri
            // 
            this.ViTri.HeaderText = "Vị trí bơm";
            this.ViTri.Name = "ViTri";
            this.ViTri.ReadOnly = true;
            // 
            // DonGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 229);
            this.Controls.Add(this.ViTriGrid);
            this.Controls.Add(this.ActionGrp);
            this.Name = "DonGiaForm";
            this.Text = "Các vị trí bơm";
            ((System.ComponentModel.ISupportInitialize)(this.ViTriGrid)).EndInit();
            this.ActionGrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ViTriGrid;
        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ViTri;
    }
}