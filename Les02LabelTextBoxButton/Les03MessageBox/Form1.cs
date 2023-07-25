using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les03MessageBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            DialogResult resultVar = MessageBox.Show("You opened message box.This is message box!!", "Notifications", 
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
                );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           /* DialogResult result = MessageBox.Show("Do you want to exit this program?",
                "Confirm",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                Close();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("Ok, Continue Using!");
            }*/
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Do you want to exit?", "Confirm",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            } else
            {
                e.Cancel = true;
            }
        }
    }
}
