using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaryManagement.Authorize;
using SalaryManagement.Common;
using SalaryManagement.Infrastructure;
using SalaryManagement.Responses;
using SalaryManagement.Services.RoleService;
using SalaryManagement.Utility.Validation;
using System;
using System.Threading.Tasks;

namespace SalaryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleService _roleService;

        public RoleController(IUnitOfWork unitOfWork, ILogger<RoleController> logger)
        {
            _roleService = new RoleService(unitOfWork);
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region GET api/Role/Roles

        /// <summary>
        /// Lấy tất cả các Role hiện tại
        /// </summary>
        [HttpGet("Roles")]
        [AuthorizeRoles(UserInfo.ROLE_AD)]
        public async Task<ActionResult> GetRole()
        {
            try
            {
                var RoleList = _roleService.GetRoles();
                return RoleList.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, RoleList))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Responses.Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found Role" }));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new Responses.Response { StatusCode = StatusCodes.Status400BadRequest, Status = StatusResponse.Failed, Message = ex.Message }));
            }
        }

        #endregion GET api/Role/Roles
    }
}