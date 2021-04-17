using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NW1
{
    public partial class FSanPham : Form
    {
        BUS_SanPham busSp;
        public FSanPham()
        {
            InitializeComponent();
            busSp = new BUS_SanPham();
        }

        private void FSanPham_Load(object sender, EventArgs e)
        {
            busSp.LayDSLSP(cbLoaiSP);
            busSp.LayDSNCC(cbNCC);
            busSp.LayDSSP(dGSP);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dGSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dGSP.Rows.Count)
            {
                txtTenSP.Text = dGSP.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                txtSoLuong.Text = dGSP.Rows[e.RowIndex].Cells["UnitsInStock"].Value.ToString();
                txtDonGia.Text = dGSP.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                cbLoaiSP.Text = dGSP.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
                cbNCC.Text = dGSP.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString(); 
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            int maSp, maLSP, maNCC;
            maSp = int.Parse(dGSP.CurrentRow.Cells[0].Value.ToString());
            maLSP = int.Parse(cbLoaiSP.SelectedValue.ToString());
            maNCC = int.Parse(cbNCC.SelectedValue.ToString());

            busSp.SuaSP(maSp, txtTenSP.Text, int.Parse(txtSoLuong.Text), double.Parse(txtDonGia.Text), maLSP, maNCC);
            dGSP.Columns.Clear();
            busSp.LayDSSP(dGSP);
        }

    }
}
