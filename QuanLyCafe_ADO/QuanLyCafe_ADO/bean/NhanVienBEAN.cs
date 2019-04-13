using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class NhanVienBEAN
    {
        public NhanVienBEAN(string maNhanVien, string hoTen, string diaChi, string matKhau, string quyen)
        {
            this.MaNhanVien = maNhanVien;
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.MatKhau = matKhau;
            this.Quyen = quyen;
        }
        private string maNhanVien;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string hoTen;

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string matKhau;

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }
        private string quyen;

        public string Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }
    }
}
