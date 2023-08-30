using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Requests.Paginations;
using SalaryManagement.Responses;
using SalaryManagement.Services.DepartmentService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger)
        {
            _departmentService = new DepartmentService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Department/Departments

        /// <summary>
        /// Lấy danh sách tất cả Phòng ban
        /// </summary>
        [HttpGet("Departments")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                var data = _departmentService.GetDepartments();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Departments" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/Departments

        #region GET api/Department/{id}

        /// <summary>
        /// Lấy một phòng ban theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetDepartment(string id)
        {
            try
            {
                var salaryBasic = _departmentService.GetDepartment(id);

                return salaryBasic != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, salaryBasic))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Department" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/{id}

        #region GET api/Department/search

        /// <summary>
        /// Tìm các Phòng ban theo tên (theo DepartmentName)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetDepartmentsByName(string departmentName)
        {
            try
            {
                var data = _departmentService.GetDepartmentsByName(departmentName);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Departments" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/search

        #region GET api/Department/Positions

        /// <summary>
        /// Lấy danh sách tất cả Chức vụ mà Phòng ban có
        /// </summary>
        [HttpGet("Positions")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetPositions()
        {
            try
            {
                var data = _departmentService.GetPositions();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Positions" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/Positions

        #region GET api/Department/Positions/{id}

        /// <summary>
        /// Lấy một chức vụ theo Id
        /// </summary>
        [HttpGet("Positions/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetPosition(string id)
        {
            try
            {
                var data = _departmentService.GetPosition(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Position" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/Positions/{id}

        #region POST api​/Department/Position

        /// <summary>
        /// Thêm mới một Chức vụ
        /// </summary>
        [HttpPost("Position")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostPosition([FromBody] PositionRequest positionRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string positionId = Guid.NewGuid().ToString();

                    int created = _departmentService.CreatePosition(positionId, positionRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { positionId, positionRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Position fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Department/Position

        #region PUT api​/Department​/Position/{id}

        /// <summary>
        /// Cập nhật một Position theo Id
        /// </summary>
        [HttpPut("Position/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutPosition(string id, [FromBody] PositionRequest positionRequest)
        {
            try
            {
                int update = _departmentService.UpdatePosition(id, positionRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, positionRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalary" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Department​/Position/{id}

        #region PUT api/Department/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của một Phòng ban với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutStatusDepartment(string id, bool status)
        {
            try
            {
                int update = _departmentService.UpdateStatusDepartment(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Department" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Department/{id}/{status}

        #region POST api​/Department

        /// <summary>
        /// Thêm mới một Phòng ban
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostDepartment([FromBody] DepartmentRequest departmentRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string departmentId = Guid.NewGuid().ToString();

                    int created = _departmentService.CreateDepartment(departmentId, departmentRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { departmentId, departmentRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Department fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Department

        #region POST api​/Department/Lecturer

        /// <summary>
        /// Thêm mới một Giảng viên vào Phòng Ban
        /// </summary>
        [HttpPost("Lecturer")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> AddLecturerToDepartment([FromBody] LecDepRequest lecDepRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string lecturerDepartmentId = Guid.NewGuid().ToString();

                    int created = _departmentService.AddLecturerToDepartment(lecturerDepartmentId, lecDepRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { lecturerDepartmentId, lecDepRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Lecturer fail" }));
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Department/Lecturer

        #region PUT api/Department/Lecturer

        /// <summary>
        /// Cập nhật thông tin Giảng Viên (Chức vụ, IsWorking) trong Phòng ban
        /// </summary>
        [HttpPut("Lecturer")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutLecturerInDepartment([FromBody] LecWorkingRequest lecWorkingRequest)
        {
            try
            {
                int update = _departmentService.UpdateLecturerInDepartment(lecWorkingRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { lecWorkingRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found some id input" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Department/Lecturer

        #region PUT api/Department

        /// <summary>
        /// Update một Phòng ban theo Id
        /// </summary>
        [HttpPut()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutDepartment(string id, [FromBody] DepartmentRequest departmentRequest)
        {
            try
            {
                int update = _departmentService.UpdateDepartment(id, departmentRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, departmentRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Department" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/Department

        #region GET api/Department/DepartmentList

        /// <summary>
        /// Lấy danh sách tất cả Phòng ban (Phân trang)
        /// </summary>
        [HttpGet("DepartmentList")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetDepartmentList([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _departmentService.GetDepartmentList(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Departments" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/DepartmentList

        #region GET api/Department/LecturerList

        /// <summary>
        /// Lấy danh sách tất cả Giảng viên trong Phòng ban theo Id Phòng ban (Phân trang)
        /// </summary>
        [HttpGet("LecturerList")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetLecturerList(string departmentId, [FromQuery] Pagination pagination, bool? isWorking)
        {
            try
            {
                var data = _departmentService.GetLecturerList(departmentId, pagination, isWorking);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Lecturers" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/LecturerList

        #region GET api/Department/Lecturers

        /// <summary>
        /// (Ưu tiên dùng cho Giao Task) Lấy danh sách tất cả Giảng viên trong Phòng ban theo Id Phòng ban
        /// </summary>
        [HttpGet("Lecturers")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetLectureInDepartment(string departmentId)
        {
            try
            {
                var data = _departmentService.GetLecturersInDepartment(departmentId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Lecturers" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/Lecturers

        #region GET api/Department/LecturersNotHead

        /// <summary>
        /// (Ưu tiên dùng cho Giao Task) Lấy danh sách tất cả Giảng viên trong Phòng ban theo Id Phòng ban (Trừ trưởng phòng ban của phòng ban đó ra)
        /// </summary>
        [HttpGet("LecturersNotHead")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetLecturesNotHeadInDepartment(string departmentId)
        {
            try
            {
                var data = _departmentService.GetLecturesNotHeadInDepartment(departmentId);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Lecturers" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/LecturersNotHead

        #region GET api/Department/Departments/Lecturer

        /// <summary>
        /// (Ưu tiên dùng cho Giao Task) Lấy danh sách tất cả Phòng ban của Lecturer theo LecturerId (bao gồm Position của Lecturer đó trong từng phòng ban)
        /// </summary>
        [HttpGet("Departments/Lecturer")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetDepartmentsByLecturer(string id)
        {
            try
            {
                var data = _departmentService.GetDepartmentsByLecturer(id);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Departments" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Department/Departments/Lecturer

        #region GET api/Departments/Lecturer/DepartmentHead

        /// <summary>
        /// (Ưu tiên dùng cho Giao Task) Lấy danh sách tất cả Phòng ban của Lecturer mà Lecturer đó là Department Head theo LecturerId
        /// </summary>
        [HttpGet("Departments/Lecturer/DepartmentHead")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_HR)]
        public async Task<ActionResult> GetDepartmentsByDepHead(string id)
        {
            try
            {
                var data = _departmentService.GetDepartmentsByDepHead(id);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Departments" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Departments/Lecturer/DepartmentHead
    }
}