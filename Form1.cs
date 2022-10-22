using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_ManagementStudent
{
    public partial class Form1 : Form
    {
        dbUtils condb = new dbUtils();
        DataTable dtProduct;

        public Form1()
        {
            InitializeComponent();
        }

       public void showData()
        {

            string sql = "select * from SVIEN";
            DataView dv = new DataView(condb.getData(sql));
            dataGridView1.DataSource = dv;
            dataGridView1.AutoResizeColumns();
        }

        void loadComboBox()
        {
            string sql = "select MAKHOA from KHOA";
            
            DataView dv1 = new DataView(condb.getData(sql));
            cbxMaKhoa.DisplayMember = "MAKHOA";
            cbxMaKhoa.DataSource = dv1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
            loadComboBox();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            btnAdd.Enabled = false;
            this.txtMaSV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            this.txtTenSV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            this.txtNgaySinh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            this.txtNamHoc.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            this.cbxMaKhoa.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            if (dataGridView1.Rows[i].Cells[5].Value.ToString().Equals("Nam"))
            {
                cbxGioiTinh.SelectedIndex = 0;
            }
            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Nữ")
            {
                cbxGioiTinh.SelectedIndex = 1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Ban co muon them SV hay Ko?", "Thong Bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ans == DialogResult.OK)
            {
                try
                {
                    string sql = "insert into SVIEN(MASV,TEN,GIOITINH,MAKH,NAM,NGAYSINH)\n"
                        + "values ('" + txtMaSV.Text + "', N'" + txtTenSV.Text + "',N'" + cbxGioiTinh.Text + "', '" + cbxMaKhoa.Text + "','" + txtNamHoc.Text + "', '" + Convert.ToDateTime(txtNgaySinh.Text).ToString("yyyy-MM-dd") + "')";
                    condb.ExecuteNonQuery(sql);
                    MessageBox.Show("Save Successfully !!");
                    showData();
                    this.btnAddnew_Click(sender, e);
                }
                catch (Exception)
                {

                    MessageBox.Show("OOO!!! sorry !!! ERORR!!!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Ban co muon Delete Ko?", "Thong Bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ans == DialogResult.OK)
            {
                try
                {
                    string sql = "delete from SVIEN where MASV= '" + txtMaSV.Text + "'";
                    condb.ExecuteNonQuery(sql);
                    MessageBox.Show("Delete Successfully !!");
                    showData();
                    this.btnAddnew_Click(sender, e);
                }
                catch (Exception)
                {

                    MessageBox.Show("OOO!!! sorry !!! ERORR!!!");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult ans;
            ans = MessageBox.Show("Ban co muon Update Ko?", "Thong Bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ans == DialogResult.OK)
            {
                try
                {
                    string sql = "update SVIEN set TEN = '" + txtTenSV.Text + "', GIOITINH = '" + cbxGioiTinh.Text + "', MAKH = '" + cbxMaKhoa.Text + "', NAM= '" + txtNamHoc.Text + "', NGAYSINH= '" + Convert.ToDateTime(txtNgaySinh.Text).ToString("yyyy-MM-dd") + "' where MASV = '" + txtMaSV.Text + "'";
                    condb.ExecuteNonQuery(sql);
                    MessageBox.Show("Update Successfully !!");
                    showData();
                    this.btnAddnew_Click(sender, e);
                }
                catch (Exception)
                {

                    MessageBox.Show("OOO!!! sorry !!! ERORR!!!");
                }
            }
        }

        private void btnAddnew_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;

            txtMaSV.Clear();
            txtNamHoc.Clear();
            txtNgaySinh.Clear();
            txtTenSV.Clear();
            cbxGioiTinh.Text = "";
            cbxMaKhoa.Text = "";

        }

        private void txtSearchByStudentName(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim().Length != 0)
            {
                dtProduct = condb.getDataReaderByName("select * from SVIEN" +
                " where TEN like @name", this.txtSearch.Text);

                dataGridView1.DataSource = dtProduct;
            }
            else
            {
                showData();
            }
        }

        private void testFuncToPushCodeOnMac(string var) {
            console.writeLine('Hello world  !string');
        }
    }
}
