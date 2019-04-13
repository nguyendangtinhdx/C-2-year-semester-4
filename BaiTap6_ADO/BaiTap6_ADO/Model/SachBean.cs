using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.Model
{
    public class SachBean
    {
        // cách khai báo khác
        //public string MaSach
        //{
        //    get;
        //    set;
        //}
        public SachBean() { }
        public SachBean(string maSach, string tenSach, string tacGia, long soLuong, long gia, string soTap, string anh, string maLoai, DateTime ngayNhap)
        {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.TacGia = tacGia;
            this.SoLuong = soLuong;
            this.Gia = gia;
            this.SoTap = soTap;
            this.Anh = anh;
            this.MaLoai = maLoai;
            this.NgayNhap = ngayNhap;
        }
        private string maSach;
        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
        private string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        private string tacGia;
        public string TacGia
        {
            get { return tacGia; }
            set { tacGia = value; }
        }
        private long soLuong;

        public long SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private long gia;

        public long Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private string soTap;

        public string SoTap
        {
            get { return soTap; }
            set { soTap = value; }
        }
        private string anh;

        public string Anh
        {
            get { return anh; }
            set { anh = value; }
        }
        private string maLoai;

        public string MaLoai
        {
            get { return maLoai; }
            set { maLoai = value; }
        }
        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
    }
}
