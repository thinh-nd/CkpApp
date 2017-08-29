using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CkpApp
{
    public partial class NhanVienForm : Form
    {
        public NhanVienForm()
        {
            InitializeComponent();

            NvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                NvGrid.Rows.Clear();
                var db = new CkpEntities();
                var allNv = (from nv in db.NhanVien where nv.TrangThai == 1 select nv).ToList();

                foreach (var nv in allNv)
                {
                    NvGrid.Rows.Add(
                        nv.Id,
                        nv.HoTen,
                        nv.ChucVu,
                        nv.SoDienThoai,
                        nv.DiaChi);
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
                var searchText = SearchTBox.Text.Trim().ToLower();
                if (searchText.Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();
                    var nvs = (from nv in db.NhanVien where nv.TrangThai == 1 select nv).ToList();

                    NvGrid.Rows.Clear();

                    nvs = nvs.Where(nv => nv.HoTen.ToLower().Contains(searchText)
                        || nv.ChucVu.ToLower() == searchText
                        || nv.SoDienThoai == searchText
                        || (nv.DiaChi != null && nv.DiaChi.Contains(searchText))).ToList();

                    foreach (var nv in nvs)
                    {
                        NvGrid.Rows.Add(
                            nv.Id,
                            nv.HoTen,
                            nv.ChucVu,
                            nv.SoDienThoai,
                            nv.DiaChi);
                    }
                    Cursor.Current = Cursors.Default;

                    if (NvGrid.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ThemNhanVien>().Count() == 1)
                Application.OpenForms.OfType<ThemNhanVien>().First().Focus();
            else
            {
                var form = new ThemNhanVien(this);
                form.Show();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = NvGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<SuaNhanVien>().Count() == 1)
                    Application.OpenForms.OfType<SuaNhanVien>().First().Close();

                var id = (int) NvGrid.SelectedRows[0].Cells[0].Value;
                var editForm = new SuaNhanVien(this, id);
                editForm.Show();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = NvGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn tối thiểu một nhân viên để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var id = (int) NvGrid.SelectedRows[i].Cells[0].Value;
                            var nv = (from n in db.NhanVien where n.Id == id select n).FirstOrDefault();
                            nv.TrangThai = 0;
                            nv.NgaySuaCuoi = DateTime.Now;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
