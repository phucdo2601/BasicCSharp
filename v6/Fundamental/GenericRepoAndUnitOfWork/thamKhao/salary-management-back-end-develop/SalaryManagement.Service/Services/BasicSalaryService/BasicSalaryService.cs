using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.BasicSalaryService
{
    public class BasicSalaryService : IBasicSalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BasicSalaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<BasicSalary> GetBasicSalaries()
        {
            var basicSalary = _unitOfWork.BasicSalary.FindAll().ToList();

            basicSalary = basicSalary.OrderBy(e => e.Salary).ToList();

            return basicSalary;
        }

        public BasicSalary GetBasicSalary(string salaryBasicId)
        {
            var salaryBasic = _unitOfWork.BasicSalary.Find(salaryBasicId);
            return salaryBasic;
        }

        public int DisableBasicSalary(string salaryBasicId, bool status)
        {
            int update = -1;

            var salaryBasic = _unitOfWork.BasicSalary.Find(salaryBasicId);

            var basicSalaryIds = _unitOfWork.Lecturer.FindAll().Select(e => e.BasicSalaryId).ToList();

            if (salaryBasic != null)
            {
                if (salaryBasic.IsDisable == false && status == true)
                {
                    if (basicSalaryIds.Any(e => e.Equals(salaryBasic.BasicSalaryId)))
                        throw new Exception($"BasicSalary '{salaryBasic.BasicSalaryLevel}' already existing lecturers");
                }

                salaryBasic.IsDisable = status;

                _unitOfWork.BasicSalary.Update(salaryBasic);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int CreateBasicSalary(string basicSalaryId, BasicSalaryRequest basicSalaryRequest)
        {
            var basicSalaryLevel = _unitOfWork.BasicSalary.FindByCondition(e => e.BasicSalaryLevel.ToLower().Equals(basicSalaryRequest.BasicSalaryLevel.ToLower())).Select(e => e.BasicSalaryLevel).FirstOrDefault();
            if (basicSalaryLevel != null) throw new Exception($"BasicSalaryLevel '{basicSalaryLevel}' already exists");

            BasicSalary basicSalary = new()
            {
                BasicSalaryId = basicSalaryId,
                BasicSalaryLevel = basicSalaryRequest.BasicSalaryLevel,
                Salary = basicSalaryRequest.Salary,
                TimeLearningLimit = basicSalaryRequest.TimeLearningLimit,
                IsDisable = basicSalaryRequest.IsDisable
            };

            _unitOfWork.BasicSalary.Create(basicSalary);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateBasicSalary(string id, BasicSalaryRequest basicSalaryRequest)
        {
            int update = -1;

            var salaryBasic = _unitOfWork.BasicSalary.Find(id);

            if (salaryBasic != null)
            {
                var basicSalaryLevel = _unitOfWork.BasicSalary.FindByCondition(e => !e.BasicSalaryId.Equals(salaryBasic.BasicSalaryId) && e.BasicSalaryLevel.ToLower().Equals(basicSalaryRequest.BasicSalaryLevel.ToLower())).Select(e => e.BasicSalaryLevel).FirstOrDefault();
                if (basicSalaryLevel != null) throw new Exception($"BasicSalaryLevel '{basicSalaryLevel}' already exists");

                salaryBasic.BasicSalaryLevel = basicSalaryRequest.BasicSalaryLevel;
                salaryBasic.Salary = basicSalaryRequest.Salary;
                salaryBasic.TimeLearningLimit = basicSalaryRequest.TimeLearningLimit;
                salaryBasic.IsDisable = basicSalaryRequest.IsDisable;

                _unitOfWork.BasicSalary.Update(salaryBasic);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int UpdateBSalaryLecturer(BasicSalaryLecturer basicSalaryLecturer)
        {
            var basicSalary = _unitOfWork.BasicSalary.Find(basicSalaryLecturer.BasicSalaryId);
            if (basicSalary == null) throw new Exception("Not found BasicSalary");

            var lecturer = _unitOfWork.Lecturer.Find(basicSalaryLecturer.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            lecturer.BasicSalaryId = basicSalaryLecturer.BasicSalaryId;

            _unitOfWork.Lecturer.Update(lecturer);

            int update = _unitOfWork.Complete();

            return update;
        }

        public JObject GetSalaries(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<BasicSalary> basicSalary = null;

            if (isDisable != null)
            {
                basicSalary = _unitOfWork.BasicSalary.FindByCondition(e => e.IsDisable == isDisable)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.BasicSalary.FindByCondition(e => e.IsDisable == isDisable).Count();
            }
            else
            {
                basicSalary = _unitOfWork.BasicSalary.FindAll()
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.BasicSalary.FindAll().Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(basicSalary)));

            return data;
        }

        public List<BasicSalary> GetBasicSalariesByName(string level)
        {
            var basicSalaries = _unitOfWork.BasicSalary.FindAll()
                .Where(delegate (BasicSalary e)
                {
                    string basicSalaryLevel = StringTemplate.ConvertUTF8(e.BasicSalaryLevel).ToLower();
                    string levelSearch = StringTemplate.ConvertUTF8(level.Trim()).ToLower();

                    if (basicSalaryLevel.Contains(levelSearch))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();
            return basicSalaries;
        }
    }
}
