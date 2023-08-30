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
using SalaryManagement.Services.BasicSalaryService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class BasicSalaryController : ControllerBase
    {
        private readonly ILogger<BasicSalaryController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasicSalaryService _basicSalaryService;

        public BasicSalaryController(IUnitOfWork unitOfWork, ILogger<BasicSalaryController> logger)
        {
            _basicSalaryService = new BasicSalaryService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region PUT api/BasicSalary/Lecturer

        /// <summary>
        /// Thay đổi Bậc lương cơ bản của Giảng viên
        /// </summary>
        [HttpPut("Lecturer")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusBasicSalary(BasicSalaryLecturer basicSalaryLecturer)
        {
            try
            {
                int update = _basicSalaryService.UpdateBSalaryLecturer(basicSalaryLecturer);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Lecturer" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/BasicSalary/Lecturer

        #region GET api/BasicSalary/BasicSalaries

        /// <summary>
        /// Lấy danh sách tất cả các Bậc lương cơ bản
        /// </summary>
        [HttpGet("BasicSalarys")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetSalaryBasics()
        {
            try
            {
                var data = _basicSalaryService.GetBasicSalaries();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/BasicSalary/BasicSalaries

        #region GET api/BasicSalary/{id}

        /// <summary>
        /// Lấy một Bậc lương cơ bản theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetSalaryBasic(string id)
        {
            try
            {
                var salaryBasic = _basicSalaryService.GetBasicSalary(id);

                return salaryBasic != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, salaryBasic))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/BasicSalary/{id}

        #region GET api/BasicSalary/search

        /// <summary>
        /// Tìm các Bậc lương cơ bản (theo BasicSalaryLevel)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetBasicSalariesByName(string basicSalaryLevel)
        {
            try
            {
                var data = _basicSalaryService.GetBasicSalariesByName(basicSalaryLevel);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/BasicSalary/search

        #region PUT api/BasicSalary/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của Bậc lương với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutStatusBasicSalary(string id, bool status)
        {
            try
            {
                int update = _basicSalaryService.DisableBasicSalary(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/BasicSalary/{id}/{status}

        #region POST api​/BasicSalary

        /// <summary>
        /// Thêm mới một Bậc lương cơ bản
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostBasicSalary([FromBody] BasicSalaryRequest basicSalaryRequest)
        {
            var transaction = _unitOfWork.BeginTransaction();
            try
            {
                string basicSalaryId = Guid.NewGuid().ToString();

                int created = _basicSalaryService.CreateBasicSalary(basicSalaryId, basicSalaryRequest);

                if (created >= 0)
                {
                    transaction.Commit();

                    return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { basicSalaryId, basicSalaryRequest } }));
                }
                else
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add BasicSalary fail" }));
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/BasicSalary

        #region PUT api​/BasicSalary​/{id}

        /// <summary>
        /// Cập nhật một Bậc lương cơ bản theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutBasicSalary(string id, [FromBody] BasicSalaryRequest basicSalaryRequest)
        {
            try
            {
                int update = _basicSalaryService.UpdateBasicSalary(id, basicSalaryRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, basicSalaryRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/BasicSalary​/{id}

        #region GET api/BasicSalary/BasicSalaryList

        /// <summary>
        /// Lấy danh sách tất cả các Bậc lương cơ bản (Phân trang)
        /// </summary>
        [HttpGet("BasicSalaryList")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetSalaries([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _basicSalaryService.GetSalaries(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/BasicSalary/BasicSalaryList
    }
}