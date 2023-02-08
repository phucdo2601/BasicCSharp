using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace LearnADO.Netb01
{
    public class Program
    {
        static void ShowDataTable(DataTable table)
        {
            Console.WriteLine($"Ten Bang: {table.TableName}");
            Console.Write($"{"Index",20}");

            foreach (DataColumn item in table.Columns)
            {
                Console.Write($"{item.ColumnName, 20}");
            }
            Console.WriteLine();

            int num_cols = table.Columns.Count;

            int index = 0;
            foreach (DataRow item in table.Rows)
            {
                /*var stt = item[0] + "\t";
                var name = item["HoTen"] + "\t";
                var age = item["Tuoi"];
                Console.Write(stt);
                Console.Write(name);
                Console.Write(age);
                Console.WriteLine();*/

               
                Console.Write($"{index,20}");
                for (int i = 0; i < num_cols; i++)
                {
                    Console.Write($"{item[i], 20}");
                }
                Console.WriteLine();
                index++;
            }
        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            /**
             *  tao chuoi ket noi bang SqlConnectionStringBuilder
             */
            var sqlstringBuilder = new SqlConnectionStringBuilder();
            sqlstringBuilder["Server"] = "LAPTOP-7CKON28R\\SQLEXPRESS";
            sqlstringBuilder["Database"] = "xtlab";
            sqlstringBuilder["User ID"] = "sa";
            sqlstringBuilder["Password"] = "12345678";

            var sqlStringConn = sqlstringBuilder.ToString();
            /*Console.WriteLine(sqlStringConn);*/


            /*var sqlConnString = "Data Source=LAPTOP-7CKON28R\\SQLEXPRESS;Initial Catalog=xtlab;User ID=sa;Password=12345678;Encrypt=false";*/

            /**
             * nen su dung tu khoa using, khi doi tuong nay khong con dc dung nua thi ct se tu dong giai phong tai nguyen
             */
            using var connection = new SqlConnection(sqlStringConn);

            /*Console.WriteLine(connection.State);*/

            //bat dau truy cap -- mo connection
            connection.Open();
            /*Console.WriteLine(connection.State);*/

            #region truy van
            /*DbCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT TOP(10) *  FROM Sanpham";
            
            var datareader = command.ExecuteReader();

            //doc du lieu ra
            while (datareader.Read())
            {
                var productName = datareader["TenSanpham"];
                var productPrice = datareader["Gia"];
                Console.WriteLine($"{productName, 20} - {productPrice, 20}");
            }*/

            #endregion

            #region SqlCommand - truy vấn và cập nhật dữ liệu SQL
            /*using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select DanhmucID, TenDanhMuc, Mota\r\nfrom Danhmuc\r\nwhere DanhmucID >= @DanhmucID";*/
            //tao ra mot parameter
            /*var danhmucId = new SqlParameter("@DanhmucID", 5);
            command.Parameters.Add(danhmucId);*/


            /*var danhmucId =  command.Parameters.AddWithValue("@DanhmucID", 5);*/

            /**
            command.ExecuteReader();
             * 
             */
            #region ExecuteReader():Dung khi ket qua tra ve nhieu dong thi hành lệnh - trả về đối tượng giao diện IDataReader như SqlDataReader, từ đó đọc được dữ liệu trả về
            /*danhmucId.Value = 3;*/

            /*using var sqlReader = command.ExecuteReader();*/

            //tao dt database luu du lieu load len
            /* var datatable = new DataTable();
             datatable.Load(sqlReader);*/




            /*if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    var id = sqlReader.GetInt32(0);
                    var tenDanhMuc = sqlReader["TenDanhMuc"];
                    var mota = sqlReader["Mota"];
                    Console.WriteLine($"{id} - {tenDanhMuc} - {mota}");
                }
                 
            }
            else
            {
                Console.WriteLine("No data!");
            }*/

            #endregion


            /**
            command.ExecuteNonQuery();
             * 
             */
            #region ExecuteNonQuery(): Insert, Update, Delete thi hành truy vấn - không cần trả về dữ liệu gì, phù hợp thực hiện các truy vấn như Insert, Update, Delete ...

            //Shipper: Hoten, Sodienthoai
            //insert
            /* using var command = new SqlCommand();
             command.Connection = connection;
             command.CommandText = "insert into Shippers(Hoten, Sodienthoai) values (@Hoten, @Sodienthoai)";
             var hoten = command.Parameters.AddWithValue("@Hoten", "");
             var sodienthoai = command.Parameters.AddWithValue("@Sodienthoai", "");

             *//* hoten.Value = "Nguyen Van A";
              sodienthoai.Value = "00686678";*//*

             for (int i = 0; i < 4; i++)
             {
                 hoten.Value = "Ho Ten "+i;
                 sodienthoai.Value = "00686678"+i;
                 var kq = command.ExecuteNonQuery();
                 Console.WriteLine(kq);
             }

             *//*var kq = command.ExecuteNonQuery();
             Console.WriteLine(kq);*/

            //update 
            /* using var command = new SqlCommand();
             command.Connection = connection;
             command.CommandText = "update Shippers set Sodienthoai = @Sodienthoai where ShipperID =@ShipperID";
             var shipperID = command.Parameters.AddWithValue("@ShipperID", "");
             var sodienthoai = command.Parameters.AddWithValue("@Sodienthoai", "");

             shipperID.Value = "4";
             sodienthoai.Value = "5";
             var kq = command.ExecuteNonQuery();
             Console.WriteLine(kq);*/

            //delete
            /*using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "delete from Shippers where ShipperID =@ShipperID";
            var shipperID = command.Parameters.AddWithValue("@ShipperID", "");
            shipperID.Value = "4";
            var kq = command.ExecuteNonQuery();
            Console.WriteLine(kq);*/

            #endregion


            /**
            command.ExecuteScalar();
             * 
             */
            #region ExecuteScalar(): tra ve 1 dong duy nhat  thì hành và trả về một giá trị duy nhất - ở hàng đầu tiên, cột đầu tiên
            /* using var command = new SqlCommand();
             command.Connection = connection;
             command.CommandText = "select count(*) from Sanpham where DanhmucId = @DanhmucID";
             var danhmucId = command.Parameters.AddWithValue("@DanhmucID", 2);
             var returnVal = command.ExecuteScalar();
             Console.WriteLine(returnVal);*/
            #endregion

            #region StoreProcudure
            /*using var command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "USP_GetProductInfo";
            command.CommandType = CommandType.StoredProcedure;

            var id = new SqlParameter("@id", 0);
            command.Parameters.Add(id);

            id.Value = 3;

            var render = command.ExecuteReader();
            if (render.HasRows)
            {
                render.Read();
                var productName = render["TenSanPham"];
                var cateName = render["TenDanhMuc"];
                Console.WriteLine($"{productName} - {cateName}");
            }*/

            #endregion

            #region dataset
            /*var dataset = new DataSet();

            //dataset.Tables
            var table = new DataTable("MyTable");

            dataset.Tables.Add(table);

            table.Columns.Add("STT");
            table.Columns.Add("HoTen");
            table.Columns.Add("Tuoi");

            table.Rows.Add(1, "PhucDn", 25);
            table.Rows.Add(2, "Nguyen Van A", 34);
            table.Rows.Add(1, "Nguyen Van B", 23);*/

            /*Console.WriteLine($"Ten Bang: {table.TableName}");

            foreach (DataColumn item in table.Columns)
            {
                Console.WriteLine($"{item.ColumnName}");
            }

            foreach (DataRow item in table.Rows)
            {
                var stt = item[0] + "\t";
                var name = item["HoTen"] + "\t";
                var age = item["Tuoi"];
                Console.Write(stt);
                Console.Write(name);
                Console.Write(age);
                Console.WriteLine();
            }*/

            /*ShowDataTable(table);*/



            #endregion

            #region
            // Thiết lập bảng trong DataSet ánh xạ tương ứng có tên là Nhanvien
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "NhanvienDto");

            // SelectCommand - Thực thi khi gọi Fill lấy dữ liệu về DataSet
            adapter.SelectCommand = new SqlCommand(@"SELECT NhanviennID,Ten,Ho FROM Nhanvien", connection);

            // InsertCommand - Thực khi khi gọi Update, nếu DataSet có chèn dòng mới (vào DataTable)
            // Dữ liệu lấy từ DataTable, như cột Ten tương  ứng với tham số @Ten
            adapter.InsertCommand = new SqlCommand("insert into Nhanvien(Ho, Ten) values (@Ho, @Ten)", connection);
            adapter.InsertCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.InsertCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");

            // DeleteCommand  - Thực thi khi gọi Update, nếu có remove dòng nào đó của DataTable
            adapter.DeleteCommand = new SqlCommand(@"DELETE FROM Nhanvien WHERE NhanviennID = @NhanviennID", connection);
            var pr1 = adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr1.SourceColumn = "NhanviennID";
            pr1.SourceVersion = DataRowVersion.Original;

            //UpdateCommand
            adapter.UpdateCommand = new SqlCommand(@"update Nhanvien set Ho = @Ho, Ten = @Ten where NhanviennID = @NhanviennID", connection);
            var pr2 = adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NhanviennID", SqlDbType.Int));
            pr2.SourceColumn = "NhanviennID";
            pr2.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand.Parameters.Add("@Ho", SqlDbType.NVarChar, 255, "Ho");
            adapter.UpdateCommand.Parameters.Add("@Ten", SqlDbType.NVarChar, 255, "Ten");

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            DataTable table = dataSet.Tables["NhanvienDto"];
            ShowDataTable(table);

            /*var row = table.Rows.Add();
            row["Ten"] = "Abc";
            row["Ho"] = "Tran Van";*/

            //delete row trong db
            /*var row10 = table.Rows[10];
            row10.Delete();*/

            //update - chinh sua cac dong du lieu
            /*var r = table.Rows[9];
            r["Ten"] = "Tuong";*/
            //cap nhat tu dataAdapter vao db
            adapter.Update(dataSet);
            

            #endregion

            #endregion

            //Ket thuc truy cap --closeCon
            connection.Close();
            /*Console.WriteLine(connection.State);*/


        }
    }
}
