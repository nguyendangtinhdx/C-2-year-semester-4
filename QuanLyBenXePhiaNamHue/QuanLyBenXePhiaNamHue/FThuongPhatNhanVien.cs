using QuanLyBenXePhiaNamHue.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenXePhiaNamHue
{
    public partial class FThuongPhatNhanVien : Form
    {
        public FThuongPhatNhanVien()
        {
            InitializeComponent();
        }

        private void FThuongPhatNhanVien_Load(object sender, EventArgs e)
        {
            lbmanhanvientp.Text = NhanVienDAO.manhanvientk;
            lbhotentp.Text = NhanVienDAO.tennhanvientk;
            lbchucvutp.Text = NhanVienDAO.chucvutk;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string hinhthuc = "";
            if (rabtnPhat.Checked)
            {
                hinhthuc = "Bị Phạt";
            }
            else if (rabtnThuong.Checked)
            {
                hinhthuc = "Được Thưởng";
            }
            if (MessageBox.Show("Xác Nhận", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (ThuongPhatDAO.Instance.themNhanVienThuongPhat(lbmanhanvientp.Text,DateTime.Now,hinhthuc,int.Parse(txtSoTien.Text),txtLyDo.Text))
                {
                    MessageBox.Show("Thêm Thành Công!!!", "Thông Báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm Thất Bại!!!", "Thông Báo");
                }
            }
        }
    }
}
