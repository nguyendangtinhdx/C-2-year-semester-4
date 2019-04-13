using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class XeBaoTriDTO
    {
        private string maXeBaoTri;
        private string bienSoXe;
        private DateTime ngaySua;
        private DateTime ngayXong;
        private string tinhTrang;

        public XeBaoTriDTO(string maxebaotri, string biensoxe, DateTime ngaysua, DateTime ngayxong, string tinhtrang)
        {
            this.MaXeBaoTri = maxebaotri;
            this.BienSoXe = biensoxe;
            this.NgaySua = ngaysua;
            this.NgayXong = ngayxong;
            this.TinhTrang = tinhtrang;
        }
        public XeBaoTriDTO(DataRow row)
        {
            this.MaXeBaoTri = (string)row["MaXeBaoTri"];
            this.BienSoXe = (string)row["BienSoXe"];
            this.NgaySua = (DateTime)row["NgaySua"];
            this.NgayXong = (DateTime)row["NgayXong"];
            this.TinhTrang = (string)row["TinhTrang"];
        }

        public string MaXeBaoTri
        {
            get
            {
                return maXeBaoTri;
            }

            set
            {
                maXeBaoTri = value;
            }
        }

        public string BienSoXe
        {
            get
            {
                return bienSoXe;
            }

            set
            {
                bienSoXe = value;
            }
        }

        public DateTime NgaySua
        {
            get
            {
                return ngaySua;
            }

            set
            {
                ngaySua = value;
            }
        }

        public DateTime NgayXong
        {
            get
            {
                return ngayXong;
            }

            set
            {
                ngayXong = value;
            }
        }

        public string TinhTrang
        {
            get
            {
                return tinhTrang;
            }

            set
            {
                tinhTrang = value;
            }
        }
    }
}
