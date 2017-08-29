namespace CkpApp
{
    partial class MayBomForm
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
            this.SearchBtn = new System.Windows.Forms.Button();
            this.TimKiemGrp = new System.Windows.Forms.GroupBox();
            this.LoaiBomCBox = new System.Windows.Forms.ComboBox();
            this.SearchTBox = new System.Windows.Forms.TextBox();
            this.TypeLbl = new System.Windows.Forms.Label();
            this.KeywordLbl = new System.Windows.Forms.Label();
            this.ActionGrp = new System.Windows.Forms.GroupBox();
            this.ShowAllBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.MayBomGrid = new System.Windows.Forms.DataGridView();
            this.MaMayBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMayBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiBom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimKiemGrp.SuspendLayout();
            this.ActionGrp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MayBomGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(446, 14);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "Tìm kiếm";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // TimKiemGrp
            // 
            this.TimKiemGrp.Controls.Add(this.LoaiBomCBox);
            this.TimKiemGrp.Controls.Add(this.SearchTBox);
            this.TimKiemGrp.Controls.Add(this.SearchBtn);
            this.TimKiemGrp.Controls.Add(this.TypeLbl);
            this.TimKiemGrp.Controls.Add(this.KeywordLbl);
            this.TimKiemGrp.Location = new System.Drawing.Point(12, 12);
            this.TimKiemGrp.Name = "TimKiemGrp";
            this.TimKiemGrp.Size = new System.Drawing.Size(527, 47);
            this.TimKiemGrp.TabIndex = 2;
            this.TimKiemGrp.TabStop = false;
            this.TimKiemGrp.Text = "Tìm kiếm";
            // 
            // LoaiBomCBox
            // 
            this.LoaiBomCBox.FormattingEnabled = true;
            this.LoaiBomCBox.Items.AddRange(new object[] {
            "Tất cả",
            "Bơm công ty",
            "Bơm thuê ngoài"});
            this.LoaiBomCBox.Location = new System.Drawing.Point(334, 16);
            this.LoaiBomCBox.Name = "LoaiBomCBox";
            this.LoaiBomCBox.Size = new System.Drawing.Size(106, 21);
            this.LoaiBomCBox.TabIndex = 3;
            // 
            // SearchTBox
            // 
            this.SearchTBox.Location = new System.Drawing.Point(106, 16);
            this.SearchTBox.Name = "SearchTBox";
            this.SearchTBox.Size = new System.Drawing.Size(166, 20);
            this.SearchTBox.TabIndex = 2;
            this.SearchTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTBox_KeyPress);
            // 
            // TypeLbl
            // 
            this.TypeLbl.AutoSize = true;
            this.TypeLbl.Location = new System.Drawing.Point(278, 19);
            this.TypeLbl.Name = "TypeLbl";
            this.TypeLbl.Size = new System.Drawing.Size(50, 13);
            this.TypeLbl.TabIndex = 1;
            this.TypeLbl.Text = "Loại bơm";
            // 
            // KeywordLbl
            // 
            this.KeywordLbl.AutoSize = true;
            this.KeywordLbl.Location = new System.Drawing.Point(6, 19);
            this.KeywordLbl.Name = "KeywordLbl";
            this.KeywordLbl.Size = new System.Drawing.Size(94, 13);
            this.KeywordLbl.TabIndex = 0;
            this.KeywordLbl.Text = "Mã hoặc Tên bơm";
            // 
            // ActionGrp
            // 
            this.ActionGrp.Controls.Add(this.ShowAllBtn);
            this.ActionGrp.Controls.Add(this.DelBtn);
            this.ActionGrp.Controls.Add(this.EditBtn);
            this.ActionGrp.Controls.Add(this.AddBtn);
            this.ActionGrp.Location = new System.Drawing.Point(12, 65);
            this.ActionGrp.Name = "ActionGrp";
            this.ActionGrp.Size = new System.Drawing.Size(72, 156);
            this.ActionGrp.TabIndex = 3;
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
            // MayBomGrid
            // 
            this.MayBomGrid.AllowUserToAddRows = false;
            this.MayBomGrid.AllowUserToDeleteRows = false;
            this.MayBomGrid.AllowUserToOrderColumns = true;
            this.MayBomGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MayBomGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MayBomGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMayBom,
            this.TenMayBom,
            this.LoaiBom});
            this.MayBomGrid.Location = new System.Drawing.Point(90, 65);
            this.MayBomGrid.Name = "MayBomGrid";
            this.MayBomGrid.Size = new System.Drawing.Size(449, 212);
            this.MayBomGrid.TabIndex = 4;
            // 
            // MaMayBom
            // 
            this.MaMayBom.HeaderText = "Mã máy bơm";
            this.MaMayBom.Name = "MaMayBom";
            this.MaMayBom.ReadOnly = true;
            // 
            // TenMayBom
            // 
            this.TenMayBom.HeaderText = "Tên máy bơm";
            this.TenMayBom.Name = "TenMayBom";
            this.TenMayBom.ReadOnly = true;
            // 
            // LoaiBom
            // 
            this.LoaiBom.HeaderText = "Loại bơm";
            this.LoaiBom.Name = "LoaiBom";
            this.LoaiBom.ReadOnly = true;
            // 
            // MayBomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(551, 289);
            this.Controls.Add(this.MayBomGrid);
            this.Controls.Add(this.ActionGrp);
            this.Controls.Add(this.TimKiemGrp);
            this.Name = "MayBomForm";
            this.Text = "Quản lý máy bơm";
            this.TimKiemGrp.ResumeLayout(false);
            this.TimKiemGrp.PerformLayout();
            this.ActionGrp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MayBomGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.GroupBox TimKiemGrp;
        private System.Windows.Forms.ComboBox LoaiBomCBox;
        private System.Windows.Forms.TextBox SearchTBox;
        private System.Windows.Forms.Label TypeLbl;
        private System.Windows.Forms.Label KeywordLbl;
        private System.Windows.Forms.GroupBox ActionGrp;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridView MayBomGrid;
        private System.Windows.Forms.Button ShowAllBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMayBom;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMayBom;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiBom;
    }
}