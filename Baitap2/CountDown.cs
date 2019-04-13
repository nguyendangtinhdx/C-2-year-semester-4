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
    public partial class CountDown : Form
    {
        public CountDown()
        {
            InitializeComponent();
        }

        int t = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = t.ToString();
            t--;
            if (t == -1)
            {
                timer1.Enabled = false;
                label1.Text = "Hết giờ";
                button1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
