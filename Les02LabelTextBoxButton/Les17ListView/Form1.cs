using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les17ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvSanPham.SelectedItems[0];
                string ma = lv1.SubItems[0].Text;
                string name = lv1.SubItems[1].Text;
                string price = lv1.SubItems[2].Text;
                //MessageBox.Show(ma+ "/" +name+ "/"+price);

                txtItemId.Text = ma;
                txtItemName.Text = name;
                txtItemPrice.Text = price;
            }
        }

        private void lvSanPham_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != -1)
            {
                ColumnHeader col = lvSanPham.Columns[e.Column];
                MessageBox.Show("Cot ban chon: "+col.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lv1 = new ListViewItem(txtItemId.Text);
            //them cac o tiep theo
            lv1.SubItems.Add(txtItemName.Text);
            lv1.SubItems.Add(txtItemPrice.Text);

            lvSanPham.Items.Add(lv1);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (lvSanPham.SelectedItems.Count > 0)
            {
                Console.WriteLine(lvSanPham.SelectedItems[0].Index);
                lvSanPham.Items.RemoveAt(lvSanPham.SelectedItems[0].Index);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            while (lvSanPham.SelectedItems.Count > 0)
            {
                Console.WriteLine(lvSanPham.SelectedItems[0].Index);
                lvSanPham.Items.Remove(lvSanPham.SelectedItems[0]);
                MessageBox.Show("da xoa 1 dong");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvSanPham.SelectedItems.Count > 0)
            {
                ListViewItem lv1 = lvSanPham.SelectedItems[0];
                lv1.SubItems[0].Text = txtItemId.Text;
                lv1.SubItems[1].Text = txtItemName.Text;
                lv1.SubItems[2].Text = txtItemPrice.Text;
            }
        }
    }
}
