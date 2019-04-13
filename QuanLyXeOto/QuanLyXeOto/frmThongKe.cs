using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyXeOto.bo;
namespace QuanLyXeOto
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
        }
        ThongKeBO tk = new ThongKeBO();
        private void frmThongKe_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tk.getListThongKe(Form1.m);
        }
    }
}
