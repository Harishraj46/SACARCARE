using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public bool IsEmailValid(string email)
        {
            string pattern = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";
            Regex r = new Regex(pattern);
            return r.IsMatch(email);
        }
        

       
private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_uname.Text.Trim() != "" && txt_spwd.Text.Trim() != "" && txt_email.Text.Trim() != "" && txt_cpwd.Text.Trim() != "" && txt_mbl.Text.Trim() != "")
                {
                    string emailaddress = txt_email.Text;
                    bool isvalid = IsEmailValid(emailaddress);
                    if (isvalid)
                    {

                        if (txt_spwd.Text.Trim().Length >= 8)
                        {
                            if (txt_mbl.Text.Trim().Length == 10)
                            {

                                if (txt_spwd.Text.Trim() == txt_cpwd.Text.Trim())
                                {
                                    SqlConnection conn = new SqlConnection(@"Data source=DESKTOP-8J3LHJL;initial catalog=sa_car;integrated security=true;");
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("sp_register", conn);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    SqlParameter p1 = new SqlParameter("@name", SqlDbType.VarChar);
                                    cmd.Parameters.Add(p1).Value = txt_uname.Text.Trim();
                                    SqlParameter p2 = new SqlParameter("@email", SqlDbType.VarChar);
                                    cmd.Parameters.Add(p2).Value = txt_email.Text.Trim();
                                    SqlParameter p3 = new SqlParameter("@spassword", SqlDbType.VarChar);
                                    cmd.Parameters.Add(p3).Value = txt_spwd.Text.Trim();
                                    SqlParameter p4 = new SqlParameter("@cpassword", SqlDbType.VarChar);
                                    cmd.Parameters.Add(p4).Value = txt_cpwd.Text.Trim();
                                    SqlParameter p5 = new SqlParameter("@mblnum", SqlDbType.VarChar);
                                    cmd.Parameters.Add(p5).Value = txt_mbl.Text.Trim();
                                    int a = cmd.ExecuteNonQuery();
                                    if (a > 0)
                                    {
                                        MessageBox.Show("registered successfully");
                                    }
                                    else
                                    {
                                        MessageBox.Show("registration failed");
                                        conn.Close();
                                    }


                                }
                                else
                                {
                                    MessageBox.Show("set password and confirm password must be same");
                                }

                            }
                            else
                            {

                                MessageBox.Show("Mobile Number should be in 10 digit");
                            }



                        }
                        else
                        {
                            MessageBox.Show("password should be atleast 8 charachters ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("enter email in correct format");
                    }


                }
                else
                {
                    MessageBox.Show("fill all data");

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_uname.Clear();
            txt_email.Clear();
            txt_spwd.Clear();
            txt_cpwd.Clear();
            txt_mbl.Clear();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Login lg=new Login();
            lg.Show();
            this.Hide();
        }
    }
}
