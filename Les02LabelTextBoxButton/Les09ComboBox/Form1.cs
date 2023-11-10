using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Les09ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cboDanhSach.Items.Add("test-item-06");
            cboDanhSach.Items.Add("test-item-07");
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cboDanhSach.Items.Insert(1, 123);
        }

        private void btnSelectedIndex_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Index of selected item: " +cboDanhSach.SelectedIndex);
        }

        private void btnSelectedItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("index pt dang chon la: " + cboDanhSach.SelectedItem);
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("so pt cua cbo: " + cboDanhSach.Items.Count);
        }

        private void btnAddRange_Click(object sender, EventArgs e)
        {
            cboDanhSach.Items.AddRange(new String[] {
                "pt1", "pt2", "pt3"
            });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            cboDanhSach.Items.Remove("pt1");
        }

        private void btnRemoveIndex_Click(object sender, EventArgs e)
        {
            cboDanhSach.Items.RemoveAt(1);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboDanhSach.Items.Clear();
        }
    }
}
