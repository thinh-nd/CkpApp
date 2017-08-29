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
    public partial class BaoCaoForm : Form
    {
        private IEnumerable<BaoCaoNgay> BcnList;
        private IEnumerable<CongTrinh> CtrList;
        private List<string> CtrIds;

        public BaoCaoForm()
        {
            InitializeComponent();
            InitializeData();

            CtrCb.AutoCompleteSource = AutoCompleteSource.ListItems;
            CtrCb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            VatTb.Text = "10";
        }

        public void InitializeData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                BcnList = (from b in db.BaoCaoNgay where b.TrangThai == 1 select b);
                CtrList = (from c in db.CongTrinh where c.TrangThai == 1 orderby c.TenCongTrinh select c);

                CtrIds = new List<string>();
                foreach (var ctr in CtrList)
                {
                    CtrCb.Items.Add(ctr.TenCongTrinh);
                    CtrIds.Add(ctr.Id);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (BcCb.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn một loại báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (BcCb.SelectedIndex == 0)
                {
                    if (CtrCb.SelectedIndex == -1)
                    {
                        MessageBox.Show("Hãy chọn một công trình", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    BaoCaoCongTrinh();
                }
                else if (BcCb.SelectedIndex == 1)
                {
                    BaoCaoThang();
                }
                else if (BcCb.SelectedIndex == 2)
                {
                    BaoCaoTongHop();
                }
                else if (BcCb.SelectedIndex == 3)
                {
                    BaoCaoKlgNv();
                }
            }
        }

        private void BaoCaoCongTrinh()
        {
            try
            {
                if (DfromTb.Text.Length == 0 || DtoTb.Text.Length == 0)
                {
                    MessageBox.Show("Hãy điền cả 2 mục phạm vi ngày", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dfrom = default(DateTime);
                DateTime dto = default(DateTime);
                var cul = CultureInfo.InvariantCulture;

                if (DfromTb.Text.Length > 0 && !DateTime.TryParseExact(DfromTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dfrom) ||
                    DtoTb.Text.Length > 0 && !DateTime.TryParseExact(DtoTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dto))
                {
                    MessageBox.Show("Ngày không đúng với format ddMMyyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var ctId = CtrIds[CtrCb.SelectedIndex];
                var data = (from b in db.BaoCaoNgay 
                            where b.CongTrinhId == ctId && b.TrangThai == 1
                            select b).ToList();
                data = data.Where(b => b.NgayBaoCao.Value.Date >= dfrom.Date && b.NgayBaoCao.Value.Date <= dto.Date).ToList();

                double vat = 0;
                int chiphi = 0;
                double tongKhoi = 0;
                double tongCb = 0;
                double tongCc = 0;
                double tongGt = 0;
                
                if (CpTb.Text.Length > 0 && !int.TryParse(CpTb.Text.Replace(",", ""), out chiphi))
                {
                    MessageBox.Show("Chi phí không phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (VatTb.Text.Length > 0 && !double.TryParse(VatTb.Text, out vat))
                {
                    MessageBox.Show("Phần trăm VAT không phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var table = new DataTable();
                var headers = new string[]{
                    "TT",
                    "Ngay",
                    "TenCongTrinh",
                    "ViTriBom",
                    "KhoiLuong",
                    "CaCho",
                    "CaBom",
                    "Dvt",
                    "DonGia",
                    "ThanhTien",
                    "GhiChu"
                };
                for (int i = 0; i < headers.Length; i++)
                {
                    table.Columns.Add(headers[i]);
                    if (i == 4 || i == 5 || i == 6 || i == 8 || i == 9) table.Columns[i].DataType = typeof(double);
                }

                int stt = 1;
                foreach (var dataRow in data)
                {
                    foreach (var vt in dataRow.ViTriBom_BaoCao)
                    {
                        DataRow tableRow = table.NewRow();

                        tableRow[0] = stt;
                        tableRow[1] = dataRow.NgayBaoCao.Value.ToString("dd/MM");
                        tableRow[2] = dataRow.CongTrinh.TenCongTrinh;
                        tableRow[3] = vt.Tang.HasValue ? vt.ViTriBom.ViTri + " tầng " + vt.Tang : vt.ViTriBom.ViTri;
                        tableRow[4] = vt.SoLuong.HasValue && vt.DonVi == "khối" ? vt.SoLuong.Value : 0;
                        tableRow[5] = vt.SoLuong.HasValue && vt.DonVi == "ca chờ" ? vt.SoLuong.Value : 0;
                        tableRow[6] = vt.SoLuong.HasValue && vt.DonVi == "ca bơm" ? vt.SoLuong.Value : 0;
                        tableRow[7] = vt.DonVi == "khối" ? "m3" : "ca";
                        tableRow[8] = vt.DonGia.HasValue ? vt.DonGia.Value : 0;
                        tableRow[9] = vt.DonGia.HasValue && vt.SoLuong.HasValue ? vt.DonGia.Value * vt.SoLuong.Value : 0;
                        tableRow[10] = vt.GhiChu;

                        table.Rows.Add(tableRow);
                        stt++;

                        tongKhoi += vt.SoLuong.HasValue && vt.DonVi == "khối" ? vt.SoLuong.Value : 0;
                        tongCc += vt.SoLuong.HasValue && vt.DonVi == "ca chờ" ? vt.SoLuong.Value : 0;
                        tongCb += vt.SoLuong.HasValue && vt.DonVi == "ca bơm" ? vt.SoLuong.Value : 0;
                        tongGt += vt.DonGia.HasValue && vt.SoLuong.HasValue ? vt.DonGia.Value * vt.SoLuong.Value : 0;
                    }
                }

                var rootPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\", "");
                var templatePath = Path.Combine(rootPath, "bao-cao-san-luong-cong-trinh-template.xlsx");
                var file = new FileInfo(templatePath);

                using (var excel = new ExcelPackage(file))
                {
                    var ws = excel.Workbook.Worksheets.First();

                    string timeframe = "";
                    if (DfromTb.Text.Length > 0) timeframe += "từ ngày " + dfrom.ToString("dd/MM/yyyy") + " ";
                    if (DtoTb.Text.Length > 0) timeframe += "đến ngày " + dto.ToString("dd/MM/yyyy");
                    ws.Cells["A6"].Value = timeframe;

                    ws.Cells["E7"].Value = data.First().KhachHang.TenCongTy.ToUpper();
                    ws.Cells["E8"].Value = "CÔNG TY CỔ PHẦN CKP";

                    ws.Cells["A9"].Value += CtrCb.Text;
                    ws.Cells["A11"].LoadFromDataTable(table, false);

                    var location = string.Format("A{0}:D{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = TdTb.Text;

                    ws.Cells["J" + ws.Dimension.End.Row].Value = chiphi;
                    ws.Cells["K" + ws.Dimension.End.Row].Value = GcRtb.Text;

                    location = string.Format("A{0}:D{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = "Tổng cộng";

                    ws.Cells["E" + ws.Dimension.End.Row].Formula = string.Format("SUM(E11:E{0})", ws.Dimension.End.Row - 2);
                    ws.Cells["F" + ws.Dimension.End.Row].Formula = string.Format("SUM(F11:F{0})", ws.Dimension.End.Row - 2);
                    ws.Cells["G" + ws.Dimension.End.Row].Formula = string.Format("SUM(G11:G{0})", ws.Dimension.End.Row - 2);
                    ws.Cells["J" + ws.Dimension.End.Row].Formula = string.Format("SUM(J11:J{0})", ws.Dimension.End.Row - 1);

                    location = string.Format("A{0}:D{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[string.Format("E{0}:I{0}", ws.Dimension.End.Row + 1)].Merge = true;
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = string.Format("Thuế VAT ({0}%)", VatTb.Text);
                    ws.Cells["J" + ws.Dimension.End.Row].Formula = string.Format("J{0}*({1}/100)", ws.Dimension.End.Row - 1, double.Parse(VatTb.Text));

                    location = string.Format("A{0}:D{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[string.Format("E{0}:I{0}", ws.Dimension.End.Row + 1)].Merge = true;
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = "Tổng cộng";
                    ws.Cells["J" + ws.Dimension.End.Row].Formula = string.Format("J{0}+J{1}", ws.Dimension.End.Row - 2, ws.Dimension.End.Row - 1);

                    for (int row = 11; row <= ws.Dimension.End.Row; row++)
                    {
                        ws.Row(row).Height = 24;
                        for (int col = 1; col <= 11; col++)
                        {
                            ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            ws.Cells[row, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            if (col == 4) ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            else if (col == 5 || col == 9 || col == 10) ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                            else ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            if (row >= ws.Dimension.End.Row - 2) ws.Cells[row, col].Style.Font.Bold = true;

                            if (col == 5 || col == 6 || col == 7)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = @"_(* #,##0.0_);_(* (#,##0.0);_(* ""-""??_);_(@_)";
                            }

                            if (col == 9 || col == 10)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = @"_(* #,##0_);_(* (#,##0);_(* ""-""??_);_(@_)";
                            }
                        }
                    }

                    location = string.Format("A{0}:C{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[location].Value = "Khối lượng bơm bằng chữ:";
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.Font.Bold = true;
                    ws.Cells[location].Style.Font.Italic = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    var klgText = new List<string>();
                    if (tongKhoi > 0) klgText.Add(Helpers.DoubleAsVnString(tongKhoi) + " khối bơm");
                    if (tongCc > 0) klgText.Add(Helpers.DoubleAsVnString(tongCc) + " ca chờ");
                    if (tongCb > 0) klgText.Add(Helpers.DoubleAsVnString(tongCb) + " ca bơm");
                    if (klgText.Count > 1) klgText[klgText.Count - 1] = "và " + klgText[klgText.Count - 1];

                    location = string.Format("D{0}:K{0}", ws.Dimension.End.Row);
                    ws.Cells[location].Value = string.Join(" ", klgText);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.Font.Bold = true;
                    ws.Cells[location].Style.Font.Italic = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    location = string.Format("A{0}:C{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[location].Value = "Giá trị bơm bằng chữ:";
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.Font.Bold = true;
                    ws.Cells[location].Style.Font.Italic = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    location = string.Format("D{0}:K{0}", ws.Dimension.End.Row);
                    ws.Cells[location].Value = Helpers.DoubleAsVnString(tongGt + chiphi) + " đồng";
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.Font.Bold = true;
                    ws.Cells[location].Style.Font.Italic = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    location = string.Format("I{0}:K{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = string.Format("Hà nội, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

                    location = string.Format("B{0}:D{1}", ws.Dimension.End.Row + 1, ws.Dimension.End.Row + 2);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.Font.Bold = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = ws.Cells["E7"].Value;
                    ws.Cells[location].Style.WrapText = true;

                    location = string.Format("I{0}:K{1}", ws.Dimension.End.Row - 1, ws.Dimension.End.Row);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.Font.Bold = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = ws.Cells["E8"].Value;

                    for (int i = 11; i <= ws.Dimension.End.Row; i++)
                    {
                        ws.Row(i).Style.Font.Size = 12;
                    }
                    ws.Column(3).AutoFit();
                    ws.Column(11).AutoFit();
                    Cursor.Current = Cursors.Default;

                    var saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = saveDialog.FileName;
                        excel.SaveAs(new FileInfo(path));
                        MessageBox.Show("Xuất file excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                if (ex.GetBaseException().Message.Contains("Sequence contains no elements"))
                {
                    MessageBox.Show("Không có kết quả nào", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BaoCaoThang()
        {
            try
            {
                if (DfromTb.Text.Length == 0 || DtoTb.Text.Length == 0)
                {
                    MessageBox.Show("Hãy điền cả 2 mục phạm vi ngày", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime dfrom = default(DateTime);
                DateTime dto = default(DateTime);
                var cul = CultureInfo.InvariantCulture;

                if (DfromTb.Text.Length > 0 && !DateTime.TryParseExact(DfromTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dfrom) ||
                    DtoTb.Text.Length > 0 && !DateTime.TryParseExact(DtoTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dto))
                {
                    MessageBox.Show("Ngày không đúng với format ddMMyyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var data = (from b in db.BaoCaoNgay
                            join v in db.ViTriBom_BaoCao on b.Id equals v.BaoCaoId
                            where b.TrangThai == 1
                            orderby b.CongTrinh.TenCongTrinh
                            select new
                            {
                                TenKh = b.KhachHang.TenCongTy,
                                TenCtr = b.CongTrinh.TenCongTrinh,
                                Ctr = b.CongTrinh,
                                Klg = v.DonVi == "khối" && v.SoLuong.HasValue ? v.SoLuong.Value : 0,
                                CaBom = v.DonVi == "ca bơm" && v.SoLuong.HasValue ? v.SoLuong.Value : 0,
                                CaCho = v.DonVi == "ca chờ" && v.SoLuong.HasValue ? v.SoLuong.Value : 0,
                                Gtri = v.SoLuong.HasValue ? v.DonGia * v.SoLuong.Value : 0,
                                GtriVat = v.SoLuong.HasValue ? v.DonGiaVat * v.SoLuong.Value : 0,
                                NgPt = b.CongTrinh.NhanVien.HoTen,
                                NgayBaoCao = b.NgayBaoCao
                            }).ToList();
                data = data.Where(a => a.NgayBaoCao.Value.Date >= dfrom.Date && a.NgayBaoCao.Value.Date <= dto.Date).ToList();

                var tblData = data.GroupBy(d => d.TenCtr).Select(d => new DoanhThuCongTrinh
                {
                    TenKh = d.FirstOrDefault().TenKh,
                    TenCtr = d.FirstOrDefault().TenCtr,
                    Klg = d.Sum(v => v.Klg),
                    CaBom = d.Sum(v => v.CaBom),
                    CaCho = d.Sum(v => v.CaCho),
                    Gtri = d.Sum(v => v.Gtri),
                    GtriVat = d.Sum(v => v.GtriVat),
                    NgPt = d.FirstOrDefault().NgPt,
                    NetCc1 = Convert.ToInt32(d.FirstOrDefault().Ctr.DonGiaBom.Where(dg => dg.CC1 != 0 && dg.CC1.HasValue).Average(dg => dg.CC1)),
                    NetCc2 = Convert.ToInt32(d.FirstOrDefault().Ctr.DonGiaBom.Where(dg => dg.NetCC2 != 0 && dg.NetCC2.HasValue).Average(dg => dg.NetCC2)),
                    GhiChu = ""
                });

                double total = 0;
                double totalVat = 0;
                double totalK = 0;
                double totalCc = 0;
                double totalCb = 0;
                foreach (var tblRow in tblData)
                {
                    totalK += tblRow.Klg.HasValue ? tblRow.Klg.Value : 0;
                    totalCb += tblRow.CaBom.HasValue ? tblRow.CaBom.Value : 0;
                    totalCc += tblRow.CaCho.HasValue ? tblRow.CaCho.Value : 0;
                    total += tblRow.Gtri.HasValue ? tblRow.Gtri.Value : 0;
                    totalVat += tblRow.GtriVat.HasValue ? tblRow.GtriVat.Value : 0;
                }

                var table = new DataTable();
                var headers = new string[]{
                    "TT",
                    "KhachHang",
                    "TenCongTrinh",
                    "KhoiLuong",
                    "CaBom",
                    "CaCho",
                    "GiaTri",
                    "GiaTriVat",
                    "NgPhuTrach",
                    "NetCc1",
                    "NetCc2",
                    "GhiChu"
                };
                for (int col = 0; col < headers.Length; col++)
                {
                    table.Columns.Add(headers[col]);

                    if (col == 3 || col == 4 || col == 5 || col == 6 || col == 7) table.Columns[col].DataType = typeof(double);
                    if (col == 9 || col == 10) table.Columns[col].DataType = typeof(int);
                }

                int stt = 1;
                foreach (var dataRow in tblData)
                {
                    DataRow tableRow = table.NewRow();

                    tableRow[0] = stt;
                    tableRow[1] = dataRow.TenKh;
                    tableRow[2] = dataRow.TenCtr;
                    tableRow[3] = dataRow.Klg ?? 0;
                    tableRow[4] = dataRow.CaBom ?? 0;
                    tableRow[5] = dataRow.CaCho ?? 0;
                    tableRow[6] = dataRow.Gtri ?? 0;
                    tableRow[7] = dataRow.GtriVat ?? 0;
                    tableRow[8] = dataRow.NgPt;
                    tableRow[9] = dataRow.NetCc1 ?? 0;
                    tableRow[10] = dataRow.NetCc2 ?? 0;
                    tableRow[11] = dataRow.GhiChu;

                    table.Rows.Add(tableRow);
                    stt++;
                }

                var rootPath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"bin\Debug\", "");
                var templatePath = Path.Combine(rootPath, "bao-cao-san-luong-thang-template.xlsx");
                var file = new FileInfo(templatePath);

                using (var excel = new ExcelPackage(file))
                {
                    var ws = excel.Workbook.Worksheets.First();

                    string timeframe = "";
                    if (dfrom != default(DateTime)) timeframe += "từ ngày " + dfrom.ToString("dd/MM/yyyy") + " ";
                    if (dto != default(DateTime)) timeframe += "đến ngày " + dto.ToString("dd/MM/yyyy");
                    ws.Cells["A6"].Value = timeframe;

                    ws.Cells["A8"].LoadFromDataTable(table, false);

                    var location = string.Format("A{0}:C{0}", ws.Dimension.End.Row + 1);
                    ws.Cells[location].Merge = true;
                    ws.Cells[location].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[location].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    ws.Cells[location].Value = "Cộng";

                    ws.Cells["D" + ws.Dimension.End.Row].Value = totalK > 0 ? totalK : 0;
                    ws.Cells["E" + ws.Dimension.End.Row].Value = totalCb > 0 ? totalCb : 0;
                    ws.Cells["F" + ws.Dimension.End.Row].Value = totalCc > 0 ? totalCc : 0;
                    ws.Cells["G" + ws.Dimension.End.Row].Value = total > 0 ? total : 0;
                    ws.Cells["H" + ws.Dimension.End.Row].Value = totalVat > 0 ? totalVat : 0;

                    for (int row = 8; row <= ws.Dimension.End.Row; row++)
                    {
                        ws.Row(row).Height = 17.25;
                        for (int col = 1; col <= 12; col++)
                        {
                            ws.Column(col).AutoFit();
                            ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            ws.Cells[row, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            if (col == 2 || col == 3) ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                            else if (col == 1 || col == 9) ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            else ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                            if (row == ws.Dimension.End.Row) ws.Cells[row, col].Style.Font.Bold = true;

                            if (col == 4 || col == 5 || col == 6)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = @"_(* #,##0.0_);_(* (#,##0.0);_(* ""-""??_);_(@_)"; //#,###.#
                            }

                            if (col == 7 || col == 8 || col == 10 || col == 11)
                            {
                                ws.Cells[row, col].Style.Numberformat.Format = @"_(* #,##0_);_(* (#,##0);_(* ""-""??_);_(@_)";  //#,###
                            }
                        }
                    }

                    for (int i = 8; i <= ws.Dimension.End.Row; i++)
                    {
                        ws.Row(i).Style.Font.Size = 9;
                    }
                    Cursor.Current = Cursors.Default;

                    var saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = saveDialog.FileName;
                        excel.SaveAs(new FileInfo(path));
                        MessageBox.Show("Xuất file excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BaoCaoTongHop()
        {
            try
            {
                int year = 0;
                if (NamTb.Text.Length > 0 && !int.TryParse(NamTb.Text, out year) && year < 1)
                {
                    MessageBox.Show("Năm phải là số lơn hơn 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime dfrom = new DateTime(year, 1, 1);
                DateTime dto = new DateTime(year, 12, 31);

                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                List<MayBom> mb = new List<MayBom>();
                
                var data = (from b in db.BaoCaoNgay
                            join vb in db.ViTriBom_BaoCao on b.Id equals vb.BaoCaoId
                            join v in db.ViTriBom on vb.ViTriId equals v.Id
                            where b.TrangThai == 1
                            select new
                            {
                                b = b,
                                v = v,
                                vb = vb
                            }).ToList();
                data = data.Where(a => a.b.NgayBaoCao.Value.Date >= dfrom.Date && a.b.NgayBaoCao.Value.Date <= dto.Date).ToList();

                foreach (var d in data)
                {
                    mb.Add(d.b.MayBom);
                }

                mb = mb.Distinct().OrderBy(b => b.LoaiBom).ThenBy(b => b.Id).ToList();

                var btnColCount = mb.Count(b => b.LoaiBom == 2);
                var mbHeader = mb.Select(b => b.TenBom + " (" + b.Id + ")").ToList();

                var dataGroup = data.GroupBy(row => new { row.b.NgayBaoCao, row.b.CongTrinhId, row.v.ViTri, row.vb.Tang, row.vb.DonGia });

                var tblData = dataGroup.Select(row => new TongSanLuong
                {
                    NgayBaoCao = row.Key.NgayBaoCao.Value,
                    TenCongTrinh = row.FirstOrDefault().b.CongTrinh.TenCongTrinh,
                    MaCongTrinh = row.Key.CongTrinhId,
                    ViTri = row.Key.ViTri,
                    Tang = row.Key.Tang,
                    DonGia = (row.FirstOrDefault().vb == null || row.FirstOrDefault().vb.DonGia == null) ? 0 : row.FirstOrDefault().vb.DonGia.Value,
                    TongCC = (row.FirstOrDefault().vb == null || row.FirstOrDefault().vb.DonGiaBom == null || row.FirstOrDefault().vb.DonGiaBom.TongCC == null) ? 0 : row.FirstOrDefault().vb.DonGiaBom.TongCC.Value,
                    TieuDeBom = row.Select(m => m.b.MayBom.TenBom + " (" + m.b.MayBom.Id + ")").ToList(),
                    KhoiLuongBom = row.Select(k => k.vb.DonVi == "khối" ? k.vb.SoLuong ?? 0 : 0).ToList(),
                    CaBom = row.Select(k => k.vb.DonVi == "ca bơm" ? k.vb.SoLuong ?? 0 : 0).FirstOrDefault(),
                    CaCho = row.Select(k => k.vb.DonVi == "ca chờ" ? k.vb.SoLuong ?? 0 : 0).FirstOrDefault()
                }).ToList();

                foreach (var row in tblData)
                {
                    row.DonGiaThuc = row.DonGia - row.TongCC;
                    row.GiaTri = row.DonGia * (row.KhoiLuongBom.Sum(k => k) + row.CaBom + row.CaCho);
                    row.GiaTriThuc = row.DonGiaThuc * (row.KhoiLuongBom.Sum(k => k) + row.CaBom + row.CaCho);
                }

                var table = new DataTable();
                var headers = new List<string>();
                headers.Add("Stt");
                headers.Add("Ngày");
                headers.Add("Tên công trình");
                headers.Add("Mã công trình");
                headers.AddRange(mbHeader);
                headers.Add("Ca bơm");
                headers.Add("Ca chờ");
                headers.Add("Tổng");
                headers.Add("Vị trí");
                headers.Add("Đơn giá (chưa VAT)");
                headers.Add("Đơn giá thực tế (chưa VAT)");
                foreach (string header in headers)
                {
                    table.Columns.Add(header);
                    if (header.Contains(')') || header == "Tổng" || header.Contains("Ca") || header.Contains("Đơn giá"))
                        table.Columns[header].DataType = typeof(double);
                }

                for (int month = 1; month <= 12; month++)
                {
                    int stt = 1;
                    var horizontalSum = new List<double>();
                    
                    var monthData = tblData
                        .Where(d => d.NgayBaoCao >= new DateTime(year, month, 1) 
                            && d.NgayBaoCao <= new DateTime(year, month, DateTime.DaysInMonth(year, month)))
                            .OrderBy(d => d.NgayBaoCao);

                    foreach (var dataRow in monthData)
                    {
                        DataRow tableRow = table.NewRow();

                        tableRow[0] = stt;
                        tableRow[1] = dataRow.NgayBaoCao.ToString("dd/MM");
                        tableRow[2] = dataRow.TenCongTrinh;
                        tableRow[3] = dataRow.MaCongTrinh;

                        for (int i = 0; i < dataRow.TieuDeBom.Count; i++)
                        {
                            tableRow[dataRow.TieuDeBom[i]] = dataRow.KhoiLuongBom[i];
                        }

                        tableRow["Ca bơm"] = dataRow.CaBom;
                        tableRow["Ca chờ"] = dataRow.CaCho;
                        tableRow["Tổng"] = dataRow.KhoiLuongBom.Sum(k => k) + dataRow.CaBom + dataRow.CaCho;
                        tableRow["Vị trí"] = dataRow.ViTri + " " + (dataRow.Tang.HasValue ? dataRow.Tang.ToString() : "");
                        tableRow["Đơn giá (chưa VAT)"] = dataRow.DonGia;
                        tableRow["Đơn giá thực tế (chưa VAT)"] = dataRow.DonGiaThuc;

                        table.Rows.Add(tableRow);
                        stt++;

                        if (dataRow == monthData.Last())
                        {
                            DataRow sumRow = table.NewRow();
                            sumRow[0] = "T" + month;
                            table.Rows.Add(sumRow);
                        }
                    }
                }

                using (var excel = new ExcelPackage())
                {
                    var ws = excel.Workbook.Worksheets.Add("Tong hop " + year);
                    ws.Cells["A1"].LoadFromDataTable(table, true); //data

                    //các cột giá trị
                    for (int c = 1; c <= mbHeader.Count; c++)
                    {
                        ws.Cells[1, ws.Dimension.End.Column + 1].Value = mbHeader[c - 1];
                    }

                    ws.Cells[1, ws.Dimension.End.Column + 1].Value = "Tổng giá trị (chưa VAT)";
                    ws.Cells[1, ws.Dimension.End.Column + 1].Value = "Giá trị thu về thực tế (chưa VAT)";
                    ws.Cells[1, ws.Dimension.End.Column + 1].Value = "Chi phí tư vấn phải trả khách hàng và bơm thuê ngoài";
                    ws.Cells[1, ws.Dimension.End.Column + 1].Value = "Ghi chú";

                    //tính giá trị
                    for (int r = 2; r <= ws.Dimension.End.Row; r++)
                    {
                        for (int c = 5; c <= mbHeader.Count; c++)
                        {
                            ws.Cells[r, c + mbHeader.Count + 6].Formula = string.Format("{0}*{1}", GetExcelColumnName(c) + r, GetExcelColumnName(mbHeader.Count + 4 + 5) + r);
                        }

                        if (ws.Cells[r, 2].Value != null)
                        {
                            ws.Cells[r, ws.Dimension.End.Column - 3].Formula = string.Format("{0}*{1}", GetExcelColumnName(mbHeader.Count + 4 + 3) + r, GetExcelColumnName(mbHeader.Count + 4 + 5) + r);

                            ws.Cells[r, ws.Dimension.End.Column - 2].Formula = string.Format("{0}*{1}", GetExcelColumnName(mbHeader.Count + 4 + 3) + r, GetExcelColumnName(mbHeader.Count + 4 + 6) + r);
                        }
                    }
                    ws.Cells[ws.Dimension.End.Row + 1, 3].Value = "Tổng cộng";

                    //style
                    List<int> breakRow = new List<int>();
                    breakRow.Add(2);
                    for (int row = 1; row <= ws.Dimension.End.Row; row++)
                    {
                        if (row == 1)
                        {
                            ws.Row(row).Height = 24;
                            ws.Row(row).Style.Font.Bold = true;
                        }
                        else
                        {
                            ws.Row(row).Height = 12;
                        }

                        //tổng các tháng
                        if (ws.Cells[row, 1].Value != null && ws.Cells[row, 1].Value.ToString().Contains("T"))
                        {
                            ws.Row(row).Style.Font.Color.SetColor(Color.Blue);
                            ws.Row(row).Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws.Row(row).Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                            ws.Row(row).Style.Font.Bold = true;
                            breakRow.Add(row + 1);
                        }

                        //tổng năm
                        if (row == ws.Dimension.End.Row)
                        {
                            ws.Row(row).Style.Font.Bold = true;
                        }

                        //border toàn bộ sheet
                        for (int col = 1; col <= ws.Dimension.End.Column; col++)
                        {
                            ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                            if (row == ws.Dimension.End.Row)
                            {
                                ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);
                            }
                        }
                    }

                    //style & format
                    for (int col = 1; col <= ws.Dimension.End.Column; col++)
                    {
                        if (col < 5)
                        {
                            if (col == 1) ws.Column(col).Width = 4;
                            if (col < 3)
                            {
                                ws.Column(col).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                ws.Column(col).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }
                            ws.Cells[1, col].Value = "";
                        }

                        ws.Cells[1, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[1, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ws.Column(col).Style.Font.Name = "Times New Roman";
                        ws.Column(col).Style.Font.Size = 9;

                        if (col > 4)
                        {
                            ws.Column(col).Style.Numberformat.Format = @"_(* #,##0.0_);_(* (#,##0.0);_(* ""-""??_);_(@_)"; //#,###.#
                            ws.Cells[1, col].Style.WrapText = true;
                        }

                        if (col < 5) ws.Column(col).AutoFit();

                        if (col > (4 + mbHeader.Count + 3) && col <= (4 + mbHeader.Count + 6))
                        {
                            ws.Column(col).Width = 12;
                        }

                        if (col > (4 + mbHeader.Count + 6) && col < ws.Dimension.End.Column - 1) 
                            ws.Column(col).Width = 14;

                        ws.Column(ws.Dimension.End.Column).Width = 40;
                    }

                    //tính tổng tháng
                    for (int i = 1; i < breakRow.Count; i++)
                    {
                        for (int col = 1; col < ws.Dimension.End.Column; col++)
                        {
                            string c = GetExcelColumnName(col);
                            var headerCell = ws.Cells[1, col].Value.ToString();
                            if (headerCell.Contains(')') || headerCell.Contains("Ca") || headerCell.Contains("Tổng") || headerCell.Contains("Giá trị") || headerCell.Contains("Chi phí"))
                            {
                                ws.Cells[breakRow[i] - 1, col].Formula = string.Format("SUM({0}:{1})", c + breakRow[i - 1].ToString(), c + (breakRow[i] - 2).ToString());
                            }

                            var TongCol = GetExcelColumnName(col - 1);
                            if (headerCell == "Vị trí")
                            {
                                var btnLastCol = GetExcelColumnName(col - 4);
                                var vtColFml = TongCol + (breakRow[i] - 1);

                                for (int btnCol = 0; btnCol < btnColCount; btnCol++)
                                {
                                    var colName = GetExcelColumnName(col - 4 - btnCol);
                                    vtColFml += "-" + colName + (breakRow[i] - 1);
                                }

                                ws.Cells[breakRow[i] - 1, col].Formula = vtColFml;
                            }

                            if (headerCell == "Đơn giá (chưa VAT)")
                            {
                                var GtriCol = GetExcelColumnName(4 + mbHeader.Count * 2 + 6 + 1);
                                ws.Cells[breakRow[i] - 1, col].Formula = string.Format("{0}/{1}", GtriCol + (breakRow[i] - 1), TongCol + (breakRow[i] - 1));
                            }

                            if (headerCell == "Đơn giá thực tế (chưa VAT)")
                            {
                                var ViTriCol = GetExcelColumnName(col - 2);
                                var GtriThucCol = GetExcelColumnName(4 + mbHeader.Count * 2 + 6 + 2);
                                ws.Cells[breakRow[i] - 1, col].Formula = string.Format("{0}/{1}", GtriThucCol + (breakRow[i] - 1), ViTriCol + (breakRow[i] - 1));
                            }
                        }
                    }

                    for (int col = 5; col < ws.Dimension.End.Column; col++)
                    {
                        if (col > 4 + mbHeader.Count + 3 && col <= 4 + mbHeader.Count + 6) continue;
                        string fml = "";
                        for (int i = 1; i < breakRow.Count; i++)
                        {
                            fml += GetExcelColumnName(col) + (breakRow[i] - 1) + "+";
                        }
                        ws.Cells[ws.Dimension.End.Row, col].Formula = fml.Substring(0, fml.Length > 0 ? fml.Length - 1 : 0);
                    }

                    ws.View.FreezePanes(2, 5);

                    Cursor.Current = Cursors.Default;
                    var saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = saveDialog.FileName;
                        excel.SaveAs(new FileInfo(path));
                        MessageBox.Show("Xuất file excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message + ex.GetBaseException().StackTrace, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BaoCaoKlgNv()
        {
            try
            {
                DateTime dfrom = default(DateTime);
                DateTime dto = default(DateTime);
                var cul = CultureInfo.InvariantCulture;

                if (DfromTb.Text.Length == 0 || DtoTb.Text.Length == 0)
                {
                    MessageBox.Show("Hãy điền cả 2 mục phạm vi ngày", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DateTime.TryParseExact(DfromTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dfrom) ||
                    !DateTime.TryParseExact(DtoTb.Text, "ddMMyyyy", cul, DateTimeStyles.None, out dto))
                {
                    MessageBox.Show("Ngày không đúng với format ddMMyyyy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                var db = new CkpEntities();
                var mb = (from b in db.MayBom where b.TrangThai == 1 orderby b.LoaiBom select b);
                List<NhanVien> nv = new List<NhanVien>();
                
                var data = db.BaoCaoNgay.ToList().Where(b => b.TrangThai == 1 && b.NgayBaoCao.Value.Date >= dfrom.Date && b.NgayBaoCao.Value.Date <= dto.Date).ToList();
                
                foreach (var d in data)
                {
                    nv.AddRange(d.NhanLuc_BaoCao.Select(nb => nb.NhanVien));
                }
                nv = nv.Distinct().OrderBy(n => n.HoTen).ToList();

                var nvId = nv.Select(n => n.Id).ToList();
                var nvHeader = nv.Select(n => n.HoTen + " (" + GetAbbreviation(n.ChucVu) + ")").ToList();

                var dataGroup = data.GroupBy(bc => bc.MayBomId).Select(g => new {
                    BomId = g.Key,
                    TenBom = g.FirstOrDefault() == null ? "" : g.FirstOrDefault().MayBom.TenBom,
                    BcNgay = g.Select(bcn => bcn)
                });

                var table = new DataTable();
                for (int i = 0; i < (1 + nv.Count() * 3); i++)
                {
                    if (i == 0)
                    {
                        table.Columns.Add();
                    }
                    else if (i % 3 == 2)
                    {
                        table.Columns.Add("", typeof(int));
                    }
                    else
                    {
                        table.Columns.Add("", typeof(double));
                    }
                }

                foreach (var group in dataGroup)
                {
                    var groupRow = table.NewRow();
                    groupRow[0] = group.TenBom + " (" + group.BomId + ")";
                    table.Rows.Add(groupRow);

                    foreach (var bc in group.BcNgay.OrderBy(b => b.NgayBaoCao))
                    {
                        var rows = bc.NhanLuc_BaoCao.GroupBy(n => n.NhanVienId).OrderByDescending(g => g.Count()).FirstOrDefault();
                        if (rows == null)
                        {
                            var paddingRow = table.NewRow();
                            paddingRow[0] = bc.NgayBaoCao.Value.ToString("dd/MM");
                            table.Rows.Add(paddingRow);
                            continue;
                        }

                        var output = new List<NhanLuc_BaoCao>();

                        for (int i = 0; i < rows.Count(); i++)
                        {
                            var tableRow = table.NewRow();
                            tableRow[0] = bc.NgayBaoCao.Value.ToString("dd/MM");
                            foreach (var nlbc in bc.NhanLuc_BaoCao.OrderBy(n => n.NhanVienId).AsEnumerable().Except(output))
                            {
                                var colGroup = nvId.IndexOf(nlbc.NhanVienId.Value) * 3;

                                if (tableRow[colGroup + 1].ToString() != string.Empty) continue;

                                tableRow[colGroup + 1] = nlbc.KhoiLuongBom ?? 0;
                                tableRow[colGroup + 2] = nlbc.DonGiaKhoi ?? 0;
                                tableRow[colGroup + 3] = (nlbc.KhoiLuongBom ?? 0) * (nlbc.DonGiaKhoi ?? 0);

                                output.Add(nlbc);
                            }
                            table.Rows.Add(tableRow);
                        }
                    }
                    
                    var sumRow = table.NewRow();
                    sumRow[0] = "Tổng bơm " + group.BomId;
                    table.Rows.Add(sumRow);
                }
                var totalRow = table.NewRow();
                totalRow[0] = "Tổng cộng";
                table.Rows.Add(totalRow);

                using (var excel = new ExcelPackage())
                {
                    string wsName = "";
                    if (dfrom.Month == dto.Month)
                    {
                        wsName = "T" + dfrom.Month;
                    }
                    else
                    {
                        wsName = "T" + dfrom.Month + "-T" + dto.Month;
                    }

                    var ws = excel.Workbook.Worksheets.Add(wsName);
                    ws.Cells["A3"].LoadFromDataTable(table, false);

                    ws.Cells["A1:A2"].Merge = true;
                    ws.Cells["A1"].Value = "Ngày tháng";
                    ws.Cells["A1"].Style.WrapText = true;

                    for (int col = 2; col <= ws.Dimension.End.Column; col = col + 3)
                    {
                        ws.Cells[string.Format("{0}1:{1}1", GetExcelColumnName(col), GetExcelColumnName(col + 2))].Merge = true;
                        ws.Cells[GetExcelColumnName(col) + "1"].Value = nvHeader[(col - 2) / 3];
                        ws.Cells[GetExcelColumnName(col) + "2"].Value = "Khối lượng";
                        ws.Cells[GetExcelColumnName(col + 1) + "2"].Value = "Đơn giá/khối";
                        ws.Cells[GetExcelColumnName(col + 2) + "2"].Value = "Thành tiền";
                    }

                    var breakRow = new List<int>();
                    breakRow.Add(4);
                    for (int row = 1; row <= ws.Dimension.End.Row; row++)
                    {
                        if (ws.Cells[row, 1].Value != null && ws.Cells[row, 1].Value.ToString().Contains("Tổng bơm"))
                        {
                            breakRow.Add(row + 2);
                        }

                        if (row == 1 || row == 2)
                        {
                            if (row == 1) ws.Row(row).Height = 21;
                            else ws.Row(row).Height = 30;

                            ws.Row(row).Style.WrapText = true;
                        }
                        else
                        {
                            ws.Row(row).Height = 25;
                        }

                        ws.Row(row).Style.Font.Name = "Times New Roman";
                        ws.Row(row).Style.Font.Size = 9;
                        if (row == ws.Dimension.End.Row) ws.Row(row).Style.Font.Bold = true;
                    }

                    for (int col = 1; col <= ws.Dimension.End.Column; col++)
                    {
                        if (col == 1)
                        {
                            ws.Column(col).Width = 10;
                            ws.Column(col).Style.WrapText = true;
                        }
                        else
                        {
                            ws.Column(col).AutoFit();
                        }

                        if (col > 1)
                        {
                            string c = GetExcelColumnName(col);
                            string fml = "";
                            for (int r = 1; r < breakRow.Count; r++)
                            {
                                fml += c + (breakRow[r] - 2) + "+";
                            }
                            fml = fml.Substring(0, fml.Length - 1);

                            ws.Cells[ws.Dimension.End.Row, col].Formula = fml;
                        }

                        for (int row = 1; row <= ws.Dimension.End.Row; row++)
                        {
                            if (row == ws.Dimension.End.Row) ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                            else ws.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            
                            ws.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[row, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            if (col % 3 == 2) ws.Cells[row, col].Style.Numberformat.Format = @"_(* #,##0.0_);_(* (#,##0.0);_(* ""-""??_);_(@_)"; //#,###.##
                            else
                            {
                                if (col > 1) ws.Cells[row, col].Style.Numberformat.Format = @"_(* #,##0_);_(* (#,##0);_(* ""-""??_);_(@_)";  //#,###
                            }
                        }
                    }

                    for (int r = 1; r < breakRow.Count; r++)
                    {
                        ws.Row(breakRow[r] - 2).Style.Font.Bold = true;

                        for (int col = 2; col <= ws.Dimension.End.Column; col++)
                        {
                            string c = GetExcelColumnName(col);
                            ws.Cells[breakRow[r] - 2, col].Formula = string.Format("SUM({0}:{1})", c + breakRow[r - 1], c + (breakRow[r] - 3));
                        }
                    }
                    ws.View.FreezePanes(3, 1);

                    Cursor.Current = Cursors.Default;
                    var saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = saveDialog.FileName;
                        excel.SaveAs(new FileInfo(path));
                        MessageBox.Show("Xuất file excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetAbbreviation(string s)
        {
            var abbr = "";
            var words = s.Split(' ');
            foreach (var word in words)
            {
                if (word.Length > 0)
                {
                    abbr += Char.ToUpper(word[0]);
                }
            }
            return abbr;
        }

        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private void BcCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (BcCb.SelectedIndex == 0)
            {
                CtrCb.Enabled = true;
                DfromTb.Enabled = true;
                DtoTb.Enabled = true;
                TdTb.Enabled = true;
                CpTb.Enabled = true;
                GcRtb.Enabled = true;
                VatTb.Enabled = true;
                NamTb.Enabled = false;
            }
            else if (BcCb.SelectedIndex == 1)
            {
                CtrCb.Enabled = false;
                DfromTb.Enabled = true;
                DtoTb.Enabled = true;
                TdTb.Enabled = false;
                CpTb.Enabled = false;
                GcRtb.Enabled = false;
                VatTb.Enabled = false;
                NamTb.Enabled = false;
            }
            else if (BcCb.SelectedIndex == 2)
            {
                CtrCb.Enabled = false;
                DfromTb.Enabled = false;
                DtoTb.Enabled = false;
                TdTb.Enabled = false;
                CpTb.Enabled = false;
                GcRtb.Enabled = false;
                VatTb.Enabled = false;
                NamTb.Enabled = true;
            }
            else if (BcCb.SelectedIndex == 3)
            {
                CtrCb.Enabled = false;
                DfromTb.Enabled = true;
                DtoTb.Enabled = true;
                TdTb.Enabled = false;
                CpTb.Enabled = false;
                GcRtb.Enabled = false;
                VatTb.Enabled = false;
                NamTb.Enabled = false;
            }
            else { }
        }

        private void CpTb_Enter(object sender, EventArgs e)
        {
            CpTb.Text = CpTb.Text.Replace(",", "");
        }

        private void CpTb_Leave(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(CpTb.Text, out val))
            {
                CpTb.Text = val.ToString("N0");
            }
        }
    }

    public class DoanhThuCongTrinh
    {
        public string TenKh { get; set; }
        public string TenCtr { get; set; }
        public double? Klg { get; set; }
        public double? CaBom { get; set; }
        public double? CaCho { get; set; }
        public double? Gtri { get; set; }
        public double? GtriVat { get; set; }
        public string NgPt { get; set; }
        public int? NetCc1 { get; set; }
        public int? NetCc2 { get; set; }
        public string GhiChu { get; set; }
    }

    public class TongSanLuong
    {
        public DateTime NgayBaoCao { get; set; }
        public string TenCongTrinh { get; set; }
        public string MaCongTrinh { get; set; }
        public List<string> TieuDeBom { get; set; }
        public List<double> KhoiLuongBom { get; set; }
        public double CaBom { get; set; }
        public double CaCho { get; set; }
        public string ViTri { get; set; }
        public int? Tang { get; set; }
        public double DonGia { get; set; }
        public double DonGiaThuc { get; set; }
        public int TongCC { get; set; }
        public double GiaTri { get; set; }
        public double GiaTriThuc { get; set; }
    }
}