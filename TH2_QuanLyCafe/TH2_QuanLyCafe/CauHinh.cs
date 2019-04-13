using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2_QuanLyCafe
{
    public class CauHinh
    {
        public static string manv, hoten, quyen; 
        public static QlCaFeDbDataContext db; 
        public CauHinh() 
        { 
            db = new QlCaFeDbDataContext(); 
        }   
    }
}
