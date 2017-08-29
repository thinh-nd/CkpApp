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
    public partial class ThemCongTrinh : Form
    {
        private CongTrinhForm parentForm { get; set; }
        private string KhId { get; set; }

        public ThemCongTrinh()
        {
            InitializeComponent();
        }

        public ThemCongTrinh(CongTrinhForm form, string kId)
            : this()
        {
            parentForm = form;
            KhId = kId;

            var db = new CkpEntities();
            CtyTBox.Text = (from k in db.KhachHang where k.Id == kId select k.TenCongTy).First();
            var nv = (from n in db.NhanVien where n.TrangThai == 1 select n);
            foreach (var n in nv)
            {
                NptCb.Items.Add(n.Id + ". " + n.HoTen + " - " + n.ChucVu);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var id = CtrIdTBox.Text.Trim();
                var name = CtrNameTBox.Text.Trim();
                if (id.Length == 0 || name.Length == 0)
                {
                    if (id.Length == 0) CtrIdLbl.ForeColor = Color.Red;
                    else CtrIdLbl.ForeColor = Color.Black;

                    if (name.Length == 0) CtrNameLbl.ForeColor = Color.Red;
                    else CtrNameLbl.ForeColor = Color.Black;
                }
                else
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

                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();
                    var newCtr = new CongTrinh
                    {
                        Id = id,
                        TenCongTrinh = name,
                        DiaChi = CtrDcTBox.Text.Length == 0 ? null : CtrDcTBox.Text.Trim(),
                        KhachHangId = KhId,
                        SoHopDong = SoHdTBox.Text.Length == 0 ? null : SoHdTBox.Text.Trim(),
                        NguoiPhuTrachId = NptCb.SelectedIndex == -1 ? (int?)null : int.Parse(NptCb.Text.Split('.')[0]),
                        NgayKyHD = NgayKyTBox.Text.Length == 0 ? (DateTime?)null : ngayKy,
                        NgayThucHien = NgayThTBox.Text.Length == 0 ? (DateTime?)null : ngayTh,
                        TrangThai = 1,
                        NgayTao = DateTime.Now,
                        NgaySuaCuoi = DateTime.Now
                    };
                    db.CongTrinh.Add(newCtr);
                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Tạo mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
