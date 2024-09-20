using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Globalization;
using System.Xml.Linq;
using System.Drawing.Drawing2D;

namespace SACARCARE
{
    public partial class emp_reg : Form
    {
        Employee employee=new Employee();
        
        public emp_reg()
        {
            InitializeComponent();
           
        }

        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private void employee_reg_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void rdmale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Connectdb();
            if (MessageBox.Show("Are you sure you want to edit this record?", "Employer Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                cmd = new SqlCommand("UPDATE tbl_employee SET name=@name, phone=@phone, address=@address, dob=@dob, gender=@gender, role=@role, salary=@salary, password=@password WHERE id=@id",conn);
                cmd.Parameters.AddWithValue("@id", lbledit.Text);
                cmd.Parameters.AddWithValue("@name", txt_name.Text);
                cmd.Parameters.AddWithValue("@phone", txt_ph.Text);
                cmd.Parameters.AddWithValue("@address", txt_address.Text);
                cmd.Parameters.AddWithValue("@dob", dtdob.Value);
                cmd.Parameters.AddWithValue("@gender", rdmale.Checked ? "Male" : "Female");
                cmd.Parameters.AddWithValue("@role", cbrole.Text);
                cmd.Parameters.AddWithValue("@salary", txt_salary.Text);
                cmd.Parameters.AddWithValue("@password", txt_pwd.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Employer has been successfully registered!");
                Clear();
                this.Dispose();
                employee.loademployee();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Clear();
            btn_update.Enabled = false;
            btn_save.Enabled = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (txt_address.Text != "" && txt_ph.Text != "" && txt_pwd.Text != "" && txt_salary.Text != "" && txt_name.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to register this employee?", "Employee Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Connectdb();

                        conn.Open();

                        SqlCommand cmd = new SqlCommand("sp_employee", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
                        cmd.Parameters.Add(p1).Value = txt_name.Text.Trim();

                        DateTime dob;
                        if (DateTime.TryParseExact(dtdob.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dob))
                        {
                            SqlParameter p2 = new SqlParameter("@dob", SqlDbType.Date);
                            cmd.Parameters.Add(p2).Value = dob;
                        }
                        else
                        {

                            MessageBox.Show("Invalid date format. Please enter the date in dd/mm/yyyy format.");
                            return;
                        }

                        SqlParameter p3 = new SqlParameter("@gender", SqlDbType.VarChar);
                        cmd.Parameters.Add(p3).Value = rdmale.Checked ? "male" : "female";

                        SqlParameter p4 = new SqlParameter("@address", SqlDbType.VarChar);
                        cmd.Parameters.Add(p4).Value = txt_address.Text.Trim();

                        SqlParameter p5 = new SqlParameter("@role", SqlDbType.VarChar);
                        cmd.Parameters.Add(p5).Value = cbrole.Text.Trim();

                        SqlParameter p6 = new SqlParameter("@phone", SqlDbType.VarChar);
                        cmd.Parameters.Add(p6).Value = txt_ph.Text.Trim();

                        decimal salary;
                        if (decimal.TryParse(txt_salary.Text.Trim(), out salary))
                        {
                            SqlParameter p7 = new SqlParameter("@salary", SqlDbType.Decimal);
                            cmd.Parameters.Add(p7).Value = salary;
                        }
                        else
                        {

                            MessageBox.Show("Invalid salary format. Please enter a valid decimal number.");
                            return;
                        }

                        SqlParameter p8 = new SqlParameter("@password", SqlDbType.VarChar);
                        cmd.Parameters.Add(p8).Value = txt_pwd.Text.Trim();

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Employee registered successfully");
                        conn.Close();
                        Clear();

                    }

                }
                else 
                {
                    MessageBox.Show("Required data Field!", "Warning");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }  

        public void Clear() 
        {
            txt_address.Clear();
            txt_name.Clear();
            txt_ph.Clear();
            txt_salary.Clear();
            txt_pwd.Clear();

            dtdob.Value=DateTime.Now;
            cbrole.SelectedIndex = 0;
            
        }

        public void checkField()
        {
            

        }
        private void dtdob_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
