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
    public partial class Service : Form
    {
        SqlDataReader dr;
        public Service()
        {
            InitializeComponent();
            loadService();
        }

        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addservice serv=new addservice(this);
            serv.btn_update.Enabled = true;
            serv.ShowDialog();
        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvService.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                
                addservice serv = new addservice(this);
                serv.lblSid.Text = dgvService.Rows[e.RowIndex].Cells[1].Value.ToString();
                serv.txt_name.Text = dgvService.Rows[e.RowIndex].Cells[2].Value.ToString();
                serv.txt_price.Text = dgvService.Rows[e.RowIndex].Cells[3].Value.ToString();


                serv.btn_save.Enabled = false;
                serv.ShowDialog();
            }
            else if (colName == "Delete") 
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM tbl_service WHERE id LIKE'" + dgvService.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Service type data has been successfully removed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            loadService();
        }

        public void loadService()
        {
            try
            {
                Connectdb();
                int i = 0; 
                dgvService.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM tbl_service WHERE name LIKE '%" + txtSearch.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                   
                    dgvService.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
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
