using QuanLyQuanCafeb01.DAO;
using QuanLyQuanCafeb01.DTO;
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
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }


        #region Events
        private void đăngXuẩtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        #endregion

        #region Methods

        //Load All tables
        void LoadTable()
        {
            List<TableDTO> tableList = TableDAO.Instance.LoadTableList();
            foreach (TableDTO item in tableList)
            {
                Button btn = new Button() { 
                    Width = TableDAO.tableWidth,
                    Height = TableDAO.tableHeight,
                };
                btn.Text = item.Name + Environment.NewLine + item.Status;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;

                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        #endregion
    }
}
