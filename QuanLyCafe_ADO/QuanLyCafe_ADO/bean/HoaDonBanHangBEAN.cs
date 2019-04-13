using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class HoaDonBanHangBEAN
    {
        public HoaDonBanHangBEAN(string tenHang, long gia, long soLuongMua, long thanhTien, string maBan, bool daTraTien)
        {
            this.TenHang = tenHang;
            this.Gia = gia;
            this.SoLuongMua = soLuongMua;
            this.ThanhTien = thanhTien;
            this.MaBan = maBan;
            this.DaTraTien = daTraTien;
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
        private string maBan;

        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }
        private bool daTraTien;

        public bool DaTraTien
        {
            get { return daTraTien; }
            set { daTraTien = value; }
        }
    }
}
