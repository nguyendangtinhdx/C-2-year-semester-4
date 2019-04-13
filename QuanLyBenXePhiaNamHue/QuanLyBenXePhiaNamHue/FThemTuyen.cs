using QuanLyBenXePhiaNamHue.DAO;
using QuanLyBenXePhiaNamHue.DTO;
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
    public partial class FThemTuyen : Form
    {
        public FThemTuyen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbTuyenXe.Text == "" || cbbXe.Text == "" || txtGiaVe.Text == "")
                {
                    MessageBox.Show("Tuyến Xe, Biển Số Xe, Giá Vé không được để trống!!!", "Thông Báo");
                }
                else
                {
                    string tuyenxe = cbbTuyenXe.Text;
                    string biensoxe = cbbXe.Text;
                    DateTime ngayxuatphat = dateTimePicker1.Value;
                    string tentaixe = txtTenTaiXe.Text;
                    int giave = int.Parse(txtGiaVe.Text);
                    if (ngayxuatphat <= DateTime.Now)
                    {
                        MessageBox.Show("Vui lòng nhập thời gian xuất phát!!!", "Thông Báo");
                    }
                    else
                    {
                        if (TuyenXeDAO.Instance.themTuyenXe(biensoxe, tuyenxe, ngayxuatphat, tentaixe, giave))
                        {
                            MessageBox.Show("Thêm Tuyến Xe thành công!!!", "Thông Báo");
                        }
                        else
                        {
                            MessageBox.Show("Thêm Tuyến Xe thất bại!!!", "Thông Báo");
                        }
                    }                    
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Tuyến Xe thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }            
        }

        private void FThemTuyen_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            List<XeDTO> listxe = XeDAO.Instance.getListXe();
            cbbXe.DataSource = listxe;
            cbbXe.DisplayMember = "BienSoXe";
            cbbXe.ValueMember = "BienSoXe";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
