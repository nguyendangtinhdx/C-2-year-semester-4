using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class ThongKeBEAN
    {
        public ThongKeBEAN(string tenHang, long gia, long soLuongMua, long thanhTien, DateTime ngayBan)
        {
            this.TenHang = tenHang;
            this.Gia = gia;
            this.SoLuongMua = soLuongMua;
            this.ThanhTien = thanhTien;
            this.NgayBan = ngayBan;
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
        private DateTime ngayBan;

        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }
    }
}
