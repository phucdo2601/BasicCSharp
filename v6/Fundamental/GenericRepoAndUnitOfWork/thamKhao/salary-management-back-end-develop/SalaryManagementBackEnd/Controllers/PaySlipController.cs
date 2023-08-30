using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Responses;
using SalaryManagement.Services.PaySlipService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class PaySlipController : ControllerBase
    {
        private readonly ILogger<PaySlipController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaySlipService _paySlipService;

        public PaySlipController(IUnitOfWork unitOfWork, ILogger<PaySlipController> logger)
        {
            _paySlipService = new PaySlipService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/PaySlip/Formula/Lecturer/{id}

        /// <summary>
        /// Khi Tạo PaySlip: Lấy một Formula và những FormulaAttribute (cần NHẬP vào tính) của Giảng viên theo LecturerId (Cái này quan trọng)
        /// </summary>
        [HttpGet("Formula/Lecturer/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaLecturer(string id)
        {
            try
            {
                var data = _paySlipService.GetFormulaLecturer(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/Formula/Lecturer/{id}

        #region GET api/PaySlip/FormulaUpdate/Lecturer/{id}

        /// <summary>
        /// Khi Update PaySlip: Lấy một Formula và những FormulaAttribute (cần NHẬP vào tính) của Giảng viên theo PaySlipId (Cái này quan trọng)
        /// </summary>
        [HttpGet("FormulaUpdate/Lecturer/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaUpdateLecturer(string id)
        {
            try
            {
                var data = _paySlipService.GetFormulaUpdateLecturer(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Formula" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/FormulaUpdate/Lecturer/{id}

        #region POST api​/PaySlip

        /// <summary>
        /// Thêm mới một PaySlip cho một Giảng viên (Cái này quan trọng)
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PostPaySlip([FromBody] PaySlipRequest paySlipRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string paySlipId = Guid.NewGuid().ToString();

                    int created = _paySlipService.CreatePaySlip(paySlipId, paySlipRequest);

                    var paySlip = _paySlipService.GetPaySlip(paySlipId);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = paySlip }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add PaySlip fail" }));
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

        #endregion POST api​/PaySlip

        #region PUT api​/PaySlip​/{id}

        /// <summary>
        /// Cập nhật một PaySlip theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PutPaySlip(string id, [FromBody] PaySlipRequest paySlipRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    int update = _paySlipService.UpdatePaySlip(id, paySlipRequest);

                    if (update >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, paySlipRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Update PaySlip fail" }));
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

        #endregion PUT api​/PaySlip​/{id}

        #region POST api​/PaySlip/PaySlipItem

        /// <summary>
        /// Thêm mới các PaySlipItem cho một PaySlip (Cái này quan trọng)
        /// </summary>
        [HttpPost("PaySlipItem")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PostPaySlipItem([FromBody] PaySlipDetailRequest paySlipRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    int created = _paySlipService.CreatePaySlipItem(paySlipRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { paySlipRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add PaySlipItem fail" }));
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

        #endregion POST api​/PaySlip/PaySlipItem

        #region PUT api​/PaySlip/PaySlipItem/{id}

        /// <summary>
        /// Cập nhật các PaySlipItem cho một PaySlip
        /// </summary>
        [HttpPut("PaySlipItem")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PutPaySlipItem([FromBody] PaySlipDetailRequest paySlipRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    int update = _paySlipService.UpdatePaySlipItem(paySlipRequest);

                    if (update >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = paySlipRequest }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Update PaySlipItem fail" }));
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

        #endregion PUT api​/PaySlip/PaySlipItem​/{id}

        #region GET api​/PaySlip/PayPeriods/{lecturerId}

        /// <summary>
        /// (Ưu tiên dùng) Lấy tất cả Kì Lương mà Giảng Viên có phiếu lương trong kì đó theo Id Giảng Viên
        /// </summary>
        [HttpGet("PayPeriods/{lecturerId}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPayPeriods(string lecturerId)
        {
            try
            {
                var data = _paySlipService.GetPayPeriods(lecturerId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPeriod" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PayPeriods/{lecturerId}

        #region GET api​/PaySlip/PayPeriods/PaySlips/{lecturerId}

        /// <summary>
        /// (Ưu tiên dùng) Lấy tất cả Kì Lương (Kèm theo phiếu lương) mà Giảng Viên có phiếu lương trong kì đó theo Id Giảng Viên
        /// </summary>
        [HttpGet("PayPeriods/PaySlips/{lecturerId}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlipsInPayPeriods(string lecturerId)
        {
            try
            {
                var data = _paySlipService.GetPaySlipsInPayPeriods(lecturerId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlips" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PayPeriods/PaySlips/{lecturerId}

        #region GET api​/PaySlip/PayPeriods1Year/PaySlips/{lecturerId}

        /// <summary>
        /// (Ưu tiên dùng) Lấy tất cả Kì Lương (Kèm theo phiếu lương) mà Giảng Viên có phiếu lương trong kì đó theo Id Giảng Viên TRONG 1 NĂM
        /// </summary>
        [HttpPost("PayPeriods1Year/PaySlips")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPayPeriods1Year([FromBody] PaySlip1YearRequest paySlipRequest)
        {
            try
            {
                var data = _paySlipService.GetPayPeriods1Year(paySlipRequest);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlips" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PayPeriods1Year/PaySlips/{lecturerId}

        #region GET api​/PaySlip/PaySlips/{payPeriodId}/{lecturerId}

        /// <summary>
        /// (Ưu tiên dùng) Lấy tất cả các Phiếu lương trong Kì Lương của Giảng Viên theo Id Giảng Viên và Id Kì Lương
        /// </summary>
        [HttpGet("PaySlips/{payPeriodId}/{lecturerId}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlipsInPayPeriod(string payPeriodId, string lecturerId)
        {
            try
            {
                var data = _paySlipService.GetPaySlipsInPayPeriod(payPeriodId, lecturerId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PaySlips/{payPeriodId}/{lecturerId}

        #region GET PaySlip/PaySlips/{lecturerId}

        /// <summary>
        /// (Ưu tiên dùng) Lấy tất cả các Phiếu Lương của Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("PaySlips/{lecturerId}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlipsByLecturer(string lecturerId)
        {
            try
            {
                var data = _paySlipService.GetPaySlipsByLecturer(lecturerId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET PaySlip/PaySlips/{lecturerId}

        #region GET PaySlip/PaySlips/Months

        /// <summary>
        /// (Ưu tiên dùng) Lấy tất cả các Phiếu Lương theo các tháng của Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpPost("PaySlips/Months")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlipsMonthsByLecturer([FromBody] PaySlipByMonthRequest paySlipByMonthRequest)
        {
            try
            {
                var data = _paySlipService.GetPaySlipsMonthsByLecturer(paySlipByMonthRequest);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET PaySlip/PaySlips/Months

        #region GET api​/PaySlip/{id}

        /// <summary>
        /// (Ưu tiên dùng) Lấy một Phiếu Lương theo Id Phiếu Lương (Bao gồm các Chi Tiết Phiếu Lương của Phiếu Lương đó)
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlip(string id)
        {
            try
            {
                var data = _paySlipService.GetPaySlip(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/{id}

        #region GET api​/PaySlip/Group/{paySlipId}

        /// <summary>
        /// (Ưu tiên dùng) Lấy một Phiếu Lương theo Id Phiếu Lương (Bao gồm các Chi Tiết Phiếu Lương được nhóm theo GROUP của Phiếu Lương đó)
        /// </summary>
        [HttpGet("Group/{paySlipId}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlipByGroup(string paySlipId)
        {
            try
            {
                var data = _paySlipService.GetPaySlipByGroup(paySlipId);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/Group/{paySlipId}

        #region GET api​/PaySlip/PayPeriods

        /// <summary>
        /// Lấy danh sách tất cả các Kì Lương
        /// </summary>
        [HttpGet("PayPeriods")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetAllPayPeriod()
        {
            try
            {
                var data = _paySlipService.GetAllPayPeriod();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PayPeriod" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PayPeriods

        #region GET api​/PaySlip/PaySlips

        /// <summary>
        /// Lấy danh sách tất cả các Phiếu Lương
        /// </summary>
        [HttpGet("PaySlips")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlips()
        {
            try
            {
                var data = _paySlipService.GetPaySlips();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PaySlips

        #region POST api​/PaySlip/CheckSalary

        /// <summary>
        /// Cách 1: Check Lương của Giảng Viên theo Id Giảng Viên với các giá trị cần tính (Giảng Viên tự check, không lưu vào DB)
        /// </summary>
        [HttpPost("CheckSalary")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PostCheckSalary([FromBody] PaySlipCheckRequest paySlipCheckRequest)
        {
            try
            {
                var data = _paySlipService.PostCheckSalary(paySlipCheckRequest);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/PaySlip/CheckSalary

        #region POST api​/PaySlip/CheckSalaryFull

        /// <summary>
        /// Cách 2: Full chi tiết - Check Lương của Giảng Viên theo Id Giảng Viên với các giá trị cần tính (Giảng Viên tự check, không lưu vào DB)
        /// </summary>
        [HttpPost("CheckSalaryFull")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PostCheckSalaryFull([FromBody] PaySlipCheckRequest paySlipCheckRequest)
        {
            try
            {
                var data = _paySlipService.CheckSalaryFull(paySlipCheckRequest);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/PaySlip/CheckSalaryFull

        #region GET api/PaySlip/TeachingSummaries

        /// <summary>
        /// Lấy danh sách tất cả các TeachingSummary
        /// </summary>
        [HttpGet("TeachingSummaries")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetTeachingSummaries()
        {
            try
            {
                var data = _paySlipService.GetTeachingSummaries();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found TeachingSummary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/TeachingSummaries

        #region GET api/PaySlip/TeachingSummary/{id}

        /// <summary>
        /// Lấy một TeachingSummary (kèm theo các TeachingSummaryDetail) theo TeachingSummaryId
        /// </summary>
        [HttpGet("TeachingSummary/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetTeachingSummary(string id)
        {
            try
            {
                var teachingSummary = _paySlipService.GetTeachingSummary(id);

                return teachingSummary != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, teachingSummary))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found TeachingSummary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/TeachingSummary/{id}

        #region GET api/PaySlip/TeachingSummary/PaySlip/{id}

        /// <summary>
        /// Lấy một TeachingSummary (kèm theo các TeachingSummaryDetail) theo PaySlipId
        /// </summary>
        [HttpGet("TeachingSummary/PaySlip/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetTeachingSummaryByPaySlip(string id)
        {
            try
            {
                var teachingSummary = _paySlipService.GetTeachingSummaryByPaySlip(id);

                return teachingSummary != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, teachingSummary))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found TeachingSummary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/TeachingSummary/PaySlip/{id}

        #region POST api​/PaySlip/TeachingSummary

        /// <summary>
        /// Thêm mới một TeachingSummary
        /// </summary>
        [HttpPost("TeachingSummary")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_EM)]
        public async Task<ActionResult> PostTeachingSummary([FromBody] TeachingSummaryRequest teachingSummaryRequest)
        {
            var transaction = _unitOfWork.BeginTransaction();
            try
            {
                string teachingSummaryId = Guid.NewGuid().ToString();

                int created = _paySlipService.CreateTeachingSummary(teachingSummaryId, teachingSummaryRequest);

                if (created >= 0)
                {
                    transaction.Commit();

                    return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { teachingSummaryId, teachingSummaryRequest } }));
                }
                else
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add TeachingSummary fail" }));
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/PaySlip/TeachingSummary

        #region GET api/PaySlip/HoursProctoringSign/{id}

        /// <summary>
        /// Lấy tổng số Giờ Canh Thi của Giảng Viên trong tháng đó theo PaySlipId
        /// </summary>
        [HttpGet("HoursProctoringSign/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetHoursProctoringSign(string id)
        {
            try
            {
                var teachingSummary = _paySlipService.GetHoursProctoringSign(id);

                return teachingSummary != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, teachingSummary))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ProctoringSign" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/HoursProctoringSign/{id}

        #region GET api​/PaySlip/PaySlipsInYear

        /// <summary>
        /// (Dùng cho biểu đồ) Lấy tất cả Phiếu Lương trong Năm của Giảng Viên theo Id Giảng Viên
        /// </summary>
        [HttpGet("PaySlipsInYear")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPaySlipInYear(string lecturerId, int year)
        {
            try
            {
                var data = _paySlipService.GetPaySlipsInYear(lecturerId, year);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found PaySlip" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api​/PaySlip/PaySlipsInYear

        #region GET api/PaySlip/Tax/TaxAttribute

        /// <summary>
        /// Khi tính Thuế: Lấy công thức Tax và các TaxAttribute (cần NHẬP vào tính) (Cái này quan trọng)
        /// </summary>
        [HttpGet("Tax/TaxAttribute")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetFormulaTax()
        {
            try
            {
                var data = _paySlipService.GetFormulaTax();

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found FormulaTax" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/PaySlip/Tax/TaxAttribute

        #region POST api​/PaySlip/Tax/CheckTax

        /// <summary>
        /// Check Tax với các giá trị cần tính (Giảng Viên tự check, không lưu vào DB)
        /// </summary>
        [HttpPost("Tax/CheckTax")]
        [AuthorizeRoles(UserInfo.ROLE_LEC)]
        public async Task<ActionResult> PostCheckTax([FromBody] PaySlipCheckTax paySlipCheckTax)
        {
            try
            {
                var data = _paySlipService.CheckSalaryTax(paySlipCheckTax);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Tax" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/PaySlip/Tax/CheckTax
    }
}
