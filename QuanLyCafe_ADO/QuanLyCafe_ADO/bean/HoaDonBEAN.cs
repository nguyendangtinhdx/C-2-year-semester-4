using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class HoaDonBEAN
    {
        public HoaDonBEAN(long maHoaDon, string maNhanVien,string maBan, DateTime ngayBan, bool daTraTien)
        {
            this.MaHoaDon = maHoaDon;
            this.MaNhanVien = maNhanVien;
            this.MaBan = maBan;
            this.NgayBan = ngayBan;
            this.DaTraTien = daTraTien;
        }
        private long maHoaDon;

        public long MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
        private string maNhanVien;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string maBan;

        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }
        private DateTime ngayBan;

        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }
        private bool daTraTien;

        public bool DaTraTien
        {
            get { return daTraTien; }
            set { daTraTien = value; }
        }
    }
}
