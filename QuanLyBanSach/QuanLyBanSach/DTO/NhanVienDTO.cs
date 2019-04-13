using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class NhanVienDTO
    {
        public NhanVienDTO(int manhanvien, string hoten, string diachi, string sodt, string email, string tendangnhap)
        {
            this.MaNhanVien = manhanvien;
            this.HoTen = hoten;
            this.DiaChi = diachi;
            this.SoDT = sodt;
            this.Email = email;
            this.TenDangNhap = tendangnhap;
        }
        public NhanVienDTO(DataRow row)
        {
            this.MaNhanVien = (int)row["manhanvien"];
            this.HoTen = (string)row["hoten"];
            this.DiaChi = (string)row["diachi"];
            this.SoDT = (string)row["sodt"];
            this.Email = (string)row["email"];
            this.TenDangNhap = (string)row["tendangnhap"];
        }

        private int maNhanVien;
        private string hoTen;
        private string diaChi;
        private string soDT;
        private string email;
        private string tenDangNhap;

        public int MaNhanVien
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

        public string SoDT
        {
            get
            {
                return soDT;
            }

            set
            {
                soDT = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
            }
        }
    }
}
