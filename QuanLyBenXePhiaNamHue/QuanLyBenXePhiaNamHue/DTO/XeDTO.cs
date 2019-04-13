using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenXePhiaNamHue.DTO
{
    public class XeDTO
    {
        private string bienSoXe;
        private string mauXe;
        private string loaiXe;
        private int soChoNgoi;
        private string tinhTrang;
        
        public XeDTO(string biensoxe, string mauxe, string loaixe, int sochongoi, string tinhtrang)
        {
            this.BienSoXe = biensoxe;
            this.MauXe = mauxe;
            this.LoaiXe = loaixe;
            this.SoChoNgoi = sochongoi;
            this.TinhTrang = tinhtrang;
        }
        public XeDTO(DataRow row)
        {
            this.BienSoXe = (string)row["BienSoXe"];
            this.MauXe = (string)row["MauXe"];
            this.LoaiXe = (string)row["LoaiXe"];
            this.SoChoNgoi = (int)row["SoChoNgoi"];
            this.TinhTrang = (string)row["TinhTrang"];
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

        public string MauXe
        {
            get
            {
                return mauXe;
            }

            set
            {
                mauXe = value;
            }
        }

        public string LoaiXe
        {
            get
            {
                return loaiXe;
            }

            set
            {
                loaiXe = value;
            }
        }

        public int SoChoNgoi
        {
            get
            {
                return soChoNgoi;
            }

            set
            {
                soChoNgoi = value;
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
