using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanSach
{
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
            LoadNhanVien();
        }
        void LoadNhanVien()
        {
            string query = "SELECT NhanVien.MaNhanVien, NhanVien.hoten, NhanVien.diachi, NhanVien.SoDT, NhanVien.email, DangNhap.TenDangNhap, DangNhap.MatKhau, DangNhap.Quyen FROM NhanVien FULL OUTER JOIN DangNhap ON NhanVien.TenDangNhap = DangNhap.TenDangNhap";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
