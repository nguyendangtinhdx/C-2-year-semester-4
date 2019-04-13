using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3
{
    public class NhanVien
    {
        public NhanVien(string maNhanVien,string tenNhanVien, string diaChi, int tuoi, long sdt)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.DiaChi = diaChi;
            this.Tuoi = tuoi;
            this.Sdt = sdt;
        }
        //public String TrangThai
        //{
        //    get
        //    {
        //        if (tuoi >= 20)
        //            return "Có thể kết hôn";
        //        return "Không thể kết hôn";
        //    }

        //}

        private long sdt;

        public long Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private int tuoi;
        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }

        private string diaChi;
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        private string tenNhanVien;
        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set { tenNhanVien = value; }
        }

        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        
    }
}
