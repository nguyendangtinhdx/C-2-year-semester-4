using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.Model
{
    public class ChiTietHoaDonBean
    {
        private int maHoaDon;

        public int MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
        private long gia;

        public long Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private long soLuongMua;

        public long SoLuongMua
        {
            get { return soLuongMua; }
            set { soLuongMua = value; }
        }
        private string maSach;

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private int maChiTietHoaDon;

        public int MaChiTietHoaDon
        {
            get { return maChiTietHoaDon; }
            set { maChiTietHoaDon = value; }
        }

    }
}
