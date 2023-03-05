using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Prac01CrudWithSQLServe
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=LAPTOP-7CKON28R\\SQLEXPRESS;Initial Catalog=LearnCSharpWinFormCRUDb01;User ID=sa;Password=12345678;Encrypt=false";
        SqlDataAdapter adapter = new SqlDataAdapter();

        DataTable table = new DataTable();

        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ThongTinNhanVien";
            adapter.SelectCommand= command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;

        }

        void ReloadFrom()
        {
            txtMaNV.ReadOnly = false;
            btnAdd.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpNgaySinh.Text ="1/1/1990";
            cbxGioiTinh.Text = "";
            txtChucVu.Text = "";
            txtTienLuong.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(str))
            {
                try
                {
                    connection.Open();
                    LoadData();
                }
                catch (Exception)
                {

                    throw;
                }
                finally { connection.Close(); }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.ReadOnly = true;
            int i;
            i = dgv.CurrentRow.Index;
            txtMaNV.Text = dgv.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgv.Rows[i].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dgv.Rows[i].Cells[2].Value.ToString();
            cbxGioiTinh.Text = dgv.Rows[i].Cells[3].Value.ToString();
            txtChucVu.Text = dgv.Rows[i].Cells[4].Value.ToString();
            txtTienLuong.Text = dgv.Rows[i].Cells[5].Value.ToString();

            btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var maNV = txtMaNV.Text.Trim();
            var tenNV = txtTenNV.Text.Trim();
            var ngaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
            var gioiTinh = cbxGioiTinh.Text.Trim();
            var chucVu = txtChucVu.Text.Trim();
            var tienLuong = txtTienLuong.Text.Trim();
            using (connection = new SqlConnection(str))
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "insert into ThongTinNhanVien values('"+maNV+"', '"+tenNV+"', '"+ngaySinh+"', '"+ gioiTinh + "', '"+chucVu+"', '"+tienLuong+"')";
                    command.ExecuteNonQuery();
                    ReloadFrom();

                    LoadData();
                }
                catch (Exception)
                {

                    throw;
                }
                finally { connection.Close(); }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(str))
            {
                var maNV = txtMaNV.Text.Trim();

                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "delete from ThongTinNhanVien where MaNV = '"+ maNV + "'";
                    command.ExecuteNonQuery();
                    ReloadFrom();

                    LoadData();
                }
                catch (Exception)
                {

                    throw;
                }
                finally { connection.Close(); }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var maNV = txtMaNV.Text.Trim();
            var tenNV = txtTenNV.Text.Trim();
            var ngaySinh = Convert.ToDateTime(dtpNgaySinh.Text);
            var gioiTinh = cbxGioiTinh.Text.Trim();
            var chucVu = txtChucVu.Text.Trim();
            var tienLuong = txtTienLuong.Text.Trim();
            using (connection = new SqlConnection(str))
            {
                try
                {
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "update ThongTinNhanVien set TenNV= '" + tenNV + "', NgaySinh= '" + ngaySinh + "', GioiTinh= '" + gioiTinh + "', ChucVu= '" + chucVu + "', TienLuong= '" + tienLuong + "' where MaNV='" + maNV + "'";
                    command.ExecuteNonQuery();
                    ReloadFrom();

                    LoadData();
                }
                catch (Exception)
                {

                    throw;
                }
                finally { connection.Close(); }
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            ReloadFrom();
        }
    }
}
