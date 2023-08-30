using LearnNet6ApiWithVue3B01.Dtos.Requests.Employee;
using LearnNet6ApiWithVue3B01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LearnNet6ApiWithVue3B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        #region get all employee
        [HttpGet("getAllEmp")]
        public async Task<IActionResult> GetAllEmployee()
        {
            string query = @"
                            select EmployeeId, EmployeeName,DepartmentId,
                            convert(varchar(10),DateOfJoining,120) as DateOfJoining,PhotoFileName
                            from
                            dbo.Employee
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }



        #endregion

        #region add new employee
        [HttpPost]
        public JsonResult Post(AddEmployeeRequestDto emp)
        {
            string query = @"
                           insert into dbo.Employee
                           (EmployeeName,DepartmentId,DateOfJoining,PhotoFileName)
                    values (@EmployeeName,@DepartmentId,@DateOfJoining,@PhotoFileName)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    myCommand.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", emp.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        #endregion


        #region update employee
        [HttpPut("updateEmp")]
        public JsonResult UpdateEmployee(Employee emp)
        {
            string query = @"
                           update dbo.Employee
                           set EmployeeName= @EmployeeName,
                            DepartmentId=@DepartmentId,
                            DateOfJoining=@DateOfJoining,
                            PhotoFileName=@PhotoFileName
                            where EmployeeId=@EmployeeId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                    myCommand.Parameters.AddWithValue("@EmployeeName", emp.EmployeeName);
                    myCommand.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", emp.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        #endregion

        #region delete employee
        [HttpDelete("deleteEmp/{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                           delete from dbo.Employee
                            where EmployeeId=@EmployeeId
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        #endregion

        #region basic update image file
        [HttpPost("SaveFile")]
        public JsonResult SaveFiles()
        {
            try
            {
                var htttpRequest = Request.Form;
                var postedFile = htttpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + fileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                return new JsonResult(fileName);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        #endregion
    }
}
