using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ASM_ManagementStudent
{
    class dbUtils
    {
        SqlConnection conn;

        public void connect()
        {
            if (conn == null)

                conn = new SqlConnection(@"Data Source = LAPTOP-N2GSO4PA\SQLEXPRESS; Initial Catalog = QLSVien; User ID = sa;Password=12345678");

            if (conn.State == ConnectionState.Closed)

                conn.Open();

        }
        public void disconnect()
        {
            if ((conn != null) && (conn.State == ConnectionState.Open))

                conn.Close();
        }
        public DataTable getData(string sql)

        {
            try
            {
                connect();

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                disconnect();

                return dt;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public void ExecuteNonQuery(string sql)

        {

            try
            {
                connect();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();

                disconnect();
            }
            catch (Exception)
            {
                throw;
            }
            

        }
        public SqlDataReader getDataReader(string sql)

        {

            try
            {
                connect();

                SqlCommand com = new SqlCommand(sql, conn);

                SqlDataReader dr = com.ExecuteReader();

                return dr;
            }
            catch (Exception)
            {
                return null;
            }

        
           

        }

        public DataTable getDataReaderByName(string sql, string name)
        {
            try
            {
                connect();

                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.AddWithValue("@name", "%" + name + "%");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dtProduct = new DataTable();
                da.Fill(dtProduct);
                return dtProduct;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
