using Newtonsoft.Json.Linq;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System.Collections.Generic;

namespace SalaryManagement.Services.DepartmentService
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        Department GetDepartment(string departmentId);
        List<Department> GetDepartmentsByName(string name);
        List<LecturerPosition> GetPositions();
        int CreatePosition(string positionId, PositionRequest positionRequest);
        List<LecturerDepartment> GetLecturersInDepartment(string departmentId);
        int UpdateDepartment(string id, DepartmentRequest departmentRequest);
        int CreateDepartment(string departmentId, DepartmentRequest departmentRequest);
        int AddLecturerToDepartment(string lecturerDepartmentId, LecDepRequest lecDepRequest);
        int UpdateLecturerInDepartment(LecWorkingRequest lecWorkingRequest);
        int UpdateStatusDepartment(string id, bool status);
        JObject GetDepartmentList(Pagination pagination, bool? isDisable);
        JObject GetLecturerList(string departmentId, Pagination pagination, bool? isWorking);
        List<LecturerDepartment> GetLecturesNotHeadInDepartment(string departmentId);
        List<dynamic> GetDepartmentsByLecturer(string lecturerId);
        List<Department> GetDepartmentsByDepHead(string lecturerId);
        int UpdatePosition(string positionId, PositionRequest positionRequest);
        LecturerPosition GetPosition(string positionId);
    }
}
