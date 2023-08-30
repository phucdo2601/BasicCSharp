using Newtonsoft.Json.Linq;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Models;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SalaryManagement.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Department> GetDepartments()
        {
            var DepartmentList = _unitOfWork.Department.FindInclude(e => e.School).OrderBy(e => e.DepartmentName).ToList();
            return DepartmentList;
        }

        public Department GetDepartment(string departmentId)
        {
            var department = _unitOfWork.Department.FindIncludeByCondition(e => e.DepartmentId.Equals(departmentId), e => e.School).FirstOrDefault();
            return department;
        }

        public List<Department> GetDepartmentsByName(string name)
        {
            var DepartmentList = _unitOfWork.Department.FindInclude(e => e.School)
                .Where(delegate (Department e)
                {
                    string departmentName = StringTemplate.ConvertUTF8(e.DepartmentName).ToLower();
                    string nameConvert = StringTemplate.ConvertUTF8(name.Trim()).ToLower();

                    if (departmentName.Contains(nameConvert))
                        return true;
                    else
                        return false;
                }).AsQueryable().ToList();

            return DepartmentList;
        }

        public List<LecturerPosition> GetPositions()
        {
            var PositionList = _unitOfWork.LecturerPosition.FindAll().OrderBy(e => e.LecturerPositionName).ToList();
            return PositionList;
        }

        public int CreatePosition(string positionId, PositionRequest positionRequest)
        {
            int created = -1;

            var positionName = _unitOfWork.LecturerPosition.FindByCondition(e => e.LecturerPositionName.ToLower().Equals(positionRequest.LecturerPositionName.ToLower())).Select(e => e.LecturerPositionName).FirstOrDefault();
            if (positionName != null) throw new Exception($"PositionName '{positionName}' already exists");

            LecturerPosition lecturerPosition = new()
            {
                LecturerPositionId = positionId,
                LecturerPositionName = positionRequest.LecturerPositionName
            };

            _unitOfWork.LecturerPosition.Create(lecturerPosition);

            created = _unitOfWork.Complete();

            return created;
        }

        public int UpdatePosition(string positionId, PositionRequest positionRequest)
        {
            var position = _unitOfWork.LecturerPosition.Find(positionId);
            if (position == null) throw new Exception("Not found Position");

            if (position != null)
            {
                var positionName = _unitOfWork.LecturerPosition.FindByCondition(e => !e.LecturerPositionId.Equals(position.LecturerPositionId) && e.LecturerPositionName.ToLower().Equals(positionRequest.LecturerPositionName.ToLower())).Select(e => e.LecturerPositionName).FirstOrDefault();
                if (positionName != null) throw new Exception($"PositionName '{positionName}' already exists");

                position.LecturerPositionName = positionRequest.LecturerPositionName;

                _unitOfWork.LecturerPosition.Update(position);
            }

            int update = _unitOfWork.Complete();

            return update;
        }

        public List<LecturerDepartment> GetLecturersInDepartment(string departmentId)
        {
            var deparment = _unitOfWork.Department.Find(departmentId);
            if (deparment == null) throw new Exception("Not found Deparment");

            var LecturerDepartments = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.DepartmentId.Equals(departmentId),
                e => e.Lecturer, e => e.Lecturer.GeneralUserInfo, e => e.LecturerPosition).ToList();
            return LecturerDepartments;
        }

        public List<LecturerDepartment> GetLecturesNotHeadInDepartment(string departmentId)
        {
            var deparment = _unitOfWork.Department.Find(departmentId);
            if (deparment == null) throw new Exception("Not found Deparment");

            var LecturerDepartments = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.DepartmentId.Equals(departmentId) && !e.LecturerPosition.LecturerPositionName.Equals(UserInfo.DEPARTMENT_HEAD),
                e => e.Lecturer, e => e.Lecturer.GeneralUserInfo, e => e.LecturerPosition).ToList();
            return LecturerDepartments;
        }

        public int UpdateDepartment(string id, DepartmentRequest departmentRequest)
        {
            int update = -1;

            var deparment = _unitOfWork.Department.FindByCondition(e => e.DepartmentId.Equals(id)).FirstOrDefault();

            var school = _unitOfWork.School.Find(departmentRequest.SchoolId);
            if (school == null) throw new Exception("Not found School");

            if (deparment != null)
            {
                var departmentName = _unitOfWork.Department.FindByCondition(e => !e.DepartmentId.Equals(deparment.DepartmentId) && e.DepartmentName.ToLower().Equals(departmentRequest.DepartmentName.ToLower())).Select(e => e.DepartmentName).FirstOrDefault();
                if (departmentName != null) throw new Exception($"DepartmentName '{departmentName}' already exists");

                deparment.DepartmentName = departmentRequest.DepartmentName;
                deparment.IsDisable = departmentRequest.IsDisable;
                deparment.SchoolId = departmentRequest.SchoolId;

                _unitOfWork.Department.Update(deparment);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int CreateDepartment(string departmentId, DepartmentRequest departmentRequest)
        {
            int created = -1;

            var departmentName = _unitOfWork.Department.FindByCondition(e => e.DepartmentName.ToLower().Equals(departmentRequest.DepartmentName.ToLower())).Select(e => e.DepartmentName).FirstOrDefault();
            if (departmentName != null) throw new Exception($"DepartmentName '{departmentName}' already exists");

            Department department = new()
            {
                DepartmentId = departmentId,
                DepartmentName = departmentRequest.DepartmentName,
                IsDisable = departmentRequest.IsDisable,
                SchoolId = departmentRequest.SchoolId
            };

            var school = _unitOfWork.School.Find(departmentRequest.SchoolId);
            if (school == null) throw new Exception("Not found School");

            _unitOfWork.Department.Create(department);

            created = _unitOfWork.Complete();

            return created;
        }

        public int AddLecturerToDepartment(string lecturerDepartmentId, LecDepRequest lecDepRequest)
        {
            var lecturerPosition = _unitOfWork.LecturerDepartment.Find(lecDepRequest.LecturerPositionId);
            if (lecturerPosition == null) throw new Exception("Not found LecturerPosition");

            var lecturer = _unitOfWork.School.Find(lecDepRequest.LecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var department = _unitOfWork.School.Find(lecDepRequest.DepartmentId);
            if (department == null) throw new Exception("Not found Department");

            LecturerDepartment lecturerDepartment = new()
            {
                LecturerDepartmentId = lecturerDepartmentId,
                StartDate = lecDepRequest.StartDate,
                IsWorking = lecDepRequest.IsWorking,
                ModifiedDate = DateTime.Now,
                LecturerPositionId = lecDepRequest.LecturerPositionId,
                LecturerId = lecDepRequest.LecturerId,
                DepartmentId = lecDepRequest.DepartmentId
            };

            _unitOfWork.LecturerDepartment.Create(lecturerDepartment);

            int created = _unitOfWork.Complete();

            return created;
        }

        public int UpdateLecturerInDepartment(LecWorkingRequest lecWorkingRequest)
        {
            int update = -1;

            var lecturerPosition = _unitOfWork.School.Find(lecWorkingRequest.LecturerPositionId);
            if (lecturerPosition == null) throw new Exception("Not found LecturerPosition");

            var lecturerDepartment = _unitOfWork.LecturerDepartment.FindByCondition(e => e.DepartmentId.Equals(lecWorkingRequest.DepartmentId) && e.LecturerId.Equals(lecWorkingRequest.LecturerId)).FirstOrDefault();

            if (lecturerDepartment != null)
            {
                if (lecturerDepartment.IsWorking == true && lecWorkingRequest.IsWorking == false)
                {
                    lecturerDepartment.EndDate = DateTime.Now;
                }

                lecturerDepartment.LecturerPositionId = lecWorkingRequest.LecturerPositionId;
                lecturerDepartment.IsWorking = lecWorkingRequest.IsWorking;

                _unitOfWork.LecturerDepartment.Update(lecturerDepartment);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public int UpdateStatusDepartment(string id, bool status)
        {
            int update = -1;

            var deparment = _unitOfWork.Department.FindByCondition(e => e.DepartmentId.Equals(id)).FirstOrDefault();

            if (deparment != null)
            {
                if (deparment.IsDisable == false && status == true)
                {
                    if (_unitOfWork.LecturerDepartment.FindAll().Any(e => e.DepartmentId.Equals(deparment.DepartmentId)))
                        throw new Exception($"Deparment '{deparment.DepartmentName}' already existing lecturers");
                }

                deparment.IsDisable = status;

                _unitOfWork.Department.Update(deparment);

                update = _unitOfWork.Complete();
            }

            return update;
        }

        public JObject GetDepartmentList(Pagination pagination, bool? isDisable)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<Department> departmentList = null;

            if (isDisable != null)
            {
                departmentList = _unitOfWork.Department.FindIncludeByCondition(e => e.IsDisable == isDisable, e => e.School)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.Department.FindByCondition(e => e.IsDisable == isDisable).Count();
            }
            else
            {
                departmentList = departmentList = _unitOfWork.Department.FindInclude(e => e.School)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.Department.FindAll().Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(departmentList)));

            return data;
        }

        public JObject GetLecturerList(string departmentId, Pagination pagination, bool? isWorking)
        {
            JObject data = new();
            int tottalRecords = 0;
            List<LecturerDepartment> lecturerDepartments = null;

            if (isWorking != null)
            {
                lecturerDepartments = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.DepartmentId.Equals(departmentId) && e.IsWorking == isWorking, e => e.Lecturer)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.LecturerDepartment.FindByCondition(e => e.DepartmentId.Equals(departmentId) && e.IsWorking == isWorking).Count();
            }
            else
            {
                lecturerDepartments = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.DepartmentId.Equals(departmentId), e => e.Lecturer)
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
                tottalRecords = _unitOfWork.LecturerDepartment.FindByCondition(e => e.DepartmentId.Equals(departmentId)).Count();
            }

            var tottalPage = Math.Ceiling(tottalRecords / (float)pagination.PageSize);

            data.Add(new JProperty("pageNumber", pagination.PageNumber));
            data.Add(new JProperty("pageSize", pagination.PageSize));
            data.Add(new JProperty("totalRecords", tottalRecords));
            data.Add(new JProperty("totalPage", tottalPage));
            data.Add(new JProperty("data", JToken.FromObject(lecturerDepartments)));

            return data;
        }

        public List<dynamic> GetDepartmentsByLecturer(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            List<dynamic> datas = new();

            var lecturerDepartments = _unitOfWork.LecturerDepartment.FindByCondition(e => e.LecturerId.Equals(lecturerId)).ToList();

            HashSet<string> departmentIds = new();

            lecturerDepartments.ForEach(lecturerDepartment =>
            {
                departmentIds.Add(lecturerDepartment.DepartmentId);
            });

            List<Department> departments = new();

            foreach (string departmentId in departmentIds)
            {
                dynamic data = new ExpandoObject();
                var department = _unitOfWork.Department.Find(departmentId);
                if (department != null) departments.Add(department);

                data.department = department;

                var lecDep = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId) && e.DepartmentId.Equals(departmentId), e => e.LecturerPosition).FirstOrDefault();
                if (lecDep != null) data.lecturerPosition = lecDep.LecturerPosition;

                datas.Add(data);
            }

            return datas;
        }

        public List<Department> GetDepartmentsByDepHead(string lecturerId)
        {
            var lecturer = _unitOfWork.Lecturer.Find(lecturerId);
            if (lecturer == null) throw new Exception("Not found Lecturer");

            var lecturerDepartments = _unitOfWork.LecturerDepartment.FindIncludeByCondition(e => e.LecturerId.Equals(lecturerId) && e.LecturerPosition.LecturerPositionName.Equals(UserInfo.DEPARTMENT_HEAD),
                                            e => e.LecturerPosition).ToList();

            HashSet<string> departmentIds = new();

            lecturerDepartments.ForEach(lecturerDepartment =>
            {
                departmentIds.Add(lecturerDepartment.DepartmentId);
            });

            List<Department> departments = new();

            foreach (string departmentId in departmentIds)
            {
                var department = _unitOfWork.Department.Find(departmentId);
                departments.Add(department);
            }

            return departments;
        }

        public LecturerPosition GetPosition(string positionId)
        {
            var position = _unitOfWork.LecturerPosition.Find(positionId);

            return position;
        }
    }
}
