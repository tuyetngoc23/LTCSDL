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
    public partial class CTDH : Form
    {
        public int maDH;
        BUS_DonHang busDH;
        public CTDH()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }
        public void chinhDep()
        {
            gVCTDH.Columns[0].Width = (int)(gVCTDH.Width * 0.2);
            gVCTDH.Columns[1].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[2].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[3].Width = (int)(gVCTDH.Width * 0.25);
        }

        private void CTDH_Load(object sender, EventArgs e)
        {
            txtMaDH.Text = maDH.ToString();
            busDH.LayCTDH(gVCTDH, maDH);
            chinhDep();
        }

        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVCTDH.Rows.Count)
            {
                txtMaSP.Text = gVCTDH.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtDonGia.Text = gVCTDH.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                txtSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
            }
        }
    }
}
