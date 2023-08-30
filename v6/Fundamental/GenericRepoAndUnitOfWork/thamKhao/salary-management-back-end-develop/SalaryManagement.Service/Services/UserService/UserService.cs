using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Utility.Mail;
using SalaryManagement.Utility.Mail.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryManagement.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public JObject GetUserById(string userId)
        {
            var user = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(userId), e => e.Role).FirstOrDefault();

            JObject data = new(JObject.FromObject(user));

            string id = null;

            string role = user.Role.RoleName;

            if (role.Equals(UserInfo.ROLE_LEC))
            {
                var lecturer = _unitOfWork.Lecturer.FindByCondition(e => e.GeneralUserInfoId.Equals(user.GeneralUserInfoId)).FirstOrDefault();
                if (lecturer != null) id = lecturer.LecturerId;
            }
            else if (role.Equals(UserInfo.ROLE_EM) || role.Equals(UserInfo.ROLE_HR))
            {
                var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(user.GeneralUserInfoId)).FirstOrDefault();
                if (manager != null) id = manager.ManagerId;
            }
            else if (role.Equals(UserInfo.ROLE_AD))
            {
                var admin = _unitOfWork.Admin.FindByCondition(e => e.GeneralUserInfoId.Equals(user.GeneralUserInfoId)).FirstOrDefault();
                if (admin != null) id = admin.AdminId;
            }

            data.Add("id", id);

            return data;
        }

        public List<JObject> GetUserInfos()
        {
            List<JObject> objectUser = new();

            var userList = _unitOfWork.GeneralUserInfo.FindInclude(e => e.Role).OrderBy(e => e.UserName).ToList();
            if (userList.Count > 0)
            {
                foreach (var user in userList)
                {
                    string id = null;

                    string role = user.Role.RoleName;

                    if (role.Equals(UserInfo.ROLE_LEC))
                    {
                        var lecturer = _unitOfWork.Lecturer.FindByCondition(e => e.GeneralUserInfoId.Equals(user.GeneralUserInfoId)).FirstOrDefault();
                        if (lecturer != null) id = lecturer.LecturerId;
                    }
                    else if (role.Equals(UserInfo.ROLE_EM) || role.Equals(UserInfo.ROLE_HR))
                    {
                        var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(user.GeneralUserInfoId)).FirstOrDefault();
                        if (manager != null) id = manager.ManagerId;
                    }
                    else if (role.Equals(UserInfo.ROLE_AD))
                    {
                        var admin = _unitOfWork.Admin.FindByCondition(e => e.GeneralUserInfoId.Equals(user.GeneralUserInfoId)).FirstOrDefault();
                        if (admin != null) id = admin.AdminId;
                    }

                    JObject data = new(JObject.FromObject(user))
                    {
                        { "id", id }
                    };

                    objectUser.Add(data);
                }
            }

            return objectUser;
        }

        public int DisableUser(string id, bool status)
        {
            int update = -1;

            var user = _unitOfWork.GeneralUserInfo.Find(id);

            if (user != null)
            {
                user.IsDisable = status;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int CreateUser(string userId, UserRequest userRequest)
        {
            int created;

            var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.UserName.ToLower().Equals(userRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
            if (userName != null) throw new Exception($"UserName '{userName}' already exists");

            var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(userRequest.Gmail.ToLower().Substring(0, userRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
            if (gmail != null) throw new Exception($"Gmail '{userRequest.Gmail.ToLower()}' already exists");

            var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.NationalId.ToLower().Equals(userRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
            if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

            var roleRequest = _unitOfWork.Role.Find(userRequest.RoleId);
            if (roleRequest == null) throw new Exception("Not found Role");

            try
            {
                string generalUserInfoId = Guid.NewGuid().ToString();

                GeneralUserInfo generalUserInfo = new()
                {
                    GeneralUserInfoId = generalUserInfoId,
                    FullName = userRequest.FullName,
                    UserName = userRequest.UserName,
                    Password = userRequest.Password,
                    Gmail = userRequest.Gmail,
                    PhoneNumber = userRequest.PhoneNumber,
                    NationalId = userRequest.NationalId,
                    ImageUrl = userRequest.ImageUrl,
                    DateOfBirth = userRequest.DateOfBirth,
                    Gender = userRequest.Gender,
                    Address = userRequest.Address,
                    IsDisable = userRequest.IsDisable,
                    RoleId = userRequest.RoleId
                };

                var role = _unitOfWork.Role.Find(userRequest.RoleId);

                _unitOfWork.GeneralUserInfo.Create(generalUserInfo);

                switch (role.RoleName)
                {
                    case UserInfo.ROLE_AD:
                        Admin admin = new()
                        {
                            AdminId = userId,
                            GeneralUserInfoId = generalUserInfoId
                        };
                        _unitOfWork.Admin.Create(admin);
                        break;
                    case UserInfo.ROLE_LEC:
                        Lecturer lecturer = new()
                        {
                            LecturerId = userId,
                            GeneralUserInfoId = generalUserInfoId
                        };
                        _unitOfWork.Lecturer.Create(lecturer);
                        break;
                    case UserInfo.ROLE_EM:
                        Manager managerE = new()
                        {
                            ManagerId = userId,
                            GeneralUserInfoId = generalUserInfoId
                        };
                        _unitOfWork.Manager.Create(managerE);
                        break;
                    case UserInfo.ROLE_HR:
                        Manager managerHR = new()
                        {
                            ManagerId = userId,
                            GeneralUserInfoId = generalUserInfoId
                        };
                        _unitOfWork.Manager.Create(managerHR);
                        break;
                }

                created = _unitOfWork.Complete();

            }
            catch (Exception)
            {
                created = -1;
            }

            return created;
        }

        public JObject GetUsers(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            List<JObject> objectUser = new();
            List<GeneralUserInfo> userList = null;
            int tottalRecords = 0;

            if (isDisable != null)
            {
                userList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.IsDisable == isDisable, e => e.Role)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();

                tottalRecords = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.IsDisable == isDisable).Count();
            }
            else
            {
                userList = _unitOfWork.GeneralUserInfo.FindInclude(e => e.Role)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();

                tottalRecords = _unitOfWork.GeneralUserInfo.FindAll().Count();
            }

            if (userList.Count > 0)
            {
                foreach (var user in userList)
                {
                    objectUser.Add(JObject.FromObject(user));
                }
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", objectUser));

            return data;
        }

        public List<GeneralUserInfo> GetUsersByName(string name)
        {
            var users = _unitOfWork.GeneralUserInfo.FindInclude(e => e.Role)
                .Where(delegate (GeneralUserInfo e)
                {
                    string fullName = StringTemplate.ConvertUTF8(e.FullName).ToLower();
                    string nameConvert = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (fullName.Contains(nameConvert))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            users.ForEach(e => e.Password = null);
            return users;
        }

        public int UpdatePasswordUser(string id, UserPasswordRequest userPasswordRequest)
        {
            int update = -1;

            var user = _unitOfWork.GeneralUserInfo.Find(id);
            if (user == null) throw new Exception("Not found User");

            if (user != null)
            {
                if (!user.Password.Equals(userPasswordRequest.PasswordOld))
                    throw new Exception("Password does not match old password");

                user.Password = userPasswordRequest.PasswordNew;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public async Task<string> SendMailForgotPassword(string generalUserInfoId)
        {
            var user = _unitOfWork.GeneralUserInfo.Find(generalUserInfoId);
            if (user == null) throw new Exception("Not found User");

            string content = TemplateMail.TEMPLATE_REGISTER_SUCCESS;

            if (user != null)
            {
                content = content.Replace(MailInfo.MAIL_TITLE, "Your password is registered with the system!");
                content = content.Replace(MailInfo.MAIL_YOURNAME, user.FullName);
                content = content.Replace(MailInfo.MAIL_GMAIL_LECTURER, "Your password: " + user.Password);
                content = content.Replace(MailInfo.MAIL_IMAGE, user.ImageUrl);

                MailRequest mailRequest = new()
                {
                    ToEmail = user.Gmail,
                    Subject = "Forgot Password",
                    Body = content
                };

                //string html = File.ReadAllText("path");
                //MailService.SendMail(mailRequest);

                await MailService.SendMailBySendGrid(mailRequest);
            }

            return "Send mail Forgot Password successful, please check your mail. If you do not receive the mail, please check in the spam in mail folder.";
        }
    }
}
