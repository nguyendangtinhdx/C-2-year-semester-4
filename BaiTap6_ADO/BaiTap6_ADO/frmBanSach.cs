using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTap6_ADO.BO;
using BaiTap6_ADO.Model;
namespace BaiTap6_ADO
{
    public partial class frmBanSach : Form
    {
        public frmBanSach()
        {
            InitializeComponent();
        }
        LoaiBo loai = new LoaiBo();
        SachBo sach = new SachBo();
        HoaDonBanSachBo hoadonbansach = new HoaDonBanSachBo();
        HoaDonBo hoadon = new HoaDonBo();
        ChiTietHoaDonBo cthd = new ChiTietHoaDonBo();
        public static List<HoaDonBanSachBean> list;
        public static List<HoaDonBean> ds;
        public static List<ChiTietHoaDonBean> ds2;
        public static List<SachBean> dsSach;
        private long MaxHoaDon = 0;
        private void frmBanSach_Load(object sender, EventArgs e)
        {
            lbSach.DataSource = loai.getLoai();
            lbSach.DisplayMember = "tenloai";
            lbSach.ValueMember = "maloai";

            cbbTenSach.DataSource = sach.getSach();
            cbbTenSach.DisplayMember = "tensach";
            cbbTenSach.ValueMember = "masach";

            txtNhanVien.Text = frmDangNhap.tenDangNhap;

            dsSach = sach.getSach();

            LoadHoaDon();
            HienThiTongTien();

            MaxHoaDon = hoadon.getHonDonMax();
           
        }
        void LoadHoaDon()
        {
            list = hoadonbansach.getHoaDonBanSach();
            dataGridView1.DataSource = list;
        }
        void HienThiTongTien()
        {
            txtTongTien.Text = hoadonbansach.getTongTien().ToString();
        }
        private void lbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLoai = lbSach.SelectedValue.ToString();
            cbbTenSach.DataSource = sach.getSachByLoai(maLoai);
            cbbTenSach.DisplayMember = "tensach";
            cbbTenSach.ValueMember = "masach";
        }
        void LoadSoLuong()
        {
            string maSach = cbbTenSach.SelectedValue.ToString();
            List<SachBean> list = sach.getSachByMaSach(maSach);
            foreach (SachBean s in list)
            {
                txtTacGia.Text = s.TacGia;
                txtSoLuongTrongKho.Text = s.SoLuong.ToString();
                txtGia.Text = s.Gia.ToString();
            }
        }
        private void cbbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSoLuong();
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
                string maSach = cbbTenSach.SelectedValue.ToString();
                if (MaxHoaDon == hoadon.getHonDonMax())
                {
                    hoadon.themHoaDon(ds,long.Parse(txtNhanVien.Text), DateTime.Now);
                }
                cthd.themChiTietHoaDon(ds2, maSach, long.Parse(txtSoLuongMua.Text), long.Parse(txtGia.Text));
                sach.suaSoLuong(dsSach,maSach,sltk-slm);
                MessageBox.Show("Bán thành công");
            }
            LoadSoLuong();
            LoadHoaDon();
            HienThiTongTien();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn thanh toán hay không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dl == DialogResult.Yes)
            {
                DialogResult dl2 = MessageBox.Show("Bạn có muốn in hóa đơn", "Thông báo", MessageBoxButtons.YesNo);
                if (dl2 == DialogResult.Yes)
                {
                    frmInHoaDon f = new frmInHoaDon();
                    f.ShowDialog();
                   
                }
                hoadon.thanhToanHoaDon(ds);
                LoadHoaDon();
                HienThiTongTien();
            }
        }

        public static string tongtienbangchu = "";
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            lbTongTien.Text = ReadNumber.ByWords(decimal.Parse(txtTongTien.Text));
            tongtienbangchu = lbTongTien.Text;
        }

    }
}
