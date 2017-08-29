using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CkpApp
{
    public partial class MayBomForm : Form
    {
        public MayBomForm()
        {
            InitializeComponent();

            LoaiBomCBox.SelectedIndex = 0;
            MayBomGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                MayBomGrid.Rows.Clear();
                var allMayBom = (from b in db.MayBom where b.TrangThai == 1 orderby b.LoaiBom select b).ToList();
                foreach (var mayBom in allMayBom)
                {
                    MayBomGrid.Rows.Add(
                        mayBom.Id,
                        mayBom.TenBom,
                        mayBom.LoaiBom == 1 ? "Bơm công ty" : "Bơm thuê ngoài");
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new CkpEntities();
                var searchText = SearchTBox.Text.Trim().ToLower();
                List<MayBom> result0 = (from b in db.MayBom where b.TrangThai == 1 select b).ToList();
                List<MayBom> result1 = (from b in db.MayBom where b.TrangThai == 1 select b).ToList();

                Cursor.Current = Cursors.WaitCursor;
                MayBomGrid.Rows.Clear();

                if (searchText.Length > 0)
                {
                    result0 = result0.Where(r => r.Id.ToLower() == searchText || r.TenBom.ToLower() == searchText).ToList();
                    result1 = result1.Where(r => r.Id.ToLower().Contains(searchText) || r.TenBom.ToLower().Contains(searchText)).ToList();
                }

                if (LoaiBomCBox.SelectedIndex == 1) //Bom cong ty
                {
                    result0 = result0.Where(r => r.LoaiBom == 1).ToList();
                    result1 = result1.Where(r => r.LoaiBom == 1).ToList();
                }
                else if (LoaiBomCBox.SelectedIndex == 2) //Bom thue ngoai
                {
                    result0 = result0.Where(r => r.LoaiBom == 2).ToList();
                    result1 = result1.Where(r => r.LoaiBom == 2).ToList();
                }
                else { } //Tat ca

                result0 = result0.Union(result1.AsEnumerable()).ToList();

                foreach (var result in result0)
                {
                    MayBomGrid.Rows.Add(
                    result.Id,
                    result.TenBom,
                    result.LoaiBom == 1 ? "Bơm công ty" : "Bơm thuê ngoài");
                }

                if (MayBomGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ThemMayBom>().Count() == 1)
                Application.OpenForms.OfType<ThemMayBom>().First().Focus();
            else
            {
                var addForm = new ThemMayBom(this);
                addForm.Show();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = MayBomGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một máy bơm để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<SuaMayBom>().Count() == 1)
                    Application.OpenForms.OfType<SuaMayBom>().First().Close();

                var id = MayBomGrid.SelectedRows[0].Cells[0].Value.ToString();
                var editForm = new SuaMayBom(this, id);
                editForm.Show();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = MayBomGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn tối thiểu một máy bơm để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var db = new CkpEntities();
                        for (int i = 0; i < selectedRows; i++)
                        {
                            var id = MayBomGrid.SelectedRows[i].Cells[0].Value.ToString();
                            var mayBom = (from b in db.MayBom where b.Id == id select b).FirstOrDefault();
                            mayBom.TrangThai = 0;
                            mayBom.NgaySuaCuoi = DateTime.Now;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " máy bơm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        UpdateDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBtn.PerformClick();
            }
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
            SearchTBox.Text = "";
        }
    }
}
