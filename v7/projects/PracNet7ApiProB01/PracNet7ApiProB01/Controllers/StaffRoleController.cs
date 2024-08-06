using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracNet7ApiProB01.Dto.Dtos.Responses;
using PracNet7ApiProB01.Dto.Dtos.StaffRole;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Model.Repositories.StaffRoleRepository;
using PracNet7ApiProB01.Services.EntityServices.StaffRoleService;
using PracNet7ApiProB01.Utils.Configs;
using Serilog;

namespace PracNet7ApiProB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffRoleController : ControllerBase
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly PracNet7ApiDbContext _context;
        private readonly IGenericRepository<StaffRole> _staffRoleRepo;
        private readonly IStaffRoleService _staffRoleService;

        public StaffRoleController(IUnitOfWork _iUnitOfWork, PracNet7ApiDbContext _context)
        {
            this._iUnitOfWork = _iUnitOfWork;
            this._context = _context;
            this._staffRoleRepo = new StaffRoleRepository(_context);
            this._staffRoleService = new  StaffRoleService(_context, _iUnitOfWork, _staffRoleRepo);
        }

        #region Get All StaffRole
        [HttpGet("getAllStaffRoles")]
        public async Task<IActionResult> GetAllStaffRoles()
        {
            List<StaffRole> staffRoles = _staffRoleService.FindAll();
            string funcName = GeneralConfigs.LogCurrentMethodName();

            Log.Information("Get data of {@var1} on {@var2} and {@var3}", funcName, DateTime.Now, staffRoles);

            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, staffRoles));
        }
        #endregion

        #region Get StaffRole by Id
        [HttpGet("getStRoleById/{staffRoleId}")]
        public async Task<IActionResult> GetStaffRoleById([FromRoute(Name = "staffRoleId")] string id)
        {
            Guid staffRoleId = Guid.Parse(id);
            StaffRole staffRole = _staffRoleService.FindById(staffRoleId);
            string funcName = GeneralConfigs.LogCurrentMethodName();
            Log.Information("Get data of {@var1} on {@var2} and {@var3}", funcName, DateTime.Now, staffRole);
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, staffRole));
        }

        #endregion

        #region Create new StaffRole
        [HttpPost("createNewStRole")]
        public async Task<IActionResult> CreateNewStaffRole([FromBody] CreateStaffRoleReqDto model)
        {
            CommonResponseDto<StaffRole> created = (CommonResponseDto<StaffRole>)await _staffRoleService.CreateNewStaffRole(model);
            string funcName = GeneralConfigs.LogCurrentMethodName();

            if (created.Data != null)
            {
                created.StatusCode = StatusCodes.Status201Created;
                Log.Information("Created of {@var1} on {@var2} and {@var3}", funcName,DateTime.Now, created);
                return await Task.FromResult(StatusCode(StatusCodes.Status201Created, new
                {
                    StatusCode = StatusCodes.Status201Created,
                    ResponseModel = created,
                }));
            }
            else
            {
                created.StatusCode = StatusCodes.Status400BadRequest;
                Log.Information("Created of {@var1} is unsuccessful on {@var2} and {@var3}", funcName, DateTime.Now, created);
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = created }));
            }
        }

        #endregion

        #region UpdateStaffRole
        [HttpPut("updateStaffRole/{staffRoleId}")]
        public async Task<IActionResult> UpdateStaffRole([FromRoute(Name = "staffRoleId")] string id, [FromBody] UpdateStaffRoleReqDto model)
        {
            CommonResponseDto<StaffRole> updated = (CommonResponseDto<StaffRole>)await _staffRoleService.UpdateStaffRole(id, model);
            string funcName = GeneralConfigs.LogCurrentMethodName();

            if (updated.Data != null)
            {
                updated.StatusCode = 200;
                Log.Information("Update @{var1} with id {@var2} on {@var3} and {@var4} Success", funcName, id, DateTime.Now, updated);
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
                {
                    StatusCode = StatusCodes.Status200OK,
                    ResponseModel = updated
                }));
            }
            else
            {
                updated.StatusCode = StatusCodes.Status400BadRequest;
                Log.Information("Update @{var1} with id {@var2} on {@var3} and {@var4} UnSuccess", funcName, id, DateTime.Now, updated);
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = updated }));
            }

        }

        #endregion

        #region Delete StaffRole
        [HttpDelete("deleteStRole/{staffRoleId}")]
        public async Task<IActionResult> DeleteStaffRole([FromRoute(Name = "staffRoleId")] string id)
        {
            CommonResponseDto<StaffRole> deleted = (CommonResponseDto<StaffRole>)await _staffRoleService.DeleteStaffRole(id);
            string funcName = GeneralConfigs.LogCurrentMethodName();

            if (deleted.StatusCode == StatusCodes.Status200OK)
            {
                Log.Information("Executing of {@var1}  with id {@var2} on {@var3} Success", funcName,id, DateTime.Now);
                return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
                {
                    StatusCode = StatusCodes.Status200OK,
                    ResponseModel = deleted
                }));
            }
            else
            {
                deleted.StatusCode = StatusCodes.Status400BadRequest;
                Log.Information("Executing of {@var1}  with id {@var2} on {@var3} UnSuccess", funcName, id, DateTime.Now);
                return await Task.FromResult(StatusCode(StatusCodes.Status400BadRequest, new { StatusCode = StatusCodes.Status400BadRequest, ResponseModel = deleted }));
            }
        }

        #endregion
    }
}
