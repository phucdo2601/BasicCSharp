using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Requests;
using SalaryManagement.Responses;
using SalaryManagement.Services.ConfigurationService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IUnitOfWork unitOfWork, ILogger<ConfigurationController> logger)
        {
            _configurationService = new ConfigurationService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Configuration/Configurations

        /// <summary>
        /// Lấy danh sách tất cả các Cấu hình của hệ thống
        /// </summary>
        [HttpGet("Configurations")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetConfigurations()
        {
            try
            {
                var data = _configurationService.GetConfigurations();

                return data.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Configuration" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Configuration/Configurations

        #region GET api/Configuration/{id}

        /// <summary>
        /// Lấy một Cấu hình theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetConfiguration(string id)
        {
            try
            {
                var data = _configurationService.GetConfiguration(id);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Configuration" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Configuration/{id}

        #region GET api/Configuration/Name/{name}

        /// <summary>
        /// Lấy một Cấu hình theo Tên (Ưu tiên dùng)
        /// </summary>
        [HttpGet("Name/{name}")]
        [AuthorizeRoles(UserInfo.ROLE_LEC, UserInfo.ROLE_HR, UserInfo.ROLE_EM)]
        public async Task<ActionResult> GetConfigurationByName(string name)
        {
            try
            {
                var data = _configurationService.GetConfigurationByName(name);

                return data != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, data))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Configuration" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest,
                    new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Configuration/Name/{name}

        #region POST api​/Configuration

        /// <summary>
        /// Thêm mới một Cấu hình cho hệ thống
        /// </summary>
        [HttpPost()]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PostConfiguration([FromBody] ConfigurationRequest configurationRequest)
        {
            var transaction = _unitOfWork.BeginTransaction();
            try
            {
                string configurationId = Guid.NewGuid().ToString();

                int created = _configurationService.CreateConfiguration(configurationId, configurationRequest);

                if (created >= 0)
                {
                    transaction.Commit();

                    return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new Responses.Response { StatusCode = StatusCodes.Status201Created, Status = StatusResponse.Success, Data = new { configurationId, configurationRequest } }));
                }
                else
                {
                    transaction.Rollback();
                    return await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Add Configuration fail" }));
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion POST api​/Configuration

        #region PUT api​/Configuration​/{name}

        /// <summary>
        /// Cập nhật một Cấu hình theo Tên
        /// </summary>
        [HttpPut("{name}")]
        [AuthorizeRoles(UserInfo.ROLE_HR)]
        public async Task<ActionResult> PutConfiguration(string name, [FromBody] ConfigurationUpdateRequest configurationRequest)
        {
            try
            {
                int update = _configurationService.UpdateConfiguration(name, configurationRequest);

                return update >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new Responses.Response { StatusCode = StatusCodes.Status200OK, Status = StatusResponse.Success, Data = new { name, configurationRequest } }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Configuration" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion PUT api​/Configuration​/{name}
    }
}
