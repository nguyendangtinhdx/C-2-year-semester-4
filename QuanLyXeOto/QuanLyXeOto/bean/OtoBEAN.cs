using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyXeOto.bean
{
    public class OtoBEAN
    {
        public OtoBEAN(string maXe, string tenXe, long soLuongTrongKho, long gia, string maHang)
        {
            this.MaXe = maXe;
            this.TenXe = tenXe;
            this.SoLuongTrongKho = soLuongTrongKho;
            this.Gia = gia;
            this.MaHang = maHang;
        }
        private string maXe;

        public string MaXe
        {
            get { return maXe; }
            set { maXe = value; }
        }
        private string tenXe;

        public string TenXe
        {
            get { return tenXe; }
            set { tenXe = value; }
        }
        private long soLuongTrongKho;

        public long SoLuongTrongKho
        {
            get { return soLuongTrongKho; }
            set { soLuongTrongKho = value; }
        }
        private long gia;

        public long Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private string maHang;

        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
    }
}
