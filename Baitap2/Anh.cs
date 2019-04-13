using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap2
{
    public partial class Anh : Form
    {
        public Anh()
        {
            InitializeComponent();
        }
        string[] ds;
        private void chọnẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); // chọn 1 ảnh
            ds = openFileDialog1.FileNames;
            timer1.Enabled = true;
        }
        int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(ds[i]);
            i++;
            if (i == ds.Length)
                i = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
}
