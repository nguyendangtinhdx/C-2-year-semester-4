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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }
        public static List<VHienThiHoaDon> ds = new List<VHienThiHoaDon>();
        public static string tenban, maban;//Lưu lại mã bàn, tên bàn 
        public static string tongtienbangchu = "";
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            lbTongTien.Text = ReadNumber.ByWords(decimal.Parse(txtTongTien.Text));
            tongtienbangchu = lbTongTien.Text;
        }
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            //Buộc dữ liệu vào các ListBox
            lbBan.DataSource = CauHinh.db.Bans;
            lbBan.DisplayMember = "TenBan";
            lbBan.ValueMember = "MaBan";

            cbbChuyenBan.DataSource = CauHinh.db.Bans;
            cbbChuyenBan.DisplayMember = "TenBan";
            cbbChuyenBan.ValueMember = "MaBan";

            //Buộc dữ liệu vào các ComboBox 
            cmbTenHang.DataSource = CauHinh.db.Hangs;
            cmbTenHang.DisplayMember = "TenHang";
            cmbTenHang.ValueMember = "MaHang";
            cmbTenHang.Text = "";
            //Buộc dữ liệu vào các TextBox 
            txtGia.DataBindings.Add("Text", CauHinh.db.Hangs, "Gia");
            txtSoHangTrongKho.DataBindings.Add("Text", CauHinh.db.Hangs, "SoLuong");
            //Hiển thi thông tin của manv
            txtNhanVien.Text = CauHinh.manv;
            //Ngày bán là ngày hiện tại 
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            //dtpkNgayBan.Value = DateTime.Now;
           
        }
        void HienThiHoaDon()
        {
            //Lấy về thông tin của hóa đơn của bàn vừa chọn trên LstBan             
            var q = CauHinh.db.VHienThiHoaDons.Where(p => p.MaBan == lbBan.SelectedValue.ToString());            
            if (q.Count() != 0)//Tính tổng tiền của hóa đơn              
                txtTongTien.Text = q.Sum(p => p.ThanhTien).ToString();             
            dataGridView1.DataSource = q; //Hiển thị hóa đơn ra lưới 
            ds = q.ToList();
        }
        private void cmbTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mahang = cmbTenHang.SelectedValue.ToString();
            int d = CauHinh.db.Hangs.Where(p => p.MaHang == mahang && p.DonViTinh.ToUpper() != "LY" && p.SoLuong == 0).Count();
            if (d != 0)
                MessageBox.Show("Hết hàng");
            return;
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            //Lấy về thông tin của hàng có mã hàng = mã hàng vừa chọn trên CmbHang 
            Hang h = CauHinh.db.Hangs.Single(p => p.MaHang == cmbTenHang.SelectedValue.ToString());
            if (txtSoLuongMua.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng mua");
                return;
            }
            //Nếu đơn vị tính = Ly và số luợng trong kho <> 0 
            if (h.DonViTinh.ToUpper() != "LY" && h.SoLuong != 0)
            {
                //Giảm số lượng 
                h.SoLuong = h.SoLuong - int.Parse(txtSoLuongMua.Text);
                CauHinh.db.SubmitChanges();
            }
            //Nếu bàn này chưa lập hóa đơn thì tạo ra 1 hóa đơn 
            if (CauHinh.db.HoaDons.Where(p => p.MaBan == lbBan.SelectedValue.ToString() && p.DaTraTien == false).Count() == 0)
            {
                 //Lưu cac hang vua ban vào bảng HoaDon 
                long MaxSoHD = 1;
                if (CauHinh.db.HoaDons.Count() != 0)
                {
                    MaxSoHD = CauHinh.db.HoaDons.Max(p => p.MaHD);
                    MaxSoHD += 1;
                }
                HoaDon hd = new HoaDon();
                hd.MaHD = MaxSoHD;
                hd.MaNv = txtNhanVien.Text;
                hd.NgayBan = DateTime.Now;
                hd.MaBan = lbBan.SelectedValue.ToString();
                hd.DaTraTien = false;
                CauHinh.db.HoaDons.InsertOnSubmit(hd);
                CauHinh.db.SubmitChanges();
            }
            //Tao chi tiet hoa don             
            //Tao ra MaCtHd 
            long MaxSoCTHD = 1;
            if (CauHinh.db.ChiTietHoaDons.Count() != 0)
            {
                MaxSoCTHD = CauHinh.db.ChiTietHoaDons.Max(p => p.MaCtHd);
                MaxSoCTHD += 1;
            }
            //Lay so hoa don cua bang hoa don 
            long shd = CauHinh.db.HoaDons.Single(p => p.MaBan == lbBan.SelectedValue.ToString() && p.DaTraTien == false).MaHD;
            ChiTietHoaDon cthd = new ChiTietHoaDon();
            cthd.MaCtHd = MaxSoCTHD;
            cthd.MaHang = cmbTenHang.SelectedValue.ToString();
            cthd.MaHD = shd;
            cthd.SoLuongMua = int.Parse(txtSoLuongMua.Text);
            cthd.ThanhTien = cthd.SoLuongMua * long.Parse(txtGia.Text);
            CauHinh.db.ChiTietHoaDons.InsertOnSubmit(cthd);
            CauHinh.db.SubmitChanges();
            HienThiHoaDon();
        }

        private void lbBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenban = lbBan.Text; //Lưu lại mã bàn và tên bà vừa chọn 
            maban = lbBan.SelectedValue.ToString();
            HienThiHoaDon();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            frmInHoaDon f = new frmInHoaDon();
            f.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CauHinh.db.ChiTietHoaDons.Where(p => p.MaCtHd == SoCTHD).Count() == 0)
            {
                MessageBox.Show("Bạn cần chọn mặt hàng cần xóa trên bảng");
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa hay không ?","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    ChiTietHoaDon cthd = CauHinh.db.ChiTietHoaDons.Single(p => p.MaCtHd == SoCTHD);
                    CauHinh.db.ChiTietHoaDons.DeleteOnSubmit(cthd);
                    CauHinh.db.SubmitChanges();
                    HienThiHoaDon();
                }
            }
        }
        long SoCTHD = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // lấy mã chi tiết hóa đơn cần xoá
            SoCTHD = long.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }


        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán hóa đơn không ?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (BanChuaThanhToan hd in CauHinh.db.BanChuaThanhToans.Where(p => p.MaBan == lbBan.SelectedValue.ToString()))
                    hd.DaTraTien = true;
                CauHinh.db.SubmitChanges();
            }
            HienThiHoaDon();
        }
        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
           
        }

    }
}
