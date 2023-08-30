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
using SalaryManagement.Services.FESalaryService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class FESalaryController : ControllerBase
    {
        private readonly ILogger<FESalaryController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFESalaryService _feSalaryService;

        public FESalaryController(IUnitOfWork unitOfWork, ILogger<FESalaryController> logger)
        {
            _feSalaryService = new FESalaryService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region PUT api/FESalary/Lecturer

        /// <summary>
        /// Thay đổi Bậc lương FE của Giảng viên
        /// </summary>
        [HttpPut("Lecturer")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusBasicSalary(FESalaryLecturer fESalaryLecturer)
        {
            try
            {
                int update = _feSalaryService.UpdateFesalaryLecturer(fESalaryLecturer);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Lecturer" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/FESalary/Lecturer

        #region GET api/FESalary/FESalaries

        /// <summary>
        /// Lấy danh sách tất cả các Bậc lương EF
        /// </summary>
        [HttpGet("FESalaries")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetFESalaries()
        {
            try
            {
                var data = _feSalaryService.GetFESalaries();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FESalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/FESalary/FESalaries

        #region GET api/FESalary/{id}

        /// <summary>
        /// Lấy một Bậc lương EF theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFESalary(string id)
        {
            try
            {
                var FESalary = _feSalaryService.GetFesalary(id);

                return FESalary != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, FESalary))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FESalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/FESalary/{id}

        #region GET api/FESalary/search

        /// <summary>
        /// Tìm các Bậc lương EF (theo FesalaryCode)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFESalariesByCode(string fesalaryCode)
        {
            try
            {
                var data = _feSalaryService.GetFESalariesByCode(fesalaryCode);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FESalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/FESalary/search

        #region PUT api/FESalary/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của Bậc lương FE với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusFESalary(string id, bool status)
        {
            try
            {
                int update = _feSalaryService.DisableFesalary(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FESalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/FESalary/{id}/{status}

        #region POST api​/FESalary

        /// <summary>
        /// Thêm mới một Bậc lương EF
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostFESalary([FromBody] FESalaryRequest fESalaryRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string fesalaryId = Guid.NewGuid().ToString();

                    int created = _feSalaryService.CreateFesalary(fesalaryId, fESalaryRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { fesalaryId, fESalaryRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add FESalary fail" }));
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

        #endregion POST api​/FESalary

        #region PUT api​/FESalary​/{id}

        /// <summary>
        /// Cập nhật một Bậc lương EF theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutFESalary(string id, [FromBody] FESalaryRequest fESalaryRequest)
        {
            try
            {
                int update = _feSalaryService.UpdateFesalary(id, fESalaryRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, fESalaryRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FESalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/FESalary​/{id}

        #region GET api/FESalary/FESalaryList

        /// <summary>
        /// Lấy danh sách tất cả các Bậc lương EF (Phân trang)
        /// </summary>
        [HttpGet("FESalaryList")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetFESalaryList([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _feSalaryService.GetFESalaryList(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FESalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/FESalary/FESalaryList
    }
}