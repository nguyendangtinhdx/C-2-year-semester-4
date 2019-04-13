using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanSach.DTO
{
    public class LoaiSachDTO
    {
        public LoaiSachDTO (int maLoai, string tenLoai)
        {
            this.MaLoai = maLoai;
            this.TenLoai = tenLoai;
        }
        public LoaiSachDTO(DataRow row)
        {
            this.MaLoai = (int)row["maloai"];
            this.TenLoai = row["tenloai"].ToString();
        }

        private int maLoai;
        private string tenLoai;

        public int MaLoai
        {
            get
            {
                return maLoai;
            }

            set
            {
                maLoai = value;
            }
        }

        public string TenLoai
        {
            get
            {
                return tenLoai;
            }

            set
            {
                tenLoai = value;
            }
        }
    }
}
