using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBanHang
{
    class BUS_DonHang
    {
        DAO_DonHang daoDH;
        public BUS_DonHang()
        {
            daoDH = new DAO_DonHang();
        }
        public void LayDSDH(DataGridView dg)
        {
            dg.DataSource = daoDH.LayDSDH3();
        }
        public void LayDSKH(ComboBox cb)
        {
            cb.DataSource = daoDH.LayDSKH();
            cb.DisplayMember = "CompanyName";
            cb.ValueMember = "CustomerID";
        }
        public void LayDSNV(ComboBox cb)
        {
            cb.DataSource = daoDH.LayDSNV();
            cb.DisplayMember = "LastName";
            cb.ValueMember = "EmployeeID";
        }
    }
}
