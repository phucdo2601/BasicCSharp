using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracNet7ApiProB01.Model.Entities;

namespace PracNet7ApiProB01.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class GeneralRoleController: ControllerBase
    {
        private readonly PracNet7ApiDbContext _context;

        public GeneralRoleController(PracNet7ApiDbContext _context)
        {
            this._context = _context;
        }

        #region Get All Gen Roles
        [HttpGet("getAllGenRoles")]
        public async Task<IActionResult> GetAllGenRoles()
        {
            List<GeneralRole> generalRoles = await _context.GeneralRoles.ToListAsync();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, generalRoles));
        }
        #endregion

    }
}
