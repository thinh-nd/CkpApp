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
    public partial class ThemKhachHang : Form
    {
        private KhachHangForm parentForm { get; set; }

        public ThemKhachHang()
        {
            InitializeComponent();

            Cvu1TBox.Enabled = false;
            Cvu2TBox.Enabled = false;
            Cvu3TBox.Enabled = false;
            Cvu4TBox.Enabled = false;

            Sdt1TBox.Enabled = false;
            Sdt2TBox.Enabled = false;
            Sdt3TBox.Enabled = false;
            Sdt4TBox.Enabled = false;

            Gc1TBox.Enabled = false;
            Gc2TBox.Enabled = false;
            Gc3TBox.Enabled = false;
            Gc4TBox.Enabled = false;
        }

        public ThemKhachHang(KhachHangForm form)
            : this()
        {
            parentForm = form;
        }

        private void Nlh1TBox_TextChanged(object sender, EventArgs e)
        {
            if (Nlh1TBox.Text.Length > 0)
            {
                Cvu1TBox.Enabled = true;
                Sdt1TBox.Enabled = true;
                Gc1TBox.Enabled = true;
            }
            else
            {
                Cvu1TBox.Enabled = false;
                Sdt1TBox.Enabled = false;
                Gc1TBox.Enabled = false;
            }
        }

        private void Nlh2TBox_TextChanged(object sender, EventArgs e)
        {
            if (Nlh2TBox.Text.Length > 0)
            {
                Cvu2TBox.Enabled = true;
                Sdt2TBox.Enabled = true;
                Gc2TBox.Enabled = true;
            }
            else
            {
                Cvu2TBox.Enabled = false;
                Sdt2TBox.Enabled = false;
                Gc2TBox.Enabled = false;
            }
        }

        private void Nlh3TBox_TextChanged(object sender, EventArgs e)
        {
            if (Nlh3TBox.Text.Length > 0)
            {
                Cvu3TBox.Enabled = true;
                Sdt3TBox.Enabled = true;
                Gc3TBox.Enabled = true;
            }
            else
            {
                Cvu3TBox.Enabled = false;
                Sdt3TBox.Enabled = false;
                Gc3TBox.Enabled = false;
            }
        }

        private void Nlh4TBox_TextChanged(object sender, EventArgs e)
        {
            if (Nlh4TBox.Text.Length > 0)
            {
                Cvu4TBox.Enabled = true;
                Sdt4TBox.Enabled = true;
                Gc4TBox.Enabled = true;
            }
            else
            {
                Cvu4TBox.Enabled = false;
                Sdt4TBox.Enabled = false;
                Gc4TBox.Enabled = false;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            var KhId = KhIdTBox.Text.Trim();
            var Cty = CtyTBox.Text.Trim();
            var Mst = MstTBox.Text.Trim();

            if (KhId.Length == 0 || Cty.Length == 0)
            {
                if (KhId.Length == 0) KhIdLbl.ForeColor = Color.Red;
                else KhIdLbl.ForeColor = Color.Black;

                if (Cty.Length == 0) CtyLbl.ForeColor = Color.Red;
                else CtyLbl.ForeColor = Color.Black;
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();
                    var newKh = new KhachHang
                    {
                        Id = KhId,
                        TenCongTy = Cty,
                        MaSoThue = Mst,
                        DiaChi = DcTBox.Text.Length == 0 ? null : DcTBox.Text.Trim(),
                        TrangThai = 1,
                        NgayTao = DateTime.Now,
                        NgaySuaCuoi = DateTime.Now
                    };

                    db.KhachHang.Add(newKh);
                    db.SaveChanges();

                    if (Nlh1TBox.Text.Length > 0)
                    {
                        var newNlh = new NguoiLienHe
                        {
                            HoTen = Nlh1TBox.Text.Trim(),
                            Chucvu = Cvu1TBox.Text.Length == 0 ? null : Cvu1TBox.Text.Trim(),
                            SoDienThoai = Sdt1TBox.Text.Length == 0 ? null : Sdt1TBox.Text.Trim(),
                            GhiChu = Gc1TBox.Text.Length == 0 ? null : Gc1TBox.Text.Trim(),
                            KhachHangId = KhId,
                            TrangThai = 1,
                            NgayTao = DateTime.Now,
                            NgaySuaCuoi = DateTime.Now,
                        };

                        db.NguoiLienHe.Add(newNlh);
                        db.SaveChanges();
                    }

                    if (Nlh2TBox.Text.Length > 0)
                    {
                        var newNlh = new NguoiLienHe
                        {
                            HoTen = Nlh2TBox.Text.Trim(),
                            Chucvu = Cvu2TBox.Text.Length == 0 ? null : Cvu2TBox.Text.Trim(),
                            SoDienThoai = Sdt2TBox.Text.Length == 0 ? null : Sdt2TBox.Text.Trim(),
                            GhiChu = Gc2TBox.Text.Length == 0 ? null : Gc2TBox.Text.Trim(),
                            KhachHangId = KhId,
                            TrangThai = 1,
                            NgayTao = DateTime.Now,
                            NgaySuaCuoi = DateTime.Now,
                        };

                        db.NguoiLienHe.Add(newNlh);
                        db.SaveChanges();
                    }

                    if (Nlh3TBox.Text.Length > 0)
                    {
                        var newNlh = new NguoiLienHe
                        {
                            HoTen = Nlh3TBox.Text.Trim(),
                            Chucvu = Cvu3TBox.Text.Length == 0 ? null : Cvu3TBox.Text.Trim(),
                            SoDienThoai = Sdt3TBox.Text.Length == 0 ? null : Sdt3TBox.Text.Trim(),
                            GhiChu = Gc3TBox.Text.Length == 0 ? null : Gc3TBox.Text.Trim(),
                            KhachHangId = KhId,
                            TrangThai = 1,
                            NgayTao = DateTime.Now,
                            NgaySuaCuoi = DateTime.Now,
                        };

                        db.NguoiLienHe.Add(newNlh);
                        db.SaveChanges();
                    }

                    if (Nlh4TBox.Text.Length > 0)
                    {
                        var newNlh = new NguoiLienHe
                        {
                            HoTen = Nlh4TBox.Text.Trim(),
                            Chucvu = Cvu4TBox.Text.Length == 0 ? null : Cvu4TBox.Text.Trim(),
                            SoDienThoai = Sdt4TBox.Text.Length == 0 ? null : Sdt4TBox.Text.Trim(),
                            GhiChu = Gc4TBox.Text.Length == 0 ? null : Gc4TBox.Text.Trim(),
                            KhachHangId = KhId,
                            TrangThai = 1,
                            NgayTao = DateTime.Now,
                            NgaySuaCuoi = DateTime.Now,
                        };

                        db.NguoiLienHe.Add(newNlh);
                        db.SaveChanges();
                    }

                    parentForm.UpdateDataGrid();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Tạo khách hàng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                catch (Exception ex)
                {
                    var exMsg = ex.GetBaseException().Message;
                    if (exMsg.Contains("Violation of PRIMARY KEY constrain"))
                    {
                        MessageBox.Show("Mã khách hàng đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
