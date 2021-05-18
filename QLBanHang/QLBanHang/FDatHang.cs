using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBanHang
{
    public partial class FDatHang : Form
    {
        public int maDH;
        bool co = false;
        BUS_DonHang busDH;
        DataTable dtSanPham;
        public FDatHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }

        private void FDatHang_Load(object sender, EventArgs e)
        {
            
            txtMaDH.Text = maDH.ToString();
            busDH.LayDSSP(cbSP);
            co = true;

            dtSanPham = new DataTable();
            dtSanPham.Columns.Add("ProductID");
            dtSanPham.Columns.Add("UnitPrice");
            dtSanPham.Columns.Add("Quantity");
            dtSanPham.Columns.Add("Discount");

            dGSP.DataSource = dtSanPham;
            chinhDep();
        }
        public void chinhDep()
        {
            dGSP.Columns[0].Width = (int)(dGSP.Width * 0.2);
            dGSP.Columns[1].Width = (int)(dGSP.Width * 0.25);
            dGSP.Columns[2].Width = (int)(dGSP.Width * 0.25);
            dGSP.Columns[3].Width = (int)(dGSP.Width * 0.25);
        }

        //void HienThiDSSP(string ma)
        //{
        //    int maSp = int.Parse(ma);
        //    Product p = busDH.HienThiDSSP(maSp);
        //    txtDonGia.Text = p.UnitPrice.ToString();
        //    txtLoaiSP.Text = p.CategoryID.ToString();
        //    txtNCC.Text = p.SupplierID.ToString();
        //}
        void HienThiDSSP(string ma)
        {
            int maSp = int.Parse(ma);
            ProductModel p = busDH.HienThiDSSP2(maSp);
            txtDonGia.Text = p.UnitPrice.ToString();
            txtLoaiSP.Text = p.CategoryName.ToString();
            txtNCC.Text = p.CompanyName.ToString();
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (co)
            {
                HienThiDSSP(cbSP.SelectedValue.ToString()); 
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            bool kiemTra = true;
            foreach (DataRow item in dtSanPham.Rows)
            {
                if(item[0].ToString() == cbSP.SelectedValue.ToString())
                {
                    kiemTra = false;
                    item[2] = int.Parse(item[2].ToString()) + int.Parse(numberSL.Value.ToString());
                }
            }
            if (kiemTra)
            {
                DataRow r = dtSanPham.NewRow();
                r[0] = cbSP.SelectedValue.ToString();
                r[1] = txtDonGia.Text;
                r[2] = numberSL.Value.ToString();
                r[3] = txtDiscount.Text;

                dtSanPham.Rows.Add(r); 
            }
        }
    }
}
