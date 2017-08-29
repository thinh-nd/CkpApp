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
    public partial class ChiTietKhachHang : Form
    {
        public ChiTietKhachHang()
        {
            InitializeComponent();
        }

        public ChiTietKhachHang(string id)
            : this()
        {
            try
            {
                var db = new CkpEntities();
                var kh = (from k in db.KhachHang where k.Id == id select k).First();

                KhIdTBox.Text = kh.Id;
                CtyTBox.Text = kh.TenCongTy;
                MstTBox.Text = kh.MaSoThue;
                DcTBox.Text = kh.DiaChi == null ? "" : kh.DiaChi;

                foreach (var nlh in kh.NguoiLienHe.Where(l => l.TrangThai == 1))
                {
                    NlhGrid.Rows.Add(
                        nlh.HoTen,
                        nlh.Chucvu == null ? "" : nlh.Chucvu,
                        nlh.SoDienThoai == null ? "" : nlh.SoDienThoai,
                        nlh.GhiChu == null ? "" : nlh.GhiChu);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
