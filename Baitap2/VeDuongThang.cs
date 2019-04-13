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
    public partial class VeDuongThang : Form
    {
        public VeDuongThang()
        {
            InitializeComponent();
        }
        int x1, y1;

        private void VeDuongThang_MouseUp(object sender, MouseEventArgs e)
        {
            //Graphics g = CreateGraphics();
            //g.DrawLine(new Pen(Color.Red), x1, y1, e.X, e.Y);
        }

        private void VeDuongThang_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            //g.DrawLine(new Pen(Color.Red), x1, y1, e.X, e.Y);// vẽ mặt định
            g.DrawLine(new Pen(colorDialog1.Color), x1, y1, e.X, e.Y);// vẽ chọn màu
        }

        private void chọnMàuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString();
        }

        private void VeDuongThang_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
        }
    }
}
