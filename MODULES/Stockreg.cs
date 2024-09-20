using System;
using System.Collections;
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
    public partial class Stockreg : Form
    {
        Stock stock;
        public Stockreg(Stock stck)
        {
            InitializeComponent();
            stock=stck;
        }

        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Connectdb();
                if (txt_stock.Text != "" && txt_price.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to register this Stock?", "Stock Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       
                        SqlCommand cmd = new SqlCommand("sp_stk_insert", conn);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@stock", txt_stock.Text);
                        cmd.Parameters.AddWithValue("@price", txt_price.Text);
                        cmd.Parameters.AddWithValue("@available", txt_abl.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Stock has been successfully registered!");
                        Clear();
                        stock.loadStock();

                    }
                    else 
                    {
                        MessageBox.Show("Stock registration canceled.");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Required data fields are empty!", "Warning");
                    return;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Connectdb();
                if (txt_stock.Text != "" && txt_price.Text != "")
                {
                    if (MessageBox.Show("Are you sure you want to edit this Stock?", "Service Editing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("stk_update", conn);


                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", lblstid.Text);
                        cmd.Parameters.AddWithValue("@stock", txt_stock.Text);
                        cmd.Parameters.AddWithValue("@price", txt_price.Text);
                        cmd.Parameters.AddWithValue("@available", txt_abl.Text);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Stock has been successfully edited!");
                        this.Dispose();

                    }
                    else
                    {
                        MessageBox.Show("Edited stock failed!!");
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
            txt_stock.Clear();
            txt_price.Clear();
            txt_abl.Clear();

            btn_save.Enabled = true;
            btn_update.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}