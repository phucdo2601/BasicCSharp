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
using SalaryManagement.Services.UserService;
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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unitOfWork, ILogger<UserController> logger)
        {
            _userService = new UserService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/User/UserInfos

        /// <summary>
        /// Lấy tất cả User
        /// </summary>
        [HttpGet("UserInfos")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetUserInfos()
        {
            try
            {
                List<JObject> data = _userService.GetUserInfos();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found UserInfos" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/User/UserInfos

        #region GET api/User/{id}

        /// <summary>
        /// Lấy một User theo GeneralUserInfoId
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetGeneralUserInfo(string id)
        {
            try
            {
                var user = _userService.GetUserById(id);

                return user != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, user))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found UserInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/User/{id}

        #region GET api/User/search

        /// <summary>
        /// Tìm các User theo Tên (theo FullName)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetUserByName(string fullName)
        {
            try
            {
                var users = _userService.GetUsersByName(fullName);

                return users.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, users))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found UserInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/User/search

        #region PUT api/User/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của User với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutStatusUser(string id, bool status)
        {
            try
            {
                int update = _userService.DisableUser(id, status);
                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found UserInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/User/{id}/{status}

        #region POST api​/User

        /// <summary>
        /// Thêm mới một User
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostUser([FromBody] UserRequest userRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string userId = Guid.NewGuid().ToString();

                    int created = _userService.CreateUser(userId, userRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { userId, userRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add User fail" }));
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

        #endregion POST api​/User

        #region GET api/User/UserList

        /// <summary>
        /// Lấy tất cả Users (Phân trang)
        /// </summary>
        [HttpGet("UserList")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetUserInfos([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _userService.GetUsers(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Users" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/User/UserList

        #region PUT api/User/Password/{id}

        /// <summary>
        /// Update password của User theo GeneralUserInfoId
        /// </summary>
        [HttpPut("Password/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> PutPasswordLecturer(string id, [FromBody] UserPasswordRequest userPasswordRequest)
        {
            try
            {
                int update = _userService.UpdatePasswordUser(id, userPasswordRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found User" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/User/Password/{id}

        #region GET api/User/ForgotPassword/{id}

        /// <summary>
        /// Lấy lại Password cũ của User theo GeneralUserInfoId (dùng cho nút Forgot Password)
        /// </summary>
        [HttpGet("ForgotPassword/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> SendMailForgotPassword(string id)
        {
            try
            {
                var user = await _userService.SendMailForgotPassword(id);

                return user != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, user))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found UserInfo" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/User/ForgotPassword/{id}
    }
}