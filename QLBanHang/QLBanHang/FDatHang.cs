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
        }

        void HienThiDSSP(string ma)
        {
            int maSp = int.Parse(ma);
            Product p = busDH.HienThiDSSP(maSp);
            txtDonGia.Text = p.UnitPrice.ToString();
            txtLoaiSP.Text = p.CategoryID.ToString();
            txtNCC.Text = p.SupplierID.ToString();
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (co)
            {
                HienThiDSSP(cbSP.SelectedValue.ToString()); 
            }
        }
    }
}
