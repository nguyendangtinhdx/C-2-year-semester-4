using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.Model
{
    public class HoaDonBean
    {
        public HoaDonBean(long maHoaDon, long maKhachHang, DateTime ngayMua, bool daMua)
        {
            this.MaHoaDon = maHoaDon;
            this.MaKhacHang = maKhacHang;
            this.NgayMua = ngayMua;
            this.DaMua = daMua;
        }
        private bool daMua;

        public bool DaMua
        {
            get { return daMua; }
            set { daMua = value; }
        }

        private DateTime ngayMua;

        public DateTime NgayMua
        {
            get { return ngayMua; }
            set { ngayMua = value; }
        }
        private long maKhacHang;

        public long MaKhacHang
        {
            get { return maKhacHang; }
            set { maKhacHang = value; }
        }
        private long maHoaDon;

        public long MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }

    }
}
