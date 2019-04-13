using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeOto.bean
{
    public class ThongKeBEAN
    {
        public ThongKeBEAN (string tenHang, long soXe, long tongThanhTien)
        {
            this.TenHang = tenHang;
            this.SoXe = soXe;
            this.TongThanhTien = tongThanhTien;
        }
        private string tenHang;

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }
        private long soXe;

        public long SoXe
        {
            get { return soXe; }
            set { soXe = value; }
        }

        private long tongThanhTien;

        public long TongThanhTien
        {
            get { return tongThanhTien; }
            set { tongThanhTien = value; }
        }
    }
}
