using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Dto.Dtos.GeneralRole;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;
using PracNet7ApiProB01.Model.Repositories;
using PracNet7ApiProB01.Services.EntityServices;

namespace PracNet7ApiProB01.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class GeneralRoleController: ControllerBase
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly PracNet7ApiDbContext _context;
        private readonly IGenericRepository<GeneralRole> _genRepo;
        private readonly IGeneralRoleService _genRoleService;


        public GeneralRoleController(IUnitOfWork _iUnitOfWork, PracNet7ApiDbContext _context)
        {
            this._iUnitOfWork = _iUnitOfWork;
            this._context = _context;
            _genRepo = new GeneralRoleRepository(_context);
            this._genRoleService = new GeneralRoleService(this._context, this._iUnitOfWork, this._genRepo);
        }

        #region Get All Gen Roles
        [HttpGet("getAllGenRoles")]
        public async Task<IActionResult> GetAllGenRoles()
        {
            List<GeneralRole> generalRoles = _genRoleService.FindAll();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, generalRoles));
        }
        #endregion

        #region Get gen code by Id
        [HttpGet("getGenRoleById/{genRoleId}")]
        public async Task<IActionResult> GetGenRoleById([FromRoute(Name = "genRoleId")] string id)
        {
            Guid genRoleId = Guid.Parse(id);
            GeneralRole generalRole = _genRoleService.FindById(genRoleId);
            return generalRole != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, generalRole)) :
                    await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"General Role with {id} does not exist." }));
        }

        #endregion

        #region Create New General Role
        [HttpPost("createNewGenRole")]
        public async Task<IActionResult> CreateNewGenRole([FromBody] CreateGeneralRoleReqDro generalRoleRequest)
        {
            GeneralRole created = _genRoleService.CreateNewGenRole(generalRoleRequest);
            return created != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, created))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create General Role is not successfully" }));
        }

        #endregion

        #region Update General Role By Id
        [HttpPut("updateGenRole/{genRoleId}")]
        public async Task<IActionResult> UpdateGenCodeById([FromRoute(Name =  "genRoleId")] string id, [FromBody] UpdateGenRoleReqDto model)
        {
            GeneralRole updated = _genRoleService.UpdateGenRole(id, model);
            return updated != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, updated))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Updated General Role is not successfully" }));
        }

        #endregion

        #region
        [HttpDelete("deleteGenRole/{genRoleId}")]
        public async Task<IActionResult> DeleteGenRole([FromRoute(Name = "genRoleId")] string id)
        {
            int deleted = _genRoleService.DeleteGenRole(id);
            return deleted != 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Deletes General Role is successfully!"
            }))
                    : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Delete General Role is not successfully" }));
        }
        #endregion

    }
}
