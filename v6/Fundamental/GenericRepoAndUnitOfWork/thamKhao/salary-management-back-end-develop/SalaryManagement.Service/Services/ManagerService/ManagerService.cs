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

namespace SalaryManagement.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<JObject> GetExaminationManagers()
        {
            List<JObject> objectUser = new();

            var userManagerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_EM), e => e.Role).OrderBy(e => e.UserName).ToList();
            if (userManagerList.Count > 0)
            {
                foreach (var userManager in userManagerList)
                {
                    userManager.Password = null;

                    var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(userManager.GeneralUserInfoId)).FirstOrDefault();

                    JObject JManager = JObject.FromObject(userManager);

                    if (manager != null)
                    {
                        JManager.Add(new JProperty("managerId", manager.ManagerId));
                        JManager.Add(new JProperty("manager", JObject.FromObject(manager)));
                    }
                    else JManager.Add(new JProperty("manager", null));

                    objectUser.Add(JObject.FromObject(JManager));
                }
            }

            return objectUser;
        }

        public List<JObject> GetHRManagers()
        {
            List<JObject> objectUser = new();

            var userManagerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_HR), e => e.Role).OrderBy(e => e.UserName).ToList();
            if (userManagerList.Count > 0)
            {
                foreach (var userManager in userManagerList)
                {
                    userManager.Password = null;

                    var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(userManager.GeneralUserInfoId)).FirstOrDefault();

                    JObject JManager = JObject.FromObject(userManager);

                    if (manager != null)
                    {
                        JManager.Add(new JProperty("managerId", manager.ManagerId));
                        JManager.Add(new JProperty("manager", JObject.FromObject(manager)));
                    }
                    else JManager.Add(new JProperty("manager", null));

                    objectUser.Add(JObject.FromObject(JManager));
                }
            }

            return objectUser;
        }

        public GeneralUserInfo GetManagerById(string userId)
        {
            var manager = _unitOfWork.Manager.FindByCondition(e => e.ManagerId.Equals(userId)).FirstOrDefault();
            GeneralUserInfo user = null;
            if (manager != null)
            {
                user = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(manager.GeneralUserInfoId), e => e.Role).FirstOrDefault();
                user.Password = null;
            }

            return user;
        }

        public List<JObject> GetManagerByName(string name)
        {
            List<JObject> objectUser = new();

            var userManagerList = _unitOfWork.GeneralUserInfo.FindInclude(e => e.Role)
                .Where(delegate (GeneralUserInfo e)
                {
                    string fullName = StringTemplate.ConvertUTF8(e.FullName).ToLower();
                    string nameConvert = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (e.Role.RoleName.Equals(UserInfo.ROLE_EM) && fullName.Contains(nameConvert))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            if (userManagerList.Count > 0)
            {
                foreach (var userManager in userManagerList)
                {
                    userManager.Password = null;

                    var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(userManager.GeneralUserInfoId)).FirstOrDefault();

                    JObject JManager = JObject.FromObject(userManager);
                    JManager.Add(new JProperty("manager", JObject.FromObject(manager)));

                    objectUser.Add(JObject.FromObject(JManager));
                }
            }

            return objectUser;
        }

        public int DisableManager(string id, bool status)
        {
            int update = -1;

            var manager = _unitOfWork.Manager.Find(id);
            GeneralUserInfo user = null;
            if (manager != null) user = _unitOfWork.GeneralUserInfo.Find(manager.GeneralUserInfoId);

            if (user != null)
            {
                user.IsDisable = status;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int CreateManager(string managerId, ManagerRequest managerRequest)
        {
            int created = -1;

            var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.UserName.ToLower().Equals(managerRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
            if (userName != null) throw new Exception($"UserName '{userName}' already exists");

            if (!managerRequest.Gmail.Contains(UserInfo.MAIL_FE) && !managerRequest.Gmail.Contains(UserInfo.MAIL_FPT))
            {
                throw new Exception($"Gmail must have the extension '{UserInfo.MAIL_FPT}' or '{UserInfo.MAIL_FE}'");
            }

            var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(managerRequest.Gmail.ToLower().Substring(0, managerRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
            if (gmail != null) throw new Exception($"Gmail '{managerRequest.Gmail.ToLower()}' already exists");

            var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.NationalId.ToLower().Equals(managerRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
            if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

            var role = _unitOfWork.Role.Find(managerRequest.RoleId);
            if (role == null) throw new Exception("Not found Role");

            string generalUserInfoId = Guid.NewGuid().ToString();

            GeneralUserInfo generalUserInfo = new()
            {
                GeneralUserInfoId = generalUserInfoId,
                FullName = managerRequest.FullName,
                UserName = managerRequest.UserName,
                Password = managerRequest.Password,
                Gmail = managerRequest.Gmail,
                PhoneNumber = managerRequest.PhoneNumber,
                NationalId = managerRequest.NationalId,
                ImageUrl = managerRequest.ImageUrl,
                DateOfBirth = managerRequest.DateOfBirth,
                Gender = managerRequest.Gender,
                Address = managerRequest.Address,
                IsDisable = managerRequest.IsDisable,
                RoleId = role.RoleId
            };

            _unitOfWork.GeneralUserInfo.Create(generalUserInfo);

            switch (role.RoleName)
            {
                case UserInfo.ROLE_EM:
                    Manager managerE = new()
                    {
                        ManagerId = managerId,
                        GeneralUserInfoId = generalUserInfoId
                    };
                    _unitOfWork.Manager.Create(managerE);
                    break;
                case UserInfo.ROLE_HR:
                    Manager managerHR = new()
                    {
                        ManagerId = managerId,
                        GeneralUserInfoId = generalUserInfoId
                    };
                    _unitOfWork.Manager.Create(managerHR);
                    break;
            }

            created = _unitOfWork.Complete();

            //Send mail
            try
            {
                var user = generalUserInfo;

                string content = TemplateMail.TEMPLATE_REGISTER_SUCCESS;

                if (user != null)
                {
                    content = content.Replace(MailInfo.MAIL_TITLE, "Your account has been created by an administrator!");
                    content = content.Replace(MailInfo.MAIL_YOURNAME, user.FullName);
                    content = content.Replace(MailInfo.MAIL_GMAIL_LECTURER, "Your password: " + user.Password);
                    content = content.Replace(MailInfo.MAIL_IMAGE, user.ImageUrl);

                    MailRequest mailRequest = new()
                    {
                        ToEmail = user.Gmail,
                        Subject = "Account is ready to use",
                        Body = content
                    };

                    //string html = File.ReadAllText("path");
                    //MailService.SendMail(mailRequest);

                    MailService.SendMailBySendGrid(mailRequest).GetAwaiter().GetResult();
                }
            }
            catch (Exception)
            {

            }

            return created;
        }

        public int UpdateManager(string id, ManagerUpdateRequest managerRequest)
        {
            int update = -1;

            var manager = _unitOfWork.Manager.Find(id);
            GeneralUserInfo user = null;
            if (manager != null)
            {
                user = _unitOfWork.GeneralUserInfo.Find(manager.GeneralUserInfoId);
            }
            if (user != null)
            {
                var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.NationalId.ToLower().Equals(managerRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
                if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

                if (!managerRequest.Gmail.Contains(UserInfo.MAIL_FE) && !managerRequest.Gmail.Contains(UserInfo.MAIL_FPT))
                {
                    throw new Exception($"Gmail must have the extension '{UserInfo.MAIL_FPT}' or '{UserInfo.MAIL_FE}'");
                }

                var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(managerRequest.Gmail.ToLower().Substring(0, managerRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
                if (gmail != null) throw new Exception($"Gmail '{managerRequest.Gmail.ToLower()}' already exists");

                var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.UserName.ToLower().Equals(managerRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
                if (userName != null) throw new Exception($"UserName '{userName}' already exists");

                user.FullName = managerRequest.FullName;
                user.UserName = managerRequest.UserName;
                user.Password = managerRequest.Password ?? user.Password; //managerRequest.Password != null ? managerRequest.Password : user.Password
                user.Gmail = managerRequest.Gmail;
                user.PhoneNumber = managerRequest.PhoneNumber;
                user.NationalId = managerRequest.NationalId;
                user.ImageUrl = managerRequest.ImageUrl;
                user.DateOfBirth = managerRequest.DateOfBirth;
                user.Gender = managerRequest.Gender;
                user.Address = managerRequest.Address;
                user.IsDisable = managerRequest.IsDisable;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public JObject GetManagerList(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            List<JObject> objectUser = new();
            List<GeneralUserInfo> userManagerList = null;
            int tottalRecords = 0;

            if (isDisable != null)
            {
                userManagerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_EM) && e.IsDisable == isDisable, e => e.Role)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_EM) && e.IsDisable == isDisable).Count();
            }
            else
            {
                userManagerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_EM), e => e.Role)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_EM)).Count();
            }

            if (userManagerList.Count > 0)
            {
                foreach (var userManager in userManagerList)
                {
                    var manager = _unitOfWork.Manager.FindByCondition(e => e.GeneralUserInfoId.Equals(userManager.GeneralUserInfoId)).FirstOrDefault();

                    JObject JManager = JObject.FromObject(userManager);
                    if (manager != null) JManager.Add(new JProperty("manager", JObject.FromObject(manager)));
                    else JManager.Add(new JProperty("manager", null));

                    objectUser.Add(JObject.FromObject(JManager));
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
    }
}
