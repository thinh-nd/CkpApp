using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CkpApp
{
    public partial class ThemMayBom : Form
    {
        private MayBomForm parentForm { get; set; }

        public ThemMayBom()
        {
            InitializeComponent();
            TypeCBox.SelectedIndex = 0;
            //TypeCBox.Enabled = false;
        }

        public ThemMayBom(MayBomForm form)
            : this()
        {
            parentForm = form;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new CkpEntities();
                var id = IdTBox.Text;
                var name = NameTBox.Text;
                if (id.Length > 0 && name.Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var newRow = new MayBom
                    {
                        Id = id.Trim(),
                        TenBom = name.Trim(),
                        LoaiBom = TypeCBox.SelectedIndex == 0 ? 1 : 2,
                        TrangThai = 1,
                        NgayTao = DateTime.Now,
                        NgaySuaCuoi = DateTime.Now
                    };
                    db.MayBom.Add(newRow);
                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Tạo mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.UpdateDataGrid();
                    Close();
                }
                else
                {
                    if (id.Length == 0) IdLbl.ForeColor = Color.Red;
                    else IdLbl.ForeColor = Color.Black;

                    if (id.Length == 0) NameLbl.ForeColor = Color.Red;
                    else NameLbl.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                var exMsg = ex.GetBaseException().Message;
                if (exMsg.Contains("Violation of PRIMARY KEY constrain"))
                {
                    MessageBox.Show("Mã máy bơm đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
