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
    public partial class FDonHang : Form
    {
        BUS_DonHang busDH;
        public FDonHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }

        private void FDonHang_Load(object sender, EventArgs e)
        {
            busDH.LayDSDH(gVDH);
            busDH.LayDSKH(cbKhachHang);
            busDH.LayDSNV(cbNhanVien);
            gVDH.Columns[0].Width = (int)(gVDH.Width * 0.15);
            gVDH.Columns[1].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[2].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[3].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[4].Width = (int)(gVDH.Width * 0.2);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                dtpNgayDH.Text = gVDH.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString(); 
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {

        }

    }
}
