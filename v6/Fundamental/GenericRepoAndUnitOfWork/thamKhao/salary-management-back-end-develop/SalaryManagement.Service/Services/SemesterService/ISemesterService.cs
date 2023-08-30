using SalaryManagement.Models;
using SalaryManagement.Requests;
using System.Collections.Generic;

namespace SalaryManagement.Services.SemesterService
{
    public interface ISemesterService
    {
        List<Semester> GetSemesters();
        Semester GetSemester(string semesterId);
        List<Semester> GetSemestersByName(string name);
        int CreateSemester(string semesterId, SemesterRequest semesterRequest);
        int UpdateSemester(string id, SemesterRequest semesterRequest);
        List<SemesterSchoolType> GetSemesterInSchoolTypes(string schoolTypeId);
        int CreateSemesterSchool(string semesterSchoolTypeId, SemesterSchoolRequest semesterSchoolRequest);
        int DisableSemester(bool status, SemesterSchoolRequest semesterSchoolRequest);
    }
}
