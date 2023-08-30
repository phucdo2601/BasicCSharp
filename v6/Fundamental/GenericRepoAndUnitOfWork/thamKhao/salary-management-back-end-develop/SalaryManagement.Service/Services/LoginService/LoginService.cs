using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests.Login;
using SalaryManagement.Responses;
using SalaryManagement.Utility.Mail;
using SalaryManagement.Utility.Mail.Template;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalaryManagement.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        // AuthenticateUser by gmail
        public GeneralUserInfo AuthenticateUserByGmail(string gmail)
        {
            GeneralUserInfo user = new();

            user = _unitOfWork.GeneralUserInfo.FindByCondition(x => x.Gmail.Equals(gmail) && x.IsDisable == false).FirstOrDefault();

            return user;
        }

        // AuthenticateUser by username and password
        public GeneralUserInfo AuthenticateUser(string userName, string password)
        {
            GeneralUserInfo user = null;

            // Lấy user
            user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.UserName.Equals(userName) && e.IsDisable == false).FirstOrDefault();
            if (user != null) if (!user.Password.Equals(password)) user = null;

            return user;
        }

        public string GenerateJSONWebToken(GeneralUserInfo userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  //Mã hóa Key trong appsetting.json
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);   //Giải thuật encode: HMAC SHA-256

            var role = _unitOfWork.Role.FindByCondition(x => x.RoleId.Equals(userInfo.RoleId)).FirstOrDefault();

            var claims = new List<Claim>()
            {
                new Claim("gmail", userInfo.Gmail),   // đưa Gmail vào token luôn
                new Claim("fullName", userInfo.FullName),   
                //new Claim("userRole", userInfo.RoleId),
                new Claim(ClaimTypes.Role, role.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  //JWT ID
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(2),   //token chỉ tồn tại trong 2 ngày
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateTokenForNewLecturer(string gmail)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  //Mã hóa Key trong appsetting.json
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);   //Giải thuật encode: HMAC SHA-256

            var claims = new List<Claim>()
            {
                new Claim("gmail", gmail),   // đưa Gmail vào token luôn   
                new Claim(ClaimTypes.Role, UserInfo.ROLE_NEW),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  //JWT ID
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(2),   //token chỉ tồn tại trong 2 ngày
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetGmailValidation(GmailLoginRequest gmailLoginDto)
        {
            GoogleJsonWebSignature.ValidationSettings settings = new();
            string GoogleClientID = _config.GetValue<string>("GoogleClientID").ToString(); //Lấy GoogleClientID từ appsettings.json

            //Google client ID
            settings.Audience = new List<string>() { GoogleClientID };

            GoogleJsonWebSignature.Payload payload = GoogleJsonWebSignature.ValidateAsync(gmailLoginDto.OauthIdToken, settings).Result;  //Lấy kết quả từ Validate của Google

            return payload.Email;
        }

        public TokenResponse GetTokenResponse(GeneralUserInfo user)
        {
            var tokenString = GenerateJSONWebToken(user);   //tạo chuỗi token
            var userResponse = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(x => x.GeneralUserInfoId.Equals(user.GeneralUserInfoId), e => e.Role).FirstOrDefault();
            userResponse.Password = null; //Xoa password

            string id = null;

            string role = userResponse.Role.RoleName;

            if (role.Equals(UserInfo.ROLE_LEC))
            {
                var lecturer = _unitOfWork.Lecturer.FindByCondition(e => e.GeneralUserInfoId.Equals(userResponse.GeneralUserInfoId)).FirstOrDefault();
                if (lecturer != null) id = lecturer.LecturerId;
            }
            else if (role.Equals(UserInfo.ROLE_EM) || role.Equals(UserInfo.ROLE_HR))
            {
                var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(userResponse.GeneralUserInfoId)).FirstOrDefault();
                if (manager != null) id = manager.ManagerId;
            }
            else if (role.Equals(UserInfo.ROLE_AD))
            {
                var admin = _unitOfWork.Admin.FindByCondition(e => e.GeneralUserInfoId.Equals(userResponse.GeneralUserInfoId)).FirstOrDefault();
                if (admin != null) id = admin.AdminId;
            }

            TokenResponse tokenResponse = new()
            {
                Token = tokenString,
                Id = id,
                ResponseData = userResponse
            };

            return tokenResponse;
        }

        public GeneralUserInfo GetUserById(string id)
        {
            var userResponse = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(x => x.GeneralUserInfoId.Equals(id), e => e.Role).FirstOrDefault();
            userResponse.Password = null; //Xoa password

            return userResponse;
        }

        public async Task SendMailRegister(GeneralUserInfo user)
        {
            try
            {
                string content = TemplateMail.TEMPLATE_REGISTER_SUCCESS;

                if (user != null)
                {
                    content = content.Replace(MailInfo.MAIL_TITLE, "You have successfully registered an account!");
                    content = content.Replace(MailInfo.MAIL_YOURNAME, user.FullName);
                    content = content.Replace(MailInfo.MAIL_GMAIL_LECTURER, user.Gmail);
                    content = content.Replace(MailInfo.MAIL_IMAGE, user.ImageUrl);

                    MailRequest mailRequest = new()
                    {
                        ToEmail = user.Gmail,
                        Subject = "Register successfully",
                        Body = content
                    };

                    //string html = File.ReadAllText("path");
                    //MailService.SendMail(mailRequest);

                    await MailService.SendMailBySendGrid(mailRequest);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}