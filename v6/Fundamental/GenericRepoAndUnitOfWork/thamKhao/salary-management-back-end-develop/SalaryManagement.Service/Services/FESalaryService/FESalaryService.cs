using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.FESalaryService
{
    public class FESalaryService : IFESalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FESalaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Fesalary> GetFESalaries()
        {
            var feSalaries = _unitOfWork.FESalary.FindAll().OrderBy(e => e.Salary).ToList();
            return feSalaries;
        }

        public List<Fesalary> GetFESalariesByCode(string code)
        {
            var feSalaries = _unitOfWork.FESalary.FindInclude()
                .Where(delegate (Fesalary e)
                {
                    string fesalaryCode = StringTemplate.ConvertUTF8(e.FesalaryCode).ToLower();
                    string codeSearch = StringTemplate.ConvertUTF8(code.Trim()).ToLower();

                    if (fesalaryCode.Contains(codeSearch))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            return feSalaries;
        }

        public Fesalary GetFesalary(string id)
        {
            var feSalary = _unitOfWork.FESalary.Find(id);
            return feSalary;
        }

        public int DisableFesalary(string id, bool status)
        {
            int update = -1;

            var fesalary = _unitOfWork.FESalary.Find(id);

            var fesalaryIds = _unitOfWork.Lecturer.FindAll().Select(e => e.FesalaryId).ToList();

            if (fesalary != null)
            {
                if (fesalary.IsDisable == false && status == true)
                {
                    if (fesalaryIds.Any(e => e.Equals(fesalary.FesalaryId)))
                        throw new Exception($"FESalary '{fesalary.FesalaryCode}' already existing lecturers");
                }

                fesalary.IsDisable = status;

                _unitOfWork.FESalary.Update(fesalary);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int CreateFesalary(string fesalaryId, FESalaryRequest fESalaryRequest)
        {
            int created;

            var FESalaryCode = _unitOfWork.FESalary.FindByCondition(e => e.FesalaryCode.ToLower().Equals(fESalaryRequest.FesalaryCode.ToLower())).Select(e => e.FesalaryCode).FirstOrDefault();
            if (FESalaryCode != null) throw new Exception($"FESalaryCode '{FESalaryCode}' already exists");

            Fesalary fesalary = new()
            {
                FesalaryId = fesalaryId,
                FesalaryCode = fESalaryRequest.FesalaryCode,
                Salary = fESalaryRequest.Salary,
                IsDisable = fESalaryRequest.IsDisable
            };

            _unitOfWork.FESalary.Create(fesalary);

            created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateFesalary(string id, FESalaryRequest fESalaryRequest)
        {
            int update = -1;

            var fESalary = _unitOfWork.FESalary.Find(id);

            if (fESalary != null)
            {
                var FESalaryCode = _unitOfWork.FESalary.FindByCondition(e => !e.FesalaryId.Equals(fESalary.FesalaryId) && e.FesalaryCode.ToLower().Equals(fESalaryRequest.FesalaryCode.ToLower())).Select(e => e.FesalaryCode).FirstOrDefault();
                if (FESalaryCode != null) throw new Exception($"FESalaryCode '{FESalaryCode}' already exists");

                fESalary.FesalaryCode = fESalaryRequest.FesalaryCode;
                fESalary.Salary = fESalaryRequest.Salary;
                fESalary.IsDisable = fESalaryRequest.IsDisable;

                _unitOfWork.FESalary.Update(fESalary);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int UpdateFesalaryLecturer(FESalaryLecturer fESalaryLecturer)
        {
            int update = -1;

            var feSalary = _unitOfWork.FESalary.Find(fESalaryLecturer.FESalaryId);
            if (feSalary == null) throw new Exception("Not found FESalary");

            var lecturer = _unitOfWork.Lecturer.Find(fESalaryLecturer.LecturerId);

            if (lecturer != null)
            {
                lecturer.FesalaryId = fESalaryLecturer.FESalaryId;

                _unitOfWork.Lecturer.Update(lecturer);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public JObject GetFESalaryList(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<Fesalary> fesalaryList = null;

            if (isDisable != null)
            {
                fesalaryList = _unitOfWork.FESalary.FindByCondition(e => e.IsDisable == isDisable)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.FESalary.FindByCondition(e => e.IsDisable == isDisable).Count();
            }
            else
            {
                fesalaryList = _unitOfWork.FESalary.FindAll()
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.FESalary.FindAll().Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(fesalaryList)));

            return data;
        }
    }
}
