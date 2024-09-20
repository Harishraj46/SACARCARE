using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class Bill : Form
    {
        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public int customerId = 0, vehicleTypeId = 0;
        public string carno, carmodel, Customer, services;

        public Bill()
        {
            InitializeComponent();
            getTransno();
            loadCash();

        }


        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelCash.Height = 200;
            PanelCash.Controls.Add(childForm);
            PanelCash.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void getTransno()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transno;
                Connectdb();

                conn.Open();
                cmd = new SqlCommand("SELECT TOP 1 transno FROM tbl_cash WHERE transno LIKE '" + sdate + "%' ORDER BY id DESC", conn);
                dr = cmd.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    lblTransno.Text = transno;
                }

                conn.Close();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelCash_Paint(object sender, PaintEventArgs e)
        {

        }



        private void dgvCash_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTransno_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCash_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCash_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvreceipt.Columns[e.ColumnIndex].Name;
            if (colName == "Delete") 
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to cancel this service?", "Cancel Services", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd = new SqlCommand("DELETE FROM tbl_cash WHERE id LIKE'" + dgvreceipt.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Service has been successfully Canceled!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            loadCash();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnAddService_Click_1(object sender, EventArgs e)
        {
            openChildForm(new cashservice(this));
            btnAddCustomer.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintBill();  

        }
        private void PrintBill()
        {
            
            StringBuilder billContent = new StringBuilder();
            billContent.AppendLine("--------------- Customer Details ---------------");
            billContent.AppendLine($"Customer Name: {Customer}");
            billContent.AppendLine($"Car Number: {carno}");
            billContent.AppendLine($"Car Model: {carmodel}");
            billContent.AppendLine($"Service Name: {services}");
            billContent.AppendLine("");
            billContent.AppendLine("--------------- Services ---------------");
            billContent.AppendLine("------------------------------------------");
            billContent.AppendLine($"Total: {lblTotal.Text}");

            
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                float width = ev.PageBounds.Width;
                float height = ev.PageBounds.Height;

                Font font = new Font("Arial", 12);
                Font headingFont = new Font("Arial", 14, FontStyle.Bold);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;

                ev.Graphics.DrawString("SACARCARE", headingFont, Brushes.Black, new RectangleF(leftMargin, topMargin, width, 40), format);

               
                float yPos = topMargin + 50; 
                float lineHeight = font.GetHeight(ev.Graphics);
                ev.Graphics.DrawString(billContent.ToString(), font, Brushes.Black, new RectangleF(leftMargin, yPos, width, height - 50));

               
                ev.Graphics.DrawString("Thank you for your business!", font, Brushes.Black, new RectangleF(leftMargin, height - 40, width, 30), format);
            };

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = pd;
            ppd.ShowDialog();

            StoreBillDetails();
            
        }

        private void StoreBillDetails()
        {
            try
            {
                Connectdb(); 
                conn.Open();

       
                decimal totalAmount;
                if (!decimal.TryParse(lblTotal.Text, out totalAmount))
                {
                    MessageBox.Show("The Total amount is not in a valid format.");
                    return;
                }

             
                string billQuery = "INSERT INTO tbl_receipt (TransactionNo, CustomerName, CarNumber, CarModel, Total) OUTPUT INSERTED.Id VALUES (@TransactionNo, @CustomerName, @CarNumber, @CarModel, @Total)";
                int billId;
                using (SqlCommand cmd = new SqlCommand(billQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@TransactionNo", lblTransno.Text);
                    cmd.Parameters.AddWithValue("@CustomerName", Customer);
                    cmd.Parameters.AddWithValue("@CarNumber", carno);
                    cmd.Parameters.AddWithValue("@CarModel", carmodel);
                    cmd.Parameters.AddWithValue("@Total", totalAmount); 
                    billId = (int)cmd.ExecuteScalar();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while storing the bill details: {ex.Message}");
            }
        }




        public void ShowBillHistory()
        {
            try
            {
                conn.Open();
                Connectdb(); 
                string query = "SELECT b.Id, b.TransactionNo, b.CustomerName, b.CarNumber, b.CarModel, b.Total, b.CreatedAt FROM tbl_receipt b";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                
                dgvreceipt.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the bill history: {ex.Message}");
            }
        }

        


        private void PanelCash_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void btnAddCustomer_Click_2(object sender, EventArgs e)
        {
            openChildForm(new CashCus(this));
            btnAddService.Enabled = true;

        }
        public void loadCash()
        {
            conn.Open();
            int i = 0;
            double total = 0;
            double price = 0;
            dgvreceipt.Rows.Clear();
            cmd = new SqlCommand("SELECT ca.id,ca.transno,cu.name,cu.carno,cu.carmodel,v.name,v.class,s.name,ca.price,ca.date FROM tbl_cash AS Ca " +
                "LEFT JOIN tbl_customer AS Cu ON CA.cid = Cu.id LEFT JOIN tbl_service AS s ON CA.sid = s.id LEFT JOIN tbl_vehicletype AS v ON Ca.vid = v.id WHERE status LIKE 'Pending' AND Ca.transno='" + lblTransno.Text + "'", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                price = int.Parse(dr[6].ToString()) * double.Parse(dr[8].ToString());

                dgvreceipt.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), price, dr[9].ToString());
                total += price;
                Customer = dr[2].ToString();
                carno = dr[3].ToString();
                carmodel = dr[4].ToString();
                services = dr[7].ToString();
            }

            dr.Close();
            conn.Close();
            lblTotal.Text = total.ToString("#,##0.00");
        }



    }

}

 


