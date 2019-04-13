using QuanLyBenXePhiaNamHue.DAO;
using QuanLyBenXePhiaNamHue.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenXePhiaNamHue
{
    public partial class FMenu : Form
    {
        public FMenu()
        {
            InitializeComponent();
            LoadTuyenXe();
        }
        public static int getmavemax;
        Timer t = new Timer();
        private void FMenu_Load(object sender, EventArgs e)
        {
            loadthongkethuongphatnhanvien();
            loadthongketuyenxe();
            loadlistxebaotri();
            loadthongkeve();
            dtpkve1.Format = DateTimePickerFormat.Custom;
            dtpkve1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpkve2.Format = DateTimePickerFormat.Custom;
            dtpkve2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpktuyenxe1.Format = DateTimePickerFormat.Custom;
            dtpktuyenxe1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpktuyenxe2.Format = DateTimePickerFormat.Custom;
            dtpktuyenxe2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpkthuongphat1.Format = DateTimePickerFormat.Custom;
            dtpkthuongphat2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            label1.Text = "Chức Vụ: "+DataProvider.TypeLoginshow;
            label2.Text = "Tên Nhân Viên: " + DataProvider.tennhanvienshow;
            if (DataProvider.TypeLoginshow=="Bán Vé")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
            }
            else if (DataProvider.TypeLoginshow == "Quản Lý")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage7);
            }
            else if (DataProvider.TypeLoginshow == "Thống Kê")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage7);
            }
            else if (DataProvider.TypeLoginshow == "Xe")
            {
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage7);
            }
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
            dtgvXe.DataSource = XeDAO.Instance.getListXe();
            loadlistvedaban();
            loadlistnhanvien(txttimnhanvien.Text);
        }
        void loadthongkethuongphatnhanvien()
        {
            string query = "SELECT ThuongPhat.MaThuongPhat AS [Mã Thưởng Phạt], ThuongPhat.MaNhanVien AS [Mã Nhân Viên], NhanVien.HoTen AS [Họ Tên], NhanVien.ChucVu AS [Chức Vụ], NhanVien.GioiTinh AS [Giới Tính], NhanVien.SoDienThoai AS [Số Điện Thoại], ThuongPhat.ThoiGianThuongPhat AS[Thời Gian], ThuongPhat.HinhThuc AS[Hình Thức], ThuongPhat.SoTien AS[Số Tiền], ThuongPhat.LyDo AS[Lý Do] FROM NhanVien INNER JOIN ThuongPhat ON NhanVien.MaNhanVien = ThuongPhat.MaNhanVien";
            dtgvthuongphat.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void loadthongketuyenxe()
        {
            string query = "SELECT TuyenXe.MaTuyenXe AS [Mã Tuyến Xe], TuyenXe.BienSoXe AS [Biển Số Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.TenTaiXe AS [Tên Tài Xế], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.ThoiGianXuatPhat AS[Thời Gian Chạy], Xe.SoChoNgoi AS[Số Chổ Ngồi], Ve.Gia AS Giá, SUM(Ve.SoLuong) AS[Số Lượng Đã Bán], SUM(Ve.SoLuong)*ve.Gia AS [Tổng Tiền] FROM TuyenXe INNER JOIN Ve ON TuyenXe.MaTuyenXe = Ve.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe GROUP BY TuyenXe.MaTuyenXe, TuyenXe.BienSoXe, TuyenXe.TuyenXe, Xe.MauXe, Xe.LoaiXe, Xe.SoChoNgoi, TuyenXe.ThoiGianXuatPhat, TuyenXe.TenTaiXe, Ve.Gia";
            dtgvThongKeTuyenXe.DataSource = DataProvider.Instance.ExecuteQuery(query);
            int sum = 0;
            for (int i = 0; i < dtgvThongKeTuyenXe.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dtgvThongKeTuyenXe.Rows[i].Cells[10].Value);
            }
            txtTKxeTongCong.Text = sum.ToString();            
        }
        void loadthongkeve()
        {
            string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], TuyenXe.BienSoXe AS [Biển Số Xe], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], Ve.ThoiGianBanVe AS [Thời Gian Bán Vé], Ve.Gia AS Giá FROM Ve INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN NhanVien ON Ve.MaNhanVien = NhanVien.MaNhanVien INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe";
            dtgvthongkeVe.DataSource = DataProvider.Instance.ExecuteQuery(query);
            int sum = 0;
            for (int i = 0; i < dtgvthongkeVe.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dtgvthongkeVe.Rows[i].Cells[8].Value);
            }
            txtTkTongCongGiaVe.Text = sum.ToString();
            lbtongsoluongve.Text = "Tổng Số Lượng Vé: " + dtgvthongkeVe.Rows.Count;
        }
        void loadlistxebaotri()
        {
            string query = "SELECT BienSoXe AS [Biển Số Xe], MauXe AS [Mẫu Xe], LoaiXe AS [Loại Xe], SoChoNgoi AS [Số Chổ Ngồi], TinhTrang AS [Tình Trạng] FROM Xe";// WHERE TinhTrang = N'Tốt'";
            dtgvxetot.DataSource = DataProvider.Instance.ExecuteQuery(query);
            string query1 = "SELECT Xe.BienSoXe AS [Biển Số Xe], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], Xe.SoChoNgoi AS [Số Chổ Ngồi], XeBaoTri.NgayXong AS [Ngày Xong], XeBaoTri.TinhTrang AS [Tình Trạng] FROM Xe LEFT OUTER JOIN XeBaoTri ON Xe.BienSoXe = XeBaoTri.BienSoXe WHERE Xe.TinhTrang = N'Bảo trì' AND XeBaoTri.BaoTri = N'Chưa xong'";
            dtgvxebaotri.DataSource = DataProvider.Instance.ExecuteQuery(query1);
        }
        void loadlistvedaban()
        {
            string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe";
            dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void loadlistnhanvien(string hoten)
        {
            string query = "SELECT NhanVien.MaNhanVien AS [Mã Nhân Viên], NhanVien.HoTen AS [Họ Tên], NhanVien.NgaySinh AS [Ngày Sinh], NhanVien.GioiTinh AS [Giới Tính], NhanVien.CMND AS [Số CMND], NhanVien.ChucVu AS [Chức Vụ], NhanVien.DiaChi AS [Địa Chỉ], NhanVien.SoDienThoai AS [Số Điện Thoại], NhanVien.HeSoLuong AS [Hệ Số Lương], Account.Username AS [Tên Đăng Nhập], Account.Password AS [Mật Khẩu], Account.TypeLogin AS Quyền FROM NhanVien LEFT OUTER JOIN Account ON NhanVien.MaNhanVien = Account.MaNhanVien WHERE NhanVien.HoTen LIKE @hoten ";
            dtgvnhanvien.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%' + hoten + '%' });
        }

        private void T_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToShortDateString();
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string time = "";
            if (hh<10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm<10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            lbTime.Text = time;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cbbTenTuyenXe.Text == "Tất Cả")
            {
                List<TuyenXeDTO> listtuyenxe = TuyenXeDAO.Instance.listTuyenXeChuaChay("");
                DateTime d = DateTime.Now;
                foreach (TuyenXeDTO item in listtuyenxe)
                {
                    if (item.ThoiGianXuatPhat < d)
                    {
                        TuyenXeDAO.Instance.chuyenTrangThaiXe(item.MaTuyenXe);
                        LoadTuyenXe();
                    }
                }
                LoadTuyenXe();
            }
            else
            {
                List<TuyenXeDTO> listtuyenxe = TuyenXeDAO.Instance.listTuyenXeChuaChay(cbbTenTuyenXe.Text);
                DateTime d = DateTime.Now;
                foreach (TuyenXeDTO item in listtuyenxe)
                {
                    if (item.ThoiGianXuatPhat < d)
                    {
                        TuyenXeDAO.Instance.chuyenTrangThaiXe(item.MaTuyenXe);
                        LoadTuyenXe();
                    }
                }
                LoadTuyenXe();
            }
            
        }

        void LoadTuyenXe()
        {
            if (cbbTenTuyenXe.Text == "Tất Cả")
            {
                flpTuyenXe.Controls.Clear();
                List<TuyenXeDTO> listtuyenxe = TuyenXeDAO.Instance.listTuyenXeChuaChay("");

                foreach (TuyenXeDTO item in listtuyenxe)
                {
                    List<XeDTO> listxetheotuyen = XeDAO.Instance.listxetheotuyen(item.BienSoXe);
                    foreach (XeDTO item1 in listxetheotuyen)
                    {
                        Button btn = new Button() { Width = 150, Height = 170 };
                        int sochocontrong = VeDAO.Instance.getSoChoConTrong(item.MaTuyenXe);
                        btn.Text = item.TuyenXe + Environment.NewLine + Environment.NewLine + item.BienSoXe + Environment.NewLine + item1.LoaiXe + Environment.NewLine + Environment.NewLine + item.ThoiGianXuatPhat + Environment.NewLine + Environment.NewLine + "So Cho Ngoi: " + sochocontrong + "/" + item1.SoChoNgoi + Environment.NewLine + Environment.NewLine + "Giá Vé: " + item.GiaVe;
                        btn.Click += Btn_Click;
                        btn.Tag = item;
                        btn.BackColor = Color.YellowGreen;
                        if (item1.SoChoNgoi - sochocontrong < 5 && item1.SoChoNgoi - sochocontrong >= 1)
                        {
                            btn.BackColor = Color.Yellow;
                        }
                        else if (item1.SoChoNgoi - sochocontrong == 0)
                        {
                            btn.BackColor = Color.Red;
                        }
                        flpTuyenXe.Controls.Add(btn);
                    }
                }
            }
            else
            {
                flpTuyenXe.Controls.Clear();
                List<TuyenXeDTO> listtuyenxe = TuyenXeDAO.Instance.listTuyenXeChuaChay(cbbTenTuyenXe.Text);

                foreach (TuyenXeDTO item in listtuyenxe)
                {
                    List<XeDTO> listxetheotuyen = XeDAO.Instance.listxetheotuyen(item.BienSoXe);
                    foreach (XeDTO item1 in listxetheotuyen)
                    {
                        Button btn = new Button() { Width = 150, Height = 170 };
                        int sochocontrong = VeDAO.Instance.getSoChoConTrong(item.MaTuyenXe);
                        btn.Text = item.TuyenXe + Environment.NewLine + Environment.NewLine + item.BienSoXe + Environment.NewLine + item1.LoaiXe + Environment.NewLine + Environment.NewLine + item.ThoiGianXuatPhat + Environment.NewLine + Environment.NewLine + "So Cho Ngoi: " + sochocontrong + "/" + item1.SoChoNgoi + Environment.NewLine + Environment.NewLine + "Giá Vé: " + item.GiaVe;
                        btn.Click += Btn_Click;
                        btn.Tag = item;
                        btn.BackColor = Color.YellowGreen;
                        if (item1.SoChoNgoi - sochocontrong < 5 && item1.SoChoNgoi - sochocontrong >= 1)
                        {
                            btn.BackColor = Color.Yellow;
                        }
                        else if (item1.SoChoNgoi - sochocontrong == 0)
                        {
                            btn.BackColor = Color.Red;
                        }
                        flpTuyenXe.Controls.Add(btn);
                    }
                }
            }                        
        }
        void Btn_Click(object sender, EventArgs e)
        {
            string matuyenxe = ((sender as Button).Tag as TuyenXeDTO).MaTuyenXe;
            string tuyenxe = ((sender as Button).Tag as TuyenXeDTO).TuyenXe;
            string biensoxe = ((sender as Button).Tag as TuyenXeDTO).BienSoXe;
            string tentaixe = ((sender as Button).Tag as TuyenXeDTO).TenTaiXe;
            int giave = ((sender as Button).Tag as TuyenXeDTO).GiaVe;
            List<XeDTO> listxetheotuyen = XeDAO.Instance.listxetheotuyen(biensoxe);
            foreach (XeDTO item1 in listxetheotuyen)
            {
                int sochongoi = item1.SoChoNgoi;
                string loaixe = item1.LoaiXe;
                lbloaixe.Text = "Loại Xe: " + loaixe;
                int sochocontrong = VeDAO.Instance.getSoChoConTrong(((sender as Button).Tag as TuyenXeDTO).MaTuyenXe);
                lbsochodangoi.Text = sochocontrong.ToString();
                lbsochomax.Text = sochongoi.ToString();
                //lbSoChoNgoi.Text = "Số Chổ Ngồi: " + VeDAO.Instance.getSoChoConTrong(((sender as Button).Tag as TuyenXeDTO).MaTuyenXe) + "/" + sochongoi;
            }            
            DateTime thoigianchay = ((sender as Button).Tag as TuyenXeDTO).ThoiGianXuatPhat;
            lbMaTuyenXe.Text = "Tuyến Xe: " + tuyenxe;
            lbbiensoxe.Text = "Biển Số Xe: " + biensoxe;
            lbthoigianchay.Text = "Thời Gian: " + thoigianchay;
            lbTenTaiXe.Text = "Tên Tài Xế: " + tentaixe;
            lbGiaVe.Text = giave.ToString();
            nudSoLuong.Value = 1;
            lbmatuyenxe1.Text = matuyenxe;
            txtthanhtien.Text = giave.ToString();
            LoadTuyenXe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FThemTuyen f = new FThemTuyen();
            f.ShowDialog();
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtthanhtien.Text = (int.Parse(lbGiaVe.Text) * nudSoLuong.Value).ToString();

            }
            catch (Exception)
            {
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn hủy tuyến xe này?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (TuyenXeDAO.Instance.huyTuyenXe(lbmatuyenxe1.Text))
                {
                    MessageBox.Show("Hủy Tuyến Xe thành công!!!","Thông Báo");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string matuyenxe = lbmatuyenxe1.Text;
            string manhanvien = DataProvider.manhanvienshow;
            int gia = int.Parse(lbGiaVe.Text);
            int soluong = Convert.ToInt32(nudSoLuong.Value);
            DateTime thoigianbanve = DateTime.Now;
            if (int.Parse(lbsochodangoi.Text) + soluong > int.Parse(lbsochomax.Text))
            {
                MessageBox.Show("Tuyến Xe này đã hết vé hoặc không đủ vé để mua!!! Vui lòng chọn Tuyến Xe khác", "Thông Báo");
            }
            else
            {
                if (MessageBox.Show("Xác nhận mua vé?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (VeDAO.Instance.muaVe(matuyenxe, manhanvien, gia, 1, thoigianbanve))
                    {
                        getmavemax = VeDAO.Instance.getMaVeMax();
                        FInVe f = new FInVe();
                        f.ShowDialog();
                        for (int i = 0; i < soluong - 1; i++)
                        {
                            VeDAO.Instance.muaVe(matuyenxe, manhanvien, gia, 1, thoigianbanve);
                            getmavemax++;
                            FInVe f1 = new FInVe();
                            f1.ShowDialog();
                        }
                        MessageBox.Show("Mua Vé thành công!!!", "Thông Báo");
                    }
                    else
                    {
                        MessageBox.Show("Mua Vé thất bại!!!", "Thông Báo");
                    }
                }
            }            
        }

        private void btnThemXe_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {            
            try
            {
                string Tbiensoxe = txtTbienso.Text;
                string Tmauxe = txtTmauxe.Text;
                string Tloaixe = txtTloaixe.Text;
                int Tsochongoi = int.Parse(txtTsochongoi.Text);
                if (MessageBox.Show("Xác nhận thêm xe?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (XeDAO.Instance.themXe(Tbiensoxe, Tmauxe, Tloaixe, Tsochongoi))
                    {
                        MessageBox.Show("Thêm xe thành công!!!", "Thông Báo");
                        txtTbienso.Text = null;
                        txtTmauxe.Text = null;
                        txtTloaixe.Text = null;
                        txtTsochongoi.Text = null;
                        dtgvXe.DataSource = XeDAO.Instance.getListXe();
                    }
                    else
                    {
                        MessageBox.Show("Thêm xe thất bại!!!", "Thông Báo");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm xe thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtTbienso.Text = null;
            txtTmauxe.Text = null;
            txtTloaixe.Text = null;
            txtTsochongoi.Text = null;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                string biensoxe = txtBienSo.Text;
                string mauxe = txtMauXe.Text;
                string loaixe = txtLoaiXe.Text;
                int sochongoi = int.Parse(txtSoChoNgoi.Text);
                if (biensoxe == null)
                {
                    MessageBox.Show("Chưa chọn xe!!!", "Thông Báo");
                }
                else
                {
                    if (MessageBox.Show("Xác nhận cập nhật xe?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (XeDAO.Instance.suaXe(biensoxe, mauxe, loaixe, sochongoi))
                        {
                            MessageBox.Show("Cập nhật xe thành công!!!", "Thông Báo");
                            dtgvXe.DataSource = XeDAO.Instance.getListXe();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật xe thất bại!!!", "Thông Báo");
                        }
                    }
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật xe thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string xoaxe = txtBienSo.Text;
                if (xoaxe == null)
                {
                    MessageBox.Show("Chưa chọn xe!!!", "Thông Báo");
                }
                else
                {
                    if (MessageBox.Show("Xác nhận xóa xe?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (XeDAO.Instance.xoaXe(xoaxe))
                        {
                            MessageBox.Show("Xóa xe thành công!!!", "Thông Báo");
                            dtgvXe.DataSource = XeDAO.Instance.getListXe();
                        }
                        else
                        {
                            MessageBox.Show("Xóa xe thất bại!!!", "Thông Báo");
                        }
                    }
                }   
            }
            catch (Exception)
            {
                MessageBox.Show("Xóa xe thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }
        }

        private void dtgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtBienSo.Text = dtgvXe[0, i].Value.ToString();
                txtMauXe.Text = dtgvXe[1, i].Value.ToString();
                txtLoaiXe.Text = dtgvXe[2, i].Value.ToString();
                txtSoChoNgoi.Text = dtgvXe[3, i].Value.ToString();
                txtTinhTrang.Text = dtgvXe[4, i].Value.ToString();
            }
            catch (Exception)
            {
            }            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string timtuyenxe = cbbTimVe.Text;
            if (cbbTimVe.Text == "Tất Cả")
            {
                if (rabtntatca.Checked)
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe";
                    dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query);
                }
                else if (rabtndachay.Checked)
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE TuyenXe.TrangThai = N'Đã Chạy'";
                    dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query);
                }
                else
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE TuyenXe.TrangThai = N'Chưa Chạy'";
                    dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query);
                }
            }
            else
            {                
                if (rabtntatca.Checked)
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE (TuyenXe.TuyenXe LIKE @timtuyenxe )";
                    dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%'+timtuyenxe+'%' });
                }
                else if (rabtndachay.Checked)
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE TuyenXe.TrangThai = N'Đã Chạy' AND TuyenXe.TuyenXe LIKE @timtuyenxe ";
                    dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%' + timtuyenxe + '%' });
                }
                else
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán Vé], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], Ve.Gia AS Giá, Ve.ThoiGianBanVe AS[Thời Gian Bán Vé], TuyenXe.TrangThai AS[Trạng Thái Của Tuyến Xe] FROM NhanVien INNER JOIN Ve ON NhanVien.MaNhanVien = Ve.MaNhanVien INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE TuyenXe.TrangThai = N'Chưa Chạy' AND TuyenXe.TuyenXe LIKE @timtuyenxe ";
                    dtgvVeDaBan.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%' + timtuyenxe + '%' });
                }
                
            }
        }

        private void dtgvVeDaBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtHuyVe.Text = dtgvVeDaBan[0, i].Value.ToString();
                if (dtgvVeDaBan[8, i].Value.ToString() == "Chưa Chạy")
                {
                    btnHuyVe.Text = "Hủy Vé";
                    btnHuyVe.Enabled = true;
                }
                else
                {
                    btnHuyVe.Text = "Xe Đã Chạy";
                    btnHuyVe.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string mavexoa = txtHuyVe.Text;
                if (mavexoa == "")
                {
                    MessageBox.Show("Vui lòng chọn vé để hủy!!!", "Thông Báo");
                }
                else
                {
                    if (MessageBox.Show("Xác nhận hủy vé?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (VeDAO.Instance.xoaVe(mavexoa))
                        {
                            MessageBox.Show("Hủy vé thành công!!!", "Thông Báo");
                            loadlistvedaban();
                        }
                        else
                        {
                            MessageBox.Show("Hủy Vé thất bại!!!", "Thông Báo");
                        }
                    }
                }                
            }
            catch (Exception)
            {
                MessageBox.Show("Hủy Vé thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = txtThotennv.Text;
                string chucvu = cbbTchucvu.Text;
                string gioitinh ="";
                if (rabtnTNamnv.Checked)
                {
                    gioitinh = "Nam";
                }
                else if (rabtnTNunv.Checked)
                {
                    gioitinh = "Nữ";
                }
                DateTime ngaysinh = dtpkTngaysinh.Value;
                string cmnd = txtTcmnd.Text;
                string diachi = txtTdiachi.Text;
                string sdt = txtTsdt.Text;
                double hesoluong = double.Parse(txtThesoluong.Text);
                if (hoten == "" || chucvu == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo");
                }
                else
                {
                    if (MessageBox.Show("Xác nhận thêm nhân viên?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (NhanVienDAO.Instance.themNhanVien(hoten,chucvu,gioitinh,ngaysinh,cmnd,diachi,sdt,hesoluong))
                        {
                            MessageBox.Show("Thêm Nhân Viên thành công!!!", "Thông Báo");
                            loadlistnhanvien("");
                            txtThotennv.Text = null;
                            cbbTchucvu.Text = null;
                            txtTcmnd.Text = null;
                            txtTdiachi.Text = null;
                            txtTsdt.Text = null;
                            txtThesoluong.Text = null;
                        }
                        else
                        {
                            MessageBox.Show("Thêm Nhân Viên thất bại!!!", "Thông Báo");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm Nhân Viên thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtThotennv.Text = null;
            cbbTchucvu.Text = null;
            txtTcmnd.Text = null;
            txtTdiachi.Text = null;
            txtTsdt.Text = null;
            txtThesoluong.Text = null;
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            FTaoTaiKhoan f = new FTaoTaiKhoan();
            f.ShowDialog();
            loadlistnhanvien("");
        }

        private void dtgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NhanVienDAO.manhanvientk = dtgvnhanvien[0, e.RowIndex].Value.ToString();
                NhanVienDAO.tennhanvientk = dtgvnhanvien[1, e.RowIndex].Value.ToString();
                NhanVienDAO.chucvutk = dtgvnhanvien[5, e.RowIndex].Value.ToString();
                AccountDAO.uesrnametk = dtgvnhanvien[9, e.RowIndex].Value.ToString();
            }
            catch (Exception)
            {
            }
            try
            {
                int i = e.RowIndex;
                txtHoTennv.Text = dtgvnhanvien[1, i].Value.ToString();
                if (dtgvnhanvien[3, i].Value.ToString() == "Nam")
                {
                    rabtnNamnv.Checked = true;
                }
                else
                {
                    rabtnNunv.Checked = true;
                }
                dtpkNgaySinh.Value = (DateTime)dtgvnhanvien[2, i].Value;
                txtcmndnv.Text = dtgvnhanvien[4, i].Value.ToString();
                txtSoDienThoainv.Text = dtgvnhanvien[7, i].Value.ToString();
                txtDiaChinv.Text = dtgvnhanvien[6, i].Value.ToString();
                cbbChucVunv.Text = dtgvnhanvien[5, i].Value.ToString();
                txtHeSoLuongnv.Text = dtgvnhanvien[8, i].Value.ToString();
                if (dtgvnhanvien[9, i].Value.ToString()=="")
                {
                    btnSuaTaiKhoan.Enabled = false;
                    btnTaoTaiKhoan.Enabled = true;
                }
                else
                {
                    btnTaoTaiKhoan.Enabled = false;
                    btnSuaTaiKhoan.Enabled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }                
        }

        private void btnCapNhatnv_Click(object sender, EventArgs e)
        {
            try
            {
                string hoten = txtHoTennv.Text;
                string chucvu = cbbChucVunv.Text;
                string gioitinh = "";
                if (rabtnNamnv.Checked)
                {
                    gioitinh = "Nam";
                }
                else if (rabtnNunv.Checked)
                {
                    gioitinh = "Nữ";
                }
                DateTime ngaysinh = dtpkNgaySinh.Value;
                string cmnd = txtcmndnv.Text;
                string diachi = txtDiaChinv.Text;
                string sdt = txtSoDienThoainv.Text;
                double hesoluong = double.Parse(txtHeSoLuongnv.Text);
                if (hoten == "" || chucvu == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Thông Báo");
                }
                else
                {
                    if (MessageBox.Show("Xác nhận cập nhật nhân viên?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (NhanVienDAO.Instance.suaNhanVien(NhanVienDAO.manhanvientk, hoten, chucvu, gioitinh, ngaysinh, cmnd, diachi, sdt, hesoluong))
                        {
                            MessageBox.Show("Cập Nhật Nhân Viên thành công!!!", "Thông Báo");
                            loadlistnhanvien(txttimnhanvien.Text);
                        }
                        else
                        {
                            MessageBox.Show("Cập Nhật Nhân Viên thất bại!!!", "Thông Báo");
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cập Nhật Nhân Viên thất bại!!! Vui lòng kiểm tra lại", "Thông Báo");
            }            
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận cập nhật nhân viên?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (NhanVienDAO.Instance.xoaNhanVien(NhanVienDAO.manhanvientk))
                {
                    MessageBox.Show("Xóa Nhân Viên Thành Công", "Thông Báo");
                    loadlistnhanvien("");
                }
                else
                {
                    MessageBox.Show("Xóa Nhân Viên Thất Bại", "Thông Báo");
                }
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            FSuaTaiKhoan f = new FSuaTaiKhoan();
            f.ShowDialog();
            loadlistnhanvien(txttimnhanvien.Text);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            dtgvXe.DataSource = XeDAO.Instance.getListXebybienso(txttimxe.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txttimxe.Text, @"[^a-zA-Z0-9 ]+"))
            {
                MessageBox.Show("Vui lòng không nhập ký tự đặc biệt", "Thông Báo");
            }
            else
            {
                loadlistnhanvien(txttimnhanvien.Text);
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (txtHoTennv.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên","Thông Báo");
            }
            else
            {
                FThuongPhatNhanVien f = new FThuongPhatNhanVien();
                f.ShowDialog();
            }
        }

        private void btnThemVaoBaoTri_Click(object sender, EventArgs e)
        {
            if (txtbiensoxeTbaotri.Text == "")
            {
                MessageBox.Show("Vui lòng chọn xe để bảo trì","Thông Báo");
            }
            else
            {
                if (lbtrangthaixe.Text == "Tốt")
                {
                    XeBaoTriDAO.Instance.themXeBaoTri(txtbiensoxeTbaotri.Text, dtpkngayxongTbaotri.Value, txttinhtrangxeTbaotri.Text);
                    loadlistxebaotri();
                }
                else if (lbtrangthaixe.Text == "Bảo trì")
                {
                    MessageBox.Show("Xe đang được bảo trì", "Thông Báo");
                }
            }            
        }

        private void dtgvxetot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                lbtrangthaixe.Text = dtgvxetot[4, i].Value.ToString();
                txtbiensoxeTbaotri.Text = dtgvxetot[0, i].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }            
        }

        private void dtgvxebaotri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtbiensoxebaotri.Text = dtgvxebaotri[0, i].Value.ToString();
            }
            catch (Exception)
            {
            }            
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (txtbiensoxebaotri.Text == "")
            {
                MessageBox.Show("Chọn xe hoàn tất bảo trì", "Thông Báo");
            }
            else
            {
                string biensoxe = txtbiensoxebaotri.Text;
                string query = "UPDATE Xe SET TinhTrang = N'Tốt' WHERE BienSoXe = @biensoxe ";
                DataProvider.Instance.ExecuteQuery(query, new object[] { biensoxe });
                string query1 = "UPDATE XeBaoTri SET BaoTri = N'Đã xong' WHERE BienSoXe = @biensoxe ";
                DataProvider.Instance.ExecuteQuery(query1, new object[] { biensoxe });
                loadlistxebaotri();
                txtbiensoxebaotri.Text = null;
            }            
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (txtbiensoxebaotri.Text == "")
            {
                MessageBox.Show("Chọn xe để thêm thời gian bảo trì", "Thông Báo");
            }
            else
            {
                string biensoxe = txtbiensoxebaotri.Text;
                DateTime ngayxong = dtpkbaotri.Value;
                string query = "UPDATE XeBaoTri SET NgayXong = @ngayxong WHERE BienSoXe = @biensoxe ";
                DataProvider.Instance.ExecuteQuery(query, new object[] { ngayxong , biensoxe });
                loadlistxebaotri();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime TKvebatdau = dtpkve1.Value;
                DateTime TKveketthuc = dtpkve2.Value;
                string TKvenhanvien = txtTkvenhanvien.Text;
                string TKvetuyenxe = cbbTKvetuyenxe.Text;
                string TKvemauxe = txtTKveMauxe.Text;
                string TKveloaixe = txtTKveLoaiXe.Text;
                int TKvegiamin = int.Parse(txtTKvegiamin.Text);
                int TKvegiamax = int.Parse(txtTKvegiamax.Text);
                if (TKvebatdau>=TKveketthuc)
                {
                    MessageBox.Show("Vui lòng chọn thời gian thống kê","Thông Báo");
                }
                else
                {
                    string query = "SELECT Ve.MaVe AS [Mã Vé], NhanVien.HoTen AS [Nhân Viên Bán], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.ThoiGianXuatPhat AS [Thời Gian Xuất Phát], TuyenXe.BienSoXe AS [Biển Số Xe], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], Ve.ThoiGianBanVe AS [Thời Gian Bán Vé], Ve.Gia AS Giá FROM Ve INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN NhanVien ON Ve.MaNhanVien = NhanVien.MaNhanVien INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE HoTen LIKE @TKvenhanvien AND Loaixe LIKE @TKveloaixe AND	TuyenXe LIKE @TKvetuyenxe AND MauXe LIKE @TKvemauxe AND Gia > @TKvegiamin AND gia < @TKvegiamax AND ThoiGianBanVe > @TKvebatdau AND ThoiGianBanVe < @TKveketthuc ";
                    dtgvthongkeVe.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%' + TKvenhanvien + '%', '%' + TKveloaixe + '%', '%' + TKvetuyenxe + '%', '%' + TKvemauxe + '%', TKvegiamin, TKvegiamax, TKvebatdau, TKveketthuc });
                    int sum = 0;
                    for (int i = 0; i < dtgvthongkeVe.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dtgvthongkeVe.Rows[i].Cells[8].Value);
                    }
                    txtTkTongCongGiaVe.Text = sum.ToString();
                    lbtongsoluongve.Text = "Tổng Số Lượng Vé: " + dtgvthongkeVe.Rows.Count;
                    //string query1 = "SELECT Sum(Gia) FROM Ve INNER JOIN TuyenXe ON Ve.MaTuyenXe = TuyenXe.MaTuyenXe INNER JOIN NhanVien ON Ve.MaNhanVien = NhanVien.MaNhanVien INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE HoTen LIKE @TKvenhanvien AND Loaixe LIKE @TKveloaixe AND	TuyenXe LIKE @TKvetuyenxe AND MauXe LIKE @TKvemauxe AND Gia > @TKvegiamin AND gia < @TKvegiamax AND ThoiGianBanVe > @TKvebatdau AND ThoiGianBanVe < @TKveketthuc ";
                    //txtTkTongCongGiaVe.Text = ((int)DataProvider.Instance.ExecuteScalar(query1, new object[] { '%' + TKvenhanvien + '%', '%' + TKveloaixe + '%', '%' + TKvetuyenxe + '%', '%' + TKvemauxe + '%', TKvegiamin, TKvegiamax, TKvebatdau, TKveketthuc })).ToString();
                }                
            }
            catch (Exception)
            {
            }            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime TKxebatdau = dtpktuyenxe1.Value;
                DateTime TKxeketthuc = dtpktuyenxe2.Value;
                string TKxebiensoxe = txtTKxeBienSoXe.Text;
                string TKxetuyenxe = cbbTKxetuyenxe.Text;
                string TKxemauxe = txtTKxemauxe.Text;
                string TKxeloaixe = txtTKxeloaixe.Text;
                string TKxetaixe = txtTKxeTaixe.Text;
                int TKxechongoimin = int.Parse(txtsochongoimin.Text);
                int TKxechongoimax = int.Parse(txtsochongoimax.Text);
                if (TKxebatdau >= TKxeketthuc)
                {
                    MessageBox.Show("Vui lòng chọn thời gian thống kê", "Thông Báo");
                }
                else
                {
                    string query = "SELECT TuyenXe.MaTuyenXe AS [Mã Tuyến Xe], TuyenXe.BienSoXe AS [Biển Số Xe], TuyenXe.TuyenXe AS [Tuyến Xe], TuyenXe.TenTaiXe AS [Tên Tài Xế], Xe.MauXe AS [Mẫu Xe], Xe.LoaiXe AS [Loại Xe], TuyenXe.ThoiGianXuatPhat AS[Thời Gian Chạy], Xe.SoChoNgoi AS[Số Chổ Ngồi], Ve.Gia AS Giá, SUM(Ve.SoLuong) AS[Số Lượng Đã Bán], SUM(Ve.SoLuong)*ve.Gia AS [Tổng Tiền] FROM TuyenXe INNER JOIN Ve ON TuyenXe.MaTuyenXe = Ve.MaTuyenXe INNER JOIN Xe ON TuyenXe.BienSoXe = Xe.BienSoXe WHERE TuyenXe.BienSoXe LIKE @TKxebiensoxe AND TuyenXe LIKE @TKxetuyenxe AND MauXe LIKE @TKxemauxe AND LoaiXe LIKE @TKxeloaixe AND TenTaiXe LIKE @TKxetaixe AND SoChoNgoi > @TKxechongoimin AND SoChoNgoi < @TKxechongoimax AND ThoiGianXuatPhat > @TKxebatdau AND ThoiGianXuatPhat < @TKxeketthuc GROUP BY TuyenXe.MaTuyenXe, TuyenXe.BienSoXe, TuyenXe.TuyenXe, Xe.MauXe, Xe.LoaiXe, Xe.SoChoNgoi, TuyenXe.ThoiGianXuatPhat, TuyenXe.TenTaiXe, Ve.Gia";
                    dtgvThongKeTuyenXe.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%' + TKxebiensoxe + '%', '%' + TKxetuyenxe + '%', '%' + TKxemauxe + '%', '%' + TKxeloaixe + '%', '%' + TKxetaixe + '%', TKxechongoimin, TKxechongoimax, TKxebatdau, TKxeketthuc });
                    int sum = 0;
                    for (int i = 0; i < dtgvThongKeTuyenXe.Rows.Count; ++i)
                    {
                        sum += Convert.ToInt32(dtgvThongKeTuyenXe.Rows[i].Cells[10].Value);
                    }
                    txtTKxeTongCong.Text = sum.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                string TPgioitinh = "";
                if (rabtnTPtatca.Checked)
                {
                    TPgioitinh = "";
                }
                else if (rabtnTPnam.Checked)
                {
                    TPgioitinh = "Nam";
                }
                else
                {
                    TPgioitinh = "Nữ";
                }
                DateTime TPbatdau = dtpkthuongphat1.Value;
                DateTime TPketthuc = dtpkthuongphat2.Value;
                string TPmanhanvien = txtTPmanhanvien.Text;
                string TPtennhanvien = txtTPtennhanvien.Text;
                string TPchucvu = txtTPchucvu.Text;                
                string TPhinhthuc = cbbTPhinhthuc.Text;
                if (cbbTPhinhthuc.Text == "Tất Cả")
                {
                    TPhinhthuc = "";
                }
                if (TPbatdau >= TPketthuc)
                {
                    MessageBox.Show("Vui lòng chọn thời gian thống kê", "Thông Báo");
                }
                else
                {
                    string query = "SELECT ThuongPhat.MaThuongPhat AS [Mã Thưởng Phạt], ThuongPhat.MaNhanVien AS [Mã Nhân Viên], NhanVien.HoTen AS [Họ Tên], NhanVien.ChucVu AS [Chức Vụ], NhanVien.GioiTinh AS [Giới Tính], NhanVien.SoDienThoai AS [Số Điện Thoại], ThuongPhat.ThoiGianThuongPhat AS[Thời Gian], ThuongPhat.HinhThuc AS[Hình Thức], ThuongPhat.SoTien AS[Số Tiền], ThuongPhat.LyDo AS[Lý Do] FROM NhanVien INNER JOIN ThuongPhat ON NhanVien.MaNhanVien = ThuongPhat.MaNhanVien WHERE NhanVien.MaNhanVien LIKE @TPmanhanvien AND HoTen LIKE @TPtennhanvien AND GioiTinh LIKE @TPgioitinh AND ChucVu LIKE @TPchucvu AND HinhThuc LIKE @TPhinhthuc AND ThoiGianThuongPhat > @TPbatdau AND ThoiGianThuongPhat < @TPketthuc ";
                    dtgvthuongphat.DataSource = DataProvider.Instance.ExecuteQuery(query, new object[] { '%' + TPmanhanvien + '%', '%' + TPtennhanvien + '%', '%' + TPgioitinh + '%', '%' + TPchucvu + '%', '%' + TPhinhthuc + '%', TPbatdau, TPketthuc });
                }                
            }
            catch (Exception)
            {
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fdoimatkhau f = new Fdoimatkhau();
            f.ShowDialog();
        }
    }
}
