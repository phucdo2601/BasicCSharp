using QuanLyQuanCafeb01.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafeb01
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            string query = @"exec USP_GetAccountByUserName @username";


            DataProvider dtProvider = new DataProvider();
            DataTable listRes = dtProvider.ExecuteQuery(query, new object[] { "testStaff01"});

            dtgvAccount.DataSource = listRes;

        }
    }
}
