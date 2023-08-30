using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalaryManagement.Services.LecturerService
{
    public interface ILecturerService
    {
        List<JObject> GetLecturerInfos();
        JObject GetLecturerById(string lecturerId);
        int DisableLecturer(string id, bool status);
        int CreateLecturer(string lecturerId, LecturerRequest lecturerRequest);
        int UpdateLecturer(string id, LecturerUpdateRequest lecturerRequest);
        int UpdatePasswordLecturer(string id, UserPasswordRequest userPasswordRequest);
        List<LecturerType> GetLecturerTypes();
        LecturerType GetLecturerType(string lecturerTypeId);
        int CreateLecturerType(string lecturerTypeId, LecturerTypeRequest lecturerTypeRequest);
        int UpdateLecturerType(string id, LecturerTypeRequest lecturerTypeRequest);
        JObject GetLecturerList(Pagination pagination, bool? isDisable);
        int CreateLecturerExcel(IFormFile file);
        List<JObject> GetLecturersByName(string name);
        Task<string> GetTestSendMail();
        Task SendMailCreateLecturer(string lecturerId);
    }
}
