using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2_QuanLyCafe.BO
{
    public class DangKyBO
    {
        Boolean kt(string MaNV)
        {
            var q = from s in CauHinh.db.NHanViens
                    where s.Manv.Equals(MaNV)
                    select s;
            return q.Count() == 0 ? true : false;
        }
        public Boolean Them(string MaNV, string hoTen, string diaChi, string matKhau, string quyen)
        {
            if (kt(MaNV) == false) return false;
            NHanVien nv = new NHanVien();
            nv.Manv = MaNV;
            nv.HoTen = hoTen;
            nv.DiaChi = diaChi;
            nv.MatKhau = matKhau;
            nv.Quyen = quyen;

            CauHinh.db.NHanViens.InsertOnSubmit(nv);
            CauHinh.db.SubmitChanges();
            return true;
        }
    }
}
