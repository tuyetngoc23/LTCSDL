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
        BUS_DonHang busDH;
        public FDatHang()
        {
            InitializeComponent();
            busDH = new BUS_DonHang();
        }

        private void FDatHang_Load(object sender, EventArgs e)
        {
            txtMaDH.Text = maDH.ToString();
        }
    }
}
