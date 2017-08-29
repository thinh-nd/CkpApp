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
    public partial class SuaNhanVien : Form
    {
        private NhanVienForm parentForm { get; set; }
        private int NvId { get; set; }

        public SuaNhanVien()
        {
            InitializeComponent();
        }

        public SuaNhanVien(NhanVienForm form, int id)
            : this()
        {
            try
            {
                parentForm = form;
                NvId = id;

                var db = new CkpEntities();
                var nv = (from n in db.NhanVien where n.Id == id select n).FirstOrDefault();
                IdTBox.Text = nv.Id.ToString();
                HtTBox.Text = nv.HoTen;
                CvTBox.Text = nv.ChucVu;
                SdtTBox.Text = nv.SoDienThoai;
                DcTBox.Text = nv.DiaChi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            var name = HtTBox.Text.Trim();
            var cvu = CvTBox.Text.Trim();
            var sdt = SdtTBox.Text.Trim();
            var dc = DcTBox.Text.Trim();

            if (name.Length == 0 || cvu.Length == 0)
            {
                if (name.Length == 0) HtLbl.ForeColor = Color.Red;
                else HtLbl.ForeColor = Color.Black;

                if (cvu.Length == 0) CvLbl.ForeColor = Color.Red;
                else CvLbl.ForeColor = Color.Black;
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();
                    var nv = (from n in db.NhanVien where n.Id == NvId select n).First();

                    nv.HoTen = name;
                    nv.ChucVu = cvu;
                    nv.SoDienThoai = sdt.Length == 0 ? null : sdt;
                    nv.DiaChi = dc.Length == 0 ? null : dc;
                    nv.NgaySuaCuoi = DateTime.Now;

                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    parentForm.UpdateDataGrid();
                    MessageBox.Show("Thay đổi thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
