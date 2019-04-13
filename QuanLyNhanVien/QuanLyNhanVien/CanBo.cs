using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien
{
    public class CanBo
    {
        private string ma;
        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }

        private string hoten;
        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }

        private bool gioitinh;
        public bool Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        private string diachi;
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private DateTime ngaysinh;
        public DateTime Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        private double hesoluong;
        public double Hesoluong
        {
            get { return hesoluong; }
            set { hesoluong = value; }
        }

        private string tendonvi;
        public string Tendonvi
        {
            get { return tendonvi; }
            set { tendonvi = value; }
        }

        public CanBo(string ma, string hoten, bool gioitinh, string diachi, DateTime ngaysinh, double hesoluong, string tendonvi)
        {
            this.ma = ma;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.ngaysinh = ngaysinh;
            this.hesoluong = hesoluong * 1250;
            this.tendonvi = tendonvi;
        }
    }
}
