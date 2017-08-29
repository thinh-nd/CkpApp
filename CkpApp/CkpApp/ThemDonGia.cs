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
    public partial class ThemDonGia : Form
    {
        private DonGiaForm parentForm;
        private string CtrId;

        public ThemDonGia()
        {
            InitializeComponent();
        }

        public ThemDonGia(DonGiaForm form, string cId)
            : this()
        {
            parentForm = form;
            CtrId = cId;

            try
            {
                var db = new CkpEntities();
                var ct = (from c in db.CongTrinh where c.Id == CtrId select c).FirstOrDefault();
                CtrTBox.Text = ct.TenCongTrinh;
                VatTBox.Text = "10";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                if (TenDgTBox.Text.Length == 0)
                {
                    TenDgLbl.ForeColor = Color.Red;
                    return;
                }
                else TenDgLbl.ForeColor = Color.Black;

                if (db.DonGiaBom.Where(dg => dg.CongTrinhId == CtrId && dg.TenDonGia == TenDgTBox.Text).Any())
                {
                    MessageBox.Show("Tên đơn giá này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (TextBox tb in this.Controls.OfType<TextBox>())
                {
                    int val = 0;
                    if (tb.Name == "TenDgTBox" || tb.Name == "CthucTBox" || tb.Name == "CtrTBox") continue;
                    else
                    {
                        if (tb.Text.Length > 0 && !int.TryParse(tb.Text.Replace(",", ""), out val))
                        {
                            MessageBox.Show("Tất cả các thông tin số liệu phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                var newDg = new DonGiaBom
                {
                    CongTrinhId = CtrId,
                    TenDonGia = TenDgTBox.Text,
                    DonGia = Dg0TBox.Text.Length > 0 ? int.Parse(Dg0TBox.Text.Replace(",", "")) : (int?)null,
                    DonGiaVAT = Dg1TBox.Text.Length > 0 ? int.Parse(Dg1TBox.Text.Replace(",", "")) : (int?)null,
                    VAT = VatTBox.Text.Length > 0 ? int.Parse(VatTBox.Text) : (int?)null,
                    MinKlgBomCan = MinBcTBox.Text.Length > 0 ? int.Parse(MinBcTBox.Text) : (int?)null,
                    MinKlgBomTinh = MinBtTBox.Text.Length > 0 ? int.Parse(MinBtTBox.Text) : (int?)null,
                    CC1 = Cc1TBox.Text.Length > 0 ? int.Parse(Cc1TBox.Text.Replace(",", "")) : (int?)null,
                    TongCC2 = TgCc2TBox.Text.Length > 0 ? int.Parse(TgCc2TBox.Text.Replace(",", "")) : (int?)null,
                    PhanTramBackCC2 = PtCc2TBox.Text.Length > 0 ? int.Parse(PtCc2TBox.Text) : (int?)null,
                    TienBackCC2 = BackCc2TBox.Text.Length > 0 ? int.Parse(BackCc2TBox.Text.Replace(",", "")) : (int?)null,
                    NetCC2 = NetCc2TBox.Text.Length > 0 ? int.Parse(NetCc2TBox.Text.Replace(",", "")) : (int?)null,
                    TongThuVAT = Kl1TBox.Text.Length > 0 ? int.Parse(Kl1TBox.Text.Replace(",", "")) : (int?)null,
                    TongVAT = KlVatTBox.Text.Length > 0 ? int.Parse(KlVatTBox.Text.Replace(",", "")) : (int?)null,
                    TongThu = Kl0TBox.Text.Length > 0 ? int.Parse(Kl0TBox.Text.Replace(",", "")) : (int?)null,
                    TongCC = KlCcTBox.Text.Length > 0 ? int.Parse(KlCcTBox.Text.Replace(",", "")) : (int?)null,
                    CongThuc = CthucTBox.Text,
                    GhiChu = GcRtb.Text,
                    TrangThai = 1,
                    NgayTao = DateTime.Now,
                    NgaySuaCuoi = DateTime.Now
                };
                db.DonGiaBom.Add(newDg);
                db.SaveChanges();

                Cursor.Current = Cursors.Default;
                MessageBox.Show("Tạo đơn giá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                parentForm.UpdateDataGrid();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            int dg1 = 0;
            int vat = 0;
            int dg0 = 0;
            if (Dg1TBox.Text.Length > 0 && int.TryParse(Dg1TBox.Text.Replace(",", ""), out dg1))
            {
                if (VatTBox.Text.Length > 0 && int.TryParse(VatTBox.Text.Replace(",", ""), out vat))
                {
                    dg0 = Convert.ToInt32(dg1 / (1 + vat / 100d));
                }
            }

            int cc2tong = 0;
            double cc2ptBack = 0;
            int cc2back = 0;
            int cc2net = 0;
            if (TgCc2TBox.Text.Length > 0 && PtCc2TBox.Text.Length > 0 && int.TryParse(TgCc2TBox.Text.Replace(",", ""), out cc2tong) && double.TryParse(PtCc2TBox.Text.Replace(",", ""), out cc2ptBack))
            {
                cc2back = Convert.ToInt32(cc2tong * (cc2ptBack / 100));
                cc2net = cc2tong - cc2back;
            }

            Dg0TBox.Text = dg0.ToString("N0");
            BackCc2TBox.Text = cc2back.ToString("N0");
            NetCc2TBox.Text = cc2net.ToString("N0");

            int totalcc = 0;
            int cc1 = 0;
            if (Cc1TBox.Text.Length > 0 && int.TryParse(Cc1TBox.Text.Replace(",", ""), out cc1))
            {
                totalcc += cc1;
            }
            if (NetCc2TBox.Text.Length > 0 && int.TryParse(NetCc2TBox.Text.Replace(",", ""), out cc2net))
            {
                totalcc += cc2net;
            }

            int kl1 = 0;
            int klvat = 0;
            int kl0 = 0;

            kl1 = dg1 - totalcc;
            klvat = dg1 - dg0;
            kl0 = kl1 - klvat;

            KlCcTBox.Text = totalcc.ToString("N0");
            Kl1TBox.Text = kl1.ToString("N0");
            KlVatTBox.Text = klvat.ToString("N0");
            Kl0TBox.Text = kl0.ToString("N0");
        }

        private void Dg1TBox_Enter(object sender, EventArgs e)
        {
            Dg1TBox.Text = Dg1TBox.Text.Replace(",", "");
        }

        private void Dg0TBox_Enter(object sender, EventArgs e)
        {
            Dg0TBox.Text = Dg0TBox.Text.Replace(",", "");
        }

        private void Cc1TBox_Enter(object sender, EventArgs e)
        {
            Cc1TBox.Text = Cc1TBox.Text.Replace(",", "");
        }

        private void TgCc2TBox_Enter(object sender, EventArgs e)
        {
            TgCc2TBox.Text = TgCc2TBox.Text.Replace(",", "");
        }

        private void BackCc2TBox_Enter(object sender, EventArgs e)
        {
            BackCc2TBox.Text = BackCc2TBox.Text.Replace(",", "");
        }

        private void NetCc2TBox_Enter(object sender, EventArgs e)
        {
            NetCc2TBox.Text = NetCc2TBox.Text.Replace(",", "");
        }

        private void Kl1TBox_Enter(object sender, EventArgs e)
        {
            Kl1TBox.Text = Kl1TBox.Text.Replace(",", "");
        }

        private void Kl0TBox_Enter(object sender, EventArgs e)
        {
            Kl0TBox.Text = Kl0TBox.Text.Replace(",", "");
        }

        private void KlVatTBox_Enter(object sender, EventArgs e)
        {
            KlVatTBox.Text = KlVatTBox.Text.Replace(",", "");
        }

        private void KlCcTBox_Enter(object sender, EventArgs e)
        {
            KlCcTBox.Text = KlCcTBox.Text.Replace(",", "");
        }

        private void Dg1TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Dg1TBox.Text, out val))
            {
                Dg1TBox.Text = val.ToString("N0");
            }
        }

        private void Dg0TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Dg0TBox.Text, out val))
            {
                Dg0TBox.Text = val.ToString("N0");
            }
        }

        private void Cc1TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Cc1TBox.Text, out val))
            {
                Cc1TBox.Text = val.ToString("N0");
            }
        }

        private void TgCc2TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(TgCc2TBox.Text, out val))
            {
                TgCc2TBox.Text = val.ToString("N0");
            }
        }

        private void BackCc2TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(BackCc2TBox.Text, out val))
            {
                BackCc2TBox.Text = val.ToString("N0");
            }
        }

        private void NetCc2TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(NetCc2TBox.Text, out val))
            {
                NetCc2TBox.Text = val.ToString("N0");
            }
        }

        private void Kl1TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Kl1TBox.Text, out val))
            {
                Kl1TBox.Text = val.ToString("N0");
            }
        }

        private void Kl0TBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(Kl0TBox.Text, out val))
            {
                Kl0TBox.Text = val.ToString("N0");
            }
        }

        private void KlVatTBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(KlVatTBox.Text, out val))
            {
                KlVatTBox.Text = val.ToString("N0");
            }
        }

        private void KlCcTBox_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(KlCcTBox.Text, out val))
            {
                KlCcTBox.Text = val.ToString("N0");
            }
        }
    }
}
