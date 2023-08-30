using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.SchoolService
{
    public interface ISchoolService
    {
        List<School> GetSchools();
        School GetSchool(string schoolId);
        List<School> GetSchoolsByName(string name);
        int DisableSchool(string schoolId, bool status);
        int CreateSchool(string schoolId, SchoolRequest schoolRequest);
        int UpdateSchool(string id, SchoolRequest schoolRequest);
        List<SchoolType> GetSchoolTypes();
        SchoolType GetSchoolType(string schoolTypeId);
        int CreateSchoolType(string schoolTypeId, SchoolTypeRequest schoolTypeRequest);
        int UpdateSchoolType(string id, SchoolTypeRequest schoolTypeRequest);
        List<School> GetSchoolsInSchoolType(string schoolTypeId);
        JObject GetSchoolList(Pagination pagination, bool? isDisable);
    }
}
