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

namespace SACARCARE
{
    public partial class report : Form
    {
        private static DataTable DataSource;

        public report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            LoadReceiptData();
        }

        private void dgvTopSelling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvRevenus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void LoadReceiptData(DateTime? startDate = null, DateTime? endDate = null)
        {           
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;

            string query = "SELECT * FROM tbl_receipt";

            if (startDate.HasValue && endDate.HasValue)
            {
                query += " WHERE CreatedAt BETWEEN @StartDate AND @EndDate"; 
            }

          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn))
                {
                   
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@StartDate", startDate.Value.Date);
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@EndDate", endDate.Value.Date);
                    }

                    
                    DataTable dataTable = new DataTable();

                    try
                    {
                        
                        dataAdapter.Fill(dataTable);

                        
                        dgvRevenus.DataSource = dataTable;

                        
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                }
            }
        }


        private void lblRevenus_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtFromRevenud_ValueChanged(object sender, EventArgs e)
        {
            LoadReceiptData(dtStart.Value, dtEnd.Value);
        }

        private void dtToRevenus_ValueChanged(object sender, EventArgs e)
        {
            LoadReceiptData(dtStart.Value, dtEnd.Value);
        }
    }
}

