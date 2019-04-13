using QuanLyBanSach.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class FInHoaDon : Form
    {
        public FInHoaDon()
        {
            InitializeComponent();
        }

        private void FInHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyBanSachDataSet.USP_InHoaDon' table. You can move, or remove it, as needed.
            this.USP_InHoaDonTableAdapter.Fill(this.QuanLyBanSachDataSet.USP_InHoaDon, HoaDonDAO.Instance.getBillMax());

            this.reportViewer1.RefreshReport();
        }
    }
}
