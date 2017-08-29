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
    public partial class ViTriForm : Form
    {
        public ViTriForm()
        {
            InitializeComponent();

            ViTriGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateDataGrid();
        }

        public void UpdateDataGrid()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ViTriGrid.Rows.Clear();
                var db = new CkpEntities();
                var allVt = (from d in db.ViTriBom where d.TrangThai == 1 select d).ToList();

                foreach (var dg in allVt)
                {
                    ViTriGrid.Rows.Add(dg.ViTri);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = ViTriGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRows == 0)
                {
                    MessageBox.Show("Vui lòng chọn tối thiểu một đơn giá để xóa", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        var db = new CkpEntities();
                        for (int i = 0; i < selectedRows; i++)
                        {
                            var id = ViTriGrid.SelectedRows[i].Cells[0].Value.ToString();
                            var dg = (from d in db.ViTriBom where d.ViTri == id select d).FirstOrDefault();
                            dg.TrangThai = 0;
                            db.SaveChanges();
                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Đã xóa " + selectedRows + " vị trí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        UpdateDataGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ThemViTri>().Count() == 1)
                Application.OpenForms.OfType<ThemViTri>().First().Focus();
            else
            {
                var form = new ThemViTri(this);
                form.Show();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var selectedRows = ViTriGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (selectedRows == 0 || selectedRows > 1)
            {
                MessageBox.Show("Vui lòng chọn một vị trí để thay đổi thông tin", "Thao tác", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Application.OpenForms.OfType<SuaViTri>().Count() == 1)
                    Application.OpenForms.OfType<SuaViTri>().First().Close();

                var vt = ViTriGrid.SelectedRows[0].Cells[0].Value.ToString();
                var form = new SuaViTri(this, vt);
                form.Show();
            }
        }
    }
}
