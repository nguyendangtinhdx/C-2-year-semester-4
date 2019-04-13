using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class SachDTO
    {
        public SachDTO(int maSach, string maLoai, string tenSach, string tacGia, int soLuong, int gia, int soTap)
        {
            this.MaSach = maSach;
            this.MaLoai = maLoai;
            this.TenSach = tenSach;
            this.TacGia = tacGia;
            this.SoLuong = soLuong;
            this.Gia = gia;
            this.SoTap = soTap;
        }
        public SachDTO(DataRow row)
        {
            this.MaSach = (int)row["MaSach"];
            this.MaLoai = (string)row["maloai"];
            this.TenSach = (string)row["tensach"];
            this.TacGia = (string)row["tacgia"];
            this.SoLuong = (int)row["soluong"];
            this.Gia = (int)row["gia"];
            this.SoTap = (int)row["sotap"];
        }


        private int maSach;
        private string maLoai;
        private string tenSach;
        private string tacGia;
        private int soLuong;
        private int gia;
        private int soTap;

        public int MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }

        public string TacGia
        {
            get
            {
                return tacGia;
            }

            set
            {
                tacGia = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public int Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }

        public int SoTap
        {
            get
            {
                return soTap;
            }

            set
            {
                soTap = value;
            }
        }

        public string MaLoai
        {
            get
            {
                return maLoai;
            }

            set
            {
                maLoai = value;
            }
        }
    }
}
