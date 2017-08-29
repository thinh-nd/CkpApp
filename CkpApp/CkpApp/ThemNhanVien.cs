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
    public partial class ThemNhanVien : Form
    {
        private NhanVienForm parentForm { get; set; }

        public ThemNhanVien()
        {
            InitializeComponent();
        }

        public ThemNhanVien(NhanVienForm form)
            : this()
        {
            parentForm = form;
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
                    var newNv = new NhanVien
                    {
                        HoTen = name,
                        ChucVu = cvu,
                        SoDienThoai = sdt.Length == 0 ? null : sdt,
                        DiaChi = dc.Length == 0 ? null : dc,
                        TrangThai = 1,
                        NgayTao = DateTime.Now,
                        NgaySuaCuoi = DateTime.Now
                    };
                    db.NhanVien.Add(newNv);
                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    parentForm.UpdateDataGrid();
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
