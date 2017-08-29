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
    public partial class SuaMayBom : Form
    {
        private MayBomForm parentForm { get; set; }

        public SuaMayBom()
        {
            InitializeComponent();
            //TypeCBox.Enabled = false;
        }

        public SuaMayBom(MayBomForm form, string id) : this()
        {
            this.parentForm = form;
            try
            {
                var db = new CkpEntities();
                var mayBom = (from b in db.MayBom where b.Id == id select b).First();
                IdTbox.Text = mayBom.Id;
                NameTBox.Text = mayBom.TenBom;
                TypeCBox.Text = mayBom.LoaiBom == 1 ? "Bơm công ty" : "Bơm thuê ngoài";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new CkpEntities();
                var name = NameTBox.Text;
                var id = IdTbox.Text;
                if (name.Length > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var mayBom = (from b in db.MayBom where b.Id == id select b).FirstOrDefault();
                    mayBom.TenBom = name.Trim();
                    mayBom.LoaiBom = TypeCBox.SelectedIndex == 0 ? 1 : 2;
                    mayBom.NgaySuaCuoi = DateTime.Now;
                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
