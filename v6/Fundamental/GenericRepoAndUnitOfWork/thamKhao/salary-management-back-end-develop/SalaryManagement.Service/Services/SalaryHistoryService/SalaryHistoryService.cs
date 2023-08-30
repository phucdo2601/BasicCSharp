using Newtonsoft.Json.Linq;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.SalaryHistoryService
{
    public class SalaryHistoryService : ISalaryHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalaryHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<SalaryHistory> GetSalaryHistories()
        {
            var salaryHistories = _unitOfWork.SalaryHistory.FindInclude(e => e.LecturerType, e => e.Lecturer.GeneralUserInfo).ToList();
            salaryHistories.ForEach(salaryHistory =>
            {
                salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
                salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);
            });

            return salaryHistories;
        }

        public SalaryHistory GetSalaryHistory(string salaryHistoryId)
        {
            var salaryHistory = _unitOfWork.SalaryHistory.FindIncludeByCondition(e => e.SalaryHistoryId.Equals(salaryHistoryId),
                                    e => e.LecturerType, e => e.Lecturer.GeneralUserInfo).FirstOrDefault();
            if (salaryHistory == null) throw new Exception("Not found SalaryHistory");
            salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
            salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);

            return salaryHistory;
        }

        public List<SalaryHistory> GetSalaryHistoriesOfLecturer(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var salaryHistories = _unitOfWork.SalaryHistory.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId),
                                    e => e.LecturerType, e => e.Lecturer.GeneralUserInfo).ToList();
            salaryHistories.ForEach(salaryHistory =>
            {
                salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
                salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);
            });

            salaryHistories = salaryHistories.OrderByDescending(e => e.StartDate).ToList();

            return salaryHistories;
        }

        public int CreateSalaryHistory(string salaryHistoryId, SalaryHistoryRequest salaryHistoryRequest)
        {
            var basicSalary = _unitOfWork.BasicSalary.Find(salaryHistoryRequest.BasicSalaryId);
            if (basicSalary == null) throw new Exception("Not found BasicSalary");

            var feSalary = _unitOfWork.FESalary.Find(salaryHistoryRequest.FesalaryId);
            if (feSalary == null) throw new Exception("Not found FESalary");

            var lecturerType = _unitOfWork.LecturerType.Find(salaryHistoryRequest.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType");

            var lecturer = _unitOfWork.Lecturer.Find(salaryHistoryRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            SalaryHistory salaryHistory = new()
            {
                SalaryHistoryId = salaryHistoryId,
                StartDate = salaryHistoryRequest.StartDate,
                EndDate = salaryHistoryRequest.EndDate,
                BasicSalary = salaryHistoryRequest.BasicSalary,
                Fesalary = salaryHistoryRequest.Fesalary,
                ModifiedDate = DateTime.Now,
                IsUsing = salaryHistoryRequest.IsUsing,
                BasicSalaryId = salaryHistoryRequest.BasicSalaryId,
                FesalaryId = salaryHistoryRequest.FesalaryId,
                LecturerTypeId = salaryHistoryRequest.LecturerTypeId,
                LecturerId = salaryHistoryRequest.LecturerId
            };

            _unitOfWork.SalaryHistory.Create(salaryHistory);

            int created = _unitOfWork.Complete();

            return created;

        }

        public int UpdateSalaryHistory(string id, SalaryHistoryRequest salaryHistoryRequest)
        {
            int update = -1;

            var basicSalary = _unitOfWork.BasicSalary.Find(salaryHistoryRequest.BasicSalaryId);
            if (basicSalary == null) throw new Exception("Not found BasicSalary");

            var feSalary = _unitOfWork.FESalary.Find(salaryHistoryRequest.FesalaryId);
            if (feSalary == null) throw new Exception("Not found FESalary");

            var lecturerType = _unitOfWork.LecturerType.Find(salaryHistoryRequest.LecturerTypeId);
            if (lecturerType == null) throw new Exception("Not found LecturerType");

            var lecturer = _unitOfWork.Lecturer.Find(salaryHistoryRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var salaryHistory = _unitOfWork.SalaryHistory.Find(id);

            if (salaryHistory != null)
            {
                salaryHistory.StartDate = salaryHistoryRequest.StartDate;
                salaryHistory.EndDate = salaryHistoryRequest.EndDate;
                salaryHistory.BasicSalary = salaryHistoryRequest.BasicSalary;
                salaryHistory.Fesalary = salaryHistoryRequest.Fesalary;
                salaryHistory.ModifiedDate = DateTime.Now;
                salaryHistory.IsUsing = salaryHistoryRequest.IsUsing;
                salaryHistory.BasicSalaryId = salaryHistoryRequest.BasicSalaryId;
                salaryHistory.FesalaryId = salaryHistoryRequest.FesalaryId;
                salaryHistory.LecturerTypeId = salaryHistoryRequest.LecturerTypeId;
                salaryHistory.LecturerId = salaryHistoryRequest.LecturerId;

                _unitOfWork.SalaryHistory.Update(salaryHistory);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int ChangeUsingSalaryHistory(string salaryHistoryId, bool status)
        {
            int update = -1;

            var salaryHistory = _unitOfWork.SalaryHistory.Find(salaryHistoryId);

            if (salaryHistory != null)
            {
                salaryHistory.IsUsing = status;

                _unitOfWork.SalaryHistory.Update(salaryHistory);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public JObject GetSalaryHistoryList(Pagination pagination, bool? isUsing)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<SalaryHistory> salaryHistories = null;

            if (isUsing != null)
            {
                salaryHistories = _unitOfWork.SalaryHistory.FindIncludeByCondition(e => e.IsUsing == isUsing,
                                    e => e.LecturerType, e => e.Lecturer.GeneralUserInfo)
                                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                salaryHistories.ForEach(salaryHistory =>
                {
                    salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
                    salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);
                });

                tottalRecords = _unitOfWork.SalaryHistory.FindByCondition(e => e.IsUsing == isUsing).Count();
            }
            else
            {
                salaryHistories = _unitOfWork.SalaryHistory.FindInclude(e => e.LecturerType, e => e.Lecturer.GeneralUserInfo)
                                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                salaryHistories.ForEach(salaryHistory =>
                {
                    salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
                    salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);
                });

                tottalRecords = _unitOfWork.SalaryHistory.FindAll().Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(salaryHistories)));

            return data;
        }

        public JObject GetLecturerHistory(string lecturerId, Pagination pagination, bool? isUsing)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<SalaryHistory> salaryHistories = null;

            if (isUsing != null)
            {
                salaryHistories = _unitOfWork.SalaryHistory.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId) && e.IsUsing == isUsing,
                                    e => e.LecturerType, e => e.Lecturer.GeneralUserInfo)
                                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                salaryHistories.ForEach(salaryHistory =>
                {
                    salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
                    salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);
                });

                tottalRecords = _unitOfWork.SalaryHistory.FindByCondition(e => e.LecturerId.Equals(lecturerId) && e.IsUsing == isUsing).Count();
            }
            else
            {
                salaryHistories = _unitOfWork.SalaryHistory.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId),
                                    e => e.LecturerType, e => e.Lecturer.GeneralUserInfo)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                salaryHistories.ForEach(salaryHistory =>
                {
                    salaryHistory.BasicSalaryInfo = _unitOfWork.BasicSalary.Find(salaryHistory.BasicSalaryId);
                    salaryHistory.FesalaryInfo = _unitOfWork.FESalary.Find(salaryHistory.FesalaryId);
                });

                tottalRecords = _unitOfWork.SalaryHistory.FindByCondition(e => e.LecturerId.Equals(lecturerId)).Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(salaryHistories)));

            return data;
        }
    }
}
