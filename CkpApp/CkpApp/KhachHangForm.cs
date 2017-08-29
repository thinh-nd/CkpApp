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
    public partial class KhachHangForm : Form
    {
        public KhachHangForm()
        {
            InitializeComponent();

            STypeCBox.Text = "Tất cả";
            KhachHangGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                KhachHangGrid.Rows.Clear();
                using (var db = new CkpEntities())
                {
                    var allKhachHang = (from k in db.KhachHang where k.TrangThai == 1 select k).ToList();
                    foreach (var kh in allKhachHang)
                    {
                        KhachHangGrid.Rows.Add(
                            kh.Id,
                            kh.TenCongTy,
                            kh.DiaChi,
                            kh.MaSoThue);
                    }
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
                    var db = new CkpEntities();
                    Cursor.Current = Cursors.WaitCursor;
                    KhachHangGrid.Rows.Clear();
                    var result = (from k in db.KhachHang where k.TrangThai == 1 select k).ToList();

                    if (STypeCBox.SelectedIndex == 1) //Ma KH
                    {
                        result = result.Where(k => k.Id.ToLower() == searchText).ToList();
                    }
                    else if (STypeCBox.SelectedIndex == 2) //Ten cong ty
                    {
                        result = result.Where(k => k.TenCongTy.ToLower().Contains(searchText)).ToList();
                    }
                    else if (STypeCBox.SelectedIndex == 3) //Dia chi
                    {
                        result = result.Where(k => k.DiaChi != null && k.DiaChi.ToLower().Contains(searchText)).ToList();
                    }
                    else if (STypeCBox.SelectedIndex == 4) //Ma so thue
                    {
                        result = result.Where(k => k.MaSoThue != null && k.MaSoThue == searchText).ToList();
                    }
                    else //All
                    {
                        result = result.Where(k => k.Id.ToLower() == searchText
                            || k.TenCongTy.ToLower().Contains(searchText)
                            || (k.DiaChi != null && k.DiaChi.ToLower().Contains(searchText))
                            || (k.MaSoThue != null && k.MaSoThue == searchText)).ToList();
                    }

                    foreach (var kh in result)
                    {
                        var lhs = (from lh in kh.NguoiLienHe select lh.HoTen).ToList();
                        KhachHangGrid.Rows.Add(
                            kh.Id,
                            kh.TenCongTy,
                            kh.DiaChi,
                            kh.MaSoThue);
                    }

                    if (KhachHangGrid.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả nào", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    Cursor.Current = Cursors.Default;
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
            if (Application.OpenForms.OfType<ThemKhachHang>().Count() == 1)
                Application.OpenForms.OfType<ThemKhachHang>().First().Focus();
            else
            {
                var form = new ThemKhachHang(this);
                form.Show();
            }
        }

        private void SearchTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchBtn.PerformClick();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = KhachHangGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<SuaKhachHang>().Count() == 1)
                    Application.OpenForms.OfType<SuaKhachHang>().First().Close();

                var id = KhachHangGrid.SelectedRows[0].Cells[0].Value.ToString();
                var form = new SuaKhachHang(this, id);
                form.Show();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = KhachHangGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn tối thiểu một khách hàng để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var id = KhachHangGrid.SelectedRows[i].Cells[0].Value.ToString();
                            var kh = (from k in db.KhachHang where k.Id == id select k).FirstOrDefault();
                            kh.TrangThai = 0;
                            kh.NgaySuaCuoi = DateTime.Now;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void DetailBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = KhachHangGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<ChiTietKhachHang>().Count() == 1)
                    Application.OpenForms.OfType<ChiTietKhachHang>().First().Close();

                var id = KhachHangGrid.SelectedRows[0].Cells[0].Value.ToString();
                var form = new ChiTietKhachHang(id);
                form.Show();
            }
        }

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
            SearchTBox.Text = "";
        }
    }
}
