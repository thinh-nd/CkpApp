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
    public partial class CongTrinhForm : Form
    {
        private string KhId { get; set; }
        private List<string> KhIds { get; set; }

        public CongTrinhForm()
        {
            InitializeComponent();

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                KhIds = new List<string>();
                var kh = (from k in db.KhachHang where k.TrangThai == 1 select k);

                foreach (var k in kh)
                {
                    CtyCBox.Items.Add(k.TenCongTy);
                    KhIds.Add(k.Id);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CTrGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CtyCBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            CtyCBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public void UpdateDataGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var ctr = (from c in db.CongTrinh where c.KhachHangId == KhId && c.TrangThai == 1 select c).ToList();

                CTrGrid.Rows.Clear();
                foreach (var ct in ctr)
                {
                    CTrGrid.Rows.Add(
                        ct.Id,
                        ct.TenCongTrinh,
                        ct.DiaChi,
                        ct.SoHopDong,
                        ct.NguoiPhuTrachId.HasValue ? ct.NhanVien.HoTen : "",
                        ct.NgayKyHD,
                        ct.NgayThucHien);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CtyCBox.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn một khách hàng để thêm công trình", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Application.OpenForms.OfType<ThemCongTrinh>().Count() == 1)
                Application.OpenForms.OfType<ThemCongTrinh>().First().Close();

            var form = new ThemCongTrinh(this, KhId);
            form.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = CTrGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một công trình để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<SuaCongTrinh>().Count() == 1)
                    Application.OpenForms.OfType<SuaCongTrinh>().First().Close();

                var id = CTrGrid.SelectedRows[0].Cells[0].Value.ToString();
                var form = new SuaCongTrinh(this, KhId, id);
                form.Show();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = CTrGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhât một công trình để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var id = CTrGrid.SelectedRows[i].Cells[0].Value.ToString();
                            var ctr = (from c in db.CongTrinh where c.Id == id && c.TrangThai == 1 select c).FirstOrDefault();
                            ctr.TrangThai = 0;
                            ctr.NgaySuaCuoi = DateTime.Now;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " công trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void ShowAllBtn_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        private void CtyCBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            KhId = KhIds[CtyCBox.SelectedIndex];
            KhIdTBox.Text = KhId;
            UpdateDataGrid();
        }
    }
}
