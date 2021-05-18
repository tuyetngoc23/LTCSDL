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

        public ProductModel HienThiDSSP2(int maSp)
        {
            dynamic sp1 = db.Products
                                        .Where(s => s.ProductID == maSp)
                                        .Select(s => new 
                                        {
                                           s.ProductID,
                                            s.ProductName,
                                            s.UnitPrice,
                                             s.Category.CategoryName,
                                            s.Supplier.CompanyName
                                        }).FirstOrDefault();
            ProductModel sp = db.Products
                                        .Where(s=> s.ProductID == maSp)
                                        .Select(s => new ProductModel()
                                        {
                                            ProductID = s.ProductID,
                                            ProductName = s.ProductName,
                                            UnitPrice = s.UnitPrice,
                                            CategoryName = s.Category.CategoryName,
                                            CompanyName = s.Supplier.CompanyName
                                        }).FirstOrDefault();
            return sp;
        }
    }
    public class ProductModel
    {
        private int productID;
        private string productName;
        private System.Nullable<decimal> unitPrice;
        private string categoryName;
        private string companyName;


        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public decimal? UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
    }
}
