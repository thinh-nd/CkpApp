using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CkpApp
{
    public partial class QuanLyBaoCaoForm : Form
    {
        private List<string> KhIds;
        private List<string> CtrIds;
        private List<int> NvIds;
        private List<string> MbIds;

        public QuanLyBaoCaoForm()
        {
            KhIds = new List<string>();
            CtrIds = new List<string>();
            NvIds = new List<int>();
            MbIds = new List<string>();

            InitializeComponent();
            InitializeData();

            BaoCaoGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            CtrCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            CtrCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            KhCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            KhCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            MbCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            MbCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            CtrCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            CtrCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void InitializeData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var kh = (from k in db.KhachHang where k.TrangThai == 1 orderby k.TenCongTy select k);
                var ct = (from c in db.CongTrinh where c.TrangThai == 1 orderby c.TenCongTrinh select c);
                var mb = (from b in db.MayBom where b.TrangThai == 1 orderby b.LoaiBom select b);
                var nv = (from n in db.NhanVien where n.TrangThai == 1 orderby n.HoTen select n);

                foreach (var k in kh)
                {
                    KhCb.Items.Add(k.TenCongTy);
                    KhIds.Add(k.Id);
                }
                foreach (var c in ct)
                {
                    CtrCb.Items.Add(c.TenCongTrinh + " - " + c.DiaChi);
                    CtrIds.Add(c.Id);
                }
                foreach (var b in mb)
                {
                    MbCb.Items.Add(b.Id + " - " + b.TenBom);
                    MbIds.Add(b.Id);
                }
                foreach (var n in nv)
                {
                    NvCb.Items.Add(n.Id + ". " + n.HoTen + " - " + n.ChucVu);
                    NvIds.Add(n.Id);
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
                if (CtrCb.SelectedIndex == -1 && KhCb.SelectedIndex == -1 && MbCb.SelectedIndex == -1 && NvCb.SelectedIndex == -1 && DateTb.Text.Length == 0 && DfromTb.Text.Length == 0 && DtoTb.Text.Length == 0) return;

                Cursor.Current = Cursors.WaitCursor;
                BaoCaoGrid.Rows.Clear();
                var dt = DateTime.Now;
                var cul = CultureInfo.InvariantCulture;
                var dts = DateTimeStyles.None;

                if ((DateTb.Text.Length > 0 && !DateTime.TryParseExact(DateTb.Text, "ddMMyyyy", cul, dts, out dt)) || 
                    (DfromTb.Text.Length > 0 && !DateTime.TryParseExact(DfromTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dt)) ||
                    (DtoTb.Text.Length > 0 && !DateTime.TryParseExact(DtoTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dt)))
                {
                    MessageBox.Show("Ngày không đúng với format ddMMyyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var db = new CkpEntities();
                var bc = (from b in db.BaoCaoNgay where b.TrangThai == 1 select b).ToList();

                if (KhCb.SelectedIndex > -1)
                {
                    bc = bc.Where(b => b.KhachHangId == KhIds[KhCb.SelectedIndex]).ToList();
                }
                if (CtrCb.SelectedIndex > -1)
                {
                    bc = bc.Where(b => b.CongTrinhId == CtrIds[CtrCb.SelectedIndex]).ToList();
                }
                if (MbCb.SelectedIndex > -1)
                {
                    bc = bc.Where(b => b.MayBomId == MbIds[MbCb.SelectedIndex]).ToList();
                }
                if (NvCb.SelectedIndex > -1)
                {
                    bc = bc.Where(b => 
                        b.NhanLuc_BaoCao.Select(n => n.NhanVienId).Contains(NvIds[NvCb.SelectedIndex]) ||
                        (b.NguoiBaoCaoId.HasValue && b.NguoiBaoCaoId.Value == NvIds[NvCb.SelectedIndex])).ToList();
                }
                if (DateTb.Text.Length > 0)
                {
                    bc = bc.Where(b => b.NgayBaoCao.Value.Date == DateTime.ParseExact(DateTb.Text, "ddMMyyyy", cul).Date).OrderBy(b => b.NgayBaoCao).ToList();
                }
                if (DfromTb.Text.Length > 0)
                {
                    bc = bc.Where(b => b.NgayBaoCao.Value.Date >= DateTime.ParseExact(DfromTb.Text, "ddMMyyyy", cul).Date).OrderBy(b => b.NgayBaoCao).ToList();
                }
                if (DtoTb.Text.Length > 0)
                {
                    bc = bc.Where(b => b.NgayBaoCao.Value.Date <= DateTime.ParseExact(DtoTb.Text, "ddMMyyyy", cul).Date).OrderBy(b => b.NgayBaoCao).ToList();
                }

                if (bc.Count == 0)
                {
                    MessageBox.Show("Không có kết quả nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                foreach (var b in bc)
                {
                    BaoCaoGrid.Rows.Add(
                    b.Id,
                    b.NgayBaoCao.Value.ToString("dd/MM"),
                    b.CongTrinh.TenCongTrinh,
                    b.KhachHang.TenCongTy,
                    string.Format("{0} ({1})", b.MayBom.TenBom, b.MayBom.Id),
                    db.NhanVien.Where(nv => nv.Id == b.NguoiBaoCaoId).Select(nv => nv.HoTen).FirstOrDefault(),
                    b.NgayTao,
                    b.NgaySuaCuoi);
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            KhCb.SelectedIndex = -1;
            CtrCb.SelectedIndex = -1;
            MbCb.SelectedIndex = -1;
            NvCb.SelectedIndex = -1;
            DateTb.Text = "";
            DfromTb.Text = "";
            DtoTb.Text = "";
            BaoCaoGrid.Rows.Clear();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = BaoCaoGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn tối thiểu một báo cáo để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            var id = int.Parse(BaoCaoGrid.SelectedRows[i].Cells[0].Value.ToString());
                            var bc = (from b in db.BaoCaoNgay where b.Id == id select b).FirstOrDefault();
                            bc.TrangThai = 0;
                            bc.NgaySuaCuoi = DateTime.Now;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        UpdateSearchResult();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = BaoCaoGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một báo cáo để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var id = int.Parse(BaoCaoGrid.SelectedRows[0].Cells[0].Value.ToString());
                var form = new BaoCaoNgayForm(this, id);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
            }
        }

        public void UpdateSearchResult()
        {
            SearchBtn.PerformClick();
        }

        private void CtrCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var cId = CtrIds[CtrCb.SelectedIndex];
                var cty = (from c in db.CongTrinh where c.Id == cId select c.KhachHang.TenCongTy).FirstOrDefault();
                KhCb.SelectedIndex = KhCb.FindStringExact(cty);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
