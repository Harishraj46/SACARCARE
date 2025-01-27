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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using System.Configuration;
using System.Security.Cryptography;

namespace SACARCARE
{
    public partial class customer_reg : Form
    {
        public int vid = 0;
        customer Customer;
        public customer_reg(customer Cust)
        {
            InitializeComponent();
            Customer=Cust;

        }
        
        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }
        private void customer_reg_Load(object sender, EventArgs e)
        {
            
            cbcartype.DataSource = vehicletype(); 
            cbcartype.DisplayMember = "name";
            cbcartype.ValueMember = "id";
            if (vid > 0)
                cbcartype.SelectedValue = vid;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Connectdb();
                
                 if (MessageBox.Show("Are you sure you want to register this Customer?", "Customer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tbl_customer(vid, name, phone, carno, carmodel, address, points) VALUES (@vid, @name, @phone, @carno, @carmodel, @address, @points)", conn); 
                      cmd.Parameters.AddWithValue("@vid", cbcartype.SelectedValue);
                      cmd.Parameters.AddWithValue("@name", txt_name.Text);
                      cmd.Parameters.AddWithValue("@phone", txt_ph.Text);
                      cmd.Parameters.AddWithValue("@carno", txt_carno.Text);
                      cmd.Parameters.AddWithValue("@carmodel", txt_carmodel.Text);
                      cmd.Parameters.AddWithValue("@address", txt_address.Text);
                      cmd.Parameters.AddWithValue("@points", udpoints.Text);

                      conn.Open();
                      cmd.ExecuteNonQuery();
                      conn.Close();
                      MessageBox.Show("Customer has been successfully registered!");
                      Clear();                      
                 }
                
                Customer.loadCustomer();

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
                    if (MessageBox.Show("Are you sure you want to edit this Customer?", "Customer Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("UPDATE tbl_customer SET vid=@vid, name=@name, phone=@phone, carno=@carno, carmodel=@carmodel, address=@address, points=@points WHERE id=@id", conn);
                        cmd.Parameters.AddWithValue("@id", lblCid.Text);
                        cmd.Parameters.AddWithValue("@vid", cbcartype.SelectedValue);
                        cmd.Parameters.AddWithValue("@name", txt_name.Text);
                        cmd.Parameters.AddWithValue("@phone", txt_ph.Text);
                        cmd.Parameters.AddWithValue("@carno", txt_carno.Text);
                        cmd.Parameters.AddWithValue("@carmodel", txt_carmodel.Text);
                        cmd.Parameters.AddWithValue("@address", txt_address.Text);
                        cmd.Parameters.AddWithValue("@points", udpoints.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Customer has been successfully Edited!");
                        this.Dispose();
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

        private void customer_reg_Load_1(object sender, EventArgs e)
        {
            cbcartype.DataSource = vehicletype();
            cbcartype.DisplayMember = "name";
            cbcartype.ValueMember = "id";
            if (vid > 0)
                cbcartype.SelectedValue = vid;
        }



        public DataTable vehicletype()
        {
            Connectdb();
            cmd = new SqlCommand("SELECT * FROM tbl_vehicletype", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            da.SelectCommand = cmd;
            da.Fill(dataTable);

            return dataTable;

        }

        public void Clear()
        {
            txt_address.Clear();
            txt_carmodel.Clear();
            txt_carno.Clear();
            txt_name.Clear();
            txt_ph.Clear();

            cbcartype.SelectedIndex = 0;
            udpoints.Value = 0;

            btn_save.Enabled = true;
            btn_update.Enabled = false;
        }

       
    }
}

