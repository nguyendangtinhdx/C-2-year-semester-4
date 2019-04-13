using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCafe_ADO.bean
{
    public class BanTrongBEAN
    {
        public BanTrongBEAN(string maBan, string tenBan, long soGhe)
        {
            this.MaBan = maBan;
            this.TenBan = tenBan;
            this.SoGhe = soGhe;
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
    }
}
