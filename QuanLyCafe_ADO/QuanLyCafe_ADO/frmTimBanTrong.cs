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
    public partial class frmTimBanTrong : Form
    {
        public frmTimBanTrong()
        {
            InitializeComponent();
        }
        public static List<BanTrongBEAN> ds = new List<BanTrongBEAN>();
        BanTrongBO ban = new BanTrongBO();
        private void frmTimBanTrong_Load(object sender, EventArgs e)
        {
            ds = ban.getListBanTrong();
            dtgvBanTrong.DataSource = ds;
        }
    }
}
