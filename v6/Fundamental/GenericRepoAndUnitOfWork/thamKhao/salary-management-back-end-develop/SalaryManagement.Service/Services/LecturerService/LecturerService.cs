using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Utility.Excel;
using SalaryManagement.Utility.Mail;
using SalaryManagement.Utility.Mail.Template;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryManagement.Services.LecturerService
{
    public class LecturerService : ILecturerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LecturerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<JObject> GetLecturerInfos()
        {
            List<JObject> objectUser = new();

            var lecturerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_LEC), e => e.Role).OrderBy(e => e.UserName).ToList();
            if (lecturerList.Count > 0)
            {
                foreach (var lecturer in lecturerList)
                {
                    lecturer.Password = null;

                    var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId), e => e.LecturerType).FirstOrDefault();
                    lec.BasicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                    lec.Fesalary = _unitOfWork.FESalary.Find(lec.FesalaryId);

                    var deparment = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.LecturerId.Equals(lec.LecturerId), e => e.LecturerPosition, e => e.Department.School).FirstOrDefault();
                    JObject JLecture = JObject.FromObject(lecturer);

                    if (lec != null) JLecture.Add(new JProperty("lecturer", JObject.FromObject(lec)));
                    else JLecture.Add(new JProperty("lecturer", null));

                    if (deparment != null) JLecture.Add(new JProperty("deparment", JObject.FromObject(deparment)));

                    objectUser.Add(JObject.FromObject(JLecture));
                }
            }

            return objectUser;
        }

        public JObject GetLecturerById(string lecturerId)
        {
            JObject data = null;

            var lecturer = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId), e => e.LecturerType).FirstOrDefault();
            if (lecturer == null) throw new Exception("Not found Lecturer");
            lecturer.BasicSalary = _unitOfWork.BasicSalary.Find(lecturer.BasicSalaryId);
            lecturer.Fesalary = _unitOfWork.FESalary.Find(lecturer.FesalaryId);

            GeneralUserInfo user = null;
            if (lecturer != null)
            {
                data = new();
                user = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId), e => e.Role).FirstOrDefault();

                user.Password = null;

                var deparment = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.LecturerId.Equals(lecturer.LecturerId), e => e.LecturerPosition, e => e.Department.School).FirstOrDefault();

                data.Add(new JProperty("info", JObject.FromObject(user)));

                if (lecturer != null) data.Add(new JProperty("lecturer", JObject.FromObject(lecturer)));
                else data.Add(new JProperty("lecturer", null));

                if (deparment != null) data.Add(new JProperty("deparment", JObject.FromObject(deparment)));
            }

            return data;
        }

        public int DisableLecturer(string id, bool status)
        {
            int update = -1;

            var lecturer = _unitOfWork.Lecturer.FindByCondition(e => e.LecturerId.Equals(id)).FirstOrDefault();
            GeneralUserInfo user = null;
            if (lecturer != null) user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId)).FirstOrDefault();

            if (user != null)
            {
                user.IsDisable = status;

                _unitOfWork.GeneralUserInfo.Update(user);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int UpdatePasswordLecturer(string id, UserPasswordRequest userPasswordRequest)
        {
            int update = -1;

            var lecturer = _unitOfWork.Lecturer.Find(id);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            GeneralUserInfo user = null;
            if (lecturer != null) user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId)).FirstOrDefault();

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

        public int CreateLecturer(string lecturerId, LecturerRequest lecturerRequest)
        {
            int created;

            var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.UserName.ToLower().Equals(lecturerRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
            if (userName != null) throw new Exception($"UserName '{userName}' already exists");

            if (!lecturerRequest.Gmail.Contains(UserInfo.MAIL_FE) && !lecturerRequest.Gmail.Contains(UserInfo.MAIL_FPT))
            {
                throw new Exception($"Gmail must have the extension '{UserInfo.MAIL_FPT}' or '{UserInfo.MAIL_FE}'");
            }

            var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(lecturerRequest.Gmail.ToLower().Substring(0, lecturerRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
            if (gmail != null) throw new Exception($"Gmail '{lecturerRequest.Gmail.ToLower()}' already exists");

            var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.NationalId.ToLower().Equals(lecturerRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
            if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

            var department = _unitOfWork.Department.Find(lecturerRequest.DepartmentId);
            if (department == null) throw new Exception("Not found Department");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturerRequest.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType");

            var basicSalary = _unitOfWork.BasicSalary.Find(lecturerRequest.BasicSalaryId);
            if (basicSalary == null) throw new Exception("Not found BasicSalary");

            var feSalary = _unitOfWork.FESalary.Find(lecturerRequest.FesalaryId);
            if (feSalary == null) throw new Exception("Not found FESalary");

            var lecturerPosition = _unitOfWork.LecturerPosition.Find(lecturerRequest.LecturerPositionId);
            if (lecturerPosition == null) throw new Exception("Not found LecturerPosition");

            var lecturerCodeLec = _unitOfWork.Lecturer.FindByCondition(e => e.LecturerCode.Equals(lecturerRequest.LecturerCode)).FirstOrDefault();
            if (lecturerCodeLec != null) throw new Exception("LecturerCode has existed");

            try
            {
                string generalUserInfoId = Guid.NewGuid().ToString();

                string roleId = (_unitOfWork.Role.FindByCondition(e => e.RoleName.Equals(UserInfo.ROLE_LEC)).FirstOrDefault()).RoleId;

                GeneralUserInfo generalUserInfo = new()
                {
                    GeneralUserInfoId = generalUserInfoId,
                    FullName = lecturerRequest.FullName,
                    UserName = lecturerRequest.UserName,
                    Password = lecturerRequest.Password,
                    Gmail = lecturerRequest.Gmail,
                    PhoneNumber = lecturerRequest.PhoneNumber,
                    NationalId = lecturerRequest.NationalId,
                    ImageUrl = lecturerRequest.ImageUrl,
                    DateOfBirth = lecturerRequest.DateOfBirth,
                    Gender = lecturerRequest.Gender,
                    Address = lecturerRequest.Address,
                    IsDisable = lecturerRequest.IsDisable,
                    RoleId = roleId
                };

                _unitOfWork.GeneralUserInfo.Create(generalUserInfo);

                Lecturer lecturer = new()
                {
                    LecturerId = lecturerId,
                    LecturerCode = lecturerRequest.LecturerCode,
                    LecturerTypeId = lecturerRequest.LecturerTypeId,
                    BasicSalaryId = lecturerRequest.BasicSalaryId,
                    FesalaryId = lecturerRequest.FesalaryId,
                    GeneralUserInfoId = generalUserInfoId
                };

                _unitOfWork.Lecturer.Create(lecturer);

                string lecturerDepartmentId = Guid.NewGuid().ToString();

                LecturerDepartment lecturerDepartment = new()
                {
                    LecturerDepartmentId = lecturerDepartmentId,
                    StartDate = DateTime.Now,
                    IsWorking = true,
                    ModifiedDate = DateTime.Now,
                    LecturerPositionId = lecturerRequest.LecturerPositionId,
                    LecturerId = lecturerId,
                    DepartmentId = lecturerRequest.DepartmentId
                };

                _unitOfWork.LecturerDepartment.Create(lecturerDepartment);

                //Add History
                SalaryHistory salaryHistory = new()
                {
                    SalaryHistoryId = Guid.NewGuid().ToString(),
                    StartDate = DateTime.Now,
                    EndDate = null,
                    BasicSalary = basicSalary.Salary,
                    Fesalary = feSalary.Salary,
                    ModifiedDate = DateTime.Now,
                    IsUsing = true,
                    BasicSalaryId = basicSalary.BasicSalaryId,
                    FesalaryId = feSalary.FesalaryId,
                    LecturerTypeId = lecturerType.LecturerTypeId,
                    LecturerId = lecturerId
                };
                _unitOfWork.SalaryHistory.Create(salaryHistory);

                created = _unitOfWork.Complete();
            }
            catch (Exception)
            {
                created = -1;
            }

            return created;
        }

        public int UpdateLecturer(string id, LecturerUpdateRequest lecturerRequest)
        {
            int update = -1;

            if (!lecturerRequest.Gmail.Contains(UserInfo.MAIL_FE) && !lecturerRequest.Gmail.Contains(UserInfo.MAIL_FPT))
            {
                throw new Exception($"Gmail must have the extension '{UserInfo.MAIL_FPT}' or '{UserInfo.MAIL_FE}'");
            }

            var department = _unitOfWork.Department.Find(lecturerRequest.DepartmentId);
            if (department == null) throw new Exception("Not found Department");

            var lecturerType = _unitOfWork.LecturerType.Find(lecturerRequest.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType");

            var basicSalary = _unitOfWork.BasicSalary.Find(lecturerRequest.BasicSalaryId);
            if (basicSalary == null) throw new Exception("Not found BasicSalary");

            var feSalary = _unitOfWork.FESalary.Find(lecturerRequest.FesalaryId);
            if (feSalary == null) throw new Exception("Not found FESalary");

            var lecturerPosition = _unitOfWork.LecturerPosition.Find(lecturerRequest.LecturerPositionId);
            if (lecturerPosition == null) throw new Exception("Not found LecturerPosition");

            var lecturer = _unitOfWork.Lecturer.FindByCondition(e => e.LecturerId.Equals(id)).FirstOrDefault();

            if (!lecturer.LecturerCode.Equals(lecturerRequest.LecturerCode))
            {
                var lecturerCodeLec = _unitOfWork.Lecturer.FindByCondition(e => e.LecturerCode.Equals(lecturerRequest.LecturerCode)).FirstOrDefault();
                if (lecturerCodeLec != null) throw new Exception("LecturerCode has existed");
            }

            //Add History
            if (!lecturer.BasicSalaryId.Equals(lecturerRequest.BasicSalaryId) ||
                !lecturer.FesalaryId.Equals(lecturerRequest.FesalaryId) ||
                !lecturer.LecturerTypeId.Equals(lecturerRequest.LecturerTypeId))
            {
                var historyOld = _unitOfWork.SalaryHistory.FindByCondition(e => e.LecturerId.Equals(id)).OrderByDescending(e => e.StartDate).FirstOrDefault();
                if (historyOld != null)
                {
                    historyOld.EndDate = DateTime.Now;
                    historyOld.IsUsing = false;
                    _unitOfWork.SalaryHistory.Update(historyOld);
                }

                SalaryHistory salaryHistory = new()
                {
                    SalaryHistoryId = Guid.NewGuid().ToString(),
                    StartDate = DateTime.Now,
                    EndDate = null,
                    BasicSalary = basicSalary.Salary,
                    Fesalary = feSalary.Salary,
                    ModifiedDate = DateTime.Now,
                    IsUsing = true,
                    BasicSalaryId = basicSalary.BasicSalaryId,
                    FesalaryId = feSalary.FesalaryId,
                    LecturerTypeId = lecturerType.LecturerTypeId,
                    LecturerId = id
                };
                _unitOfWork.SalaryHistory.Create(salaryHistory);
            }

            GeneralUserInfo user = null;
            if (lecturer != null)
            {
                user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId)).FirstOrDefault();

                lecturer.LecturerCode = lecturerRequest.LecturerCode;
                lecturer.LecturerTypeId = lecturerRequest.LecturerTypeId;
                lecturer.BasicSalaryId = lecturerRequest.BasicSalaryId;
                lecturer.FesalaryId = lecturerRequest.FesalaryId;

                _unitOfWork.Lecturer.Update(lecturer);
            }

            if (user != null)
            {
                var userName = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.UserName.ToLower().Equals(lecturerRequest.UserName.ToLower())).Select(e => e.UserName).FirstOrDefault();
                if (userName != null) throw new Exception($"UserName '{userName}' already exists");

                var gmail = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.Gmail.ToLower().Substring(0, e.Gmail.ToLower().IndexOf("@")).Equals(lecturerRequest.Gmail.ToLower().Substring(0, lecturerRequest.Gmail.ToLower().IndexOf("@")))).Select(e => e.Gmail).FirstOrDefault();
                if (gmail != null) throw new Exception($"Gmail '{lecturerRequest.Gmail.ToLower()}' already exists");

                var nationalId = _unitOfWork.GeneralUserInfo.FindByCondition(e => !e.GeneralUserInfoId.Equals(user.GeneralUserInfoId) && e.NationalId.ToLower().Equals(lecturerRequest.NationalId.ToLower())).Select(e => e.NationalId).FirstOrDefault();
                if (nationalId != null) throw new Exception($"NationalId '{nationalId}' already exists");

                user.FullName = lecturerRequest.FullName;
                user.UserName = lecturerRequest.UserName;
                user.Password = lecturerRequest.Password ?? user.Password; //lecturerRequest.Password != null ? lecturerRequest.Password : user.Password
                user.Gmail = lecturerRequest.Gmail;
                user.PhoneNumber = lecturerRequest.PhoneNumber;
                user.NationalId = lecturerRequest.NationalId;
                user.ImageUrl = lecturerRequest.ImageUrl;
                user.DateOfBirth = lecturerRequest.DateOfBirth;
                user.Gender = lecturerRequest.Gender;
                user.Address = lecturerRequest.Address;
                user.IsDisable = lecturerRequest.IsDisable;

                _unitOfWork.GeneralUserInfo.Update(user);
            }

            //Update LecturerDepartment
            var lecDep = _unitOfWork.LecturerDepartment.FindByCondition(e => e.LecturerId.Equals(id)).FirstOrDefault();
            if (lecDep != null)
            {
                lecDep.DepartmentId = lecturerRequest.DepartmentId;
                lecDep.LecturerPositionId = lecturerRequest.LecturerPositionId;

                _unitOfWork.LecturerDepartment.Update(lecDep);
            }

            update = _unitOfWork.Complete();

            return update;
        }

        public List<LecturerType> GetLecturerTypes()
        {
            var lecturerTypes = _unitOfWork.LecturerType.FindInclude(e => e.Formula).OrderBy(e => e.LecturerTypeName).ToList();
            return lecturerTypes;
        }
        public int CreateLecturerType(string lecturerTypeId, LecturerTypeRequest lecturerTypeRequest)
        {
            var formula = _unitOfWork.Formula.Find(lecturerTypeRequest.FormulaId);
            if (formula == null) throw new Exception("Not found Formula");

            var lecturerTypeName = _unitOfWork.LecturerType.FindByCondition(e => e.LecturerTypeName.ToLower().Equals(lecturerTypeRequest.LecturerTypeName.ToLower())).Select(e => e.LecturerTypeName).FirstOrDefault();
            if (lecturerTypeName != null) throw new Exception($"LecturerTypeName '{lecturerTypeName}' already exists");

            LecturerType lecturerType = new()
            {
                LecturerTypeId = lecturerTypeId,
                LecturerTypeName = lecturerTypeRequest.LecturerTypeName,
                StatisticsStartDay = lecturerTypeRequest.StatisticsStartDay,
                StatisticsEndDay = lecturerTypeRequest.StatisticsEndDay,
                PayDay = lecturerTypeRequest.PayDay,
                FormulaId = lecturerTypeRequest.FormulaId
            };

            _unitOfWork.LecturerType.Create(lecturerType);

            int created = _unitOfWork.Complete();

            return created;
        }
        public int UpdateLecturerType(string id, LecturerTypeRequest lecturerTypeRequest)
        {
            int update = -1;

            var formula = _unitOfWork.Formula.Find(lecturerTypeRequest.FormulaId);
            if (formula == null) throw new Exception("Not found Formula");

            var lecturerType = _unitOfWork.LecturerType.Find(id);

            if (lecturerType != null)
            {
                var lecturerTypeName = _unitOfWork.LecturerType.FindByCondition(e => !e.LecturerTypeId.Equals(lecturerType.LecturerTypeId) && e.LecturerTypeName.ToLower().Equals(lecturerTypeRequest.LecturerTypeName.ToLower())).Select(e => e.LecturerTypeName).FirstOrDefault();
                if (lecturerTypeName != null) throw new Exception($"LecturerTypeName '{lecturerTypeName}' already exists");

                lecturerType.LecturerTypeName = lecturerTypeRequest.LecturerTypeName;
                lecturerType.StatisticsStartDay = lecturerTypeRequest.StatisticsStartDay;
                lecturerType.StatisticsEndDay = lecturerTypeRequest.StatisticsEndDay;
                lecturerType.PayDay = lecturerTypeRequest.PayDay;
                lecturerType.FormulaId = lecturerTypeRequest.FormulaId;

                _unitOfWork.LecturerType.Update(lecturerType);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public JObject GetLecturerList(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            List<JObject> objectUser = new();
            List<GeneralUserInfo> lecturerList = null;
            int tottalRecords = 0;

            if (isDisable != null)
            {
                lecturerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_LEC) && e.IsDisable == isDisable, e => e.Role)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_LEC) && e.IsDisable == isDisable).Count();
            }
            else
            {
                lecturerList = _unitOfWork.GeneralUserInfo.FindIncludeByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_LEC), e => e.Role)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.Role.RoleName.Equals(UserInfo.ROLE_LEC)).Count();
            }

            if (lecturerList.Count > 0)
            {
                foreach (var lecturer in lecturerList)
                {
                    var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId), e => e.LecturerType).FirstOrDefault();
                    lec.BasicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                    lec.Fesalary = _unitOfWork.FESalary.Find(lec.FesalaryId);

                    var deparment = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.LecturerId.Equals(lec.LecturerId), e => e.LecturerPosition, e => e.Department.School).FirstOrDefault();

                    JObject JLecture = JObject.FromObject(lecturer);

                    if (lec != null) data.Add(new JProperty("lecturer", JObject.FromObject(lec)));
                    else data.Add(new JProperty("lecturer", null));

                    if (deparment != null) JLecture.Add(new JProperty("deparment", JObject.FromObject(deparment)));

                    objectUser.Add(JObject.FromObject(JLecture));
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

        public int CreateLecturerExcel(IFormFile file)
        {
            int created;

            try
            {
                ExcelManage excelManage = new();
                List<LecturerRequest> lecturerRequests = ExcelManage.ReadFileExcel(file, _unitOfWork.GetContext());

                foreach (LecturerRequest lecturer in lecturerRequests)
                {
                    string lecturerId = Guid.NewGuid().ToString();
                    CreateLecturer(lecturerId, lecturer);
                }

                created = _unitOfWork.Complete();
            }
            catch (Exception)
            {
                throw;
            }

            return created;
        }

        public List<JObject> GetLecturersByName(string name)
        {
            List<JObject> objectUser = new();

            var lecturerList = _unitOfWork.GeneralUserInfo.FindInclude(e => e.Role)
                .Where(delegate (GeneralUserInfo e)
                {
                    string fullName = StringTemplate.ConvertUTF8(e.FullName).ToLower();
                    string nameConvert = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (e.Role.RoleName.Equals(UserInfo.ROLE_LEC) && fullName.Contains(nameConvert))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            if (lecturerList.Count > 0)
            {
                foreach (var lecturer in lecturerList)
                {
                    lecturer.Password = null;

                    var lec = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.GeneralUserInfoId.Equals(lecturer.GeneralUserInfoId), e => e.LecturerType).FirstOrDefault();
                    lec.BasicSalary = _unitOfWork.BasicSalary.Find(lec.BasicSalaryId);
                    lec.Fesalary = _unitOfWork.FESalary.Find(lec.FesalaryId);

                    var deparment = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.LecturerId.Equals(lec.LecturerId), e => e.LecturerPosition, e => e.Department.School).FirstOrDefault();

                    JObject JLecture = JObject.FromObject(lecturer);

                    if (lec != null) JLecture.Add(new JProperty("lecturer", JObject.FromObject(lec)));
                    else JLecture.Add(new JProperty("lecturer", null));

                    if (deparment != null) JLecture.Add(new JProperty("deparment", JObject.FromObject(deparment)));

                    objectUser.Add(JObject.FromObject(JLecture));
                }
            }

            return objectUser;
        }

        public LecturerType GetLecturerType(string lecturerTypeId)
        {
            var lecturerType = _unitOfWork.LecturerType.FindIncludeByCondition(e => e.LecturerTypeId.Equals(lecturerTypeId), e => e.Formula).FirstOrDefault();
            return lecturerType;
        }

        public async Task<string> GetTestSendMail()
        {
            string content = TemplateMail.TEMPLATE_REGISTER_SUCCESS;

            var user = _unitOfWork.GeneralUserInfo.FindByCondition(e => e.UserName.Equals("vinhlecturer")).FirstOrDefault();

            if (user != null)
            {
                content = content.Replace(MailInfo.MAIL_YOURNAME, user.FullName);
                content = content.Replace(MailInfo.MAIL_TITLE, "Test mail");
                content = content.Replace(MailInfo.MAIL_GMAIL_LECTURER, user.Gmail);
                content = content.Replace(MailInfo.MAIL_IMAGE, user.ImageUrl);
            }

            MailRequest mailRequest = new()
            {
                ToEmail = "zingleeng@gmail.com",
                Subject = "Test mail successful",
                Body = content
            };

            //string html = File.ReadAllText("path");
            //MailService.SendMail(mailRequest);

            await MailService.SendMailBySendGrid(mailRequest);

            return "Send mail successful";
        }

        public async Task SendMailCreateLecturer(string lecturerId)
        {
            //Send mail
            try
            {
                var user = _unitOfWork.Lecturer.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId), e => e.GeneralUserInfo).Select(e => e.GeneralUserInfo).FirstOrDefault();

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

                    await MailService.SendMailBySendGrid(mailRequest);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
