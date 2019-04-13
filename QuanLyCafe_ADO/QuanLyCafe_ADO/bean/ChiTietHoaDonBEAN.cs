using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class ChiTietHoaDonBEAN
    {
        public ChiTietHoaDonBEAN(long maChiTietHoaDon, string maHang, long soLuongMua, long thanhTien, long maHoaDon)
        {
            this.MaChiTietHoaDon = maChiTietHoaDon;
            this.MaHang = maHang;
            this.SoLuongMua = soLuongMua;
            this.ThanhTien = thanhTien;
            this.MaHoaDon = maHoaDon;
        }
        private long maChiTietHoaDon;

        public long MaChiTietHoaDon
        {
            get { return maChiTietHoaDon; }
            set { maChiTietHoaDon = value; }
        }
        private string maHang;

        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
        private long soLuongMua;

        public long SoLuongMua
        {
            get { return soLuongMua; }
            set { soLuongMua = value; }
        }
        private long thanhTien;

        public long ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        private long maHoaDon;

        public long MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
    }
}
