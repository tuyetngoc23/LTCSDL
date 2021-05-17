using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBanHang
{
    class DAO_SanPham
    {
        public NWDataContext db;
        public DAO_SanPham()
        {
            db = new NWDataContext();
        }

        public dynamic LayDSSP()
        {
            var ds = db.Products.Select(s => new { 
                                        s.ProductID,
                                        s.ProductName
                                        });
            return ds;
        }

        public Product HienThiDSSP(int maSp)
        {
            Product sp = db.Products.FirstOrDefault(s => s.ProductID == maSp);
            return sp;
        }
    }
}
