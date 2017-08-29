using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace CkpApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            try
            {
                DataMgmtBtn.Hide();

                //Compare the data source in app.config file this pc's name
                //  if they are identical (which means this is the machine which MSSQLSERVER is installed)
                //  show the option to backup and restore database
                //Note: this is only apply when this app is deploy on a LAN network,
                //  which is the initial purpose of this app
                if (Environment.MachineName == Helpers.GetDataSource().ToUpper())
                {
                    DataMgmtBtn.Show();
                    InitializeService();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //if MSSQLSERVER hasn't started, start the service
        private void InitializeService()
        {
            ServiceController sc = new ServiceController("MSSQLSERVER", Helpers.GetDataSource().ToUpper());
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
            }
            if (sc.Status == ServiceControllerStatus.Paused)
            {
                sc.Continue();
            }
        }

        private void MayBomBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MayBomForm>().Count() == 1)
                Application.OpenForms.OfType<MayBomForm>().First().Focus();
            else
            {
                var form = new MayBomForm();
                form.Show();
            }
        }

        private void KhachHangBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<KhachHangForm>().Count() == 1)
                Application.OpenForms.OfType<KhachHangForm>().First().Focus();
            else
            {
                var form = new KhachHangForm();
                form.Show();
            }
        }

        private void NhanSuBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<NhanVienForm>().Count() == 1)
                Application.OpenForms.OfType<NhanVienForm>().First().Focus();
            else
            {
                var form = new NhanVienForm();
                form.Show();
            }
        }

        private void ViTriBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ViTriForm>().Count() == 1)
                Application.OpenForms.OfType<ViTriForm>().First().Focus();
            else
            {
                var form = new ViTriForm();
                form.Show();
            }
        }

        private void BaoCaoNgayBtn_Click(object sender, EventArgs e)
        {
            var form = new BaoCaoNgayForm();
            form.Show();
        }

        private void QlyBaoCaoBtn_Click(object sender, EventArgs e)
        {
            var form = new QuanLyBaoCaoForm();
            form.Show();
        }

        private void CongTrinhBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CongTrinhForm>().Count() == 1)
                Application.OpenForms.OfType<CongTrinhForm>().First().Focus();
            else
            {
                var form = new CongTrinhForm();
                form.Show();
            }
        }

        private void XuatBaoCaoBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<BaoCaoForm>().Count() == 1)
                Application.OpenForms.OfType<BaoCaoForm>().First().Focus();
            else
            {
                var form = new BaoCaoForm();
                form.Show();
            }
        }

        private void DonGiaBtn_Click(object sender, EventArgs e)
        {
            var form = new DonGiaForm();
            form.Show();
        }

        private void DataMgmtBtn_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<DataManager>().Count() == 1)
                Application.OpenForms.OfType<DataManager>().First().Focus();
            else
            {
                var form = new DataManager();
                form.Show();
            }
        }
    }
}
