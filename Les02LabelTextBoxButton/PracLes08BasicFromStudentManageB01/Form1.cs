using PracLes08BasicFromStudentManageB01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracLes08BasicFromStudentManageB01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            st.StudentName = txtName.Text;
            st.StudentCode = int.Parse(txtCode.Text);
            string s = st.StudentCode + "-" + st.StudentName;
            lsDanhSach.Items.Add(s);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lsDanhSach.Items.Clear();
        }
    }
}
