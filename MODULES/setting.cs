using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
    public partial class setting : Form
    {
        SqlDataReader dr;
        public SqlConnection conn;
        public SqlCommand cmd;
        bool detail = false;

        public setting()
        {
            InitializeComponent();
            loadVehicleType();
        }



        public void connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
        }

        private void setting_Load(object sender, EventArgs e)
        {

        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            loadVehicleType();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            vehicle_type vt = new vehicle_type();
            vt.btn_update.Enabled = false;
            vt.ShowDialog();
        }
        private void dgvvehicletype_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            connectdb();
            string colName = dgvvehicletype.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                vehicle_type vt = new vehicle_type();
                vt.lblVid.Text = dgvvehicletype.Rows[e.RowIndex].Cells[1].Value.ToString();
                vt.txt_name.Text = dgvvehicletype.Rows[e.RowIndex].Cells[2].Value.ToString();
                vt.cbclass.Text = dgvvehicletype.Rows[e.RowIndex].Cells[3].Value.ToString();


                vt.btn_save.Enabled = false;
                vt.ShowDialog();
            }
            else if (colName == "Delete") 
            {
                try
                {
                    connectdb();
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM tbl_vehicletype WHERE id LIKE'" + dgvvehicletype.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Vehicle type data has been successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            loadVehicleType();
        }


        public void loadVehicleType()
        {
            try
            {
                connectdb();
                int i = 0; 
                dgvvehicletype.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM tbl_vehicletype WHERE CONCAT (name,class) LIKE '%" + txt_search.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;                  
                    dgvvehicletype.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void loadCompany()
        {
            try
            {
                connectdb();
                cmd = new SqlCommand("SELECT * FROM tbCompany", conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    detail = true;
                    txtcomname.Text = dr["name"].ToString();
                    txtcomaddress.Text = dr["address"].ToString();
                }
                else
                {
                    txtcomname.Clear();
                    txtcomaddress.Clear();
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connectdb();
                if (MessageBox.Show("Save company detail?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (detail)
                    {
                        cmd = new SqlCommand("UPDATE tbl_company SET name=@name, address=@address WHERE companyId=@companyId", conn);
                        cmd.Parameters.AddWithValue("@name", txtcomname.Text);
                        cmd.Parameters.AddWithValue("@address", txtcomaddress.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO tbl_company (name,address) VALUES (@name, @address)", conn);
                        cmd.Parameters.AddWithValue("@name", txtcomname.Text);
                        cmd.Parameters.AddWithValue("@address", txtcomaddress.Text);
                        cmd.ExecuteNonQuery();
                    
                }
                MessageBox.Show("Company detail has been successfully saved!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtcomname.Clear();
            txtcomaddress.Clear();
        }

    }

}        
            










