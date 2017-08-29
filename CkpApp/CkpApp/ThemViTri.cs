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
    public partial class ThemViTri : Form
    {
        private ViTriForm parentForm { get; set; }

        public ThemViTri()
        {
            InitializeComponent();
        }

        public ThemViTri(ViTriForm form)
            : this()
        {
            parentForm = form;
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

                    if (db.ViTriBom.Select(v => v.ViTri).Contains(viTri))
                    {
                        MessageBox.Show("Vị trí bơm này đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newVt = new ViTriBom
                    {
                        ViTri = viTri,
                        TrangThai = 1,
                        NgayTao = DateTime.Now,
                        NgaySuaCuoi = DateTime.Now
                    };
                    db.ViTriBom.Add(newVt);
                    db.SaveChanges();

                    Cursor.Current = Cursors.Default;
                    parentForm.UpdateDataGrid();
                    MessageBox.Show("Thêm vị trí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
