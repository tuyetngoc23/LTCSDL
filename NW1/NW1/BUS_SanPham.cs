using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NW1
{
    class BUS_SanPham
    {
        DAO_SanPham DaoSp;
        public BUS_SanPham()
        {
            DaoSp = new DAO_SanPham();
        }
        public void LayDSLSP(ComboBox cb)
        {
            cb.DataSource = DaoSp.LayDSLSP();
            cb.DisplayMember = "CategoryName";
            cb.ValueMember = "CategoryID";
        }
        public void LayDSNCC(ComboBox cb)
        {
            cb.DataSource = DaoSp.LayDSNCC();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "SupplierID";
        }
        public void LayDSSP(DataGridView dg)
        {
            dg.DataSource = DaoSp.LayDSSP();
        }
        public void SuaSP(int maSp, string tenSp, int sl, double gia, int maLSP, int maNCC)
        {
            DaoSp.SuaSP(maSp, tenSp, sl, gia, maLSP,maNCC);
        }
    }
}
