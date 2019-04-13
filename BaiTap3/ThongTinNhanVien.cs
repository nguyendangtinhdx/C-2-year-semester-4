using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BaiTap3
{
    public class ThongTinNhanVien
    {
        public List<NhanVien> ds = new List<NhanVien>();
        public ThongTinNhanVien()
        {
            //NhanVien n1 = new NhanVien("n1", "Nguyễn Minh Hưng", "Đà Nẵng", 18, 02984934);
            //ds.Add(n1);
            //NhanVien n2 = new NhanVien("n2", "Lê Thị Liễu", "Huế", 25, 04324324);
            //ds.Add(n2);
            //NhanVien n3 = new NhanVien("n3", "Đoàn Thanh Tuấn", "Quảng Nam", 29, 54354675);
            //ds.Add(n3);
            //NhanVien n4 = new NhanVien("n4", "Trần Văn Bình", "Quảng Bình", 17, 2143254325);
            //ds.Add(n4);

            StreamReader f = new StreamReader("BaiTap3.txt");
            while (true)
            {
                string maNhanVien = f.ReadLine();
                if (string.IsNullOrEmpty(maNhanVien))
                    break;
                string tenNhanVien = f.ReadLine();
                string diaChi = f.ReadLine();
                string tuoi = f.ReadLine();
                string sdt = f.ReadLine();

                NhanVien nv = new NhanVien(maNhanVien, tenNhanVien, diaChi, int.Parse(tuoi), long.Parse(sdt));
                ds.Add(nv);

            }
            f.Close();


        }
        bool KtMa(List<NhanVien> tt, string maNhanVien)
        {
            foreach (NhanVien n in tt)
                if (n.MaNhanVien.Equals(maNhanVien))
                    return true;
                return false;
        }
        // thêm
        public List<NhanVien> Add(List<NhanVien> tt, string maNhanVien,string tenNhanVien, string diaChi, int tuoi, long sdt)
        {
            if (KtMa(tt,maNhanVien) == false)
            {
                NhanVien nv = new NhanVien(maNhanVien,tenNhanVien, diaChi, tuoi, sdt);
                tt.Add(nv);
                return tt;
            }
            return null;
        }
        
        // sửa
        public List<NhanVien> Edit(List<NhanVien> tt, string maNhanVien,string tenNhanVien, string diaChi, int tuoi, long sdt)
        {

            return null;
        }

        // Xóa

        public List<NhanVien> Delete(List<NhanVien> tt, string maNhanVien,string tenNhanVien, string diaChi, int tuoi, long sdt)
        {
            return null;
        }

        // Tìm kiếm 
        public List<NhanVien> Search(List<NhanVien> tt, string tenNhanVien)
        {
            List<NhanVien> tam = new List<NhanVien>();
            foreach(NhanVien s in tt)
                if (s.TenNhanVien.Contains(tenNhanVien))
                {
                    tam.Add(s);
                }
            return tam;
        }
    }
}
