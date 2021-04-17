using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBanHang
{
    
    class DAO_DonHang
    {
        NWDataContext db;
        public DAO_DonHang()
        {
            db = new NWDataContext();
        }

        public IEnumerable<Order> LayDSDH()
        {
            var dsDH = from i in db.Orders select i;
            return dsDH;
        }
        public List<Order> LayDSDH2()
        {
            var dsDH = db.Orders.Select(s => s).ToList();
            return dsDH;
        }
        public dynamic LayDSDH3()
        {
            dynamic dsDH = db.Orders.Select(s => new
            {
                                        s.OrderID,
                                        s.OrderDate,
                                        s.Customer.CompanyName,
                                        s.Employee.EmployeeID,
                                        s.Employee.LastName
                                        });
            return dsDH;
        }
        public dynamic LayDSKH()
        {
            dynamic dsKH = db.Customers.Select(s => new
                                                {
                                                    s.CustomerID,
                                                    s.CompanyName
                                                });
            return dsKH;
        }

        public dynamic LayDSNV()
        {
            dynamic dsNV = db.Employees.Select(s => new { 
                s.EmployeeID,
                s.LastName
            });
            return dsNV;
        }

        public void ThemDH()
        {
            
        }
    }
}
