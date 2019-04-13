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
using QuanLyCafe_ADO.tool;
namespace QuanLyCafe_ADO
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnBan_Click(object sender, EventArgs e)
        {
            frmBan f = new frmBan();
            f.ShowDialog();
        }

        private void mnHang_Click(object sender, EventArgs e)
        {
            frmHang f = new frmHang();
            f.ShowDialog();
        }

        private void mnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
        }

        private void bànChưaThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimBanChuaThanhToan f = new frmTimBanChuaThanhToan();
            f.ShowDialog();
        }

        private void bànTrốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimBanTrong f = new frmTimBanTrong();
            f.ShowDialog();
        }

        private void theoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeTheoNgay f = new frmThongKeTheoNgay();
            f.ShowDialog();
        }

        private void theoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeTheoThang f = new frmThongKeTheoThang();
            f.ShowDialog();
        }

        private void theoNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeTheoNam f = new frmThongKeTheoNam();
            f.ShowDialog();
        }

        private void đăngKýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon f = new frmHoaDon();
            f.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChiTietHoaDon f = new frmChiTietHoaDon();
            f.ShowDialog();
        }
        public static List<HoaDonBanHangBEAN> ds = new List<HoaDonBanHangBEAN>();
        public static List<HoaDonBEAN> dsHoaDon = new List<HoaDonBEAN>();
        public static List<ChiTietHoaDonBEAN> dsChiTietHoaDon = new List<ChiTietHoaDonBEAN>();
        public static List<BanBEAN> dsBan = new List<BanBEAN>();
        public static List<HangBEAN> dsHang = new List<HangBEAN>();
        BanBO ban = new BanBO();
        HangBO hang = new HangBO();
        HoaDonBO hoaDon = new HoaDonBO();
        NhanVienBO nhanVien = new NhanVienBO();
        ChiTietHoaDonBO chiTietHoaDon = new ChiTietHoaDonBO();
        HoaDonBanHangBO hoaDonBanHang = new HoaDonBanHangBO();
        private long MaxHoaDon = 0;
        private void frmMenu_Load(object sender, EventArgs e)
        {
            txtNgayBan.Text = DateTime.Now.ToString();
            txtNhanVien.Text = frmDangNhap.tenDangNhap;

            if (!nhanVien.checkNhanVien(frmDangNhap.tenDangNhap))
            {
                đăngKýTàiKhoảnToolStripMenuItem.Enabled = false;
                mnNhanVien.Enabled = false;
            }

            lbBan.DataSource = ban.getListBan();
            lbBan.DisplayMember = "TenBan";
            lbBan.ValueMember = "MaBan";

            cbbChuyenBan.DataSource = ban.getListBan();
            cbbChuyenBan.DisplayMember = "TenBan";
            cbbChuyenBan.ValueMember = "MaBan";

            cbbTenHang.DataSource = hang.getListHang();
            cbbTenHang.DisplayMember = "TenHang";
            cbbTenHang.ValueMember = "MaHang";

            LoadHang();
            LoadHoaDonBanHang();
            LoadTongTien();
            //MaxHoaDon = hoaDon.getHonDonMax();
        }
        void LoadHang()
        {
            string maHang = cbbTenHang.SelectedValue.ToString();
            List<HangBEAN> list = hang.getListHangByMaHang(maHang);
            foreach (HangBEAN h in list)
            {
                txtGia.Text = h.Gia.ToString();
                txtSoLuongTrongKho.Text = h.SoLuong.ToString();
            }
        }
        private void cbbTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHang();
        }
        void LoadHoaDonBanHang()
        {
            string maBan = lbBan.SelectedValue.ToString();
            ds = hoaDonBanHang.getListHoaDonBanHang(maBan);
            dtgvBanHang.DataSource = ds;
        }
        private void lbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadHoaDonBanHang();
            LoadTongTien();
        }
        void LoadTongTien()
        {
            string maBan = lbBan.SelectedValue.ToString();
            txtTongTien.Text = hoaDonBanHang.getTongTien(maBan).ToString();
        }
        public static string tongtienbangchu = "";
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            lbTongTien.Text = ReadNumber.ByWords(decimal.Parse(txtTongTien.Text)) + "đồng";
            tongtienbangchu = lbTongTien.Text;
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
                string maBan = lbBan.SelectedValue.ToString();
                string maHang = cbbTenHang.SelectedValue.ToString();
                long maHoaDon = hoaDon.getMaHoaDonByMaBan(maBan); // thêm chi tiết hóa đơn khi bàn đã có hóa đơn

                if (!hoaDon.getMaBanByMaBan(maBan).Equals(maBan))
                {
                    hoaDon.themHoaDon(dsHoaDon, txtNhanVien.Text, maBan);
                    chiTietHoaDon.themChiTietHoaDon(dsChiTietHoaDon, maHang, long.Parse(txtSoLuongMua.Text), gia * slm);
                }
                else
                {
                    if (chiTietHoaDon.getMaHangByMaHang(maHang,maHoaDon).Equals(maHang))
                    {
                        chiTietHoaDon.suaSoLuongChiTietHoaDonByTrungMaHang(dsChiTietHoaDon, maHang, long.Parse(txtSoLuongMua.Text), maHoaDon);
                    }
                    else
                    {
                        chiTietHoaDon.themChiTietHoaDonKhiTonTaiMaHoaDon(dsChiTietHoaDon, maHang, long.Parse(txtSoLuongMua.Text), gia * slm, maHoaDon);
                    }
                }

                hang.suaSoLuong(dsHang, maHang, sltk - slm);
                MessageBox.Show("Bán thành công");
            }
            LoadHoaDonBanHang();
            LoadHang();
            LoadTongTien();
        }

        private void txtSoLuongMua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maBan = lbBan.SelectedValue.ToString();
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn hàng ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                hoaDon.xoaHoaDonByMaBan(maBan);
                MessageBox.Show("Xóa đơn hàng thành công");
                LoadHoaDonBanHang();
                LoadTongTien();
            }
        }
        public static string tenBan = "";
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maBan = lbBan.SelectedValue.ToString();
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn thanh toán ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DialogResult dr2 = MessageBox.Show("Bạn có muốn in hóa đơn ?", "Thông báo", MessageBoxButtons.YesNo);
                if (dr2 == DialogResult.Yes)
                {
                    tenBan = ban.getTenBan(maBan);
                    //frmInHoaDonBanHang f = new frmInHoaDonBanHang();
                    frmInHoaDonBanHangCrystal f = new frmInHoaDonBanHangCrystal();
                    f.ShowDialog();
                }
                hoaDon.thanhToanHoaDon(dsHoaDon, maBan);
                MessageBox.Show("Thanh toán hóa đơn thành công");
                LoadHoaDonBanHang();
                LoadTongTien();
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            string maBanCu = lbBan.SelectedValue.ToString();
            string maBanMoi = cbbChuyenBan.SelectedValue.ToString();
            DialogResult dr = MessageBox.Show(string.Format("Bạn có chắc chắn muốn chuyển từ {0} sang {1}", ban.getTenBan(maBanCu), ban.getTenBan(maBanMoi)), "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                hoaDon.chuyenBan(dsHoaDon,maBanCu,maBanMoi);
                MessageBox.Show("Chuyển bàn thành công");
                LoadHoaDonBanHang();
                LoadTongTien();
            }
        }
    }
}
