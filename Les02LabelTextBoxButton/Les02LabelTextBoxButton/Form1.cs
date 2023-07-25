using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Les02LabelTextBoxButton
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(txtNumA.Text);
            int b = Int32.Parse(txtNumB.Text);
            int sum = a + b;
            lblResult.Text = txtNumA.Text + " + " + txtNumB.Text + " = " + sum.ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(txtNumA.Text);
            int b = Int32.Parse(txtNumB.Text);
            int sub = a - b;
            lblResult.Text = txtNumA.Text+" - "+ txtNumB.Text+ " = " + sub.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to reset this form?", "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lblResult.Text = "";
                txtNumA.Text = "";
                txtNumB.Text = "";
            }

            
        }
    }
}
