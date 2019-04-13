using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class HoaDonDTO
    {
        public HoaDonDTO(int mahoadon, int manhanvien, DateTime? ngayban, bool damua)
        {
            this.MaHoaDon = mahoadon;
            this.MaNhanVien = manhanvien;
            this.NgayBan = ngayban;
            this.Damua = damua;
        }
        public HoaDonDTO(DataRow row)
        {
            this.MaHoaDon = (int)row["mahoadon"];
            this.MaNhanVien = (int)row["manhanvien"];
            this.NgayBan = (DateTime?)row["ngayban"];
            this.Damua = (bool)row["damua"];
        }

        private int maHoaDon;
        private int maNhanVien;
        private DateTime? ngayBan;
        private bool damua;

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

        public DateTime? NgayBan
        {
            get
            {
                return ngayBan;
            }

            set
            {
                ngayBan = value;
            }
        }

        public bool Damua
        {
            get
            {
                return damua;
            }

            set
            {
                damua = value;
            }
        }
    }
}
