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
    public partial class frmChiTietHoaDon : Form
    {
        public static List<ChiTietHoaDonBEAN> ds, tam = new List<ChiTietHoaDonBEAN>();
        ChiTietHoaDonBO chiTietHoaDon = new ChiTietHoaDonBO();
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            ds = chiTietHoaDon.getListChiTietHoaDon();
            dtgvChiTietHoaDon.DataSource = ds;
        }

        private void dtgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaChiTietHoaDon.Text = dtgvChiTietHoaDon[0, d].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaChiTietHoaDon.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chi tiết hóa đơn để xóa");
                return;
            }
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết hóa đơn hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = chiTietHoaDon.xoaChiTietHoaDon(ds, long.Parse(txtMaChiTietHoaDon.Text));
                if (tam == null)
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thất bại");
                    return;
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công");
                }
                ds = chiTietHoaDon.getListChiTietHoaDon();
                dtgvChiTietHoaDon.DataSource = ds;
            }
        }
    }
}
