using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NguyenDangTinh
{
    public class HangHoa
    {
        
        public List<CuaHang> dsCuaHang= new List<CuaHang>(); 
        
        public HangHoa(string tenfile)
        {
            StreamReader f = new StreamReader(tenfile); 
            while (true) 
            {
                string st = f.ReadLine();   
                if (string.IsNullOrEmpty(st)) break;
                    string [] ds = st.Split(';');  
               
                CuaHang ch = new CuaHang(ds[0],ds[1],double.Parse(ds[2]),int.Parse(ds[3]),DateTime.Parse(ds[4]),double.Parse(ds[5]));

                dsCuaHang.Add(ch);
            }
        }
        public void Sua(string maHang,string tenHang, double gia, int soLuong,DateTime ngayNhap, double thanhTien)
        {
            foreach (CuaHang ch in dsCuaHang)
            {
                if (ch.MaHang.Equals(maHang))
                {
                    ch.TenHang = tenHang;
                    ch.Gia = gia;
                    ch.SoLuong = soLuong;
                    ch.NgayNhap = ngayNhap;
                    ch.ThanhTien = thanhTien*soLuong;
                }
            }
        }

        public List<CuaHang> Tim(string tenHang)
        {
            List<CuaHang> dstam = new List<CuaHang>();
            foreach (CuaHang ch in dsCuaHang)
                if (ch.TenHang.Trim().ToLower().Equals(tenHang.ToLower()))
                    dstam.Add(ch);
            return dstam;
        }

        public void LuuFile(string tenfile)
        {
            StreamWriter f = new StreamWriter(tenfile);
            foreach (CuaHang ch in dsCuaHang)
            {
                string st = ch.MaHang + ";" + ch.TenHang+ ";" + ch.Gia + ";" + ch.SoLuong+ ";" +
                    ch.NgayNhap + ";" + ch.ThanhTien;
                f.WriteLine(st);
            }
            f.Close();
        }
    }
}
