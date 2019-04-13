using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach_BaiTap3.DTO
{
    public class Sach
    {
        public Sach(string maSach, string tenSach, string tacGia, int soLuong, float gia)
        {
            this.MaSach = maSach;
            this.TenSach = tenSach;
            this.TacGia = tacGia;
            this.SoLuong = soLuong;
            this.Gia = gia;
        }
        public Sach(DataRow row)
        {
            this.MaSach = row["MaSach"].ToString();
            this.TenSach = row["TenSach"].ToString();
            this.TacGia = row["TacGia"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
        }

        private float gia;
        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        private int soLuong;
        public int SoLuong
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
