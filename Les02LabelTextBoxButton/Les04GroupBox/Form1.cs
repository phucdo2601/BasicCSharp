using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les04GroupBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit this program?", "Confirm", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question );

            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbtnRed.Checked = true;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            lblResult.Text = txtInput.Text;
            if (rbtnRed.Checked)
            {
                lblResult.ForeColor = rbtnRed.ForeColor;
            }

            if (rbtnBlue.Checked)
            {
                lblResult.ForeColor = rbtnBlue.ForeColor;
            }

            if (rbtnGreen.Checked)
            {
                lblResult.ForeColor = rbtnGreen.ForeColor;
            }

            if (rbtnBlack.Checked)
            {
                lblResult.ForeColor = rbtnBlack.ForeColor;
            }
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            lblResult.Font = new Font(
                lblResult.Font.Name,
                lblResult.Font.Size,
                lblResult.Font.Style^FontStyle.Bold
                );
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            lblResult.Font = new Font(
                lblResult.Font.Name,
                lblResult.Font.Size,
                lblResult.Font.Style ^ FontStyle.Italic
                );
        }

        private void chkUnderline_CheckedChanged(object sender, EventArgs e)
        {
            lblResult.Font = new Font(
                lblResult.Font.Name,
                lblResult.Font.Size,
                lblResult.Font.Style ^ FontStyle.Underline
                );
        }
    }
}
