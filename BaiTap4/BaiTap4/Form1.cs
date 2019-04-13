using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SinhVien sv = new SinhVien("s1", "nguyen van a ", 23, 32.5);
            //MessageBox.Show(sv.Hoten);
            Nguoi n1 = new SinhVien("s1", "bbb", 12, 32.45);
            MessageBox.Show(n1.getTen());
        }
    }
}
