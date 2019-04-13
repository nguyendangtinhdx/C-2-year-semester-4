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
    public partial class FThongKe : Form
    {
        public FThongKe()
        {
            InitializeComponent();
        }

        private void FThongKe_Load(object sender, EventArgs e)
        {
            string query = "SELECT hoadon.MaHoaDon AS [Mã Cho Mượn], NhanVien.hoten AS [Nhân Viên Cho Mượn], hoadon.NgayBan AS [Ngày Giờ Cho Mượn] FROM hoadon INNER JOIN NhanVien ON hoadon.MaNhanVien = NhanVien.MaNhanVien";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
