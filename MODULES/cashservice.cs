using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class cashservice : Form
    {
        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        Bill cash;
        public cashservice(Bill csh)
        {
            InitializeComponent();
            cash = csh;
            loadService();
        }
        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private void dgvService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvService.Rows)
            {
                bool chkbox = Convert.ToBoolean(dr.Cells["Select"].Value);
                if (chkbox)
                {
                    try
                    {
                        cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM tbl_cash WHERE sid=@sid AND transno=@transno) INSERT INTO tbl_cash(transno,cid,sid,vid,price,date) VALUES(@transno,@cid,@sid,@vid,@price,@date)", conn);
                        cmd.Parameters.AddWithValue("@transno", cash.lblTransno.Text);
                        cmd.Parameters.AddWithValue("@cid", cash.customerId);
                        cmd.Parameters.AddWithValue("@sid", dr.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@vid", cash.vehicleTypeId);
                        cmd.Parameters.AddWithValue("@price", dr.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@date", DateTime.Now);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        cash.btn_print.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            this.Dispose();
            cash.PanelCash.Height = 1;
            cash.loadCash();
        }
        public void loadService()
        {
            try
            {
                Connectdb();
                int i = 0; 
                dgvService.Rows.Clear();
                cmd = new SqlCommand("SELECT * FROM tbl_service WHERE name LIKE '%" + txtSearch.Text + "%'", conn);
                conn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    
                    dgvService.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
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
