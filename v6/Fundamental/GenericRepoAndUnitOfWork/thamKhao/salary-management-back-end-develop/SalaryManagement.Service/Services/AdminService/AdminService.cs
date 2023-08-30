using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<JObject> GetAdminInfos()
        {
            List<JObject> objectUser = new();

            var adminList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_AD), e => e.Role).ToList();
            if (adminList.Count > 0)
            {
                foreach (var admin in adminList)
                {
                    admin.Password = null;
                    var ad = _unitOfWork.Admin.FindByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId)).FirstOrDefault();

                    JObject JAdmin = JObject.FromObject(admin);
                    if (ad != null) JAdmin.Add(new JProperty("admin", JObject.FromObject(ad)));
                    else JAdmin.Add(new JProperty("admin", null));
                    objectUser.Add(JObject.FromObject(JAdmin));
                }
            }

            return objectUser;
        }

        public GeneralUserInfo GetAdminById(string adminId)
        {
            var admin = _unitOfWork.Admin.FindByCondition(e => e.AdminId.Equals(adminId)).FirstOrDefault();
            GeneralUserInfo user = null;
            if (admin != null)
            {
                user = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId), e => e.Role).FirstOrDefault();
                user.Password = null;
            }
            return user;
        }

        public int DisableAdmin(string id, bool status)
        {
            int update = -1;
            var admin = _unitOfWork.Admin.FindByCondition(e => e.AdminId.Equals(id)).FirstOrDefault();
            GeneralUserInfo user = null;
            if (admin != null) user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId)).FirstOrDefault();

            if (user != null)
            {
                user.IsDisable = status;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int UpdatePasswordAdmin(string id, UserPasswordRequest userPasswordRequest)
        {
            int update = -1;

            var admin = _unitOfWork.Admin.Find(id);
            if (admin == null) throw new Exception("Not found Admin");

            GeneralUserInfo user = null;
            if (admin != null) user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId)).FirstOrDefault();

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

        public int CreateAdmin(string adminId, AdminRequest adminRequest)
        {
            int created = -1;

            var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.UserName.ToLower().Equals(adminRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
            if (userName != null) throw new Exception($"UserName '{userName}' already exists");

            var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(adminRequest.Gmail.ToLower().Substring(0, adminRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
            if (gmail != null) throw new Exception($"Gmail '{adminRequest.Gmail.ToLower()}' already exists");

            var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.NationalId.ToLower().Equals(adminRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
            if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

            string generalUserInfoId = Guid.NewGuid().ToString();

            string roleId = (_unitOfWork.Role.FindByCondition(e => e.RoleName.Equals(UserInfo.ROLE_AD)).FirstOrDefault()).RoleId;

            GeneralUserInfo generalUserInfo = new()
            {
                GeneralUserInfoId = generalUserInfoId,
                FullName = adminRequest.FullName,
                UserName = adminRequest.UserName,
                Password = adminRequest.Password,
                Gmail = adminRequest.Gmail,
                PhoneNumber = adminRequest.PhoneNumber,
                NationalId = adminRequest.NationalId,
                ImageUrl = adminRequest.ImageUrl,
                DateOfBirth = adminRequest.DateOfBirth,
                Gender = adminRequest.Gender,
                Address = adminRequest.Address,
                IsDisable = adminRequest.IsDisable,
                RoleId = roleId
            };

            _unitOfWork.GeneralUserInfo.Create(generalUserInfo);

            Admin admin = new()
            {
                AdminId = adminId,
                GeneralUserInfoId = generalUserInfoId
            };

            _unitOfWork.Admin.Create(admin);

            created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateAdmin(string id, AdminUpdateRequest adminRequest)
        {
            int update = -1;

            var admin = _unitOfWork.Admin.FindByCondition(e => e.AdminId.Equals(id)).FirstOrDefault();
            GeneralUserInfo user = null;
            if (admin != null) user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId)).FirstOrDefault();

            if (user != null)
            {
                var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.NationalId.ToLower().Equals(adminRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
                if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

                var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.UserName.ToLower().Equals(adminRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
                if (userName != null) throw new Exception($"UserName '{userName}' already exists");

                var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(adminRequest.Gmail.ToLower().Substring(0, adminRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
                if (gmail != null) throw new Exception($"Gmail '{adminRequest.Gmail.ToLower()}' already exists");

                user.FullName = adminRequest.FullName;
                user.UserName = adminRequest.UserName;
                user.Password = adminRequest.Password ?? user.Password; //adminRequest.Password != null ? adminRequest.Password : user.Password
                user.Gmail = adminRequest.Gmail;
                user.PhoneNumber = adminRequest.PhoneNumber;
                user.NationalId = adminRequest.NationalId;
                user.ImageUrl = adminRequest.ImageUrl;
                user.DateOfBirth = adminRequest.DateOfBirth;
                user.Gender = adminRequest.Gender;
                user.Address = adminRequest.Address;
                user.IsDisable = adminRequest.IsDisable;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public JObject GetAdmins(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            List<JObject> objectUser = new();
            int tottalRecords = 0;
            List<GeneralUserInfo> adminList = null;

            if (isDisable != null)
            {
                adminList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_AD) && e.IsDisable == isDisable, e => e.Role)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_AD) && e.IsDisable == isDisable, e => e.Role).Count();
            }
            else
            {
                adminList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_AD), e => e.Role)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_AD), e => e.Role).Count();
            }

            if (adminList.Count > 0)
            {
                foreach (var admin in adminList)
                {

                    var ad = _unitOfWork.Admin.FindByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId)).FirstOrDefault();

                    JObject JAdmin = JObject.FromObject(admin);

                    if (ad != null) JAdmin.Add(new JProperty("admin", JObject.FromObject(ad)));
                    else JAdmin.Add(new JProperty("admin", null));

                    objectUser.Add(JObject.FromObject(JAdmin));
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

        public List<JObject> GetAdminsByName(string name)
        {
            List<JObject> objectUser = new();

            var adminList = _unitOfWork.GeneralUserInfo.FindInclude(e => e.Role)
                .Where(delegate (GeneralUserInfo e)
                {
                    string fullName = StringTemplate.ConvertUTF8(e.FullName).ToLower();
                    string nameConvert = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (e.Role.RoleName.Equals(UserInfo.ROLE_AD) && fullName.Contains(nameConvert))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            if (adminList.Count > 0)
            {
                foreach (var admin in adminList)
                {
                    admin.Password = null;

                    var ad = _unitOfWork.Admin.FindByCondition(e => e.GeneralUserInfoId.Equals(admin.GeneralUserInfoId)).FirstOrDefault();

                    JObject JAdmin = JObject.FromObject(admin);

                    if (ad != null) JAdmin.Add(new JProperty("admin", JObject.FromObject(ad)));
                    else JAdmin.Add(new JProperty("admin", null));

                    objectUser.Add(JObject.FromObject(JAdmin));
                }
            }

            return objectUser;
        }
    }
}
