using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class NhanVienDTO
    {
        private string maNhanVien;
        private string hoTen;
        private string chucVu;
        private string gioiTinh;
        private DateTime ngaySinh;
        private string cMND;
        private string diaChi;
        private string soDienThoai;
        private double heSoLuong;

        public NhanVienDTO(string manhanvien, string hoten, string chucvu, string gioitinh, DateTime ngaysinh, string cmnd, string diachi, string sodienthoai, double hesoluong)
        {
            this.MaNhanVien = manhanvien;
            this.HoTen = hoten;
            this.ChucVu = chucvu;
            this.GioiTinh = gioitinh;
            this.NgaySinh = ngaysinh;
            this.CMND = cmnd;
            this.DiaChi = diachi;
            this.SoDienThoai = sodienthoai;
            this.HeSoLuong = hesoluong;
        }
        public NhanVienDTO(DataRow row)
        {
            this.MaNhanVien = (string)row["MaNhanVien"];
            this.HoTen = (string)row["HoTen"];
            this.ChucVu = (string)row["ChucVu"];
            this.GioiTinh = (string)row["GioiTinh"];
            this.NgaySinh = (DateTime)row["NgaySinh"];
            this.CMND = (string)row["CMND"];
            this.DiaChi = (string)row["DiaChi"];
            this.SoDienThoai = (string)row["SoDienThoai"];
            this.HeSoLuong = (double)row["HeSoLuong"];
        }

        public string MaNhanVien
        {
            get
            {
                return maNhanVien;
            }

            set
            {
                maNhanVien = value;
            }
        }

        public string HoTen
        {
            get
            {
                return hoTen;
            }

            set
            {
                hoTen = value;
            }
        }

        public string ChucVu
        {
            get
            {
                return chucVu;
            }

            set
            {
                chucVu = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public string CMND
        {
            get
            {
                return cMND;
            }

            set
            {
                cMND = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string SoDienThoai
        {
            get
            {
                return soDienThoai;
            }

            set
            {
                soDienThoai = value;
            }
        }

        public double HeSoLuong
        {
            get
            {
                return heSoLuong;
            }

            set
            {
                heSoLuong = value;
            }
        }
    }
}
