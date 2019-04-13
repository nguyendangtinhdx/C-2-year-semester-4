using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap5_LinQ.BO
{
    public class LoaiBO
    {
        dbDataContext db = new dbDataContext();
        public List<loai> getLoai()
        {
            return db.loais.ToList();
        }
    }
}
