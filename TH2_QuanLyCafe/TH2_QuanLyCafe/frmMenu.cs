using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH2_QuanLyCafe
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void MnNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            f.ShowDialog();
        }

        private void MnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MnBan_Click(object sender, EventArgs e)
        {
            frmBan f = new frmBan();
            f.ShowDialog();
        }

        private void MnHang_Click(object sender, EventArgs e)
        {
            frmHang f = new frmHang();
            f.ShowDialog();
        }

        private void MnTimBanChuaThanhToan_Click(object sender, EventArgs e)
        {
            frmTimBanChuaThanhToan f = new frmTimBanChuaThanhToan();
            f.ShowDialog();
        }


        private void MnTimKiemBanTrong_Click(object sender, EventArgs e)
        {
            frmTimKiemBanTrong f = new frmTimKiemBanTrong();
            f.ShowDialog();
        }

        private void MnThongKeTheoNgay_Click(object sender, EventArgs e)
        {
            frmThongKeTheoNgay f = new frmThongKeTheoNgay();
            f.ShowDialog();
        }

        private void MnThongKeTheoThang_Click(object sender, EventArgs e)
        {
            frmThongKeTheoThang f = new frmThongKeTheoThang();
            f.ShowDialog();
        }

        private void MnThongKeTheoNam_Click(object sender, EventArgs e)
        {
            frmThongKeTheoNam f = new frmThongKeTheoNam();
            f.ShowDialog();
        }

        private void MnHangTonKho_Click(object sender, EventArgs e)
        {
            frmHangTonKho f = new frmHangTonKho();
            f.ShowDialog();
        }

        private void MnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHang f = new frmBanHang();
            f.ShowDialog();
        }

        private void MnHuyDangNhap_Click(object sender, EventArgs e)
        {
            frmDangKy f = new frmDangKy();
            f.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            var q = from p in CauHinh.db.NHanViens
                    where p.Manv == frmDangNhap.quyen && p.Quyen == "admin"
                    select p;
            if (q.Count() != 0)
            {
                MnDangKy.Enabled = true;
                MnNhanVien.Enabled = true;
            }
            else
            {
                MnDangKy.Enabled = false;
                MnNhanVien.Enabled = false;
            }

        }
    }
}
