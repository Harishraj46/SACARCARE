using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class Employee : Form
    {
        SqlDataReader dr;

        public Employee()
        {
            
            InitializeComponent();
            loademployee();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            string colName = dgvemp.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                
                emp_reg empreg = new emp_reg();
                empreg.lbledit.Text = dgvemp.Rows[e.RowIndex].Cells[1].Value.ToString();
                empreg.txt_name.Text = dgvemp.Rows[e.RowIndex].Cells[2].Value.ToString();
                string dateString = dgvemp.Rows[e.RowIndex].Cells[3].Value.ToString();
                DateTime dob;
                if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                {
                    empreg.dtdob.Value = dob;
                }
                else
                {
                    MessageBox.Show("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                    
                }

                empreg.rdmale.Checked = dgvemp.Rows[e.RowIndex].Cells[6].Value.ToString() == "Male" ? true : false;
                empreg.txt_address.Text = dgvemp.Rows[e.RowIndex].Cells[5].Value.ToString();
                empreg.cbrole.Text = dgvemp.Rows[e.RowIndex].Cells[6].Value.ToString();
                empreg.txt_ph.Text = dgvemp.Rows[e.RowIndex].Cells[7].Value.ToString();
                empreg.txt_salary.Text = dgvemp.Rows[e.RowIndex].Cells[8].Value.ToString();
                empreg.txt_pwd.Text = dgvemp.Rows[e.RowIndex].Cells[9].Value.ToString();

                empreg.btn_save.Enabled = false;
                empreg.ShowDialog();
            }
            else if (colName == "Delete") 
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM tbl_employee WHERE id LIKE'" + dgvemp.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Employer data has been successfully removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            emp_reg emp=new emp_reg();
            emp.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            loademployee();
        }

        public void loademployee()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                int i = 0; 
                dgvemp.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ID, Name, CONVERT(varchar, CONVERT(date, dob), 103) as dob, gender, address, role, phone, salary, password FROM tbl_employee WHERE CONCAT(name, address, role) LIKE '%" + txt_search.Text + "%'", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvemp.Rows.Add(i, dr["ID"].ToString(), dr["Name"].ToString(), dr["dob"].ToString(), dr["gender"].ToString(), dr["address"].ToString(), dr["role"].ToString(), dr["phone"].ToString(), dr["salary"].ToString(), dr["password"].ToString());
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











