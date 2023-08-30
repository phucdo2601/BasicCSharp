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
using SalaryManagement.Services.AdminService;
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
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminService _adminService;

        public AdminController(IUnitOfWork unitOfWork, ILogger<AdminController> logger)
        {
            _adminService = new AdminService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Admin/AdminInfos

        /// <summary>
        /// Lấy danh sách tất cả Admin
        /// </summary>
        [HttpGet("AdminInfos")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetAdminInfos()
        {
            try
            {
                List<JObject> data = _adminService.GetAdminInfos();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Success, Message = "Not found AdminInfos" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Admin/AdminInfos

        #region GET api/Admin/{id}

        /// <summary>
        /// Lấy một Admin theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetAdminInfo(string id)
        {
            try
            {
                var user = _adminService.GetAdminById(id);

                return user != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, user))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found AdminInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Admin/{id}

        #region GET api/Admin/search

        /// <summary>
        /// Tìm các Admin theo tên (theo FullName)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetAdminsByName(string fullName)
        {
            try
            {
                var users = _adminService.GetAdminsByName(fullName);

                return users.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, users))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found AdminInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Admin/search

        #region PUT api/Admin/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) Admin với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutStatusAdmin(string id, bool status)
        {
            try
            {
                int update = _adminService.DisableAdmin(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found AdminInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Admin/{id}/{status}

        #region PUT api/Admin/Password/{id}

        /// <summary>
        /// Update password của Admin theo Id
        /// </summary>
        [HttpPut("Password/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutPasswordAdmin(string id, [FromBody] UserPasswordRequest userPasswordRequest)
        {
            try
            {
                int update = _adminService.UpdatePasswordAdmin(id, userPasswordRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found AdminInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Admin/Password/{id}

        #region POST api​/Admin

        /// <summary>
        /// Thêm mới một Admin
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostAdmin([FromBody] AdminRequest adminRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string adminId = Guid.NewGuid().ToString();

                    int created = _adminService.CreateAdmin(adminId, adminRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();

                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { adminId, adminRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Admin fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                        new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Admin

        #region PUT api​/Admin​/{id}

        /// <summary>
        /// Cập nhật một Admin theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutAdmin(string id, [FromBody] AdminUpdateRequest adminRequest)
        {
            try
            {
                int update = _adminService.UpdateAdmin(id, adminRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, adminRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found AdminInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Admin​/{id}

        #region GET api/Admin/AdminList

        /// <summary>
        /// Lấy danh sách tất cả Admin (Phân trang)
        /// </summary>
        [HttpGet("AdminList")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetAdmins([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _adminService.GetAdmins(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Admins" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Admin/AdminList
    }
}