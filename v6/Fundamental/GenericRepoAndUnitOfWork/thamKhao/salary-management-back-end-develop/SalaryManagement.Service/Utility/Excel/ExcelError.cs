using System.Collections.Generic;

namespace SalaryManagement.Utility.Excel
{
    public class ErrorItem
    {
        public string ErrorName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ExcelError
    {
        public int Row { get; set; }
        public List<ErrorItem> ListError { get; set; }
    }
}
