using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeOto.bean
{
    public class HoaDonDEAN
    {
        public HoaDonDEAN(string maHoaDon, string maXe, long soLuongMua, long thanhTien, bool trangThai)
        {
            this.MaHoaDon = maHoaDon;
            this.MaXe = maXe;
            this.SoLuongMua = soLuongMua;
            this.ThanhTien = thanhTien;
            this.TrangThai = trangThai;
        }
        private string maHoaDon;

        public string MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
        private string maXe;

        public string MaXe
        {
            get { return maXe; }
            set { maXe = value; }
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
        private bool trangThai;

        public bool TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    }
}
