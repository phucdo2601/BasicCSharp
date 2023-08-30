using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Responses;
using SalaryManagement.Services.LecturerService;
using SalaryManagement.Utility.Excel;
using SalaryManagement.Utility.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class LecturerController : ControllerBase
    {
        private readonly ILogger<LecturerController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILecturerService _lecturerService;

        public LecturerController(IUnitOfWork unitOfWork, ILogger<LecturerController> logger)
        {
            _lecturerService = new LecturerService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Lecturer/LecturerInfos

        /// <summary>
        /// Lấy danh sách Giảng viên
        /// </summary>
        [HttpGet("LecturerInfos")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetLecturerInfos()
        {
            try
            {
                List<JObject> data = _lecturerService.GetLecturerInfos();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerInfos" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/LecturerInfos

        #region GET api/Lecturer/{id}

        /// <summary>
        /// Lấy một Giảng viên theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetLectureInfo(string id)
        {
            try
            {
                JObject data = _lecturerService.GetLecturerById(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LectureInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/{id}

        #region GET api/Lecturer/search

        /// <summary>
        /// Tìm các Giảng viên theo tên (theo FullName)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetLecturersByName(string fullName)
        {
            try
            {
                List<JObject> data = _lecturerService.GetLecturersByName(fullName);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerInfos" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/search

        #region PUT api/Lecturer/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của một Giảng viên theo Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutStatusLecture(string id, bool status)
        {
            try
            {
                int update = _lecturerService.DisableLecturer(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Lecturer/{id}/{status}

        #region PUT api/Lecturer/Password/{id}

        /// <summary>
        /// Update password của Lecturer theo Id
        /// </summary>
        [HttpPut("Password/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PutPasswordLecturer(string id, [FromBody] UserPasswordRequest userPasswordRequest)
        {
            try
            {
                int update = _lecturerService.UpdatePasswordLecturer(id, userPasswordRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Lecturer/Password/{id}

        #region POST api​/Lecturer

        /// <summary>
        /// Thêm mới một Giảng viên
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostLecturer([FromBody] LecturerRequest lecturerRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string lecturerId = Guid.NewGuid().ToString();

                    int created = _lecturerService.CreateLecturer(lecturerId, lecturerRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        await _lecturerService.SendMailCreateLecturer(lecturerId);

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { lecturerId, lecturerRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Lecturer fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Lecturer

        #region PUT api​/Lecturer​/{id}

        /// <summary>
        /// Update thông tin Giảng viên theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PutLecture(string id, [FromBody] LecturerUpdateRequest lecturerRequest)
        {
            try
            {
                int update = _lecturerService.UpdateLecturer(id, lecturerRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, lecturerRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Lecturer​/{id}

        #region GET api/Lecturer/LecturerTypes

        /// <summary>
        /// Lấy danh sách tất cả các Loại giảng viên
        /// </summary>
        [HttpGet("LecturerTypes")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetLecturerTypes()
        {
            try
            {
                var data = _lecturerService.GetLecturerTypes();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerTypes" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/LecturerTypes

        #region GET api/Lecturer/LecturerType/{id}

        /// <summary>
        /// Lấy một LecturerType theo Id
        /// </summary>
        [HttpGet("LecturerType/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetLecturerType(string id)
        {
            try
            {
                var lecturerType = _lecturerService.GetLecturerType(id);

                return lecturerType != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, lecturerType))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerType" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/LecturerType/{id}

        #region POST api/Lecturer/LecturerType

        /// <summary>
        /// Thêm mới một Loại giảng viên
        /// </summary>
        [HttpPost("LecturerType")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostLecturerType([FromBody] LecturerTypeRequest lecturerTypeRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string lecturerTypeId = Guid.NewGuid().ToString();

                    int created = _lecturerService.CreateLecturerType(lecturerTypeId, lecturerTypeRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { lecturerTypeId, lecturerTypeRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add LecturerType fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api/Lecturer/LecturerType

        #region PUT api​/Lecturer/LecturerType/{id}

        /// <summary>
        /// Cập nhật một Loại giảng viên theo Id
        /// </summary>
        [HttpPut("LecturerType/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutLecturerType(string id, [FromBody] LecturerTypeRequest lecturerTypeRequest)
        {
            try
            {
                int update = _lecturerService.UpdateLecturerType(id, lecturerTypeRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, lecturerTypeRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerType" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Lecturer/LecturerType/{id}

        #region GET api/Lecturer/LecturerList

        /// <summary>
        /// Lấy danh sách Giảng viên (Phân trang)
        /// </summary>
        [HttpGet("LecturerList")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetLecturerList([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _lecturerService.GetLecturerList(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found LecturerList" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/LecturerList

        #region GET api/Lecturer/SampleExcel

        /// <summary>
        /// Download file Excel mẫu dùng để import Giảng viên
        /// </summary>
        [HttpGet("SampleExcel")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR)]
        public async Task<ActionResult> LecturerExcel()
        {
            try
            {
                ExcelManage excelManage = new();

                var stream = ExcelManage.CreateExcelFile<LecturerRequest>();
                var buffer = stream as MemoryStream;

                Response.Headers.Add("Content-Disposition", "attachment; filename=LecturerExcel.xlsx");

                //var data = File(buffer.ToArray(), "application/vnd.ms-excel");
                var data = File(buffer.ToArray(), "multipart/form-data");

                return data;
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/SampleExcel

        #region POST api/Lecturer/LecturerExcel

        /// <summary>
        /// Import Excel Giảng viên
        /// </summary>
        [HttpPost("LecturerExcel")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR)]
        public async Task<IActionResult> ReadFile(IFormFile file)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    int created = _lecturerService.CreateLecturerExcel(file);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add LecturerType fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    if (ex.Data.Count > 0)
                    {
                        return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Data = ex.Data }));
                    }
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api/Lecturer/LecturerExcel

        #region GET api/Lecturer/TestSendMail

        /// <summary>
        /// Dùng để test gửi mail, xem gửi mail còn hoạt động ko (chỉ dùng để test)
        /// </summary>
        [HttpGet("TestSendMail")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetTestSendMail()
        {
            try
            {
                var data = await _lecturerService.GetTestSendMail();

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "TestSendMail not response" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Lecturer/TestSendMail
    }
}