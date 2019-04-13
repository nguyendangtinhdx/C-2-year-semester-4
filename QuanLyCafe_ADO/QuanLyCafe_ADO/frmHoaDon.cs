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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }
        public static List<HoaDonBEAN> ds, tam = new List<HoaDonBEAN>();
        HoaDonBO hoaDon = new HoaDonBO();
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            ds = hoaDon.getListHoaDon();
            dtgvHoaDon.DataSource = ds;
        }

        private void dtgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int d = e.RowIndex;
            txtMaHoaDon.Text = dtgvHoaDon[0, d].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "")
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa");
                return;
            }
            DialogResult t = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (t == DialogResult.Yes)
            {
                tam = hoaDon.xoaHoaDon(ds, long.Parse(txtMaHoaDon.Text));
                if (tam == null)
                {
                    MessageBox.Show("Xóa hóa đơn thất bại");
                    return;
                }
                else
                {
                    ds = tam;
                    MessageBox.Show("Xóa hóa đơn thành công");
                }
                ds = hoaDon.getListHoaDon();
                dtgvHoaDon.DataSource = ds;
            }
        }
    }
}
