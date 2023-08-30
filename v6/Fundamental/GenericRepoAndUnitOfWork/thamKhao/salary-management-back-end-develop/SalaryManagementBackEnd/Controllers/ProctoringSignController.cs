using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Responses;
using SalaryManagement.Services.AzureBlobStorageService;
using SalaryManagement.Services.ProctoringSignService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class ProctoringSignController : ControllerBase
    {
        private readonly ILogger<ProctoringSignController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProctoringSignService _proctoringSignService;
        private readonly IConfiguration _configuration;
        private readonly IAzureBlobStorageService _storage;

        public ProctoringSignController(IUnitOfWork unitOfWork, ILogger<ProctoringSignController> logger, IConfiguration iconfig, IAzureBlobStorageService storage)
        {
            _proctoringSignService = new ProctoringSignService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
            _configuration = iconfig;
            _storage = storage;
        }

        #region GET api/ProctoringSign/ProctoringSigns

        /// <summary>
        /// (Manager) Lấy tất cả các danh sách tất cả các Giảng Viên có khung giờ canh thi
        /// </summary>
        [HttpGet("ProctoringSigns")]
        [AuthorizeRoles(UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetProctoringSigns()
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSigns();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/ProctoringSigns

        #region GET api/ProctoringSign/ProctoringSigns/Date

        /// <summary>
        /// (Manager) Lấy tất cả các danh sách khung giờ canh thi của tất cả Giảng Viên theo Ngày
        /// </summary>
        [HttpGet("ProctoringSigns/Date")]
        [AuthorizeRoles(UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetProctoringSignsByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSignsByDate(fromDate, toDate);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/ProctoringSigns/Date

        #region GET api/ProctoringSign/Lecturer/{id}

        /// <summary>
        /// (Manager,Lecturer) Lấy tất cả các danh sách khung giờ canh thi của một Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("Lecturer/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetProctoringSignByLecturer(string id)
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSignByLecturer(id);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/Lecturer/{id}

        #region GET api/ProctoringSign/Lecturer/Date

        /// <summary>
        /// (Manager,Lecturer) Lấy tất cả các danh sách khung giờ canh thi theo Ngày của một Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("Lecturer/Date")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetProctoringSignDateByLecturer(string id, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSignDateByLecturer(id, fromDate, toDate);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/Lecturer/Date

        #region GET api/ProctoringSign/Current/Lecturer/{id}

        /// <summary>
        /// (Lecturer) (Quan trọng dùng để nhắc việc) Lấy tất cả các danh sách khung giờ canh thi Hiện tại đang có của một Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("Current/Lecturer/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetProctoringSignCurrentByLecturer(string id)
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSignCurrentByLecturer(id);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/Current/Lecturer/{id}

        #region GET api/ProctoringSign/History/Lecturer/{id}

        /// <summary>
        /// (Lecturer) Lấy tất cả các danh sách khung giờ canh thi Đã làm của một Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("History/Lecturer/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetProctoringSignHistoryByLecturer(string id)
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSignHistoryByLecturer(id);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/History/Lecturer/{id}

        #region POST api/ProctoringSign/ProctoringSignExcel

        /// <summary>
        /// Import Excel ProctoringSignExcel (Dùng để BackEnd test, show tất cả dữ liệu trên file Excel)
        /// </summary>
        [HttpPost("ProctoringSignExcel")]
        [AuthorizeRoles(UserInfo.ROLE_EM)]
        public async Task<IActionResult> ReadFile(IFormFile file)
        {
            try
            {
                try
                {
                    var data = _proctoringSignService.ReadProtoringSignExcel(file);

                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = data }));
                }
                catch (Exception ex)
                {
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

        #endregion POST api/ProctoringSign/ProctoringSignExcel

        #region POST api​/ProctoringSign

        /// <summary>
        /// Import File Excel đăng ký canh thi (BackEnd xử lý hết)
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_EM)]
        public async Task<ActionResult> PostProctoringSign(IFormFile file)
        {
            var transaction = _unitOfWork.BeginTransaction();
            try
            {
                int created = _proctoringSignService.CreateProtoringSignExcel(file);

                if (created >= 0)
                {
                    transaction.Commit();

                    return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success }));
                }
                else
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add ProctoringSign fail" }));
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/ProctoringSign

        #region POST api​/ProctoringSign/Excel

        /// <summary>
        /// Import File Excel đăng ký canh thi (FE đọc file excel, xong đưa dữ liệu cho BE)
        /// </summary>
        [HttpPost("Excel")]
        [AuthorizeRoles(UserInfo.ROLE_EM)]
        public async Task<ActionResult> PostProctoringSignExcel(ProctoringSignExcelRequest proctoringSignRequest)
        {
            var transaction = _unitOfWork.BeginTransaction();
            try
            {
                int created = _proctoringSignService.CreateProtoringSign(proctoringSignRequest);

                if (created >= 0)
                {
                    transaction.Commit();

                    return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success }));
                }
                else
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add ProctoringSign fail" }));
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/ProctoringSign/Excel

        #region GET api/ProctoringSign/ProctoringSignsInMonth

        /// <summary>
        /// (Dùng cho biểu đồ) Lấy tất cả các danh sách khung giờ canh thi theo Tháng của một Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("ProctoringSignsInMonth")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetProctoringSignsInMonth(string lecturerId, int month)
        {
            try
            {
                var data = _proctoringSignService.GetProctoringSignsInMonth(lecturerId, month);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/ProctoringSignsInMonth

        #region GET api/ProctoringSign/User

        /// <summary>
        /// (Dùng cho azure function gửi mail) Lấy user theo user id
        /// </summary>
        [HttpPost("User")]
        [AllowAnonymous]
        public async Task<ActionResult> GetUser(UserProcRequest userRequest)
        {
            try
            {
                //check Secret Key
                var secretKey = _configuration.GetValue<string>("AzureFunctionConfig:SecretKey");
                if (!userRequest.SecretKey.Equals(secretKey)) throw new Exception("Secret Key is wrong");

                var data = _proctoringSignService.GetUser(userRequest.UserId);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found User" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/User

        #region GET api/ProctoringSign/UserIdsOnDate

        /// <summary>
        /// (Dùng cho azure function gửi mail) Lấy danh sách userId canh thi trong ngày
        /// </summary>
        [HttpPost("UserIdsOnDate")]
        [AllowAnonymous]
        public async Task<ActionResult> GetUserIdsOnDate(DateProcRequest dateRequest)
        {
            try
            {
                //check Secret Key
                var secretKey = _configuration.GetValue<string>("AzureFunctionConfig:SecretKey");
                if (!dateRequest.SecretKey.Equals(secretKey)) throw new Exception("Secret Key is wrong");

                var data = _proctoringSignService.GetUserIdsOnDate(dateRequest.Date);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found User" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/UserIdsOnDate

        #region GET api/ProctoringSign/TimeSlotsLecturerSigned

        /// <summary>
        /// (Dùng cho azure function gửi mail) Lấy danh sách TimeSlot mà Giảng Viên đó đăng kí
        /// </summary>
        [HttpPost("TimeSlotsLecturerSigned")]
        [AllowAnonymous]
        public async Task<ActionResult> GetTimeSlotsLecturerSigned(DateUserRequest dateUserRequest)
        {
            try
            {
                //check Secret Key
                var secretKey = _configuration.GetValue<string>("AzureFunctionConfig:SecretKey");
                if (!dateUserRequest.SecretKey.Equals(secretKey)) throw new Exception("Secret Key is wrong");

                var data = _proctoringSignService.GetTimeSlotsLecturerSigned(dateUserRequest.UserId, dateUserRequest.Date);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found User" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/ProctoringSign/TimeSlotsLecturerSigned

        #region GET api/ProctoringSign/Template

        /// <summary>
        /// Lấy Template để import
        /// </summary>
        [HttpGet("Template")]
        [AuthorizeRoles(UserInfo.ROLE_EM)]
        public async Task<IActionResult> GetTemplate()
        {
            string fileName = FileName.EXCEL_TEMPLATE_PROCTORING;

            AzureBlobStorageModel file = await _storage.DownloadAsync(fileName);

            // Check if file was found
            if (file == null)
            {
                // Was not, return error message to client
                return StatusCode(StatusCodes.Status500InternalServerError, $"File {fileName} could not be downloaded.");
            }
            else
            {
                // File was found, return it to client
                return File(file.Content, file.ContentType, file.Name);
            }
        }
        #endregion GET api/ProctoringSign/Template
    }
}
