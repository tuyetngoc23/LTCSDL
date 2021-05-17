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
        DAO_SanPham daoSP;
        public BUS_DonHang()
        {
            daoDH = new DAO_DonHang();
            daoSP = new DAO_SanPham();
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

        public void ThemDonHang(Order donHang)
        {
            try
            {
                daoDH.ThemDH(donHang);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void SuaDH(Order donHang)
        {
            if (daoDH.SuaDH(donHang))
                MessageBox.Show("success!!!");
            else
                MessageBox.Show("failed!!!");
        }
        public void XoaDH(String maDH)
        {
            try
            {
                daoDH.XoaDH(maDH);
                MessageBox.Show("success!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void LayCTDH(DataGridView dg, int maDH)
        {
            dg.DataSource = daoDH.LayCTDH(maDH);
        }

        public void LayDSSP(ComboBox cb)
        {
            cb.DataSource = daoSP.LayDSSP();
            cb.DisplayMember = "ProductName";
            cb.ValueMember = "ProductID";
        }

        public Product HienThiDSSP(int maSp)
        {
            Product s = daoSP.HienThiDSSP(maSp);
            return s;
        }
    }
}
