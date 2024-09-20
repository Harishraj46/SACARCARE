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
    public partial class customer : Form
    {
        SqlDataReader dr;
        public customer()
        {
            InitializeComponent();
            loadCustomer();
        }

        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }


        private void dgvcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvcustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
               
                customer_reg cusreg = new customer_reg(this);
                cusreg.lblCid.Text = dgvcustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                cusreg.txt_name.Text = dgvcustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                cusreg.txt_ph.Text = dgvcustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                cusreg.txt_carno.Text = dgvcustomer.Rows[e.RowIndex].Cells[4].Value.ToString();
                cusreg.txt_carmodel.Text = dgvcustomer.Rows[e.RowIndex].Cells[5].Value.ToString();
                cusreg.vid = vehicleIdbyName(dgvcustomer.Rows[e.RowIndex].Cells[6].Value.ToString());
                cusreg.txt_address.Text = dgvcustomer.Rows[e.RowIndex].Cells[7].Value.ToString();
                cusreg.udpoints.Text = dgvcustomer.Rows[e.RowIndex].Cells[8].Value.ToString();

                cusreg.btn_save.Enabled = false;
                cusreg.udpoints.Enabled = true;
                cusreg.ShowDialog();

            }
            else if (colName == "Delete") 
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM tbl_customer WHERE id LIKE'" + dgvcustomer.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Customer data has been successfully removed!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            loadCustomer();
        }
        public void loadCustomer()
        {
            Connectdb();
            try
            {
                int i = 0; 
                dgvcustomer.Rows.Clear();
                cmd = new SqlCommand("SELECT C.id,C.name, phone, carno, carmodel, V.name, address, points FROM tbl_customer AS C INNER JOIN tbl_vehicletype AS V ON C.vid=V.id WHERE CONCAT (C.name,carno,carmodel,address) LIKE '%" + txtSearch.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    
                    dgvcustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int vehicleIdbyName(string str)
        {
            int i = 0;
            cmd = new SqlCommand("SELECT id FROM tbl_vehicletype WHERE name LIKE '" + str + "' ", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                i = int.Parse(dr["id"].ToString());
            }
            conn.Close();
            return i;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customer_reg cusreg = new customer_reg(this);
            cusreg.btn_update.Enabled = false;
            cusreg.ShowDialog();
        }

    }
}
