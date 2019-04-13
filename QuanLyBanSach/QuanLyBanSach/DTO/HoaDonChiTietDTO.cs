using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class HoaDonChiTietDTO
    {
        public HoaDonChiTietDTO(int machitiethd, int masach, int soluongmua, int mahoadon)
        {
            this.MaChiTietHD = machitiethd;
            this.MaSach = masach;
            this.SoLuongMua = soluongmua;
            this.MaHoaDon = mahoadon;
        }
        public HoaDonChiTietDTO(DataRow row)
        {
            this.MaChiTietHD = (int)row["machitiethd"];
            this.MaSach = (int)row["masach"];
            this.SoLuongMua = (int)row["soluongmua"];
            this.MaHoaDon = (int)row["mahoadon"];
        }
        private int maChiTietHD;
        private int maSach;
        private int soLuongMua;
        private int maHoaDon;

        public int MaChiTietHD
        {
            get
            {
                return maChiTietHD;
            }

            set
            {
                maChiTietHD = value;
            }
        }

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

        public int SoLuongMua
        {
            get
            {
                return soLuongMua;
            }

            set
            {
                soLuongMua = value;
            }
        }

        public int MaHoaDon
        {
            get
            {
                return maHoaDon;
            }

            set
            {
                maHoaDon = value;
            }
        }
    }
}
