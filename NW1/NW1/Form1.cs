using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NW1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        
        string chuoiKetNoi;
        void KetNoi()
        {
            chuoiKetNoi = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            conn = new SqlConnection(chuoiKetNoi);
        }

        DataTable LayDSNhanVien()
        {
            string query = "Select * from Employees";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            KetNoi();
            dGNhanVien.DataSource = LayDSNhanVien();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = cmd = new SqlCommand();
            try
            {
                string query = string.Format(
                        "set dateformat dmy insert into Employees(LastName,FirstName , BirthDate, Address, HomePhone) values (N'{0}', '{1}', '{2}','{3}','{4}')", txtHoten.Text, txtHoten.Text, dtpNgaySinh.Value.ToShortDateString(), txtDiaChi.Text, txtDienThoai.Text);
                cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }
            dGNhanVien.Columns.Clear();
            dGNhanVien.DataSource = LayDSNhanVien();
        }

        private void dGNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0 &&e.RowIndex<dGNhanVien.Rows.Count-1)
            {
                txtHoten.Text = dGNhanVien.Rows[e.RowIndex].Cells["LastName"].Value.ToString() + " " + dGNhanVien.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                txtDiaChi.Text = dGNhanVien.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtDienThoai.Text = dGNhanVien.Rows[e.RowIndex].Cells["HomePhone"].Value.ToString();
                dtpNgaySinh.Text = dGNhanVien.Rows[e.RowIndex].Cells["BirthDate"].Value.ToString(); 
            }
            
        }
        public void XoaNhanVien(string index_nv)
        {

            SqlCommand cmd = cmd = new SqlCommand();
            try
            {
                string query = string.Format(
                        "delete Employees where EmployeeID="+ index_nv);
                cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception exxx)
            {

                MessageBox.Show(exxx.Message.ToString());
            }
            finally
            {
                cmd.Connection.Close();
            }

        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            XoaNhanVien(dGNhanVien.Rows[dGNhanVien.CurrentRow.Index].Cells[0].Value.ToString());

            //Lay dong dang duoc click: dGNhanVien.CurrentRow.Index
            //dGNhanVien.Rows[0].Cells["EmployeeID"].Value.ToString());

            dGNhanVien.Columns.Clear();
            dGNhanVien.DataSource = LayDSNhanVien();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = cmd = new SqlCommand();
            try
            {
                string query = string.Format(
                        "set dateformat dmy update Employees set LastName='{0}',FirstName='{5}', Address='{1}', HomePhone={2}, BirthDate={3} where EmployeeID={4}",
                        txtHoten.Text, txtDiaChi.Text,txtDienThoai.Text, dtpNgaySinh.Value.ToShortDateString(), int.Parse(dGNhanVien.Rows[dGNhanVien.CurrentRow.Index].Cells["EmployeeID"].Value.ToString()), txtHoten.Text);
                cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception exxx)
            {

                MessageBox.Show(exxx.Message.ToString());
            }
            finally
            {
                cmd.Connection.Close();
            }
            dGNhanVien.Columns.Clear();
            dGNhanVien.DataSource = LayDSNhanVien();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
