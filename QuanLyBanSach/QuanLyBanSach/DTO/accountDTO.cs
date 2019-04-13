using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class accountDTO
    {
        public accountDTO(string tendangnhap,string matkhau, bool quyen)
        {
            this.TenDangNhap = tendangnhap;
            this.MatKhau = matkhau;
            this.Quyen = quyen;
        }
        public accountDTO(DataRow row)
        {
            this.TenDangNhap = (string)row["tendangnhap"];
            this.MatKhau = (string)row["matkhau"];
            this.Quyen = (bool)row["Quyen"];
        }
        private string tenDangNhap;
        private string matKhau;
        private bool quyen;

        public string TenDangNhap
        {
            get
            {
                return tenDangNhap;
            }

            set
            {
                tenDangNhap = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return matKhau;
            }

            set
            {
                matKhau = value;
            }
        }

        public bool Quyen
        {
            get
            {
                return quyen;
            }

            set
            {
                quyen = value;
            }
        }
    }
}
