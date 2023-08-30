using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.SchoolService
{
    public class SchoolService : ISchoolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SchoolService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<School> GetSchools()
        {
            var schools = _unitOfWork.School.FindInclude(e => e.SchoolType).ToList();
            return schools;
        }

        public List<School> GetSchoolsByName(string name)
        {
            var schools = _unitOfWork.School.FindInclude(e => e.SchoolType)
                .Where(delegate (School e)
                {
                    string schoolName = StringTemplate.ConvertUTF8(e.SchoolName).ToLower();
                    string nameSearch = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (schoolName.Contains(nameSearch))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();
            return schools;
        }

        public School GetSchool(string schoolId)
        {
            var school = _unitOfWork.School.FindIncludeByCondition(e => e.SchoolId.Equals(schoolId), e => e.SchoolType).FirstOrDefault();
            return school;
        }

        public int DisableSchool(string schoolId, bool status)
        {
            int update = -1;

            var school = _unitOfWork.School.Find(schoolId);

            if (school != null)
            {
                if (school.IsDisable == false && status == true)
                {
                    if (_unitOfWork.Department.FindAll().Any(e => e.SchoolId.Equals(school.SchoolId)))
                        throw new Exception($"School '{school.SchoolName}' already existing deparment");
                }

                school.IsDisable = status;

                _unitOfWork.School.Update(school);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int CreateSchool(string schoolId, SchoolRequest schoolRequest)
        {
            int created = -1;

            var schoolName = _unitOfWork.School.FindByCondition(e => e.SchoolName.ToLower().Equals(schoolRequest.SchoolName.ToLower())).Select(e => e.SchoolName).FirstOrDefault();
            if (schoolName != null) throw new Exception($"SchoolName '{schoolName}' already exists");

            var schoolType = _unitOfWork.SchoolType.Find(schoolRequest.SchoolTypeId);
            if (schoolType == null) throw new Exception("Not found SchoolType");

            School school = new()
            {
                SchoolId = schoolId,
                SchoolName = schoolRequest.SchoolName,
                Address = schoolRequest.Address,
                IsDisable = schoolRequest.IsDisable,
                SchoolTypeId = schoolRequest.SchoolTypeId
            };

            _unitOfWork.School.Create(school);

            created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateSchool(string id, SchoolRequest schoolRequest)
        {
            int update = -1;

            var schoolType = _unitOfWork.SchoolType.Find(schoolRequest.SchoolTypeId);
            if (schoolType == null) throw new Exception("Not found SchoolType");

            var school = _unitOfWork.School.Find(id);

            if (school != null)
            {
                var schoolName = _unitOfWork.School.FindByCondition(e => !e.SchoolId.Equals(school.SchoolId) && e.SchoolName.ToLower().Equals(schoolRequest.SchoolName.ToLower())).Select(e => e.SchoolName).FirstOrDefault();
                if (schoolName != null) throw new Exception($"SchoolName '{schoolName}' already exists");

                school.SchoolName = schoolRequest.SchoolName;
                school.Address = schoolRequest.Address;
                school.IsDisable = schoolRequest.IsDisable;
                school.SchoolTypeId = schoolRequest.SchoolTypeId;

                _unitOfWork.School.Update(school);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public List<SchoolType> GetSchoolTypes()
        {
            var schoolType = _unitOfWork.SchoolType.FindAll().OrderBy(e => e.SchoolTypeName).ToList();
            return schoolType;
        }

        public SchoolType GetSchoolType(string schoolTypeId)
        {
            var schoolType = _unitOfWork.SchoolType.Find(schoolTypeId);
            return schoolType;
        }

        public int CreateSchoolType(string schoolTypeId, SchoolTypeRequest schoolTypeRequest)
        {
            int created = -1;

            var schoolTypeName = _unitOfWork.SchoolType.FindByCondition(e => e.SchoolTypeName.ToLower().Equals(schoolTypeRequest.SchoolTypeName.ToLower())).Select(e => e.SchoolTypeName).FirstOrDefault();
            if (schoolTypeName != null) throw new Exception($"SchoolTypeName '{schoolTypeName}' already exists");

            SchoolType schoolType = new()
            {
                SchoolTypeId = schoolTypeId,
                SchoolTypeName = schoolTypeRequest.SchoolTypeName
            };

            _unitOfWork.SchoolType.Create(schoolType);

            created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateSchoolType(string id, SchoolTypeRequest schoolTypeRequest)
        {
            int update = -1;

            var schoolType = _unitOfWork.SchoolType.Find(id);

            if (schoolType != null)
            {
                var schoolTypeName = _unitOfWork.SchoolType.FindByCondition(e => !e.SchoolTypeId.Equals(schoolType.SchoolTypeId) && e.SchoolTypeName.ToLower().Equals(schoolTypeRequest.SchoolTypeName.ToLower())).Select(e => e.SchoolTypeName).FirstOrDefault();
                if (schoolTypeName != null) throw new Exception($"SchoolTypeName '{schoolTypeName}' already exists");

                schoolType.SchoolTypeName = schoolTypeRequest.SchoolTypeName;

                _unitOfWork.SchoolType.Update(schoolType);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public List<School> GetSchoolsInSchoolType(string schoolTypeId)
        {
            var schools = _unitOfWork.School.FindByCondition(e => e.SchoolTypeId.Equals(schoolTypeId)).OrderBy(e => e.SchoolName).ToList();
            return schools;
        }

        public JObject GetSchoolList(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<School> schoolList = null;

            if (isDisable != null)
            {
                schoolList = _unitOfWork.School.FindIncludeByCondition(e => e.IsDisable == isDisable, e => e.SchoolType)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.School.FindByCondition(e => e.IsDisable == isDisable).Count();
            }
            else
            {
                schoolList = _unitOfWork.School.FindInclude(e => e.SchoolType)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.School.FindAll().Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(schoolList)));

            return data;
        }
    }
}
