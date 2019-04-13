using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap3
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static string ten;
        private void button1_Click(object sender, EventArgs e)
        {
            ten = textBox1.Text;
            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
        }
    }
}
