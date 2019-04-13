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
    public partial class frmHienThi : Form
    {
        public frmHienThi()
        {
            InitializeComponent();
        }

        dbDataContext db = new dbDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.saches;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = db.saches;
            listBox1.DisplayMember = "HoTen";
            listBox1.ValueMember = "Manv";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.saches;
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "Manv";
        }

        private void frmHienThi_Load(object sender, EventArgs e)
        {

        }
    }
}
