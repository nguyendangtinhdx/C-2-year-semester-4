using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe_ADO.bean;
using QuanLyCafe_ADO.bo;
namespace QuanLyCafe_ADO
{
    public partial class frmTimBanChuaThanhToan : Form
    {
        public frmTimBanChuaThanhToan()
        {
            InitializeComponent();
        }
        public static List<BanChuaThanhToanBEAN> ds = new List<BanChuaThanhToanBEAN>();
        BanChuaThanhToanBO ban = new BanChuaThanhToanBO();
        private void frmTimBanChuaThanhToan_Load(object sender, EventArgs e)
        {
            ds = ban.getListBanChuaThanhToan();
            dtgvBanChuaThanhToan.DataSource = ds;
        }
    }
}
