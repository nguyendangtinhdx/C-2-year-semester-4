using QuanLyBanSach.DAO;
using QuanLyBanSach.DTO;
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
    public partial class QuanLyBanSach123 : Form
    {
        BindingSource listSach = new BindingSource();
        private accountDTO loginacc;

        public accountDTO Loginacc
        {
            get
            {
                return loginacc;
            }

            set
            {
                loginacc = value;
            }
        }

        public QuanLyBanSach123(accountDTO acc)
        {
            InitializeComponent();
            this.Loginacc = acc;
            dtgvsearch.DataSource = listSach;
            LoadSach();
            LoadLoaiSach();
            AddSachBinding();
            admin();
            ShowName();
            testbill();
            hienthihoadon();
        }
        void testbill()
        {
            string query = "SELECT MaNhanVien FROM NhanVien WHERE TenDangNhap = N'" + lbtennhanvien.Text + "'";
            lbmanhanvien.Text = DataProvider.Instance.ExecuteScalar(query).ToString();
        }
        void admin()
        {
            AdminToolStripMenuItem.Enabled = Loginacc.Quyen;
        }
        void ShowName()
        {
            lbtennhanvien.Text = Loginacc.TenDangNhap;
        }
        void hienthihoadon()
        {
            lvhoadon.Items.Clear();
            List<MuaBanSach> listhoadon = MuaBanSachDAO.Instance.getList();
            int tongtien = 0;
            foreach (MuaBanSach item in listhoadon)
            {
                ListViewItem lvitem = new ListViewItem(item.MaSach.ToString());
                lvitem.SubItems.Add(item.TenSach.ToString());
                lvitem.SubItems.Add(item.Gia.ToString());
                lvitem.SubItems.Add(item.SoLuong.ToString());
                tongtien += item.ThanhTien;
                lvhoadon.Items.Add(lvitem);
            }
        }
        void LoadSach()
        {
            string query = "SELECT MaSach AS[Mã Sách],tensach AS[Tên Sách], loai.tenloai as [Loại Sách], tacgia AS[Tác Giả], soluong AS[Số Lượng], gia AS[Giá], sotap AS[Số Tập] FROM sach INNER JOIN loai ON sach.maloai = loai.maloai";
            listSach.DataSource = DataProvider.Instance.ExecuteQuery(query);
            //listSach.DataSource = SachDAO.Instance.GetListSach();
        }
        void TimKiemSach(string tenSach, string loaiSach, string tacGia, int giamin, int giamax)
        {
            string query = string.Format("SELECT MaSach AS [Mã Sách], tensach AS [Tên Sách], loai.tenloai as [Loại Sách], tacgia AS [Tác Giả], soluong AS [Số Lượng], gia AS [Giá], sotap AS [Số Tập] FROM sach INNER JOIN loai ON sach.maloai = loai.maloai WHERE tensach like N'%{0}%' AND tenloai like N'%{1}%' AND TacGia like N'%{2}%' AND ({3} <= gia) AND (gia <= {4})", tenSach, loaiSach, tacGia, giamin, giamax);
            listSach.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void LoadLoaiSach()
        {
            List<LoaiSachDTO> listloaisach = LoaiSach.Instance.GetLoaiSach();
            cbSLoaiSach.DataSource = listloaisach;
            cbSLoaiSach.DisplayMember = "tenloai";
            cbLoaiSach.DataSource = listloaisach;
            cbLoaiSach.DisplayMember = "tenloai";
        }
        void AddSachBinding()
        {
            txtMaSach.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Mã Sách", true, DataSourceUpdateMode.Never));
            txtTenSach.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Tên Sách", true, DataSourceUpdateMode.Never));
            cbLoaiSach.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Loại Sách", true, DataSourceUpdateMode.Never));
            txtTacGia.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Tác Giả", true, DataSourceUpdateMode.Never));
            nudsoluong.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Số Lượng", true, DataSourceUpdateMode.Never));
            nudgia.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Giá", true, DataSourceUpdateMode.Never));
            nudsotap.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Số Tập", true, DataSourceUpdateMode.Never));
            txttensachmua.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Tên Sách", true, DataSourceUpdateMode.Never));
            //txtGiaMua.DataBindings.Add(new Binding("Text", dtgvsearch.DataSource, "Giá", true, DataSourceUpdateMode.Never));
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tensach = txtTenSach.Text;
            int loaisach = (cbLoaiSach.SelectedItem as LoaiSachDTO).MaLoai;
            string tacgia = txtTacGia.Text;
            int gia = (int)nudgia.Value;
            int soluong = (int)nudsoluong.Value;
            int sotap = (int)nudsotap.Value;
            if (SachDAO.Instance.ThemSach(tensach,loaisach,tacgia,soluong,gia,sotap))
            {
                MessageBox.Show("Thêm Sách Thành Công !!!");
                LoadSach();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm, Thêm Thất Bại !!!");
            }
        }
        

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fl = new Form1();
            this.Close();
        }

        private void QuanLyBanSach_Load(object sender, EventArgs e)
        {

        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassWord f = new ChangePassWord();
            f.ShowDialog();
        }

        private void QuanLyBanSach_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TimKiemSach(txtSTenSach.Text, cbSLoaiSach.Text,txtSTacGia.Text, Convert.ToInt32(GiaSMin.Value), Convert.ToInt32(GiaSMax.Value));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int masach = Convert.ToInt32(txtMaSach.Text);
            string tensach = txtTenSach.Text;
            int loaisach = (cbLoaiSach.SelectedItem as LoaiSachDTO).MaLoai;
            string tacgia = txtTacGia.Text;
            int gia = (int)nudgia.Value;
            int soluong = (int)nudsoluong.Value;
            int sotap = (int)nudsotap.Value;
            if (SachDAO.Instance.SuaSach(masach,tensach,loaisach,tacgia,gia,soluong,sotap))
            {
                MessageBox.Show("Sửa Sách Thành Công !!!");
                LoadSach();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa, Sửa Thất Bại !!!");
            }
        }

        private void btnShowdata_Click(object sender, EventArgs e)
        {
            LoadSach();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int masach = Convert.ToInt32(txtMaSach.Text);
            if (SachDAO.Instance.XoaSach(masach))
            {
                MessageBox.Show("Xóa Sách Thành Công !!!");
                LoadSach();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa, Xóa Thất Bại !!!");
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (nudsoluongmua.Value > nudsoluong.Value)
            {
                MessageBox.Show("Vượt quá số lượng sách hiện có !!!","Thông Báo",MessageBoxButtons.OK);
                nudsoluongmua.Value = nudsoluong.Value;
            }
            if (txtGiaMua.Text != null)
            {
                int s;
                s = (int)nudgia.Value * (int)nudsoluongmua.Value;
                txtGiaMua.Text = s.ToString();
            }
            
        }

        private void txttensachmua_TextChanged(object sender, EventArgs e)
        {
            txtGiaMua.Text = ((int)nudgia.Value * (int)nudsoluongmua.Value).ToString();
            nudsoluongmua.Value = 1;
        }

        private void btnThemBot_Click(object sender, EventArgs e)
        {
            int manhanvien = Convert.ToInt32(lbmanhanvien.Text);
            int masach = Convert.ToInt32(txtMaSach.Text);
            int soluong = (int)nudsoluongmua.Value;
            if (HoaDonDAO.Instance.TestBill() == 0)
            {
                HoaDonDAO.Instance.InsertHoaDon(manhanvien);
                int mahoadon = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT MaHoaDon FROM dbo.hoadon WHERE damua = 0").ToString());
                HoaDonChiTietDAO.Instance.InsertHoaDonChiTiet(masach,mahoadon,soluong);
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK);
            }
            else if (HoaDonDAO.Instance.TestBill() == 1)
            {
                int mahoadon = Convert.ToInt32(DataProvider.Instance.ExecuteScalar("SELECT MaHoaDon FROM dbo.hoadon WHERE damua = 0").ToString());
                HoaDonChiTietDAO.Instance.InsertHoaDonChiTiet(masach, mahoadon, soluong);
                MessageBox.Show("Thêm Thành Công", "Thông Báo", MessageBoxButtons.OK);
            }
            hienthihoadon();
            LoadSach();
        }

        private void AdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FNhanVien f = new FNhanVien();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mahoadon = HoaDonDAO.Instance.getBillMax();
            if (MessageBox.Show("Bạn có chắc chắn hủy số sách đã chọn", "Thong Bao", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (HoaDonDAO.Instance.HuyHoaDon(mahoadon))
                {
                    MessageBox.Show("Hủy thành công !!!");
                    hienthihoadon();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi Hủy, Hủy Thất Bại !!!");
                }
            }
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int mahoadon = HoaDonDAO.Instance.getBillMax();
            if (HoaDonDAO.Instance.TestBill() == 0)
            {
                MessageBox.Show("Chưa có sách !!!", "Thông Báo");
            }
            else
            {
                    if (MessageBox.Show("Bạn muốn in phiếu", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        FInHoaDon f = new FInHoaDon();
                        f.ShowDialog();
                    }
                    HoaDonDAO.Instance.ThanhToan(mahoadon,0);
                    hienthihoadon();
            }
        }

        private void nudgiamgia_ValueChanged(object sender, EventArgs e)
        {
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FThongKe f = new FThongKe();
            f.ShowDialog();
        }
    }
}
