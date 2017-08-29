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
    public partial class DonGiaForm : Form
    {
        private string CtrId;
        private List<string> CtrIds;

        public DonGiaForm()
        {
            InitializeComponent();

            try
            {
                var db = new CkpEntities();
                CtrIds = new List<string>();
                var ctr = (from c in db.CongTrinh where c.TrangThai == 1 select c);

                foreach (var c in ctr)
                {
                    CtrCb.Items.Add(c.TenCongTrinh);
                    CtrIds.Add(c.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DonGiaGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CtrCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            CtrCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public void UpdateDataGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DonGiaGrid.Rows.Clear();
                var db = new CkpEntities();
                var ctr = (from c in db.CongTrinh where c.Id == CtrId && c.TrangThai == 1 select c).FirstOrDefault();
                DcTBox.Text = ctr.DiaChi;
                KhTBox.Text = ctr.KhachHang.TenCongTy;

                foreach (var dg in ctr.DonGiaBom.Where(d => d.TrangThai == 1))
                {
                    DonGiaGrid.Rows.Add(
                        dg.Id,
                        dg.TenDonGia,
                        dg.DonGia.HasValue ? dg.DonGia.Value.ToString("N0") : null,
                        dg.DonGiaVAT.HasValue ? dg.DonGia.Value.ToString("N0") : null,
                        dg.MinKlgBomCan.HasValue ? dg.MinKlgBomCan.Value.ToString("N2") : null,
                        dg.MinKlgBomTinh.HasValue ? dg.MinKlgBomTinh.Value.ToString("N2") : null,
                        dg.CC1.HasValue ? dg.CC1.Value.ToString("N0") : null,
                        dg.TongCC2.HasValue ? dg.TongCC2.Value.ToString("N0") : null,
                        dg.PhanTramBackCC2.HasValue ? dg.PhanTramBackCC2.Value.ToString("N2") : null,
                        dg.TienBackCC2.HasValue ? dg.TienBackCC2.Value.ToString("N0") : null,
                        dg.NetCC2.HasValue ? dg.NetCC2.Value.ToString("N0") : null,
                        dg.TongThuVAT.HasValue ? dg.TongThuVAT.Value.ToString("N0") : null,
                        dg.TongVAT.HasValue ? dg.TongVAT.Value.ToString("N0") : null,
                        dg.TongThu.HasValue ? dg.TongThu.Value.ToString("N0") : null,
                        dg.TongCC.HasValue ? dg.TongCC.Value.ToString("N0") : null,
                        dg.CongThuc,
                        dg.GhiChu);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CtrCb.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn một công trình để thêm đơn giá", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Application.OpenForms.OfType<ThemDonGia>().Count() == 1)
                Application.OpenForms.OfType<ThemDonGia>().First().Close();

            var form = new ThemDonGia(this, CtrId);
            form.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = DonGiaGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một đơn giá để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<SuaDonGia>().Count() == 1)
                    Application.OpenForms.OfType<SuaDonGia>().First().Close();

                var id = int.Parse(DonGiaGrid.SelectedRows[0].Cells[0].Value.ToString());
                var form = new SuaDonGia(this, id);
                form.Show();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = DonGiaGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn tối thiểu một đơn giá để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var id = int.Parse(DonGiaGrid.SelectedRows[i].Cells[0].Value.ToString());
                            var dg = (from d in db.DonGiaBom where d.Id == id select d).FirstOrDefault();
                            dg.TrangThai = 0;
                            dg.NgaySuaCuoi = DateTime.Now;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void CtrCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                var db = new CkpEntities();
                CtrId = CtrIds[CtrCb.SelectedIndex];
                var ctr = (from c in db.CongTrinh where c.TrangThai == 1 && c.Id == CtrId select c).FirstOrDefault();
                DcTBox.Text = ctr.DiaChi;
                KhTBox.Text = ctr.KhachHang.Id + " - " + ctr.KhachHang.TenCongTy;
                UpdateDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
