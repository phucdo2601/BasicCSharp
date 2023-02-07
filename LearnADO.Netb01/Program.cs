using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace LearnADO.Netb01
{
    public class Program
    {
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
            Console.WriteLine(sqlStringConn);


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
            using var command = new SqlCommand();
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
            }

            #endregion


            #endregion

            //Ket thuc truy cap --closeCon
            connection.Close();
            /*Console.WriteLine(connection.State);*/


        }
    }
}
