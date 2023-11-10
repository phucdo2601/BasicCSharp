using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les08ListBox
{
    public partial class btnIndex : Form
    {
        public btnIndex()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lstDanSach.Items.Add("item_5");
            lstDanSach.Items.Add("item_6");
            lstDanSach.Items.Add("item_7");
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            int a = lstDanSach.Items.Count;
            MessageBox.Show("So phan tu list box la: "+a);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lstDanSach.Items[2].ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lstDanSach.Items.RemoveAt(0);
        }

        private void btnSelectIndex_Click(object sender, EventArgs e)
        {
            foreach (int i in lstDanSach.SelectedIndices)
            {
                Console.WriteLine(i);
            }

            //tra ve gia tri dau tien trong list dc chon
            Console.WriteLine(lstDanSach.SelectedIndices[0]);

            //dem so phan tu dang dc chon
            Console.WriteLine(lstDanSach.SelectedIndices.Count);
        }

        private void btnGan_Click(object sender, EventArgs e)
        {
            lstDanSach.Items[0] = "basic set-up new-var-b01";
        }

        private void btnSelectedIndex_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Index of item selectted: " + lstDanSach.SelectedIndex);
        }
    }
}
