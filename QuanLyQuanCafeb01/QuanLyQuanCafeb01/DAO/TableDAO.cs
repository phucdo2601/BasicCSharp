using QuanLyQuanCafeb01.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafeb01.DAO
{
    public class TableDAO
    {
        public static int tableWidth = 70;
        public static int tableHeight = 70;

        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if(instance == null) instance = new TableDAO(); return instance;
            }

            private set { instance = value; }
        }

        private TableDAO() { }

        public List<TableDTO> LoadTableList()
        {
            List<TableDTO> tableList = new List<TableDTO>(); ;

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            //covert DataTable to List
            foreach (DataRow item in data.Rows)
            {
                TableDTO table = new TableDTO(item);
                tableList.Add(table);
            }

            return tableList;
        }

    }
}
