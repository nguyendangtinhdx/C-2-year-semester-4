
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class MuaBanSach
    {
        public MuaBanSach(int masach, string tensach, int gia, int soluong, int thanhtien)
        {
            this.MaSach = maSach;
            this.TenSach = tensach;
            this.Gia = gia;
            this.soLuong = soluong;
            this.ThanhTien = thanhtien;
        }
        public MuaBanSach(DataRow row)
        {
            this.MaSach = (int)row["maSach"];
            this.TenSach = (string)row["tensach"];
            this.Gia = (int)row["gia"];
            this.soLuong = (int)row["SoLuongMua"];
            this.ThanhTien = (int)row["thanhtien"];
        }
        private int maSach;
        private string tenSach;
        private int gia;
        private int soLuong;
        private int thanhTien;

        public int MaSach
        {
            get
            {
                return maSach;
            }

            set
            {
                maSach = value;
            }
        }

        public string TenSach
        {
            get
            {
                return tenSach;
            }

            set
            {
                tenSach = value;
            }
        }

        public int Gia
        {
            get
            {
                return gia;
            }

            set
            {
                gia = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public int ThanhTien
        {
            get
            {
                return thanhTien;
            }

            set
            {
                thanhTien = value;
            }
        }
    }
}
