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
using SalaryManagement.Services.SchoolService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class SchoolController : ControllerBase
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISchoolService _schoolService;

        public SchoolController(IUnitOfWork unitOfWork, ILogger<SchoolController> logger)
        {
            _schoolService = new SchoolService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/School/Schools

        /// <summary>
        /// Lấy danh sách các Trường
        /// </summary>
        [HttpGet("Schools")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetSchools()
        {
            try
            {
                var data = _schoolService.GetSchools();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Schools" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/Schools

        #region GET api/School/{id}

        /// <summary>
        /// Lấy một Trường theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC, UserInfo.ROLE_NEW)]
        public async Task<ActionResult> GetSchool(string id)
        {
            try
            {
                var school = _schoolService.GetSchool(id);

                return school != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, school))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found School" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/{id}

        #region GET api/School/search

        /// <summary>
        /// Tìm các Trường (theo SchoolName)
        /// </summary>
        [HttpGet("search")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetSchoolsByName(string schoolName)
        {
            try
            {
                var data = _schoolService.GetSchoolsByName(schoolName);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Schools" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/search

        #region PUT api/School/{id}/{status}

        /// <summary>
        /// Update trạng thái (IsDisable) của Trường với Id
        /// </summary>
        [HttpPut("{id}/{status}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutStatusSchool(string id, bool status)
        {
            try
            {
                int update = _schoolService.DisableSchool(id, status);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success }))
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found School" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api/School/{id}/{status}

        #region POST api​/School

        /// <summary>
        /// Thêm mới một Trường
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostSchool([FromBody] SchoolRequest schoolRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string schoolId = Guid.NewGuid().ToString();

                    int created = _schoolService.CreateSchool(schoolId, schoolRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { schoolId, schoolRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add School fail" }));
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

        #endregion POST api​/School

        #region PUT api​/School​/{id}

        /// <summary>
        /// Cập nhật một Trường theo Id
        /// </summary>
        [HttpPut("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutSchool(string id, [FromBody] SchoolRequest schoolRequest)
        {
            try
            {
                int update = _schoolService.UpdateSchool(id, schoolRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, schoolRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found School" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/School​/{id}

        #region GET api/School/SchoolTypes

        /// <summary>
        /// Lấy danh sách các Loại trường
        /// </summary>
        [HttpGet("SchoolTypes")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSchoolTypes()
        {
            try
            {
                var data = _schoolService.GetSchoolTypes();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SchoolTypes" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/SchoolTypes

        #region GET api/School/SchoolType/{id}

        /// <summary>
        /// Lấy một Loại trường theo Id
        /// </summary>
        [HttpGet("SchoolType/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSchoolType(string id)
        {
            try
            {
                var schoolType = _schoolService.GetSchoolType(id);

                return schoolType != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, schoolType))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SchoolType" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/SchoolType/{id}

        #region POST api​/School/SchoolType

        /// <summary>
        /// Thêm mới một Loại trường
        /// </summary>
        [HttpPost("SchoolType")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PostSchoolType([FromBody] SchoolTypeRequest schoolTypeRequest)
        {
            try
            {
                var transaction = _unitOfWork.BeginTransaction();
                try
                {
                    string schoolTypeId = Guid.NewGuid().ToString();

                    int created = _schoolService.CreateSchoolType(schoolTypeId, schoolTypeRequest);

                    if (created >= 0)
                    {
                        await transaction.CommitAsync();
                        return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { schoolTypeId, schoolTypeRequest } }));
                    }
                    else
                    {
                        transaction.Rollback();
                        return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add SchoolType fail" }));
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

        #endregion POST api​/School/SchoolType

        #region PUT api​/School​/SchoolType/{id}

        /// <summary>
        /// Cập nhật một Trường theo Id
        /// </summary>
        [HttpPut("SchoolType/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> PutSchoolType(string id, [FromBody] SchoolTypeRequest schoolTypeRequest)
        {
            try
            {
                int update = _schoolService.UpdateSchoolType(id, schoolTypeRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { id, schoolTypeRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found SchoolType" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/School​/SchoolType/{id}

        #region GET api/School/Schools/{id}

        /// <summary>
        /// Lấy danh sách các Trường thuộc Loại trường theo Id
        /// </summary>
        [HttpGet("Schools/{id}")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSchoolsInSchoolType(string id)
        {
            try
            {
                var data = _schoolService.GetSchoolsInSchoolType(id);

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Schools" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/Schools/{id}

        #region GET api/School/SchoolList

        /// <summary>
        /// Lấy danh sách các Trường (Phân trang)
        /// </summary>
        [HttpGet("SchoolList")]
        [AuthorizeRoles(UserInfo.ROLE_AD, UserInfo.ROLE_LEC)]
        public async Task<ActionResult> GetSchoolList([FromQuery] Pagination pagination, bool? isDisable)
        {
            try
            {
                var data = _schoolService.GetSchoolList(pagination, isDisable);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Schools" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/School/SchoolList
    }
}