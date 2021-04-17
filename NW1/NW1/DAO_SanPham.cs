using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NW1
{
    class DAO_SanPham
    {
        SqlConnection conn;
        string chuoiKetNoi;
        SqlDataAdapter da;
        public DAO_SanPham()
        {
            chuoiKetNoi = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            conn = new SqlConnection(chuoiKetNoi);
        }
        public DataTable LayDSLSP()
        {
            DataSet ds = new DataSet();
            string query = "select CategoryID,CategoryName from Categories";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable LayDSNCC()
        {
            DataSet ds = new DataSet();
            string query = "select SupplierID, CompanyName from Suppliers";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable LayDSSP()
        {
            DataSet ds = new DataSet();
            string query = "select Products.ProductID, ProductName, UnitsInStock, UnitPrice, Categories.CategoryName, Suppliers.CompanyName from Categories, Suppliers, Products where Products.CategoryID = Categories.CategoryID and Products.SupplierID = Suppliers.SupplierID";
            da = new SqlDataAdapter(query, conn);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void SuaSP(int maSp, string tenSp, int sl, double gia, int maLSP, int maNCC)
        {
            SqlCommand cmd;
            try
            {
                string query = string.Format("update Products set ProductName ='{0}', UnitPrice={1}, UnitsInStock={2}, CategoryID={3}, SupplierID={4} where ProductID={5}",
                        tenSp, gia, sl, maLSP, maNCC, maSp);
                cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //xu ly loi
            }
            finally
            {
                conn.Close();
            }
        }
        
    }
}
