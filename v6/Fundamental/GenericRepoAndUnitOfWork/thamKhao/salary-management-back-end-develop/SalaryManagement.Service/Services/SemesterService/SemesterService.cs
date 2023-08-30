using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryManagement.Services.SemesterService
{
    public class SemesterService : ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Semester> GetSemesters()
        {
            var semesters = _unitOfWork.Semester.FindAll().OrderByDescending(e => e.EndDate).ToList();
            return semesters;
        }

        public Semester GetSemester(string semesterId)
        {
            var semester = _unitOfWork.Semester.Find(semesterId);
            return semester;
        }

        public List<Semester> GetSemestersByName(string name)
        {
            var semesters = _unitOfWork.Semester.FindInclude()
                .Where(delegate (Semester e)
                {
                    string semesterName = StringTemplate.ConvertUTF8(e.SemesterName).ToLower();
                    string nameSearch = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (semesterName.Contains(nameSearch))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();
            return semesters;
        }

        public int CreateSemester(string semesterId, SemesterRequest semesterRequest)
        {
            int created = -1;

            var semesterName = _unitOfWork.Semester.FindByCondition(e => e.SemesterName.ToLower().Equals(semesterRequest.SemesterName.ToLower())).Select(e => e.SemesterName).FirstOrDefault();
            if (semesterName != null) throw new Exception($"SemesterName '{semesterName}' already exists");

            if (semesterRequest.EndDate < semesterRequest.StartDate) throw new Exception("EndDate must be greater than StartDate");

            if (semesterRequest.EndDate < DateTime.Now && semesterRequest.StartDate < DateTime.Now) throw new Exception("Unable to create a semester during the past");

            if (semesterRequest.StartDate.AddYears(1) <= semesterRequest.EndDate) throw new Exception("The duration of a semester must be less than 1 year");

            /*var semesters = _unitOfWork.Semester.FindAll().ToList();
            semesters.ForEach(semester =>
            {
                if ((semester.StartDate <= semesterRequest.StartDate && semesterRequest.StartDate <= semester.EndDate)
                      || (semester.StartDate <= semesterRequest.EndDate && semesterRequest.EndDate <= semester.EndDate)
                      || (semesterRequest.StartDate <= semester.StartDate && semester.StartDate <= semesterRequest.EndDate)
                      || (semesterRequest.StartDate <= semester.EndDate && semester.EndDate <= semesterRequest.EndDate))
                {
                    throw new Exception("StartDate or EndDate already exists for another time on another Semester.");
                }
            });*/

            Semester semester = new()
            {
                SemesterId = semesterId,
                SemesterName = semesterRequest.SemesterName,
                StartDate = semesterRequest.StartDate,
                EndDate = semesterRequest.EndDate
            };

            _unitOfWork.Semester.Create(semester);

            created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateSemester(string id, SemesterRequest semesterRequest)
        {
            int update = -1;

            if (semesterRequest.EndDate < semesterRequest.StartDate) throw new Exception("EndDate must be greater than StartDate");

            if (semesterRequest.StartDate.AddYears(1) <= semesterRequest.EndDate) throw new Exception("The duration of a semester must be less than 1 year");

            var semester = _unitOfWork.Semester.Find(id);

            if (_unitOfWork.PayPeriod.FindAll().Any(e => e.SemesterId.Equals(semester.SemesterId)))
                throw new Exception($"Semester '{semester.SemesterName}' already existing in PayPeriod");

            /*var semesters = _unitOfWork.Semester.FindByCondition(e => !e.SemesterId.Equals(id)).ToList();
            semesters.ForEach(semester =>
            {
                if ((semester.StartDate <= semesterRequest.StartDate && semesterRequest.StartDate <= semester.EndDate)
                      || (semester.StartDate <= semesterRequest.EndDate && semesterRequest.EndDate <= semester.EndDate)
                      || (semesterRequest.StartDate <= semester.StartDate && semester.StartDate <= semesterRequest.EndDate)
                      || (semesterRequest.StartDate <= semester.EndDate && semester.EndDate <= semesterRequest.EndDate))
                {
                    throw new Exception("StartDate or EndDate already exists for another time on another Semester.");
                }
            });*/

            if (semester != null)
            {
                var semesterName = _unitOfWork.Semester.FindByCondition(e => !e.SemesterId.Equals(semester.SemesterId) && e.SemesterName.ToLower().Equals(semesterRequest.SemesterName.ToLower())).Select(e => e.SemesterName).FirstOrDefault();
                if (semesterName != null) throw new Exception($"SemesterName '{semesterName}' already exists");

                semester.SemesterName = semesterRequest.SemesterName;
                semester.StartDate = semesterRequest.StartDate;
                semester.EndDate = semesterRequest.EndDate;

                _unitOfWork.Semester.Update(semester);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public List<SemesterSchoolType> GetSemesterInSchoolTypes(string schoolTypeId)
        {
            var semesters = _unitOfWork.SemesterSchoolType.FindIncludeByCondition(e => e.SchoolTypeId.Equals(schoolTypeId), e => e.Semester).OrderByDescending(e => e.Semester.EndDate).ToList();
            return semesters;
        }

        public int CreateSemesterSchool(string semesterSchoolTypeId, SemesterSchoolRequest semesterSchoolRequest)
        {
            var semester = _unitOfWork.Semester.Find(semesterSchoolRequest.SemesterId);
            if (semester == null) throw new Exception("Not found Semester");

            var semesterRequest = semester;
            var semesters = _unitOfWork.SemesterSchoolType.FindByCondition(e => e.SchoolTypeId.Equals(semesterSchoolRequest.SchoolTypeId)).Select(e => e.Semester).ToList();
            semesters.ForEach(sem =>
            {
                if ((sem.StartDate <= semesterRequest.StartDate && semesterRequest.StartDate <= sem.EndDate)
                      || (sem.StartDate <= semesterRequest.EndDate && semesterRequest.EndDate <= sem.EndDate)
                      || (semesterRequest.StartDate <= sem.StartDate && sem.StartDate <= semesterRequest.EndDate)
                      || (semesterRequest.StartDate <= sem.EndDate && sem.EndDate <= semesterRequest.EndDate))
                {
                    throw new Exception("StartDate or EndDate already exists for another time on another Semester in School Type.");
                }
            });

            SemesterSchoolType semesterSchool = new()
            {
                SemesterSchoolTypeId = semesterSchoolTypeId,
                SchoolTypeId = semesterSchoolRequest.SchoolTypeId,
                SemesterId = semesterSchoolRequest.SemesterId,
                IsDisable = false
            };

            _unitOfWork.SemesterSchoolType.Create(semesterSchool);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int DisableSemester(bool status, SemesterSchoolRequest semesterSchoolRequest)
        {
            int update = -1;

            var semester = _unitOfWork.Semester.Find(semesterSchoolRequest.SemesterId);
            if (semester == null) throw new Exception("Not found Semester");

            var semesterSchool = _unitOfWork.SemesterSchoolType.FindByCondition(e => e.SchoolTypeId.Equals(semesterSchoolRequest.SchoolTypeId)
                && e.SemesterId.Equals(semesterSchoolRequest.SemesterId)).FirstOrDefault();

            if (semesterSchool != null)
            {
                semesterSchool.IsDisable = status;

                _unitOfWork.SemesterSchoolType.Update(semesterSchool);

                update = _unitOfWork.Complete();
            }

            return update;
        }
    }
}
