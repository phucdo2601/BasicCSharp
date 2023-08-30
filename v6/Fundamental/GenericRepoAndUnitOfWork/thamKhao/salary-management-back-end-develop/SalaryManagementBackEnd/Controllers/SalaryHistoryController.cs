using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Responses;
using SalaryManagement.Services.SalaryHistoryService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class SalaryHistoryController : ControllerBase
    {
        private readonly ILogger<SalaryHistoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISalaryHistoryService _salaryHistoryService;

        public SalaryHistoryController(IUnitOfWork unitOfWork, ILogger<SalaryHistoryController> logger)
        {
            _salaryHistoryService = new SalaryHistoryService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/SalaryHistory/SalaryHistories

        /// <summary>
        /// Lấy danh sách lịch sử lương
        /// </summary>
        [HttpGet("SalaryHistories")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSalaryHistories()
        {
            try
            {
                var data = _salaryHistoryService.GetSalaryHistories();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistories" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/SalaryHistory/SalaryHistories

        #region GET api/SalaryHistory/{id}

        /// <summary>
        /// Lấy Lịch sử lương theo id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSalaryHistory(string id)
        {
            try
            {
                var data = _salaryHistoryService.GetSalaryHistory(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistory" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/SalaryHistory/{id}

        #region GET api/SalaryHistory/Lecturer/{id}

        /// <summary>
        /// Lấy tất cả Lịch sử lương của Giảng viên theo Id Giảng viên
        /// </summary>
        [HttpGet("Lecturer/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSalaryHistoryOfLecturer(string id)
        {
            try
            {
                var salaryHistory = _salaryHistoryService.GetSalaryHistoriesOfLecturer(id);

                return salaryHistory.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, salaryHistory))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistory" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/SalaryHistory/Lecturer/{id}

        #region POST api​/SalaryHistory

        /// <summary>
        /// Thêm mới một Lịch sử lương cho một Giảng viên
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PostSalaryHistory([FromBody] SalaryHistoryRequest salaryHistoryRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string salaryHistoryId = Guid.NewGuid().ToString();

                    int created = _salaryHistoryService.CreateSalaryHistory(salaryHistoryId, salaryHistoryRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { salaryHistoryId, salaryHistoryRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add SalaryHistory fail" }));
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

        #endregion POST api​/SalaryHistory

        #region PUT api​/SalaryHistory​/{id}

        /// <summary>
        /// Cập nhật một Lịch sử lương dựa trên Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PutSalaryHistory(string id, [FromBody] SalaryHistoryRequest salaryHistoryRequest)
        {
            try
            {
                int update = _salaryHistoryService.UpdateSalaryHistory(id, salaryHistoryRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, salaryHistoryRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistory" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/SalaryHistory​/{id}

        #region PUT api/SalaryHistory/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsUsing) của Lịch sử lương với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PutStatusSalaryHistory(string id, bool status)
        {
            try
            {
                int update = _salaryHistoryService.ChangeUsingSalaryHistory(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistory" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/SalaryHistory/{id}/{status}

        #region GET api/SalaryHistory/SalaryHistoryList

        /// <summary>
        /// Lấy danh sách lịch sử lương (Phân trang)
        /// </summary>
        [HttpGet("SalaryHistoryList")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSalaryHistoryList([FromQuery] Pagination pagination, bool? isUsing)
        {
            try
            {
                var data = _salaryHistoryService.GetSalaryHistoryList(pagination, isUsing);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistories" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/SalaryHistory/SalaryHistoryList

        #region GET api/SalaryHistory/LecturerHistory/{id}

        /// <summary>
        /// Lấy tất cả Lịch sử lương của Giảng viên theo Id Giảng viên (Phân trang)
        /// </summary>
        [HttpGet("LecturerHistory/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetLecturerHistory(string id, [FromQuery] Pagination pagination, bool? isUsing)
        {
            try
            {
                var salaryHistory = _salaryHistoryService.GetLecturerHistory(id, pagination, isUsing);

                return salaryHistory != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, salaryHistory))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SalaryHistory" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/SalaryHistory/LecturerHistory/{id}
    }
}