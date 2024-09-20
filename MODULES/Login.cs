using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_2_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();


            if (txt_pwd.Text.Trim() == "" || txt_uname.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in all data");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8J3LHJL;Initial Catalog=sa_car;Integrated Security=True;"))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", txt_uname.Text.Trim());
                    cmd.Parameters.AddWithValue("@cpassword", txt_pwd.Text.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) 
                    {
                        string role = reader["Role"].ToString();

                        if (role == "sales")
                        {
                            MessageBox.Show("Welcome to SA CAR CARE");
                            
                            dashboard.btn_emp.Visible = false; 
                            dashboard.btn_setting.Visible = false;
                            dashboard.Show();
                            this.Hide();
                        }
                        else if (role == "admin")
                        {
                            MessageBox.Show("Welcome to SA CAR CARE");
                            
                            dashboard.btn_emp.Visible = true; 

                            dashboard.btn_setting.Visible = true; 
                            dashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

            private void txt_pwd_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void cbshowpwd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshowpwd.Checked)
            {
                txt_pwd.UseSystemPasswordChar = true;
            }
            else
            {
                txt_pwd.UseSystemPasswordChar = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register r=new Register();
            r.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
