using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class CashCus : Form
    {
        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        Bill cash;
        public CashCus(Bill csh)
        {
            InitializeComponent();
            cash = csh;
            loadCustomer();
        }

        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                cash.customerId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString());
                cash.vehicleTypeId = int.Parse(dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            else return;
            this.Dispose();
            cash.PanelCash.Height = 1;
        }
        public void loadCustomer()
        {
            try
            {
                Connectdb();
                int i = 0; 
                dgvCustomer.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM tbl_customer WHERE CONCAT (name,phone,address) LIKE '%" + textSearch.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                   
                    dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            loadCustomer(); 
        }
    }
}
