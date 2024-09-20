using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SACARCARE
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 5;
            if (panel2.Width >= 599)
            {
                timer1.Stop();
                Login lg = new Login();
                lg.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
    }
}
