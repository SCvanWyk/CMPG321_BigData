using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_operations
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sales salesForm = new Sales();
            salesForm.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Purchases purchasesForm = new Purchases();
            purchasesForm.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            payments paymentsForm = new payments();
            paymentsForm.Show();
            //this.Hide();
        }
    }
}


//hello