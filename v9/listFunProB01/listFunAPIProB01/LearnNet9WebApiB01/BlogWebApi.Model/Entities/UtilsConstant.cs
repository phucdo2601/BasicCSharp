using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Model.Entities
{
    public class UtilsConstant
    {
        // Connection string on mssql on local install
        //public const string CONNECTION_STR = @"Server=DESKTOP-7SRJOU8\SQLEXPRESS,1433; Database=BlogNet9ApiB01; User Id=sa;Password=12345678; Encrypt=false";

        // Connection string on mssql build up on docker container
        public const string CONNECTION_STR = @"Server=localhost,1441; Database=BlogNet9ApiB01; user=sa;password=12345678@Abc; Encrypt=false";
    }
}
