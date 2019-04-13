using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // thư viện truy xuất file
namespace BaiTap3
{
    public class CuaHang
    {
        public List<Sach> ds = new List<Sach>();
        public CuaHang()
        {
            //Sach s1 = new Sach("s1", "Cấu trúc dữ liệu 1", "KK1", 100); // 2 byte
            //ds.Add(s1);  // ds chứa địa chỉ, 
            //Sach s2 = new Sach("s2", "Cấu trúc dữ liệu 2", "KK2", 200);
            //ds.Add(s2);
            //Sach s3 = new Sach("s3", "Cấu trúc dữ liệu 3", "KK3", 300);
            //ds.Add(s3);
            //Sach s4 = new Sach("s4", "Cấu trúc dữ liệu 4", "KK4", 400);
            //ds.Add(s4);
            //Sach s5 = new Sach("s5", "Cấu trúc dữ liệu 5", "KK5", 500);
            //ds.Add(s5);
            //Sach s6 = new Sach("s6", "Cấu trúc dữ liệu 6", "KK6", 600);
            //ds.Add(s6);

            // Mở file để đọc
            StreamReader f = new StreamReader("data.txt");
            while (true)
            {
                string ms = f.ReadLine();
                if (string.IsNullOrEmpty(ms)) // đọc hết file
                    break;
                string tensach = f.ReadLine();
                string tacgia = f.ReadLine();
                string gia = f.ReadLine();

                Sach s = new Sach(ms, tensach, tacgia, long.Parse(gia));
                ds.Add(s);
            }
            f.Close();
        }
        bool KtMa(List<Sach> ds, string masach)
        {
            foreach (Sach s in ds) // duyệt các sách trong ds
                if (s.Masach.Equals(masach))
                    return true;
                return false;
        }
        // thêm sách
        public List<Sach> Add(List<Sach> ds, string masach, string tensach, string tacgia, long gia)  
        {
            if (KtMa(ds,masach) == false)
            {
                Sach s = new Sach(masach, tacgia, tacgia, gia);
                ds.Add(s);
                return ds;
            }

            return null;
        }
        //sửa sách
        
    }
}
