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
    public partial class frmShow : Form
    {
        public frmShow()
        {
            InitializeComponent();
        }

        private void frmShow_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BO.DungChung.db.TestThongKes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            MessageBox.Show(e.Start.Year.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
