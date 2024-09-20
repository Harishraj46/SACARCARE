using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SACARCARE
{
    public partial class addservice : Form
    {
      Service service;
        public addservice(Service ser)
        {
            InitializeComponent();
            service=ser;
        }

        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Connectdb();
                if (txt_name.Text != "" && txt_price.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to register this service?", "Service Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       
                        SqlCommand cmd = new SqlCommand("sp_insert", conn);
                        
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@name", txt_name.Text);
                            cmd.Parameters.AddWithValue("@price", txt_price.Text);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Service has been successfully registered!");
                            Clear();

                         service.loadService();

                    }
                }
                else
                {         
                    MessageBox.Show("Required data field!", "Warning");
                    return; 
                }
            }
            catch (Exception ex)
            {
             
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Connectdb();
                if (txt_name.Text != "" && txt_price.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to edit this service?", "Service Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("sp_servupdate", conn);


                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", lblSid.Text);
                            cmd.Parameters.AddWithValue("@name", txt_name.Text);
                            cmd.Parameters.AddWithValue("@price", txt_price.Text); 
                             conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Service has been successfully edited!");
                            this.Dispose();

                    }
                    else
                    {
                        MessageBox.Show("Edited service failed!!");
                    }
                }
                else
                {
                    MessageBox.Show("Required data fields are empty!", "Warning");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txt_name.Clear();
            txt_price.Clear();

            btn_save.Enabled = true;
            btn_update.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
