using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prac08ListBoxB01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtInputNumber.Text);
               lstNumber.Items.Add(x);
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (int i in lstNumber.Items)
            {
                sum += i;
            }

            MessageBox.Show("Tong cua ds la: " + sum);
        }

        private void btnDeleteFirstAndLast_Click(object sender, EventArgs e)
        {
            lstNumber.Items.RemoveAt(0);
            lstNumber.Items.RemoveAt(lstNumber.Items.Count - 1);
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            while (lstNumber.SelectedIndex != -1)
            {
                lstNumber.Items.RemoveAt(lstNumber.SelectedIndex);
            }
        }

        private void btnIncrementTwo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstNumber.Items.Count; i++)
            {
                //Console.WriteLine(i);
                Console.WriteLine(lstNumber.Items[i]);
                int k = (int) lstNumber.Items[i] + 2;
                lstNumber.Items[i] = k;

            }
        }

        private void btnSquaredNumber_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstNumber.Items.Count; i++)
            {
                //Console.WriteLine(i);
                Console.WriteLine(lstNumber.Items[i]);
                int k = (int)lstNumber.Items[i] * (int)lstNumber.Items[i];
                lstNumber.Items[i] = k;

            }
        }

        private void btnEvenNumber_Click(object sender, EventArgs e)
        {
            lstNumber.SelectedIndex = -1;
            for (int i  = 0; i  < lstNumber.Items.Count; i++)
            {

                int k = (int)lstNumber.Items[i];
                if (k % 2 == 0)
                {
                    lstNumber.SelectedIndex = i;
                }
            }
        }

        private void btnOddNumber_Click(object sender, EventArgs e)
        {
            lstNumber.SelectedIndex = -1;
            for (int i = 0; i < lstNumber.Items.Count; i++)
            {

                int k = (int)lstNumber.Items[i];
                if (k % 2 != 0)
                {
                    lstNumber.SelectedIndex = i;
                }
            }
        }
    }
}
