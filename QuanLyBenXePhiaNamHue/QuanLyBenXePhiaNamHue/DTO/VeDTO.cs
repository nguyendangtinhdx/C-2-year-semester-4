using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class VeDTO
    {
        private int maVe;
        private string maTuyenXe;
        private string maNhanVien;
        private int gia;
        private int soLuong;
        private DateTime thoiGianBanVe;

        public VeDTO(int mave, string matuyenxe, string manhanvien, int gia, int soluong, DateTime thoigianbanve)
        {
            this.MaVe = mave;
            this.MaTuyenXe = matuyenxe;
            this.MaNhanVien = manhanvien;
            this.Gia = gia;
            this.SoLuong = soluong;
            this.ThoiGianBanVe = thoigianbanve;
        }
        public VeDTO(DataRow row)
        {
            this.MaVe = (int)row["MaVe"];
            this.MaTuyenXe = (string)row["MaTuyenXe"];
            this.MaNhanVien = (string)row["MaNhanVien"];
            this.Gia = (int)row["Gia"];
            this.SoLuong = (int)row["SoLuong"];
            this.ThoiGianBanVe = (DateTime)row["ThoiGianBanVe"];
        }

        public int MaVe
        {
            get
            {
                return maVe;
            }

            set
            {
                maVe = value;
            }
        }

        public string MaTuyenXe
        {
            get
            {
                return maTuyenXe;
            }

            set
            {
                maTuyenXe = value;
            }
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

        public DateTime ThoiGianBanVe
        {
            get
            {
                return thoiGianBanVe;
            }

            set
            {
                thoiGianBanVe = value;
            }
        }
    }
}
