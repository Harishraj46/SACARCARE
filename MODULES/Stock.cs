using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class Stock : Form
    {
        SqlDataReader dr;
        public Stock()
        {
            InitializeComponent();
            loadStock();
        }

        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            loadStock();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Stockreg stk = new Stockreg(this);
            stk.btn_update.Enabled = true;
            stk.ShowDialog();
        }
        

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStock.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                
                Stockreg stk = new Stockreg(this);
                stk.lblstid.Text = dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString();
                stk.txt_stock.Text = dgvStock.Rows[e.RowIndex].Cells[2].Value.ToString();
                stk.txt_price.Text = dgvStock.Rows[e.RowIndex].Cells[3].Value.ToString();
                stk.txt_abl.Text = dgvStock.Rows[e.RowIndex].Cells[4].Value.ToString();


                stk.btn_save.Enabled = false;
                stk.ShowDialog();
            }
            else if (colName == "Delete") 
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM tbl_stock WHERE id LIKE'" + dgvStock.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Service type data has been successfully removed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            loadStock();
        }
        public void loadStock()
        {
            try
            {
                Connectdb();
                int i = 0;
                dgvStock.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM tbl_stock WHERE stock LIKE '%" + txt_search.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    
                    dgvStock.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
    
        
}
