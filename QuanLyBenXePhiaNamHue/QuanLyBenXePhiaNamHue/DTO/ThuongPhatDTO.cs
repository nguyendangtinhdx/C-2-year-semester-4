using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class ThuongPhatDTO
    {
        private int maThuongPhat;
        private string maNhanVien;
        private DateTime thoiGianThuongPhat;
        private string hinhThuc;
        private int soTien;
        private string lyDo;

        public ThuongPhatDTO(int mathuongphat, string manhanvien, DateTime thoigianthuongphat, string hinhthuc, int sotien, string lydo)
        {
            this.MaThuongPhat = mathuongphat;
            this.MaNhanVien = manhanvien;
            this.ThoiGianThuongPhat = thoigianthuongphat;
            this.HinhThuc = hinhthuc;
            this.SoTien = sotien;
            this.LyDo = lydo;
        }
        public ThuongPhatDTO(DataRow row)
        {
            this.MaThuongPhat = (int)row["MaThuongPhat"];
            this.MaNhanVien = (string)row["MaNhanVien"];
            this.ThoiGianThuongPhat = (DateTime)row["ThoiGianThuongPhat"];
            this.HinhThuc = (string)row["HinhThuc"];
            this.SoTien = (int)row["SoTien"];
            this.LyDo = (string)row["LyDo"];
        }

        public int MaThuongPhat
        {
            get
            {
                return maThuongPhat;
            }

            set
            {
                maThuongPhat = value;
            }
        }

        public string MaNhanVien
        {
            get
            {
                return maNhanVien;
            }

            set
            {
                maNhanVien = value;
            }
        }

        public DateTime ThoiGianThuongPhat
        {
            get
            {
                return thoiGianThuongPhat;
            }

            set
            {
                thoiGianThuongPhat = value;
            }
        }

        public string HinhThuc
        {
            get
            {
                return hinhThuc;
            }

            set
            {
                hinhThuc = value;
            }
        }

        public int SoTien
        {
            get
            {
                return soTien;
            }

            set
            {
                soTien = value;
            }
        }

        public string LyDo
        {
            get
            {
                return lyDo;
            }

            set
            {
                lyDo = value;
            }
        }
    }
}
