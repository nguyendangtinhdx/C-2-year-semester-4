using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class BanChuaThanhToanBEAN
    {
        public BanChuaThanhToanBEAN(string maBan, string tenBan, long soGhe, bool daTraTien)
        {
            this.MaBan = maBan;
            this.TenBan = tenBan;
            this.SoGhe = soGhe;
            this.DaTraTien = DaTraTien;
        }
        private string maBan;

        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }
        private string tenBan;

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }
        private long soGhe;

        public long SoGhe
        {
            get { return soGhe; }
            set { soGhe = value; }
        }
        private bool daTraTien;

        public bool DaTraTien
        {
            get { return daTraTien; }
            set { daTraTien = value; }
        }
    }
}
