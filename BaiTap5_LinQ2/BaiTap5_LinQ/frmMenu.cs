using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap5_LinQ
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void đăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap f = new frmDangNhap();
            f.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapSuaXoa f = new frmNhapSuaXoa();
            f.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaiKhoan f = new frmTaiKhoan();
            f.ShowDialog();
        }
    }
}
