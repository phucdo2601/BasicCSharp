using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafeb01.DTO
{
    public class TableDTO
    {
        private int iD;

        private string name;
        private string status;

        public TableDTO(int id, string name, string status)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
        }

        public TableDTO(DataRow row) {
            this.Id =(int) row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

        public int Id { 
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }
        public string Name { 
            get { return name; }
            set { name = value; }
        }

        public string Status {
            get { return status; }
            set { status = value; }
        }
    }
}
