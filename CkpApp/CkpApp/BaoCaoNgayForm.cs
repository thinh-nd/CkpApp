using NCalc;
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
    public partial class BaoCaoNgayForm : Form
    {
        private List<string> BomIds;
        private List<string> CtrIds;
        private List<string> KhIds;
        private List<int> NvIds;
        private List<int> VtIds;
        private List<int> DgIds;

        private QuanLyBaoCaoForm parentForm;
        private int BcId = 0;

        public BaoCaoNgayForm()
        {
            InitializeComponent();
            InitializeGui();
            InitializeData();
        }

        public BaoCaoNgayForm(QuanLyBaoCaoForm form, int id)
            : this()
        {
            parentForm = form;
            BcId = id;

            NgayBcTb.ReadOnly = true;
            BomCb.Enabled = false;
            NgBcCb.Enabled = false;
            CtrCb.Enabled = false;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var bc = (from b in db.BaoCaoNgay where b.Id == id && b.TrangThai == 1 select b).FirstOrDefault();

                //in case a record has been deleted, which cause the combo boxes selected index set to -1
                //add the deleted record back to the combobox
                if (bc.MayBom.TrangThai == 0)
                {
                    BomCb.Items.Add(bc.MayBom.Id + " - " + bc.MayBom.TenBom);
                    BomIds.Add(bc.MayBom.Id);
                }
                if (bc.NhanVien.TrangThai == 0)
                {
                    NgBcCb.Items.Add(bc.NhanVien.Id + "." + bc.NhanVien.HoTen + " - " + bc.NhanVien.ChucVu);
                    NvIds.Add(bc.NhanVien.Id);
                }
                if (bc.CongTrinh.TrangThai == 0)
                {
                    CtrCb.Items.Add(bc.CongTrinh.TenCongTrinh);
                    CtrIds.Add(bc.CongTrinh.Id);
                    KhCb.Items.Add(bc.KhachHang.Id + " - " + bc.KhachHang.TenCongTy);
                    KhIds.Add(bc.KhachHang.Id);
                }
                foreach (var vb in bc.ViTriBom_BaoCao)
                {
                    if (vb.ViTriBom.TrangThai == 0)
                    {
                        VtCb1.Items.Add(vb.ViTriBom.ViTri);
                        VtCb2.Items.Add(vb.ViTriBom.ViTri);
                        VtCb3.Items.Add(vb.ViTriBom.ViTri);
                        VtIds.Add(vb.ViTriBom.Id);
                    }
                }
                foreach (var dg in bc.CongTrinh.DonGiaBom)
                {
                    if (dg.TrangThai == 0 && !DgCb1.Items.Contains(dg.TenDonGia))
                    {
                        DgCb1.Items.Add(dg.TenDonGia);
                        DgCb2.Items.Add(dg.TenDonGia);
                        DgCb3.Items.Add(dg.TenDonGia);
                        DgIds.Add(dg.Id);
                    }
                }
                var cbc = (DataGridViewComboBoxColumn)NhanLucGrid.Columns[0];
                foreach (var nv in bc.NhanLuc_BaoCao)
                {
                    var item = nv.NhanVien.Id + "." + nv.NhanVien.HoTen;
                    if (nv.NhanVien.TrangThai == 0 && !cbc.Items.Contains(item))
                    {
                        cbc.Items.Add(item);
                    }
                }

                NgayBcTb.Text = bc.NgayBaoCao.Value.ToString("ddMMyyyy");
                BomCb.SelectedIndex = BomCb.FindStringExact(bc.MayBom.Id + " - " + bc.MayBom.TenBom);
                NgBcCb.SelectedIndex = NgBcCb.FindStringExact(bc.NhanVien.Id + "." + bc.NhanVien.HoTen + " - " + bc.NhanVien.ChucVu);
                CtrCb.SelectedIndex = CtrCb.FindStringExact(bc.CongTrinh.TenCongTrinh);
                KhCb.SelectedIndex = KhCb.FindStringExact(bc.KhachHang.Id + " - " + bc.KhachHang.TenCongTy);
                DcTb.Text = bc.CongTrinh.DiaChi;
                GcRtb.Text = bc.GhiChu;

                ViTriBom_BaoCao[] vtarr = new ViTriBom_BaoCao[] {null, null, null};
                var vitri = bc.ViTriBom_BaoCao.ToList();

                foreach (var dg in bc.CongTrinh.DonGiaBom.Where(d => d.TrangThai == 1))
                {
                    DgCb1.Items.Add(dg.TenDonGia);
                    DgCb2.Items.Add(dg.TenDonGia);
                    DgCb3.Items.Add(dg.TenDonGia);
                    DgIds.Add(dg.Id);
                }

                for (int i = 0; i < vitri.Count; i++)
                {
                    vtarr[i] = vitri[i];
                    if (vtarr[0] != null)
                    {
                        VtCb1.SelectedIndex = VtCb1.FindStringExact(vtarr[0].ViTriBom.ViTri);
                        TangTb1.Text = vtarr[0].Tang.HasValue ? vtarr[0].Tang.Value.ToString() : "";
                        SlTb1.Text = vtarr[0].SoLuong.HasValue ? vtarr[0].SoLuong.Value.ToString() : "";
                        DvCb1.SelectedIndex = DvCb1.FindStringExact(vtarr[0].DonVi);
                        DgTtTb1.Text = vtarr[0].DonGia.HasValue ? vtarr[0].DonGia.Value.ToString("N0") : "";
                        DgStTb1.Text = vtarr[0].DonGiaVat.HasValue ? vtarr[0].DonGiaVat.Value.ToString("N0") : "";
                        DgCb1.SelectedIndex = vtarr[0].DonGiaId.HasValue ? DgCb1.FindStringExact(vtarr[0].DonGiaBom.TenDonGia) : -1;
                        GcTb1.Text = vtarr[0].GhiChu;

                        TangTb1.Enabled = true;
                        SlTb1.Enabled = true;
                        DvCb1.Enabled = true;
                        DgTtTb1.Enabled = true;
                        DgStTb1.Enabled = true;
                        GcTb1.Enabled = true;
                        DgCb1.Enabled = true;
                    }
                    if (vtarr[1] != null)
                    {
                        VtCb2.SelectedIndex = VtCb2.FindStringExact(vtarr[1].ViTriBom.ViTri);
                        TangTb2.Text = vtarr[1].Tang.HasValue ? vtarr[1].Tang.Value.ToString() : "";
                        SlTb2.Text = vtarr[1].SoLuong.HasValue ? vtarr[1].SoLuong.Value.ToString() : "";
                        DvCb2.SelectedIndex = DvCb2.FindStringExact(vtarr[1].DonVi);
                        DgTtTb2.Text = vtarr[1].DonGia.HasValue ? vtarr[1].DonGia.Value.ToString("N0") : "";
                        DgStTb2.Text = vtarr[1].DonGiaVat.HasValue ? vtarr[1].DonGiaVat.Value.ToString("N0") : "";
                        DgCb2.SelectedIndex = vtarr[1].DonGiaId.HasValue ? DgCb2.FindStringExact(vtarr[1].DonGiaBom.TenDonGia) : -1;
                        GcTb2.Text = vtarr[1].GhiChu;

                        TangTb2.Enabled = true;
                        SlTb2.Enabled = true;
                        DvCb2.Enabled = true;
                        DgTtTb2.Enabled = true;
                        DgStTb2.Enabled = true;
                        GcTb2.Enabled = true;
                        DgCb2.Enabled = true;
                    }

                    if (vtarr[2] != null)
                    {
                        VtCb3.SelectedIndex = VtCb3.FindStringExact(vtarr[2].ViTriBom.ViTri);
                        TangTb3.Text = vtarr[2].Tang.HasValue ? vtarr[2].Tang.Value.ToString() : "";
                        SlTb3.Text = vtarr[2].SoLuong.HasValue ? vtarr[2].SoLuong.Value.ToString() : "";
                        DvCb3.SelectedIndex = DvCb3.FindStringExact(vtarr[2].DonVi);
                        DgTtTb3.Text = vtarr[2].DonGia.HasValue ? vtarr[2].DonGia.Value.ToString("N0") : "";
                        DgStTb3.Text = vtarr[2].DonGiaVat.HasValue ? vtarr[2].DonGiaVat.Value.ToString("N0") : "";
                        DgCb3.SelectedIndex = vtarr[2].DonGiaId.HasValue ? DgCb3.FindStringExact(vtarr[2].DonGiaBom.TenDonGia) : -1;
                        GcTb3.Text = vtarr[2].GhiChu;

                        TangTb3.Enabled = true;
                        SlTb3.Enabled = true;
                        DvCb3.Enabled = true;
                        DgTtTb3.Enabled = true;
                        DgStTb3.Enabled = true;
                        GcTb3.Enabled = true;
                        DgCb3.Enabled = true;
                    }
                }

                if (DgCb1.SelectedIndex != -1) DgInfoBtn1.Enabled = true;
                if (DgCb2.SelectedIndex != -1) DgInfoBtn2.Enabled = true;
                if (DgCb3.SelectedIndex != -1) DgInfoBtn3.Enabled = true;

                foreach (var nl in bc.NhanLuc_BaoCao)
                {
                    NhanLucGrid.Rows.Add(
                        nl.NhanVien.Id + "." + nl.NhanVien.HoTen,
                        nl.KhoiLuongBom,
                        nl.DonGiaKhoi);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeGui()
        {
            DvCb1.SelectedIndex = 0;
            DvCb2.SelectedIndex = 0;
            DvCb3.SelectedIndex = 0;

            TangTb1.Enabled = false;
            TangTb2.Enabled = false;
            TangTb3.Enabled = false;

            SlTb1.Enabled = false;
            SlTb2.Enabled = false;
            SlTb3.Enabled = false;

            DvCb1.Enabled = false;
            DvCb2.Enabled = false;
            DvCb3.Enabled = false;

            DgTtTb1.Enabled = false;
            DgTtTb2.Enabled = false;
            DgTtTb3.Enabled = false;

            GcTb1.Enabled = false;
            GcTb2.Enabled = false;
            GcTb3.Enabled = false;

            DgStTb1.Enabled = false;
            DgStTb2.Enabled = false;
            DgStTb3.Enabled = false;

            DgCb1.Enabled = false;
            DgCb2.Enabled = false;
            DgCb3.Enabled = false;

            DgInfoBtn1.Enabled = false;
            DgInfoBtn2.Enabled = false;
            DgInfoBtn3.Enabled = false;

            BomCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            BomCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            NgBcCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            NgBcCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            CtrCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            CtrCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            NhanLucGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            NhanLucGrid.Columns[0].Width = 190;
            NhanLucGrid.Columns[1].Width = 70;
            NhanLucGrid.Columns[2].Width = 70;
        }

        private void InitializeData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();

                var allBom = (from b in db.MayBom where b.TrangThai == 1 orderby b.LoaiBom select b);
                var allNv = (from n in db.NhanVien where n.TrangThai == 1 orderby n.HoTen select n);
                var allCt = (from c in db.CongTrinh where c.TrangThai == 1 orderby c.TenCongTrinh select c);
                var allVt = (from v in db.ViTriBom where v.TrangThai == 1 select v);
                var allKh = (from k in db.KhachHang where k.TrangThai == 1 orderby k.TenCongTy select k);

                BomIds = new List<string>();
                CtrIds = new List<string>();
                KhIds = new List<string>();
                NvIds = new List<int>();
                VtIds = new List<int>();
                DgIds = new List<int>();
                var cbc = (DataGridViewComboBoxColumn)NhanLucGrid.Columns[0];

                foreach (var bom in allBom)
                {
                    BomCb.Items.Add(bom.Id + " - " + bom.TenBom);
                    BomIds.Add(bom.Id);
                }
                foreach (var nv in allNv)
                {
                    NgBcCb.Items.Add(nv.Id + "." + nv.HoTen + " - " + nv.ChucVu);
                    cbc.Items.Add(nv.Id + "." + nv.HoTen);
                    NvIds.Add(nv.Id);
                }
                foreach (var ct in allCt)
                {
                    CtrCb.Items.Add(ct.TenCongTrinh);
                    CtrIds.Add(ct.Id);
                }
                foreach (var kh in allKh)
                {
                    KhCb.Items.Add(kh.Id + " - " + kh.TenCongTy);
                    KhIds.Add(kh.Id);
                }
                foreach (var vt in allVt)
                {
                    VtCb1.Items.Add(vt.ViTri);
                    VtCb2.Items.Add(vt.ViTri);
                    VtCb3.Items.Add(vt.ViTri);
                    VtIds.Add(vt.Id);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhanLucGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
            {
                var selectedRows = NhanLucGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 1)
                {
                    NhanLucGrid.Rows.RemoveAt(NhanLucGrid.SelectedRows[0].Index);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double ftemp = 0;
                int temp = 0;
                DateTime dt = DateTime.Now;

                if ((!int.TryParse(TangTb1.Text, out temp) && TangTb1.Text.Length > 0) ||
                    (!int.TryParse(TangTb2.Text, out temp) && TangTb2.Text.Length > 0) ||
                    (!int.TryParse(TangTb3.Text, out temp) && TangTb3.Text.Length > 0))
                {
                    MessageBox.Show("Tầng phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((!double.TryParse(SlTb1.Text, out ftemp) && SlTb1.Text.Length > 0) ||
                    (!double.TryParse(SlTb2.Text, out ftemp) && SlTb2.Text.Length > 0) ||
                    (!double.TryParse(SlTb3.Text, out ftemp) && SlTb3.Text.Length > 0))
                {
                    MessageBox.Show("Số khối/số ca phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((!double.TryParse(DgTtTb1.Text.Replace(",", ""), out ftemp) && DgTtTb1.Text.Length > 0) ||
                    (!double.TryParse(DgTtTb2.Text.Replace(",", ""), out ftemp) && DgTtTb2.Text.Length > 0) ||
                    (!double.TryParse(DgTtTb3.Text.Replace(",", ""), out ftemp) && DgTtTb3.Text.Length > 0))
                {
                    MessageBox.Show("Đơn giá trước thuế phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((!double.TryParse(DgStTb1.Text.Replace(",", ""), out ftemp) && DgStTb1.Text.Length > 0) ||
                    (!double.TryParse(DgStTb2.Text.Replace(",", ""), out ftemp) && DgStTb2.Text.Length > 0) ||
                    (!double.TryParse(DgStTb3.Text.Replace(",", ""), out ftemp) && DgStTb3.Text.Length > 0))
                {
                    MessageBox.Show("Đơn giá sau thuế phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParseExact(NgayBcTb.Text, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) 
                {
                    MessageBox.Show("Ngày báo cáo không đúng format ddMMyyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataGridViewRow row in NhanLucGrid.Rows)
                {
                    if (row.Cells[1].Value != null && !double.TryParse(row.Cells[1].Value.ToString(), out ftemp))
                    {
                        MessageBox.Show("Số khối bơm phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (row.Cells[2].Value != null && !int.TryParse(row.Cells[2].Value.ToString(), out temp))
                    {
                        MessageBox.Show("Lương/khối phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (BcId != 0) // if this is edit mode
                {
                    UpdateData();
                    return;
                }

                if (NgayBcTb.Text.Length == 0 || BomCb.SelectedIndex == -1 || NgBcCb.SelectedIndex == -1 || CtrCb.SelectedIndex == -1)
                {
                    if (NgayBcTb.Text.Length == 0) NgayBcLbl.ForeColor = Color.Red;
                    else NgayBcLbl.ForeColor = Color.Black;

                    if (BomCb.SelectedIndex == -1) BomLbl.ForeColor = Color.Red;
                    else BomLbl.ForeColor = Color.Black;

                    if (NgBcCb.SelectedIndex == -1) NgBcLbl.ForeColor = Color.Red;
                    else NgBcLbl.ForeColor = Color.Black;

                    if (CtrCb.SelectedIndex == -1) CtrLbl.ForeColor = Color.Red;
                    else CtrLbl.ForeColor = Color.Black;
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();
                    var cul = CultureInfo.InvariantCulture;
                    
                    //Bao cao
                    var newReport = new BaoCaoNgay
                    {
                        NgayBaoCao = DateTime.ParseExact(NgayBcTb.Text, "ddMMyyyy", cul),
                        NguoiBaoCaoId = NvIds[NgBcCb.SelectedIndex],
                        MayBomId = BomIds[BomCb.SelectedIndex],
                        CongTrinhId = CtrIds[CtrCb.SelectedIndex],
                        KhachHangId = KhIds[KhCb.SelectedIndex],
                        TrangThai = 1,
                        GhiChu = GcRtb.Text,
                        NgayTao = DateTime.Now,
                        NgaySuaCuoi = DateTime.Now
                    };
                    db.BaoCaoNgay.Add(newReport);

                    //Vi tri
                    if (VtCb1.SelectedIndex > -1)
                    {
                        double dgv = 0;
                        double.TryParse(DgStTb1.Text.Replace(",", ""), out dgv);
                        double dg = 0;
                        double.TryParse(DgTtTb1.Text.Replace(",", ""), out dg);

                        var newVt = new ViTriBom_BaoCao
                        {
                            BaoCaoId = newReport.Id,
                            ViTriId = VtIds[VtCb1.SelectedIndex],
                            Tang = TangTb1.Text.Length > 0 ? int.Parse(TangTb1.Text) : (int?)null,
                            SoLuong = SlTb1.Text.Length > 0 ? double.Parse(SlTb1.Text) : (double?)null,
                            DonVi = DvCb1.Text,
                            DonGiaVat = dgv,
                            DonGia = dg,
                            GhiChu = GcTb1.Text,
                            DonGiaId = DgCb1.SelectedIndex != -1 ? DgIds[DgCb1.SelectedIndex] : (int?)null
                        };
                        db.ViTriBom_BaoCao.Add(newVt);
                    }
                    if (VtCb2.SelectedIndex > -1)
                    {
                        double dgv = 0;
                        double.TryParse(DgStTb2.Text.Replace(",", ""), out dgv);
                        double dg = 0;
                        double.TryParse(DgTtTb2.Text.Replace(",", ""), out dg);

                        var newVt = new ViTriBom_BaoCao
                        {
                            BaoCaoId = newReport.Id,
                            ViTriId = VtIds[VtCb2.SelectedIndex],
                            Tang = TangTb2.Text.Length > 0 ? int.Parse(TangTb2.Text) : (int?)null,
                            SoLuong = SlTb2.Text.Length > 0 ? double.Parse(SlTb2.Text) : (double?)null,
                            DonVi = DvCb2.Text,
                            DonGiaVat = dgv,
                            DonGia = dg,
                            GhiChu = GcTb2.Text,
                            DonGiaId = DgCb2.SelectedIndex != -1 ? DgIds[DgCb2.SelectedIndex] : (int?)null
                        };
                        db.ViTriBom_BaoCao.Add(newVt);
                    }
                    if (VtCb3.SelectedIndex > -1)
                    {
                        double dgv = 0;
                        double.TryParse(DgStTb3.Text.Replace(",", ""), out dgv);
                        double dg = 0;
                        double.TryParse(DgTtTb3.Text.Replace(",", ""), out dg);

                        var newVt = new ViTriBom_BaoCao
                        {
                            BaoCaoId = newReport.Id,
                            ViTriId = VtIds[VtCb3.SelectedIndex],
                            Tang = TangTb3.Text.Length > 0 ? int.Parse(TangTb3.Text) : (int?)null,
                            SoLuong = SlTb3.Text.Length > 0 ? double.Parse(SlTb3.Text) : (double?)null,
                            DonVi = DvCb3.Text,
                            DonGiaVat = dgv,
                            DonGia = dg,
                            GhiChu = GcTb3.Text,
                            DonGiaId = DgCb3.SelectedIndex != -1 ? DgIds[DgCb3.SelectedIndex] : (int?)null
                        };
                        db.ViTriBom_BaoCao.Add(newVt);
                    }

                    //Nhan luc
                    for (int i = 0; i < NhanLucGrid.Rows.Count; i++)
                    {
                        var row = NhanLucGrid.Rows[i];

                        if (row.Cells[0].Value == null) continue;

                        var nvid = row.Cells[0].Value.ToString().Split('.')[0];
                        var bcnl = new NhanLuc_BaoCao
                        {
                            BaoCaoId = newReport.Id,
                            NhanVienId = int.Parse(nvid),
                            KhoiLuongBom = row.Cells[1].Value == null ? (double?)null : double.Parse(row.Cells[1].Value.ToString()),
                            DonGiaKhoi = row.Cells[2].Value == null ? (int?)null : int.Parse(row.Cells[2].Value.ToString())
                        };
                        db.NhanLuc_BaoCao.Add(bcnl);
                    }
                    db.SaveChanges();
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Tạo báo cáo mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VtCb1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TangTb1.Enabled = true;
            SlTb1.Enabled = true;
            DvCb1.Enabled = true;
            DgTtTb1.Enabled = true;
            GcTb1.Enabled = true;
            DgStTb1.Enabled = true;
            DgCb1.Enabled = true;
        }

        private void VtCb2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TangTb2.Enabled = true;
            SlTb2.Enabled = true;
            DvCb2.Enabled = true;
            DgTtTb2.Enabled = true;
            GcTb2.Enabled = true;
            DgStTb2.Enabled = true;
            DgCb2.Enabled = true;
        }

        private void VtCb3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TangTb3.Enabled = true;
            SlTb3.Enabled = true;
            DvCb3.Enabled = true;
            DgTtTb3.Enabled = true;
            GcTb3.Enabled = true;
            DgStTb3.Enabled = true;
            DgCb3.Enabled = true;
        }

        private void CtrCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var id = CtrIds[CtrCb.SelectedIndex];
                var ctr = (from c in db.CongTrinh where c.Id == id && c.TrangThai == 1 select c).FirstOrDefault();
                KhCb.SelectedIndex = KhCb.FindStringExact(ctr.KhachHang.Id + " - " + ctr.KhachHang.TenCongTy);
                DcTb.Text = ctr.DiaChi;

                var dg = (from d in db.DonGiaBom where d.CongTrinhId == id && d.TrangThai == 1 select d);
                foreach (var d in dg)
                {
                    DgCb1.Items.Add(d.TenDonGia);
                    DgCb2.Items.Add(d.TenDonGia);
                    DgCb3.Items.Add(d.TenDonGia);
                    DgIds.Add(d.Id);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcDg1()
        {
            try
            {
                var db = new CkpEntities();
                double val = 0;
                if (DgCb1.SelectedIndex == -1) return;
                var id = DgIds[DgCb1.SelectedIndex];
                var dg = (from d in db.DonGiaBom where d.Id == id && d.TrangThai == 1 select d).FirstOrDefault();

                int t = 0;
                double sl = 0;

                if (!string.IsNullOrEmpty(dg.CongThuc))
                {
                    t = int.TryParse(TangTb1.Text, out t) ? t : 0;
                    sl = double.TryParse(SlTb1.Text, out sl) ? sl : 0;

                    var e = new Expression(dg.CongThuc);
                    e.Parameters["t"] = t;
                    e.Parameters["sl"] = sl;

                    val = Convert.ToDouble(e.Evaluate());
                    DgStTb1.Text = val.ToString("N0");
                    DgTtTb1.Text = Convert.ToDouble(val / (1 + (dg.VAT ?? 0) / 100d)).ToString("N0");
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message + ex.GetBaseException().StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcDg2()
        {
            try
            {
                var db = new CkpEntities();
                double val = 0;
                if (DgCb2.SelectedIndex == -1) return;
                var id = DgIds[DgCb2.SelectedIndex];
                var dg = (from d in db.DonGiaBom where d.Id == id && d.TrangThai == 1 select d).FirstOrDefault();

                int t = 0;
                double sl = 0;

                if (!string.IsNullOrEmpty(dg.CongThuc))
                {
                    t = int.TryParse(TangTb2.Text, out t) ? t : 0;
                    sl = double.TryParse(SlTb2.Text, out sl) ? sl : 0;

                    var e = new Expression(dg.CongThuc);
                    e.Parameters["t"] = t;
                    e.Parameters["sl"] = sl;

                    val = Convert.ToDouble(e.Evaluate());
                    DgStTb2.Text = val.ToString();
                    DgTtTb2.Text = Convert.ToDouble(val / (1 + (dg.VAT ?? 0) / 100d)).ToString();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcDg3()
        {
            try
            {
                var db = new CkpEntities();
                double val = 0;
                if (DgCb3.SelectedIndex == -1) return;
                var id = DgIds[DgCb3.SelectedIndex];
                var dg = (from d in db.DonGiaBom where d.Id == id && d.TrangThai == 1 select d).FirstOrDefault();

                int t = 0;
                double sl = 0;

                if (!string.IsNullOrEmpty(dg.CongThuc))
                {
                    t = int.TryParse(TangTb3.Text, out t) ? t : 0;
                    sl = double.TryParse(SlTb3.Text, out sl) ? sl : 0;

                    var e = new Expression(dg.CongThuc);
                    e.Parameters["t"] = t;
                    e.Parameters["sl"] = sl;

                    val = Convert.ToDouble(e.Evaluate());
                    DgStTb3.Text = val.ToString();
                    DgTtTb3.Text = Convert.ToDouble(val / (1 + (dg.VAT ?? 0) / 100d)).ToString();
                }

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var db = new CkpEntities();
                var bc = (from b in db.BaoCaoNgay where b.Id == BcId && b.TrangThai == 1 select b).FirstOrDefault();
                var vtbc = (from v in db.ViTriBom_BaoCao where v.BaoCaoId == BcId select v);
                var nlbc = (from n in db.NhanLuc_BaoCao where n.BaoCaoId == BcId select n);
                var cul = CultureInfo.InvariantCulture;

                //Bao cao
                bc.NgayBaoCao = DateTime.ParseExact(NgayBcTb.Text, "ddMMyyyy", cul);
                bc.NguoiBaoCaoId = NvIds[NgBcCb.SelectedIndex];
                bc.MayBomId = BomIds[BomCb.SelectedIndex];
                bc.CongTrinhId = CtrIds[CtrCb.SelectedIndex];
                bc.KhachHangId = KhIds[KhCb.SelectedIndex];
                bc.GhiChu = GcRtb.Text;
                bc.NgaySuaCuoi = DateTime.Now;

                foreach (var vt in vtbc)
                {
                    db.ViTriBom_BaoCao.Remove(vt);
                }
                foreach (var nl in nlbc)
                {
                    db.NhanLuc_BaoCao.Remove(nl);
                }

                //Vi tri
                if (VtCb1.SelectedIndex > -1)
                {
                    double dgv = 0;
                    double.TryParse(DgStTb1.Text.Replace(",", ""), out dgv);
                    double dg = 0;
                    double.TryParse(DgTtTb1.Text.Replace(",", ""), out dg);

                    var newVt = new ViTriBom_BaoCao
                    {
                        BaoCaoId = bc.Id,
                        ViTriId = VtIds[VtCb1.SelectedIndex],
                        Tang = int.Parse(TangTb1.Text),
                        SoLuong = double.Parse(SlTb1.Text),
                        DonVi = DvCb1.Text,
                        DonGiaVat = dgv,
                        DonGia = dg,
                        GhiChu = GcTb1.Text,
                        DonGiaId = DgCb1.SelectedIndex != -1 ? DgIds[DgCb1.SelectedIndex] : (int?)null
                    };
                    db.ViTriBom_BaoCao.Add(newVt);
                }
                if (VtCb2.SelectedIndex > -1)
                {
                    double dgv = 0;
                    double.TryParse(DgStTb2.Text.Replace(",", ""), out dgv);
                    double dg = 0;
                    double.TryParse(DgTtTb2.Text.Replace(",", ""), out dg);

                    var newVt = new ViTriBom_BaoCao
                    {
                        BaoCaoId = bc.Id,
                        ViTriId = VtIds[VtCb2.SelectedIndex],
                        Tang = int.Parse(TangTb2.Text),
                        SoLuong = double.Parse(SlTb2.Text),
                        DonVi = DvCb2.Text,
                        DonGiaVat = dgv,
                        DonGia = dg,
                        GhiChu = GcTb2.Text,
                        DonGiaId = DgCb2.SelectedIndex != -1 ? DgIds[DgCb2.SelectedIndex] : (int?)null
                    };
                    db.ViTriBom_BaoCao.Add(newVt);
                }
                if (VtCb3.SelectedIndex > -1)
                {
                    double dgv = 0;
                    double.TryParse(DgStTb3.Text.Replace(",", ""), out dgv);
                    double dg = 0;
                    double.TryParse(DgTtTb3.Text.Replace(",", ""), out dg);

                    var newVt = new ViTriBom_BaoCao
                    {
                        BaoCaoId = bc.Id,
                        ViTriId = VtIds[VtCb3.SelectedIndex],
                        Tang = int.Parse(TangTb3.Text),
                        SoLuong = double.Parse(SlTb3.Text),
                        DonVi = DvCb3.Text,
                        DonGiaVat = dgv,
                        DonGia = dg,
                        GhiChu = GcTb3.Text,
                        DonGiaId = DgCb3.SelectedIndex != -1 ? DgIds[DgCb3.SelectedIndex] : (int?)null
                    };
                    db.ViTriBom_BaoCao.Add(newVt);
                }

                //Nhan luc
                for (int i = 0; i < NhanLucGrid.Rows.Count; i++)
                {
                    var row = NhanLucGrid.Rows[i];

                    if (row.Cells[0].Value == null) continue;

                    var nvid = row.Cells[0].Value.ToString().Split('.')[0];
                    var bcnl = new NhanLuc_BaoCao
                    {
                        BaoCaoId = bc.Id,
                        NhanVienId = int.Parse(nvid),
                        KhoiLuongBom = row.Cells[1].Value == null ? (double?)null : double.Parse(row.Cells[1].Value.ToString()),
                        DonGiaKhoi = row.Cells[2].Value == null ? (int?)null : int.Parse(row.Cells[2].Value.ToString())
                    };
                    db.NhanLuc_BaoCao.Add(bcnl);
                }

                db.SaveChanges();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                parentForm.UpdateSearchResult();
                Close();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgCb1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcDg1();
            DgInfoBtn1.Enabled = true;
        }

        private void SlTb1_Leave(object sender, EventArgs e)
        {
            CalcDg1();
        }

        private void TangTb1_Leave(object sender, EventArgs e)
        {
            CalcDg1();
        }

        private void TangTb2_Leave(object sender, EventArgs e)
        {
            CalcDg2();
        }

        private void SlTb2_Leave(object sender, EventArgs e)
        {
            CalcDg2();
        }

        private void DgCb2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcDg2();
            DgInfoBtn2.Enabled = true;
        }

        private void TangTb3_Leave(object sender, EventArgs e)
        {
            CalcDg3();
        }

        private void SlTb3_Leave(object sender, EventArgs e)
        {
            CalcDg3();
        }

        private void DgCb3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CalcDg3();
            DgInfoBtn3.Enabled = true;
        }

        private void DgInfoBtn1_Click(object sender, EventArgs e)
        {
            if (DgCb1.SelectedIndex == -1) return;
            ShowDgInfo(DgIds[DgCb1.SelectedIndex]);
        }

        private void DgInfoBtn2_Click(object sender, EventArgs e)
        {
            if (DgCb2.SelectedIndex == -1) return;
            ShowDgInfo(DgIds[DgCb2.SelectedIndex]);
        }

        private void DgInfoBtn3_Click(object sender, EventArgs e)
        {
            if (DgCb3.SelectedIndex == -1) return;
            ShowDgInfo(DgIds[DgCb3.SelectedIndex]);
        }

        private void ShowDgInfo(int dgId)
        {
            var db = new CkpEntities();
            var dginfo = (from d in db.DonGiaBom where d.TrangThai == 1 && d.Id == dgId select d).FirstOrDefault();

            var sb = new StringBuilder();
            sb.AppendLine("Đơn giá:" + (dginfo.DonGia.HasValue ? dginfo.DonGia.Value.ToString("N0") : ""));
            sb.AppendLine("Đơn giá (+VAT):" + (dginfo.DonGiaVAT.HasValue ? dginfo.DonGiaVAT.Value.ToString("N0") : ""));
            sb.AppendLine("KL b.cần tối thiểu:" + (dginfo.MinKlgBomCan.HasValue ? dginfo.MinKlgBomCan.Value.ToString("N0") : ""));
            sb.AppendLine("KL b.tĩnh tối thiểu:" + (dginfo.MinKlgBomTinh.HasValue ? dginfo.MinKlgBomTinh.Value.ToString("N0") : ""));
            sb.AppendLine("CC1:" + (dginfo.CC1.HasValue ? dginfo.CC1.Value.ToString("N0") : ""));
            sb.AppendLine("Tổng CC2:" + (dginfo.TongCC2.HasValue ? dginfo.TongCC2.Value.ToString("N0") : ""));
            sb.AppendLine("% Back CC2:" + (dginfo.PhanTramBackCC2.HasValue ? dginfo.PhanTramBackCC2.Value.ToString("N0") : ""));
            sb.AppendLine("Tiền Back CC2:" + (dginfo.TienBackCC2.HasValue ? dginfo.TienBackCC2.Value.ToString("N0") : ""));
            sb.AppendLine("Net CC2:" + (dginfo.NetCC2.HasValue ? dginfo.NetCC2.Value.ToString("N0") : ""));
            sb.AppendLine("Tổng CC: " + (dginfo.TongCC.HasValue ? dginfo.TongCC.Value.ToString("N0") : ""));
            sb.AppendLine("KL giá: " + (dginfo.TongThu.HasValue ? dginfo.TongThu.Value.ToString("N0") : ""));
            sb.AppendLine("KL giá (+VAT): " + (dginfo.TongThuVAT.HasValue ? dginfo.TongThuVAT.Value.ToString("N0") : ""));
            sb.AppendLine("Công thức: " + dginfo.CongThuc);
            if (!string.IsNullOrEmpty(dginfo.GhiChu)) sb.AppendLine("Ghi chú: " + dginfo.GhiChu);

            MessageBox.Show(sb.ToString());
        }

        private void DgTtTb1_Enter(object sender, EventArgs e)
        {
            DgTtTb1.Text = DgTtTb1.Text.Replace(",", "");
        }

        private void DgTtTb2_Enter(object sender, EventArgs e)
        {
            DgTtTb2.Text = DgTtTb2.Text.Replace(",", "");
        }

        private void DgTtTb3_Enter(object sender, EventArgs e)
        {
            DgTtTb3.Text = DgTtTb3.Text.Replace(",", "");
        }

        private void DgStTb1_Enter(object sender, EventArgs e)
        {
            DgStTb1.Text = DgStTb1.Text.Replace(",", "");
        }

        private void DgStTb2_Enter(object sender, EventArgs e)
        {
            DgStTb2.Text = DgStTb2.Text.Replace(",", "");
        }

        private void DgStTb3_Enter(object sender, EventArgs e)
        {
            DgStTb3.Text = DgStTb3.Text.Replace(",", "");
        }

        private void DgTtTb1_Leave(object sender, EventArgs e)
        {
            double dg = 0;
            if (double.TryParse(DgTtTb1.Text, out dg))
            {
                DgTtTb1.Text = dg.ToString("N0");
            }
        }

        private void DgTtTb2_Leave(object sender, EventArgs e)
        {
            double dg = 0;
            if (double.TryParse(DgTtTb2.Text, out dg))
            {
                DgTtTb2.Text = dg.ToString("N0");
            }
        }

        private void DgTtTb3_Leave(object sender, EventArgs e)
        {
            double dg = 0;
            if (double.TryParse(DgTtTb3.Text, out dg))
            {
                DgTtTb3.Text = dg.ToString("N0");
            }
        }

        private void DgStTb1_Leave(object sender, EventArgs e)
        {
            double dg = 0;
            if (double.TryParse(DgStTb1.Text, out dg))
            {
                DgStTb1.Text = dg.ToString("N0");
            }
        }

        private void DgStTb2_Leave(object sender, EventArgs e)
        {
            double dg = 0;
            if (double.TryParse(DgStTb2.Text, out dg))
            {
                DgStTb2.Text = dg.ToString("N0");
            }
        }

        private void DgStTb3_Leave(object sender, EventArgs e)
        {
            double dg = 0;
            if (double.TryParse(DgStTb3.Text, out dg))
            {
                DgStTb3.Text = dg.ToString("N0");
            }
        }
    }
}
