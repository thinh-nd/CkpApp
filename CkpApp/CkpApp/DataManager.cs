using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CkpApp
{
    public partial class DataManager : Form
    {
        public DataManager()
        {
            InitializeComponent();
        }

        private void BackupBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Backup files (*.bak)|*.bak";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var path = saveDialog.FileName;

                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.RedirectStandardOutput = true;

                    p.StartInfo.Arguments = string.Format(@"/C SqlCmd -E -S {0} -Q ""BACKUP DATABASE Ckp TO DISK='{1}'""", Environment.MachineName, path);

                    p = Process.Start(p.StartInfo);
                    var success = p.WaitForExit(30 * 1000);

                    string output = p.StandardOutput.ReadToEnd();
                    MessageBox.Show(output);
                    Cursor.Current = Cursors.Default;

                    if (success && output.Contains("successfully"))
                    {
                        MessageBox.Show("Sao lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (success && output.Contains("Operating system error 5"))
                    {
                        MessageBox.Show("Hệ thống không có quyền truy cập vào thư mục này, hãy chọn thư mục khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Sao lưu dữ liệu thất bại, lỗi không xác định", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    p.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestoreBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var openDialog = new OpenFileDialog();
                openDialog.Filter = "Backup files (*.bak)|*.bak";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var path = openDialog.FileName;

                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.RedirectStandardOutput = true;

                    p.StartInfo.Arguments = string.Format(@"/C SqlCmd -E -S {0} -Q ""RESTORE DATABASE Ckp FROM DISK='{1}'""", Environment.MachineName, path);

                    p = Process.Start(p.StartInfo);
                    var success = p.WaitForExit(30 * 1000);

                    string output = p.StandardOutput.ReadToEnd();
                    MessageBox.Show(output);
                    Cursor.Current = Cursors.Default;

                    if (success && output.Contains("successfully"))
                    {
                        MessageBox.Show("Sao lưu dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else if (success && output.Contains("Operating system error 5"))
                    {
                        MessageBox.Show("Hệ thống không có quyền truy cập vào thư mục này, hãy chọn thư mục khác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Sao lưu dữ liệu thất bại, lỗi không xác định", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    p.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.GetBaseException().Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
