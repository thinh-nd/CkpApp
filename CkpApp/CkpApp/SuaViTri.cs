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
    public partial class SuaViTri : Form
    {
        private ViTriForm parentForm { get; set; }
        private string Vt { get; set; }

        public SuaViTri()
        {
            InitializeComponent();
        }

        public SuaViTri(ViTriForm form, string vt)
            : this()
        {
            try
            {
                parentForm = form;
                Vt = vt;

                var db = new CkpEntities();
                var v = (from d in db.ViTriBom where d.ViTri == vt select d).FirstOrDefault();

                ViTriTBox.Text = v.ViTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            var viTri = ViTriTBox.Text.Trim();

            if (viTri.Length == 0)
            {
                if (viTri.Length == 0) ViTriLbl.ForeColor = Color.Red;
                else ViTriLbl.ForeColor = Color.Black;
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var db = new CkpEntities();

                    var allVt = (from d in db.ViTriBom where d.ViTri == Vt select d);

                    if (allVt.Select(v => v.ViTri).Contains(viTri))
                    {
                        MessageBox.Show("Vị trí bơm này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var vt = allVt.FirstOrDefault();

                    vt.ViTri = viTri;
                    vt.NgaySuaCuoi = DateTime.Now;

                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    parentForm.UpdateDataGrid();
                    MessageBox.Show("Thay đổi vị trí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
