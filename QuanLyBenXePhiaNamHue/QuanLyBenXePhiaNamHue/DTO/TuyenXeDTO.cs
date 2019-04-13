using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class TuyenXeDTO
    {
        private string maTuyenXe;
        private string bienSoXe;
        private string tuyenXe;
        private DateTime thoiGianXuatPhat;
        private string tenTaiXe;
        private string trangThai;
        private int giaVe;

        public TuyenXeDTO(string matuyenxe, string biensoxe, string tuyenxe, DateTime thoigianxuatphat, string tentaixe,string trangthai, int giave)
        {
            this.MaTuyenXe = matuyenxe;
            this.BienSoXe = biensoxe;
            this.TuyenXe = tuyenxe;
            this.ThoiGianXuatPhat = thoiGianXuatPhat;
            this.TenTaiXe = tentaixe;
            this.TrangThai = trangthai;
            this.GiaVe = giave;
        }
        public TuyenXeDTO(DataRow row)
        {
            this.MaTuyenXe = (string)row["MaTuyenXe"];
            this.BienSoXe = (string)row["BienSoXe"];
            this.TuyenXe = (string)row["TuyenXe"];
            this.ThoiGianXuatPhat = (DateTime)row["ThoiGianXuatPhat"];
            this.TenTaiXe = (string)row["TenTaiXe"];
            this.TrangThai = (string)row["TrangThai"];
            this.GiaVe = (int)row["GiaVe"];
        }

        public string MaTuyenXe
        {
            get
            {
                return maTuyenXe;
            }

            set
            {
                maTuyenXe = value;
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

        public string TuyenXe
        {
            get
            {
                return tuyenXe;
            }

            set
            {
                tuyenXe = value;
            }
        }

        public DateTime ThoiGianXuatPhat
        {
            get
            {
                return thoiGianXuatPhat;
            }

            set
            {
                thoiGianXuatPhat = value;
            }
        }

        public string TenTaiXe
        {
            get
            {
                return tenTaiXe;
            }

            set
            {
                tenTaiXe = value;
            }
        }

        public string TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }

        public int GiaVe
        {
            get
            {
                return giaVe;
            }

            set
            {
                giaVe = value;
            }
        }
    }
}
