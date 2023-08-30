using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Utility.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SalaryManagement.Utility.Excel
{
    public class ExcelManage
    {
        const string SOME_KEY = "errors";
        public static Stream CreateExcelFile<Class>(Stream stream = null)
        {
            using var excelPackage = new ExcelPackage(stream ?? new MemoryStream());

            excelPackage.Workbook.Properties.Author = "Author";

            excelPackage.Workbook.Properties.Title = "LecturerExcel";

            excelPackage.Workbook.Properties.Comments = "This is my Excel to import Lecturer";

            excelPackage.Workbook.Worksheets.Add("Lecturer Sheet");

            var workSheet = excelPackage.Workbook.Worksheets["Lecturer Sheet"];

            BindingFormatForExcel<Class>(workSheet);

            excelPackage.Save();
            return excelPackage.Stream;
        }

        public static string ConvertField(string field)
        {
            int index = field.IndexOf('>');
            return field[1..index]; //field.Substring(1, index - 1)
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            string columnName = "";

            while (columnNumber > 0)
            {
                int modulo = (columnNumber - 1) % 26;
                columnName = Convert.ToChar('A' + modulo) + columnName;
                columnNumber = (columnNumber - modulo) / 26;
            }

            return columnName;
        }

        public static void BindingFormatForExcel<Class>(ExcelWorksheet worksheet)
        {
            worksheet.DefaultColWidth = 20;

            worksheet.Cells.Style.WrapText = true;

            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;
            var fieldNames = typeof(Class).GetFields(bindingFlags).Select(field => field.Name).ToList();

            for (int i = 0; i < fieldNames.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = ConvertField(fieldNames[i]);
            }

            string columnName = GetExcelColumnName(fieldNames.Count);

            using var range = worksheet.Cells[$"A1:{columnName}1"];

            range.Style.Fill.PatternType = ExcelFillStyle.Solid;

            range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 217, 102));

            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            range.Style.Font.SetFromFont(new Font("Arial", 12, FontStyle.Bold));

            range.Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);
        }

        public static List<LecturerRequest> ReadFileExcel(IFormFile file, SalaryConfirmContext _context)
        {
            List<LecturerRequest> lecturerRequests = new();

            if (file == null || file.Length <= 0)
            {
                throw new Exception("Formfile is empty");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Not Support file extension");
            }

            using (var excelPack = new ExcelPackage())
            {
                using (var stream = file.OpenReadStream())
                {
                    excelPack.Load(stream);
                }

                var worksheet = excelPack.Workbook.Worksheets["Lecturer Sheet"];

                var rowCount = worksheet.Dimension.Rows;

                List<ExcelError> excelErrors = new();

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        LecturerRequest lecturerRequest = new()
                        {
                            FullName = worksheet.Cells[row, 1].Value?.ToString().Trim(),
                            UserName = worksheet.Cells[row, 2].Value?.ToString().Trim(),
                            Password = worksheet.Cells[row, 3].Value?.ToString().Trim(),
                            Gmail = worksheet.Cells[row, 4].Value?.ToString().Trim(),
                            PhoneNumber = worksheet.Cells[row, 5].Value?.ToString().Trim(),
                            NationalId = worksheet.Cells[row, 6].Value?.ToString().Trim(),
                            ImageUrl = worksheet.Cells[row, 7].Value?.ToString().Trim(),
                            DateOfBirth = DateTime.Parse(worksheet.Cells[row, 8].Value?.ToString().Trim()),
                            Gender = worksheet.Cells[row, 9].Value?.ToString().Trim(),
                            Address = worksheet.Cells[row, 11].Value?.ToString().Trim(),
                            IsDisable = bool.Parse(worksheet.Cells[row, 12].Value?.ToString().Trim()),
                            DepartmentId = worksheet.Cells[row, 13].Value?.ToString().Trim(),
                            LecturerTypeId = worksheet.Cells[row, 14].Value?.ToString().Trim(),
                            BasicSalaryId = worksheet.Cells[row, 15].Value?.ToString().Trim(),
                            FesalaryId = worksheet.Cells[row, 16].Value?.ToString().Trim()
                        };

                        var department = _context.Departments.Find(lecturerRequest.DepartmentId);
                        var lecturerType = _context.LecturerTypes.Find(lecturerRequest.LecturerTypeId);
                        var basicSalary = _context.BasicSalaries.Find(lecturerRequest.BasicSalaryId);
                        var feSalary = _context.Fesalaries.Find(lecturerRequest.FesalaryId);

                        if (!ValidationModel.Validate(lecturerRequest, out ICollection<ValidationResult> results) || department == null || lecturerType == null || basicSalary == null || feSalary == null)
                        {
                            /*throw new AggregateException(
                                results.Select((e) => new ValidationException(e.ErrorMessage)
                            ));*/

                            ExcelError excelError = new()
                            {
                                Row = row,
                                ListError = new List<ErrorItem>()
                            };
                            results.ToList().ForEach(e =>
                            {

                                ErrorItem errorItem = new()
                                {
                                    ErrorName = e.MemberNames.FirstOrDefault(),
                                    ErrorMessage = e.ErrorMessage
                                };

                                excelError.ListError.Add(errorItem);
                            });

                            if (department == null)
                            {
                                ErrorItem errorItem = new()
                                {
                                    ErrorName = "DepartmentId",
                                    ErrorMessage = "Not found Department"
                                };
                                excelError.ListError.Add(errorItem);
                            }

                            if (lecturerType == null)
                            {
                                ErrorItem errorItem = new()
                                {
                                    ErrorName = "LecturerTypeId",
                                    ErrorMessage = "Not found LecturerType"
                                };
                                excelError.ListError.Add(errorItem);
                            }

                            if (basicSalary == null)
                            {
                                ErrorItem errorItem = new()
                                {
                                    ErrorName = "BasicSalaryId",
                                    ErrorMessage = "Not found BasicSalary"
                                };
                                excelError.ListError.Add(errorItem);
                            }

                            if (feSalary == null)
                            {
                                ErrorItem errorItem = new()
                                {
                                    ErrorName = "FESalaryId",
                                    ErrorMessage = "Not found FESalary"
                                };
                                excelError.ListError.Add(errorItem);
                            }

                            excelErrors.Add(excelError);
                        }

                        lecturerRequests.Add(lecturerRequest);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                Exception e = new("Error Excel");

                if (excelErrors.Count > 0)
                {
                    e.Data.Add(SOME_KEY, excelErrors);
                    throw e;
                }
            }

            return lecturerRequests;
        }

        public static List<object> ReadTestProctoringSignExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                throw new Exception("Formfile is empty");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Not Support file extension");
            }

            List<object> dataList = new();

            ProctoringSignRequest proctor = new();

            using (var excelPack = new ExcelPackage())
            {
                using (var stream = file.OpenReadStream())
                {
                    excelPack.Load(stream);
                }

                var worksheet = excelPack.Workbook.Worksheets["Proctors"];

                var rowCount = worksheet.Dimension.Rows;

                DateTime dateOnly = DateTime.Now;

                for (int row = 1; row <= rowCount; row++)
                {
                    try
                    {
                        var columns = worksheet.Columns.Count();

                        UserSign userSign = new();

                        List<object> ob = new();
                        for (int column = 1; column <= columns; column++)
                        {
                            string value = worksheet.Cells[row, column].Value?.ToString().Trim();
                            if (row == 1)
                            {
                                DateTime dateParse;

                                if (value != null)
                                {
                                    if (column == 5)
                                    {
                                        value = new string(value.Where(Char.IsDigit).ToArray()); //convert 90.000

                                        _ = double.TryParse(value, out double moneyParse);
                                        proctor.Value = moneyParse;
                                    }
                                    else if (DateTime.TryParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 31/8/2022 (date not format)
                                    {
                                        value = dateParse.ToString();
                                    }
                                    else if (double.TryParse(value, out double dateDouble))
                                    {
                                        DateTime dateConvert = DateTime.FromOADate(dateDouble);  //convert 44667
                                        value = dateConvert.ToString();
                                    }
                                }

                                if (column >= 8)
                                {
                                    if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                    {
                                        proctor.DateSign.Dates.Add(dateParse);
                                        value = dateParse.ToString();
                                    }
                                    else proctor.DateSign.Dates.Add(null);
                                }
                            }

                            if ((row == 2 || row == 3) && column >= 8)
                            {
                                if (value != null && DateTime.TryParseExact(value, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateParse)) //convert 10:40
                                {
                                    value = dateParse.ToString();
                                }

                                if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                {
                                    value = dateParse.ToString();
                                }

                                if (proctor.DateSign.Dates[column - 8] != null)
                                {
                                    dateOnly = proctor.DateSign.Dates[column - 8].Value;
                                }

                                if (row == 2)
                                {
                                    if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                    {
                                        DateTime combinedDate = dateOnly.Date.Add(dateParse.TimeOfDay);

                                        proctor.DateSign.StartDates.Add(combinedDate);
                                        value = dateParse.ToString();
                                    }
                                    else proctor.DateSign.StartDates.Add(null);
                                }

                                if (row == 3)
                                {
                                    if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                    {
                                        DateTime combinedDate = dateOnly.Date.Add(dateParse.TimeOfDay);

                                        proctor.DateSign.EndDates.Add(combinedDate);
                                        value = dateParse.ToString();
                                    }
                                    else proctor.DateSign.EndDates.Add(null);
                                }
                            }

                            if (row >= 6 && column >= 2)
                            {
                                if (column == 2)
                                {
                                    userSign.AccountFE = value;
                                }
                                if (column >= 8)
                                {
                                    if (int.TryParse(value, out int intParse))
                                    {
                                        userSign.TimeSlots.Add(intParse);
                                    }
                                    else userSign.TimeSlots.Add(null);
                                }
                            }

                            ob.Add(value);
                        }

                        if (row >= 6) proctor.UserSigns.Add(userSign);

                        dataList.Add(ob);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            dataList.Add(proctor);

            return dataList;
        }

        public static ProctoringSignRequest ReadFileProctoringSignExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                throw new Exception("Formfile is empty");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("Not Support file extension");
            }

            List<object> dataList = new();

            ProctoringSignRequest proctor = new();

            using (var excelPack = new ExcelPackage())
            {
                using (var stream = file.OpenReadStream())
                {
                    excelPack.Load(stream);
                }

                var worksheet = excelPack.Workbook.Worksheets["Proctors"];

                var rowCount = worksheet.Dimension.Rows;

                DateTime dateOnly = DateTime.Now;

                for (int row = 1; row <= rowCount; row++)
                {
                    try
                    {
                        var columns = worksheet.Columns.Count();

                        UserSign userSign = new();

                        List<object> ob = new();
                        for (int column = 1; column <= columns; column++)
                        {
                            string value = worksheet.Cells[row, column].Value?.ToString().Trim();
                            if (row == 1)
                            {
                                DateTime dateParse;

                                if (value != null)
                                {
                                    if (column == 5)
                                    {
                                        value = new string(value.Where(Char.IsDigit).ToArray()); //convert 90.000

                                        _ = double.TryParse(value, out double moneyParse);
                                        proctor.Value = moneyParse;
                                    }
                                    else if (DateTime.TryParseExact(value, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 31/8/2022 (date not format)
                                    {
                                        value = dateParse.ToString();
                                    }
                                    else if (double.TryParse(value, out double dateDouble))
                                    {
                                        DateTime dateConvert = DateTime.FromOADate(dateDouble);  //convert 44667
                                        value = dateConvert.ToString();
                                    }
                                }

                                if (column >= 8)
                                {
                                    if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                    {
                                        proctor.DateSign.Dates.Add(dateParse);
                                        value = dateParse.ToString();
                                    }
                                    else proctor.DateSign.Dates.Add(null);
                                }
                            }

                            if ((row == 2 || row == 3) && column >= 8)
                            {
                                if (value != null && DateTime.TryParseExact(value, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateParse)) //convert 10:40
                                {
                                    value = dateParse.ToString();
                                }

                                if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                {
                                    value = dateParse.ToString();
                                }

                                if (proctor.DateSign.Dates[column - 8] != null)
                                {
                                    dateOnly = proctor.DateSign.Dates[column - 8].Value;
                                }

                                if (row == 2)
                                {
                                    if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                    {
                                        DateTime combinedDate = dateOnly.Date.Add(dateParse.TimeOfDay);

                                        proctor.DateSign.StartDates.Add(combinedDate);
                                        value = dateParse.ToString();
                                    }
                                    else proctor.DateSign.StartDates.Add(null);
                                }

                                if (row == 3)
                                {
                                    if (DateTime.TryParseExact(value, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateParse)) //convert 10/14/2022 7:30:00 AM
                                    {
                                        DateTime combinedDate = dateOnly.Date.Add(dateParse.TimeOfDay);

                                        proctor.DateSign.EndDates.Add(combinedDate);
                                        value = dateParse.ToString();
                                    }
                                    else proctor.DateSign.EndDates.Add(null);
                                }
                            }

                            if (row >= 6 && column >= 2)
                            {
                                if (column == 2)
                                {
                                    userSign.AccountFE = value;
                                }
                                if (column >= 8)
                                {
                                    if (int.TryParse(value, out int intParse))
                                    {
                                        userSign.TimeSlots.Add(intParse);
                                    }
                                    else userSign.TimeSlots.Add(null);
                                }
                            }

                            ob.Add(value);
                        }

                        if (row >= 6) proctor.UserSigns.Add(userSign);

                        dataList.Add(ob);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            dataList.Add(proctor);

            return proctor;
        }
    }
}
