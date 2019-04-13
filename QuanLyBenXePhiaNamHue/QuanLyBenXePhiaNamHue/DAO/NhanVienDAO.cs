using QuanLyBenXePhiaNamHue.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NhanVienDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        private NhanVienDAO() { }
        public static string manhanvientk = "";
        public static string tennhanvientk = "";
        public static string chucvutk = "";
        public List<NhanVienDTO> getNhanVienDangNhap(string manhanvien)
        {
            List<NhanVienDTO> listnv = new List<NhanVienDTO>();
            string query = "SELECT * FROM NhanVien WHERE MaNhanVien = @manhanvien ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { manhanvien });
            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO(item);
                listnv.Add(nv);
            }
            return listnv;
        }
        public bool themNhanVien(string hoten, string chucvu, string gioitinh, DateTime ngaysinh, string cmnd, string diachi, string sodienthoai, double hesoluong)
        {
            string query = "INSERT dbo.NhanVien ( MaNhanVien , HoTen , ChucVu , GioiTinh , NgaySinh , CMND , DiaChi , SoDienThoai , HeSoLuong) VALUES  ( N'' , @hoten , @chucvu , @gioitinh , @ngaysinh , @cmnd , @diachi , @sodienthoai , @hesoluong )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoten, chucvu, gioitinh, ngaysinh, cmnd, diachi, sodienthoai, hesoluong });
            return result > 0;
        }
        public bool suaNhanVien(string manhanvien,string hoten, string chucvu, string gioitinh, DateTime ngaysinh, string cmnd, string diachi, string sodienthoai, double hesoluong)
        {
            string query = "UPDATE NhanVien SET HoTen = @hoten , ChucVu = @chucvu , GioiTinh = @gioitinh , NgaySinh = @ngaysinh , CMND = @cmnd , DiaChi = @diachi , SoDienThoai = @sodienthoai , HeSoLuong = @hesoluong WHERE (MaNhanVien = @manhanvien )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { hoten, chucvu, gioitinh, ngaysinh, cmnd, diachi, sodienthoai, hesoluong, manhanvien });
            return result > 0;
        }
        public bool xoaNhanVien(string manhanvien)
        {
            string query = "DELETE FROM NhanVien WHERE(MaNhanVien = @manhanvien )";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { manhanvien });
            return result > 0;
        }
    }
}
