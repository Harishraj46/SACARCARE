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
    public partial class dashboard : Form
    {
        private SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        public dashboard()
        {
            InitializeComponent();
            Customercount();
            Employeecount();
            Stockcount();
        }

        private void Connectdb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sacar"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_dash.Height;
            Slide.Top= btn_dash.Top;
            
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Slide.Height = btn_stock.Height;
            Slide.Top = btn_stock.Top;
            openChildForm(new Stock());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_emp.Height;
            Slide.Top = btn_emp.Top;
            openChildForm(new Employee());
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_cus.Height;
            Slide.Top = btn_cus.Top;
            openChildForm(new customer());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_service.Height;
            Slide.Top = btn_service.Top;
            openChildForm(new Service());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_log.Height;
            Slide.Top = btn_log.Top;
            if (MessageBox.Show("Logout Application?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
               
            }
        }

        private void btn_bill_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_bill.Height;
            Slide.Top = btn_bill.Top;
            openChildForm(new Bill());
        }
        private void btn_setting_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_setting.Height;
            Slide.Top = btn_setting.Top;
            openChildForm(new setting());

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
            mainform.Controls.Add(childForm);
            mainform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lbl_customer_count_Click(object sender, EventArgs e)
        {

        }
        private void Customercount()
        {
            try
            {
                Connectdb(); 

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(id) FROM tbl_customer", conn);
                int customerCount = (int)cmd.ExecuteScalar();

                lbl_cus_count.Text = customerCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching customer count: " + ex.Message);
            }
            conn.Close();
        }

        private void Employeecount()
        {
            try
            {
                Connectdb(); 

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(id) FROM tbl_employee", conn);
                int customerCount = (int)cmd.ExecuteScalar();

                lbl_empcount.Text = customerCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching customer count: " + ex.Message);
            }
            conn.Close();
        }

        private void Stockcount()
        {
            try
            {
                Connectdb(); 

                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT COUNT(id) FROM tbl_stock", conn);
                int customerCount = (int)cmd.ExecuteScalar();

                stk_count.Text = customerCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching customer count: " + ex.Message);
            }
            conn.Close();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            Slide.Height = btn_report.Height;
            Slide.Top = btn_report.Top;
            openChildForm(new report());
        }
    }

}


