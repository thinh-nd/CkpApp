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
    public partial class SuaCongTrinh : Form
    {
        private CongTrinhForm parentForm { get; set; }
        private string KhId { get; set; }

        public SuaCongTrinh()
        {
            InitializeComponent();
        }

        public SuaCongTrinh(CongTrinhForm form, string kId, string cId)
            : this()
        {
            parentForm = form;
            KhId = kId;

            var db = new CkpEntities();
            CtyTBox.Text = (from k in db.KhachHang where k.Id == kId select k.TenCongTy).First();
            var ct = (from c in db.CongTrinh where c.Id == cId select c).First();
            var nv = (from n in db.NhanVien where n.TrangThai == 1 select n);
            foreach (var n in nv)
            {
                NptCb.Items.Add(n.Id + ". " + n.HoTen + " - " + n.ChucVu);
            }

            CtrIdTBox.Text = ct.Id;
            CtrIdTBox.ReadOnly = true;
            CtrNameTBox.Text = ct.TenCongTrinh;
            CtrDcTBox.Text = ct.DiaChi == null ? "" : ct.DiaChi;
            SoHdTBox.Text = ct.SoHopDong == null ? "" : ct.SoHopDong;
            NptCb.SelectedIndex = ct.NguoiPhuTrachId == null ? -1 : NptCb.FindStringExact(ct.NhanVien.Id + ". " + ct.NhanVien.HoTen + " - " + ct.NhanVien.ChucVu);
            NgayKyTBox.Text = ct.NgayKyHD == null ? "" : ct.NgayKyHD.Value.ToString("ddMMyyyy");
            NgayThTBox.Text = ct.NgayThucHien == null ? "" : ct.NgayThucHien.Value.ToString("ddMMyyyy");
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayKy = new DateTime();
                DateTime ngayTh = new DateTime();
                var cul = CultureInfo.InvariantCulture;
                var dts = DateTimeStyles.None;

                if ((!DateTime.TryParseExact(NgayKyTBox.Text, "ddMMyyyy", cul, dts, out ngayKy) && NgayKyTBox.Text.Length > 0) ||
                        (!DateTime.TryParseExact(NgayThTBox.Text, "ddMMyyyy", cul, dts, out ngayTh) && NgayThTBox.Text.Length > 0))
                {
                    MessageBox.Show("Ngày ký hoặc ngày thực hiện không đúng format ddMMyyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var id = CtrIdTBox.Text.Trim();
                var name = CtrNameTBox.Text.Trim();
                if (id.Length == 0 || name.Length == 0)
                {
                    if (id.Length == 0) CtrIdTBox.ForeColor = Color.Red;
                    else CtrIdTBox.ForeColor = Color.Black;

                    if (name.Length == 0) CtrNameTBox.ForeColor = Color.Red;
                    else CtrNameTBox.ForeColor = Color.Black;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();
                    var ctr = (from c in db.CongTrinh where c.Id == id select c).First();
                    ctr.TenCongTrinh = name;
                    ctr.DiaChi = CtrDcTBox.Text.Length > 0 ? CtrDcTBox.Text.Trim() : null;
                    ctr.SoHopDong = SoHdTBox.Text.Length > 0 ? SoHdTBox.Text.Trim() : null;
                    ctr.NguoiPhuTrachId = NptCb.SelectedIndex > -1 ? int.Parse(NptCb.Text.Split('.')[0]) : (int?)null;
                    ctr.NgayKyHD = NgayKyTBox.Text.Length > 0 ? ngayKy : (DateTime?)null;
                    ctr.NgayThucHien = NgayThTBox.Text.Length > 0 ? ngayTh : (DateTime?)null;
                    ctr.NgaySuaCuoi = DateTime.Now;

                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    parentForm.UpdateDataGrid();
                    Close();
                }
            }
            catch (Exception ex)
            {
                var exMsg = ex.GetBaseException().Message;
                if (exMsg.Contains("Violation of PRIMARY KEY constrain"))
                {
                    MessageBox.Show("Mã công trình đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
