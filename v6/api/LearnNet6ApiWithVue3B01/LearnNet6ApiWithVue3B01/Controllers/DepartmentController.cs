using LearnNet6ApiWithVue3B01.Dtos.Requests.Departments;
using LearnNet6ApiWithVue3B01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace LearnNet6ApiWithVue3B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region get all list departments
        [HttpGet("getAllDepts")]
        public async Task<JsonResult> GetAllEmps()
        {

            string query = @"select DepartmentId, DepartmentName
from Department";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");

            SqlDataReader myReader;
            var message = "";

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                try
                {
                    myCon.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                    {
                        myReader = sqlCommand.ExecuteReader();
                        try
                        {
                            table.Load(myReader);
                            return await Task.FromResult(new JsonResult(table));

                        }
                        catch (Exception)
                        {
                            message = "(Exception) Load Department dont Successfully!";

                            return await Task.FromResult(new JsonResult(StatusCode(StatusCodes.Status400BadRequest, new
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                Message = message
                            })));
                            throw;
                        }
                        finally
                        {
                            myReader.Close();
                        }
                    }

                }
                catch (Exception)
                {
                    message = "Connection Database dont Successfully!";

                    return await Task.FromResult(new JsonResult(StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = message
                    })));
                    throw;
                }
                finally
                {
                    myCon.Close();
                }

            }

        }

        #endregion



        #region get department by id
        [HttpGet("getEmpById/{id}")]
        public async Task<IActionResult> GetEmpById([FromRoute(Name = "id")] int id)
        {
            /*string query = @"Select DepartmentId, DepartmentName from Department where DepartmentId =@DepartmentId";*/
            string query = $"Select DepartmentId, DepartmentName from Department where DepartmentId ={id}";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            var message = "";
            Department dept = null;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                try
                {
                    await myCon.OpenAsync();
                    using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                    {
                        /*sqlCommand.Parameters.AddWithValue("@DepartmentId", id);*/
                        myReader = await sqlCommand.ExecuteReaderAsync();
                        try
                        {
                            if (myReader.HasRows)
                            {
                                while (await myReader.ReadAsync())
                                {
                                    dept = new Department()
                                    {
                                        DepartmentId = myReader.GetInt32(myReader.GetOrdinal("DepartmentId")),
                                        DepartmentName = myReader.GetString(myReader.GetOrdinal("DepartmentName"))
                                    };

                                }
                                return await Task.FromResult(new JsonResult(dept));

                            } else
                            {
                                message = "Load Department dont Successfully!";

                                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                                {
                                    StatusCode = StatusCodes.Status400BadRequest,
                                    Message = message
                                })));
                            }
                        }
                        catch (Exception)
                        {
                            message = "(Exception) Load Department dont Successfully!";

                            return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                Message = message
                            })));
                            throw;
                        }
                        finally
                        {
                            await myReader.CloseAsync();
                        }
                    }
                }
                catch (Exception)
                {
                    message = "Connection Database dont Successfully!";

                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = message
                    })));
                    throw;
                }

                finally
                {
                    await myCon.CloseAsync();
                }
            }
        }

        #endregion

        #region  add new department
        [HttpPost("addNewDept")]
        public async Task<IActionResult> AddNewDepartment([FromBody] AddDepartmentRequestDto dep)
        {

            string query = @"insert into Department(DepartmentName) values (@DepartmentName)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            var message = "";

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                try
                {
                    myCon.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                    {
                        sqlCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                        myReader = sqlCommand.ExecuteReader(); 

                        try
                        {
                            table.Load(myReader);
                            return await Task.FromResult(new JsonResult("Added successfully!"));
                        }
                        catch (Exception)
                        {
                            message = "Add New Department dont Successfully!";

                            return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                Message = message
                            })));
                            throw;
                        }
                        finally
                        {
                           
                            myReader.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    message = "Connection Database dont Successfully!";

                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = message
                    })));
                    throw;
                }
                finally
                {
                    myCon.Close();
                }
            }


            
        }

        #endregion

        #region update department by id
        [HttpPut("updateDept/{id}")]
        public async Task<IActionResult> UpdateDepartmentById([FromRoute(Name ="id")] int id, [FromBody] Department dep)
        {
            string query = @"update Department set DepartmentName = @DepartmentName where DepartmentId = @DepartmentId";
            DataTable table = new DataTable();
            string dataSource = _configuration.GetConnectionString("DefaultConnection");
            var message = "";

            using (SqlConnection myCon = new SqlConnection(dataSource))
            {
                try
                {
                    myCon.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                    {
                        if (id == dep.DepartmentId)
                        {
                            SqlTransaction transaction;
                            transaction = myCon.BeginTransaction();
                            try
                            {
                                sqlCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);
                                sqlCommand.Parameters.AddWithValue("@DepartmentId", dep.DepartmentId);
                                transaction.Commit();
                                var kq = sqlCommand.ExecuteNonQuery();
                                Console.WriteLine(kq);
                                return await Task.FromResult(new JsonResult("Updated Successfully!"));

                               

                            }
                            catch (Exception)
                            {
                                message = "Update dont Successfully with this id. Please checking again!";
                                Console.WriteLine(message);
                                transaction.Rollback();

                                throw;
                            }
                        } else
                        {
                            message = "The id with route not match with the id of update item. Please Checking again!";
                            return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                Message = message
                            })));

                        }

                        
                        
                    }
                }
                catch (Exception)
                {

                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = message
                    })));
                    throw;
                }
                finally
                {
                    myCon.Close();
                }
            }


        }


        #endregion

        #region delete department by id
        [HttpDelete("deleteDept/{id}")]
        public async Task<IActionResult> DeleteDept([FromRoute(Name = "id")] int id)
        {
            string query = @"delete from Department where DepartmentId = @DepartmentId";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            var message ="";

            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                try
                {
                    myCon.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, myCon))
                    {
                        try
                        {
                            sqlCommand.Parameters.AddWithValue("@DepartmentId", id);
                            var kq = sqlCommand.ExecuteNonQuery();
                            if (kq == 1)
                            {
                                message = "Delete Successfully!";

                                return await Task.FromResult(new JsonResult(message));

                            }
                            else
                            {
                                message = "Delete dont Successfully!";

                                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                                {
                                    StatusCode = StatusCodes.Status400BadRequest,
                                    Message = message
                                })));

                            }
                        }
                        catch (Exception)
                        {

                            message = "Delete dont Successfully by exception!";
                            return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                Message = message
                            })));

                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    message = "Connection String is not valid!";
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new JsonResult(new
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = message
                    })));

                    throw;
                }
                finally
                {
                    myCon.Close();
                }
            }


        }



        #endregion
    }
}
