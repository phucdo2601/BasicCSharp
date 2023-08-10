using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafeb01.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO(); return AccountDAO.instance;
            }

            private set {  instance = value; }
        }

        private AccountDAO() { }


        public bool Login(string username, string password)
        {
            string query = @"select * from Account where UserName = N'"+username+"' AND PassWord = N'"+password+"'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);


            return result.Rows.Count > 0;
        }
    }
}
