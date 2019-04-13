using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenDangTinh
{
    public class CuaHang
    {
        private string maHang;
        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
        private string tenHang;
        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }
        private double gia;
        public double Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        private double thanhTien;

        public double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        public CuaHang(string maHang, string tenHang, double gia, int soLuong, DateTime ngayNhap, double thanhTien)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.Gia = gia;
            this.SoLuong = soLuong;
            this.NgayNhap = ngayNhap;
            this.ThanhTien = gia * soLuong;
        }
    }
}
