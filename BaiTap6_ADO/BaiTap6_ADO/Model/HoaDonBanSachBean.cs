using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap6_ADO.Model
{
    public class HoaDonBanSachBean
    {
        public HoaDonBanSachBean(string maSach, string tenSach, string tacGia, long soLuong, long gia, DateTime ngayMua, bool daMua)
        {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.TacGia = tacGia;
            this.SoLuong = soLuong;
            this.Gia = gia;
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
        private string tacGia;

        public string TacGia
        {
            get { return tacGia; }
            set { tacGia = value; }
        }
        private string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        private string maSach;

        public string MaSach
        {
            get { return maSach; }
            set { maSach = value; }
        }
    }
}
