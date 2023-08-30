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
using SalaryManagement.Services.ManagerService;
using SalaryManagement.Utility.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class ManagerController : ControllerBase
    {
        private readonly ILogger<ManagerController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IManagerService _managerService;

        public ManagerController(IUnitOfWork unitOfWork, ILogger<ManagerController> logger)
        {
            _managerService = new ManagerService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Manager/ExaminationManagers

        /// <summary>
        /// Lấy tất cả các Examination Manager
        /// </summary>
        [HttpGet("ExaminationManagers")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetExaminationManagers()
        {
            try
            {
                List<JObject> data = _managerService.GetExaminationManagers();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found ExaminationManager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Manager/ExaminationManagers

        #region GET api/Manager/HRManagers

        /// <summary>
        /// Lấy tất cả các HR Manager
        /// </summary>
        [HttpGet("HRManagers")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetHRManagers()
        {
            try
            {
                List<JObject> data = _managerService.GetHRManagers();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found HRManager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Manager/HRManagers

        #region GET api/Manager/{id}

        /// <summary>
        /// Lấy một Manager theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetManager(string id)
        {
            try
            {
                var user = _managerService.GetManagerById(id);

                return user != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, user))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Manager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Manager/{id}

        #region GET api/Manager/search

        /// <summary>
        /// Tìm các Manager theo tên (theo FullName)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetManagerByName(string fullName)
        {
            try
            {
                List<JObject> data = _managerService.GetManagerByName(fullName);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Manager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Manager/search

        #region PUT api/Manager/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của Manager với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutStatusManager(string id, bool status)
        {
            try
            {
                int update = _managerService.DisableManager(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Manager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Manager/{id}/{status}

        #region POST api/Manager

        /// <summary>
        /// Thêm mới một Manager
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostManager([FromBody] ManagerRequest managerRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string managerId = Guid.NewGuid().ToString();

                    int created = _managerService.CreateManager(managerId, managerRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { managerId, managerRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Manager fail" }));
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

        #endregion POST api/Manager

        #region PUT api/Manager/{id}

        /// <summary>
        /// Update một Manager với Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> PutManager(string id, [FromBody] ManagerUpdateRequest managerRequest)
        {
            try
            {
                int update = _managerService.UpdateManager(id, managerRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, managerRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Manager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Manager/{id}

        #region GET api/Manager/ManagerList

        /// <summary>
        /// Lấy tất cả các Manager (Phân trang)
        /// </summary>
        [HttpGet("ManagerList")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetManagerList([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _managerService.GetManagerList(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Manager" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Manager/ManagerList
    }
}