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
            chinhDep();
        }

        public void chinhDep()
        {
            gVDH.Columns[0].Width = (int)(gVDH.Width * 0.2);
            gVDH.Columns[1].Width = (int)(gVDH.Width * 0.25);
            gVDH.Columns[2].Width = (int)(gVDH.Width * 0.25);
            gVDH.Columns[3].Width = (int)(gVDH.Width * 0.25);
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
            Order d = new Order();
            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachHang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());
            busDH.ThemDonHang(d);
            gVDH.Columns.Clear();
            busDH.LayDSDH(gVDH);
            chinhDep();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Order d = new Order();
            d.OrderID = int.Parse(txtMaDH.Text);
            d.OrderDate = dtpNgayDH.Value;
            d.CustomerID = cbKhachHang.SelectedValue.ToString();
            d.EmployeeID = int.Parse(cbNhanVien.SelectedValue.ToString());
            busDH.SuaDH(d);
            gVDH.Columns.Clear();
            busDH.LayDSDH(gVDH);
            chinhDep();
        }

        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int maDH = int.Parse(gVDH.CurrentRow.Cells["OrderID"].Value.ToString());
            CTDH c = new CTDH();
            c.maDH = maDH;
            c.ShowDialog();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            
            busDH.XoaDH(gVDH.Rows[gVDH.CurrentRow.Index].Cells["OrderID"].Value.ToString());
            gVDH.Columns.Clear();
            busDH.LayDSDH(gVDH);
            chinhDep();
        }
        
        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btThemCTDH_Click(object sender, EventArgs e)
        {
            int maDH = int.Parse(gVDH.CurrentRow.Cells["OrderID"].Value.ToString());
            FDatHang fDatHang = new FDatHang();
            fDatHang.maDH = maDH;
            fDatHang.ShowDialog();
        }
    }
}
