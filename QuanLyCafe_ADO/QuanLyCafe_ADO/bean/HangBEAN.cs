using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class HangBEAN
    {
        public HangBEAN(string maHang, string tenHang, long gia, long soLuong, string donViTinh)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.Gia = gia;
            this.SoLuong = soLuong;
            this.DonViTinh = donViTinh;
        }
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
        private long gia;

        public long Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private long soLuong;

        public long SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string donViTinh;

        public string DonViTinh
        {
            get { return donViTinh; }
            set { donViTinh = value; }
        }
    }
}
