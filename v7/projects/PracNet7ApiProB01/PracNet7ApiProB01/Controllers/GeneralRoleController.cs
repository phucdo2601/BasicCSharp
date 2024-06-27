using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;

namespace PracNet7ApiProB01.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class GeneralRoleController: ControllerBase
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly PracNet7ApiDbContext _context;


        public GeneralRoleController(IUnitOfWork _iUnitOfWork, PracNet7ApiDbContext _context)
        {
            this._iUnitOfWork = _iUnitOfWork;
            this._context = _context;
        }

        #region Get All Gen Roles
        [HttpGet("getAllGenRoles")]
        public async Task<IActionResult> GetAllGenRoles()
        {
            List<GeneralRole> generalRoles = _iUnitOfWork.GeneralRoleRepository.FindAll().ToList();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, generalRoles));
        }
        #endregion

        #region Create New General Role
        [HttpPost("createNewGenRole")]
        public async Task<IActionResult> CreateNewGenRole([FromBody] GeneralRole generalRoleRequest)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _iUnitOfWork.GeneralRoleRepository.CreateNew(generalRoleRequest);
                    int created = _iUnitOfWork.Save();
                    transaction.Commit();

                    return created > 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, generalRoleRequest))
                        : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = "Create Category is not successfully" }));
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _iUnitOfWork.Dispose();
                }
            }
        }

        #endregion

    }
}
