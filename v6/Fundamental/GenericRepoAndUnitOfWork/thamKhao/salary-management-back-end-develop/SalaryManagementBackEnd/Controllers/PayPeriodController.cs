using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Responses;
using SalaryManagement.Services.PayPeriodService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class PayPeriodController : ControllerBase
    {
        private readonly ILogger<PayPeriodController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPayPeriodService _lecturerService;

        public PayPeriodController(IUnitOfWork unitOfWork, ILogger<PayPeriodController> logger)
        {
            _lecturerService = new PayPeriodService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/PayPeriod/PayPeriods

        /// <summary>
        /// Lấy danh sách tất cả các Kì Lương
        /// </summary>
        [HttpGet("PayPeriods")]
        [AuthorizeRoles(UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPayPeriods()
        {
            try
            {
                var data = _lecturerService.GetPayPeriods();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPeriod" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PayPeriod/PayPeriods

        #region GET api/PayPeriod/{id}

        /// <summary>
        /// Lấy một Kì Lương theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPayPeriod(string id)
        {
            try
            {
                var payPeriod = _lecturerService.GetPayPeriod(id);

                return payPeriod != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, payPeriod))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPeriod" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PayPeriod/{id}

        #region POST api​/PayPeriod

        /// <summary>
        /// Thêm mới một Kì lương cơ bản
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostPayPeriod([FromBody] PayPeriodRequest payPeriodRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string payPeriodId = Guid.NewGuid().ToString();

                    int created = _lecturerService.CreatePayPeriod(payPeriodId, payPeriodRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        var payPeriod = _lecturerService.GetPayPeriod(payPeriodId);

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { payPeriod } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add PayPeriod fail" }));
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

        #endregion POST api​/PayPeriod

        #region PUT api​/PayPeriod​/{id}

        /// <summary>
        /// Cập nhật một Kì Lương theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutPayPeriod(string id, [FromBody] PayPeriodRequest payPeriodRequest)
        {
            try
            {
                int update = _lecturerService.UpdatePayPeriod(id, payPeriodRequest);

                var payPeriod = _lecturerService.GetPayPeriod(id);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { payPeriod } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPeriod" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/PayPeriod​/{id}

        #region GET api/PayPeriod/Months

        /// <summary>
        /// Lấy danh sách tất cả các Tháng có trong Kì Lương và ngày Thống kê lương của GV theo Id Giảng Viên
        /// </summary>
        [HttpPost("Months")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPayMonthPeriods([FromBody] PayPeriodMonthsRequest payPeriodRequest)
        {
            try
            {
                var data = _lecturerService.GetPayMonthsPeriods(payPeriodRequest);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPeriod" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PayPeriod/Months
    }
}
