using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Login;
using SalaryManagement.Responses;
using SalaryManagement.Services.LecturerService;
using SalaryManagement.Services.LoginService;
using SalaryManagement.Utility.Validation;
using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [ApiController]
    [Route("api")]
    [ValidateModel]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginService _loginService;
        private readonly ILecturerService _lecturerService;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration config, ILogger<LoginController> logger)
        {
            _loginService = new LoginService(unitOfWork, config);
            _lecturerService = new LecturerService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
        }

        #region POST api/Login

        /// <summary>
        /// Login bằng username với password
        /// </summary>
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest gmailLoginDto)
        {
            IActionResult response;
            var user = _loginService.AuthenticateUser(gmailLoginDto.UserName, gmailLoginDto.Password);  //check user lúc login

            if (user != null)
            {
                var tokenResponse = _loginService.GetTokenResponse(user);

                response = Ok(tokenResponse);
            }
            else
            {
                response = Unauthorized("User name or password incorrect");
            }

            return response;
        }

        #endregion POST api/Login

        #region POST api/LoginByGmail

        /// <summary>
        /// Login bằng Gmail
        /// </summary>
        [AllowAnonymous]
        [HttpPost("LoginByGmail")]
        public IActionResult LoginGmail(GmailLoginRequest gmailLoginDto)
        {
            IActionResult response;

            try
            {
                string gmail = _loginService.GetGmailValidation(gmailLoginDto);  //Lấy ra email từ OauthIdToken của frontend trả về

                var user = _loginService.AuthenticateUserByGmail(gmail);
                if (user != null)
                {
                    var tokenString = _loginService.GenerateJSONWebToken(user);   //tạo chuỗi token
                    var userResponse = _loginService.GetUserById(user.GeneralUserInfoId);

                    response = Ok(new { token = tokenString, responseData = userResponse });
                }
                else
                {
                    response = Unauthorized("The user does not exist or has been banned by the system");
                }
            }
            catch (Exception e)
            {
                response = Unauthorized(e.Message);
            }

            return response;
        }

        #endregion POST api/LoginByGmail

        #region POST api/LoginByGmailNew

        /// <summary>
        /// Login bằng Gmail - New
        /// </summary>
        [AllowAnonymous]
        [HttpPost("LoginByGmailNew")]
        public async Task<ActionResult> LoginGmailNew(GmailLoginRequest gmailLoginDto)
        {
            try
            {
                string gmail = _loginService.GetGmailValidation(gmailLoginDto);

                var user = _loginService.AuthenticateUserByGmail(gmail);
                if (user != null)
                {
                    var tokenResponse = _loginService.GetTokenResponse(user);

                    return await Task.FromResult(StatusCode(StatusCodes.Status200OK, tokenResponse));
                }
                else
                {
                    if (gmail.Contains(UserInfo.MAIL_FE) || gmail.Contains(UserInfo.MAIL_FPT))
                    {
                        var tokenString = _loginService.GenerateTokenForNewLecturer(gmail);   //tạo chuỗi token
                        dynamic data = new ExpandoObject();
                        data.message = "Not found information of Lecturer, please register!";
                        data.mail = gmail;
                        data.token = tokenString;
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Data = data }));
                    }
                    else
                    {
                        return await Task.FromResult(StatusCode(StatusCodes.Status401Unauthorized, new Responses.Response { StatusCode = StatusCodes.Status401Unauthorized, Status = StatusResponse.Failed, Message = "The user does not exist or has been banned by the system" }));
                    }
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api/LoginByGmailNew

        #region POST api/Resgister

        /// <summary>
        /// Đăng kí một tài khoản Lecturer mới
        /// </summary>
        [AuthorizeRoles(UserInfo.ROLE_NEW)]
        [HttpPost("Resgister")]
        public async Task<ActionResult> Resgister([FromBody] LecturerRequest lecturerRequest)
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
                        var user = _loginService.AuthenticateUserByGmail(lecturerRequest.Gmail);
                        var tokenResponse = _loginService.GetTokenResponse(user);
                        await _loginService.SendMailRegister(user);
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, tokenResponse));
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

        #endregion POST api/Resgister
    }
}