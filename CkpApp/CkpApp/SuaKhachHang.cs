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
    public partial class SuaKhachHang : Form
    {
        private KhachHangForm parentForm { get; set; }
        private string KhachHangId { get; set; }
        private int[] NlhIds = new int[4] {0, 0, 0, 0};

        public SuaKhachHang()
        {
            InitializeComponent();
            KhIdTBox.ReadOnly = true;

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

        public SuaKhachHang(KhachHangForm form, string KhId)
            : this()
        {
            parentForm = form;
            KhachHangId = KhId;
            GetCurrentData(KhId);
        }

        private void GetCurrentData(string id)
        {
            try
            {
                var db = new CkpEntities();
                var kh = (from k in db.KhachHang where k.Id == id select k).First();

                KhIdTBox.Text = kh.Id;
                CtyTBox.Text = kh.TenCongTy;
                MstTBox.Text = kh.MaSoThue;
                DcTBox.Text = kh.DiaChi == null ? "" : kh.DiaChi;

                NguoiLienHe[] NlhArr = { null, null, null, null };
                for (int i = 0; i < kh.NguoiLienHe.Where(l => l.TrangThai == 1).Count(); i++)
                {
                    NlhArr[i] = kh.NguoiLienHe.ToList()[i];
                }

                if (NlhArr[0] != null)
                {
                    var nlh = NlhArr[0];
                    NlhIds[0] = nlh.Id;
                    Nlh1TBox.Text = nlh.HoTen;
                    Cvu1TBox.Text = nlh.Chucvu == null ? "" : nlh.Chucvu;
                    Sdt1TBox.Text = nlh.SoDienThoai == null ? "" : nlh.SoDienThoai;
                    Gc1TBox.Text = nlh.GhiChu == null ? "" : nlh.GhiChu;
                }

                if (NlhArr[1] != null)
                {
                    var nlh = NlhArr[1];
                    NlhIds[1] = nlh.Id;
                    Nlh2TBox.Text = nlh.HoTen;
                    Cvu2TBox.Text = nlh.Chucvu == null ? "" : nlh.Chucvu;
                    Sdt2TBox.Text = nlh.SoDienThoai == null ? "" : nlh.SoDienThoai;
                    Gc2TBox.Text = nlh.GhiChu == null ? "" : nlh.GhiChu;
                }

                if (NlhArr[2] != null)
                {
                    var nlh = NlhArr[0];
                    NlhIds[2] = nlh.Id;
                    Nlh3TBox.Text = nlh.HoTen;
                    Cvu3TBox.Text = nlh.Chucvu == null ? "" : nlh.Chucvu;
                    Sdt3TBox.Text = nlh.SoDienThoai == null ? "" : nlh.SoDienThoai;
                    Gc3TBox.Text = nlh.GhiChu == null ? "" : nlh.GhiChu;
                }

                if (NlhArr[3] != null)
                {
                    var nlh = NlhArr[0];
                    NlhIds[3] = nlh.Id;
                    Nlh4TBox.Text = nlh.HoTen;
                    Cvu4TBox.Text = nlh.Chucvu == null ? "" : nlh.Chucvu;
                    Sdt4TBox.Text = nlh.SoDienThoai == null ? "" : nlh.SoDienThoai;
                    Gc4TBox.Text = nlh.GhiChu == null ? "" : nlh.GhiChu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            var Dc = DcTBox.Text.Trim();

            var db = new CkpEntities();

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
                    var kh = (from k in db.KhachHang where k.Id == KhachHangId select k).First();
                    kh.Id = KhId;
                    kh.TenCongTy = Cty;
                    kh.MaSoThue = Mst;
                    kh.DiaChi = Dc.Length == 0 ? null : Dc;
                    kh.NgaySuaCuoi = DateTime.Now;

                    if (Nlh1TBox.Text.Length > 0)
                    {
                        var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[0] select n).FirstOrDefault();
                        var Nlh1 = Nlh1TBox.Text.Trim();
                        var Cvu1 = Cvu1TBox.Text.Trim();
                        var Sdt1 = Sdt1TBox.Text.Trim();
                        var Gc1 = Gc1TBox.Text.Trim();

                        if (nlh != null)
                        {
                            nlh.HoTen = Nlh1;
                            nlh.Chucvu = Cvu1.Length == 0 ? null : Cvu1;
                            nlh.SoDienThoai = Sdt1.Length == 0 ? null : Sdt1;
                            nlh.GhiChu = Gc1.Length == 0 ? null : Gc1;
                        }
                        else
                        {
                            var newNlh = new NguoiLienHe
                            {
                                HoTen = Nlh1,
                                Chucvu = Cvu1,
                                SoDienThoai = Sdt1,
                                GhiChu = Gc1,
                                KhachHangId = KhId,
                                TrangThai = 1,
                                NgayTao = DateTime.Now,
                                NgaySuaCuoi = DateTime.Now,
                            };
                            db.NguoiLienHe.Add(newNlh);
                        }
                    }
                    else
                    {
                        if (NlhIds[0] != 0)
                        {
                            var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[0] select n).FirstOrDefault();
                            nlh.TrangThai = 0;
                        }
                    }

                    if (Nlh2TBox.Text.Length > 0)
                    {
                        var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[1] select n).FirstOrDefault();
                        var Nlh2 = Nlh2TBox.Text.Trim();
                        var Cvu2 = Cvu2TBox.Text.Trim();
                        var Sdt2 = Sdt2TBox.Text.Trim();
                        var Gc2 = Gc2TBox.Text.Trim();

                        if (nlh != null)
                        {
                            nlh.HoTen = Nlh2;
                            nlh.Chucvu = Cvu2.Length == 0 ? null : Cvu2;
                            nlh.SoDienThoai = Sdt2.Length == 0 ? null : Sdt2;
                            nlh.GhiChu = Gc2.Length == 0 ? null : Gc2;
                        }
                        else
                        {
                            var newNlh = new NguoiLienHe
                            {
                                HoTen = Nlh2,
                                Chucvu = Cvu2,
                                SoDienThoai = Sdt2,
                                GhiChu = Gc2,
                                KhachHangId = KhId,
                                TrangThai = 1,
                                NgayTao = DateTime.Now,
                                NgaySuaCuoi = DateTime.Now,
                            };
                            db.NguoiLienHe.Add(newNlh);
                        }
                    }
                    else
                    {
                        if (NlhIds[1] != 0)
                        {
                            var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[1] select n).FirstOrDefault();
                            nlh.TrangThai = 0;
                        }
                    }

                    if (Nlh3TBox.Text.Length > 0)
                    {
                        var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[2] select n).FirstOrDefault();
                        var Nlh3 = Nlh3TBox.Text.Trim();
                        var Cvu3 = Cvu3TBox.Text.Trim();
                        var Sdt3 = Sdt3TBox.Text.Trim();
                        var Gc3 = Gc3TBox.Text.Trim();

                        if (nlh != null)
                        {
                            nlh.HoTen = Nlh3;
                            nlh.Chucvu = Cvu3.Length == 0 ? null : Cvu3;
                            nlh.SoDienThoai = Sdt3.Length == 0 ? null : Sdt3;
                            nlh.GhiChu = Gc3.Length == 0 ? null : Gc3;
                        }
                        else
                        {
                            var newNlh = new NguoiLienHe
                            {
                                HoTen = Nlh3,
                                Chucvu = Cvu3,
                                SoDienThoai = Sdt3,
                                GhiChu = Gc3,
                                KhachHangId = KhId,
                                TrangThai = 1,
                                NgayTao = DateTime.Now,
                                NgaySuaCuoi = DateTime.Now,
                            };
                            db.NguoiLienHe.Add(newNlh);
                        }
                    }
                    else
                    {
                        if (NlhIds[2] != 0)
                        {
                            var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[2] select n).FirstOrDefault();
                            nlh.TrangThai = 0;
                        }
                    }

                    if (Nlh4TBox.Text.Length > 0)
                    {
                        var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[3] select n).FirstOrDefault();
                        var Nlh4 = Nlh4TBox.Text.Trim();
                        var Cvu4 = Cvu4TBox.Text.Trim();
                        var Sdt4 = Sdt4TBox.Text.Trim();
                        var Gc4 = Gc4TBox.Text.Trim();

                        if (nlh != null)
                        {
                            nlh.HoTen = Nlh4;
                            nlh.Chucvu = Cvu4.Length == 0 ? null : Cvu4;
                            nlh.SoDienThoai = Sdt4.Length == 0 ? null : Sdt4;
                            nlh.GhiChu = Gc4.Length == 0 ? null : Gc4;
                        }
                        else
                        {
                            var newNlh = new NguoiLienHe
                            {
                                HoTen = Nlh4,
                                Chucvu = Cvu4,
                                SoDienThoai = Sdt4,
                                GhiChu = Gc4,
                                KhachHangId = KhId,
                                TrangThai = 1,
                                NgayTao = DateTime.Now,
                                NgaySuaCuoi = DateTime.Now,
                            };
                            db.NguoiLienHe.Add(newNlh);
                        }
                    }
                    else
                    {
                        if (NlhIds[3] != 0)
                        {
                            var nlh = (from n in kh.NguoiLienHe where n.Id == NlhIds[3] select n).FirstOrDefault();
                            nlh.TrangThai = 0;
                        }
                    }

                    db.SaveChanges();

                    parentForm.UpdateDataGrid();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Cập nhật khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                        MessageBox.Show(exMsg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
