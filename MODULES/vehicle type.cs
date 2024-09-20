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
using System.Xml.Linq;

namespace SACARCARE
{
    public partial class vehicle_type : Form
    {
       
        public vehicle_type()
        {
          
            InitializeComponent();
            
        }
        public SqlConnection conn;
        public SqlCommand cmd;
        public void connectdb() 
        {
           string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
           conn = new SqlConnection(connectionString);
           SqlCommand cmd = new SqlCommand();
        }

        private void vehicle_type_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                connectdb();
                if (txt_name.Text == "")
                {
                    MessageBox.Show("Required vehicle type name!", "Warning");
                    return; 
                }
                if (MessageBox.Show("Are you sure you want to register this vehicle type?", "Vehicle Type Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("INSERT INTO tbl_vehicletype(name,class)VALUES(@name,@class)", conn);
                    cmd.Parameters.AddWithValue("@name", txt_name.Text);
                    cmd.Parameters.AddWithValue("@class", cbclass.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Vehicle type has been successfully registered!");
                    Clear();
                    
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
                connectdb();
                if (txt_name.Text == "")
                {
                    MessageBox.Show("Required vehicle type name!", "Warning");
                    return; 
                }
                if (MessageBox.Show("Are you sure you want to edit this vehicle type?", "Vehicle Type Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("UPDATE tbl_vehicletype SET name=@name, class=@class WHERE id=@id", conn);
                    cmd.Parameters.AddWithValue("@id", lblVid.Text);
                    cmd.Parameters.AddWithValue("@name", txt_name.Text);
                    cmd.Parameters.AddWithValue("@class", cbclass.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Vehicle type has been successfully Edited!");
                    Clear();                                      
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Clear()
        {
            txt_name.Clear();
            cbclass.SelectedIndex = 0;

            btn_save.Enabled = true;
            btn_update.Enabled = false;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

