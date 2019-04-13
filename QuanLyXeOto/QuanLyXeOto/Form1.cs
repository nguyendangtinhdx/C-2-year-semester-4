using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyXeOto.dao;
using QuanLyXeOto.bean;
using QuanLyXeOto.bo;
namespace QuanLyXeOto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static List<HangBEAN> dsHang = new List<HangBEAN>();
        public static List<OtoBEAN> dsOto = new List<OtoBEAN>();
        public static List<HoaDonDEAN> dsHoaDon,tam = new List<HoaDonDEAN>();
        HangBO hang = new HangBO();
        OtoBO oto = new OtoBO();
        HoaDoBO hoaDon = new HoaDoBO();
        ThongKeBO tk = new ThongKeBO();
        DungChung dc = new DungChung();
        private void Form1_Load(object sender, EventArgs e)
        {
            dc.KetNoi();
            lbHang.DataSource = hang.getListHang();
            lbHang.DisplayMember = "TenHang";
            lbHang.ValueMember = "MaHang";

            cbbTenXe.DataSource = oto.getListOto();
            cbbTenXe.DisplayMember = "TenXe";
            cbbTenXe.ValueMember = "MaXe";
            dsHoaDon = hoaDon.getListHoaDon();

            dataGridView1.DataSource  = dsHoaDon;

            LoadXe();

        }
        void LoadXe()
        {
            string maXe = cbbTenXe.SelectedValue.ToString();
            List<OtoBEAN> list = oto.getListOtoByMa(maXe);
            foreach (OtoBEAN h in list)
            {
                txtMaXe.Text = h.MaXe.ToString();
                txtSoLuongTrongKho.Text = h.SoLuongTrongKho.ToString();
                txtGia.Text = h.Gia.ToString();
            }
        }
        void LoadXeByMa()
        {
            string maHang = lbHang.SelectedValue.ToString();
            cbbTenXe.DataSource = oto.getListOtoByMaHang(maHang);
            cbbTenXe.DisplayMember = "TenXe";
            cbbTenXe.ValueMember = "MaXe";

        }
        private void lbHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadXeByMa();
        }

        private void cbbTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadXe();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            if (txtSoLuongMua.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng mua");
            }
            else
            {
                long slm = long.Parse(txtSoLuongMua.Text);
                long sltk = long.Parse(txtSoLuongTrongKho.Text);
                long gia = long.Parse(txtGia.Text);
                if (slm == 0)
                {
                    MessageBox.Show("Số lượng mua > 0");
                    return;
                }
                if (sltk == 0)
                {
                    MessageBox.Show("Hết hàng");
                    return;
                }
                if (slm > sltk)
                {
                    MessageBox.Show("Số lượng không đủ bán");
                    return;
                }
                string maXe = cbbTenXe.SelectedValue.ToString();
                if(hoaDon.getMaXeByMaXe(maXe).Equals(maXe))
                {
                    hoaDon.suaSoLuongHoaDonByTrungMaXe(maXe,slm);
                }
                else
                {
                    hoaDon.themHoaDon(dsHoaDon, maXe, slm, gia * slm);
                }

                    dsHoaDon = hoaDon.getListHoaDon();
                    dataGridView1.DataSource = dsHoaDon;

                    oto.suaSoLuong(dsOto, maXe, sltk - slm);
                    LoadXe();

                    long thanhTien = slm * gia;
                    txtThanhTien.Text = thanhTien.ToString();

                MessageBox.Show("Bán thành công");
            }
         
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thanh toán ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DialogResult dr2 = MessageBox.Show("Bạn có muốn in hóa đơn ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dr2 == DialogResult.Yes)
                {
                    frmInHoaDon f = new frmInHoaDon();
                    f.ShowDialog();
                }
                hoaDon.thanhToanHoaDon();
                MessageBox.Show("Thanh toán hóa đơn thành công");
                dsHoaDon = hoaDon.getListHoaDon();

                dataGridView1.DataSource = dsHoaDon;
                LoadXe();
                txtThanhTien.Text = hoaDon.getTongTien().ToString();
            }
        }

        public static string m = "";
        private void lbHang_DoubleClick(object sender, EventArgs e)
        {

            m = lbHang.SelectedValue.ToString();

            frmThongKe f = new frmThongKe();
            f.ShowDialog();
        }

        private void txtSoLuongMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }
    }
}
