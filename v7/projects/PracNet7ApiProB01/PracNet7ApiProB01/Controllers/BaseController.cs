using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracNet7ApiProB01.Model.Entities;
using PracNet7ApiProB01.Model.Infrastructures;

namespace PracNet7ApiProB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PracNet7ApiDbContext _context;
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IGenericService<TEntity> _service;

        public BaseController(IUnitOfWork unitOfWork, PracNet7ApiDbContext context, IGenericRepository<TEntity> repository, IGenericService<TEntity> service)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _repository = repository;
            _service = service;
        }

        #region get all items controller
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllItems()
        {
            List<TEntity> listAllItems = _service.FindAll();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, listAllItems));
        }

        #endregion

        #region
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetItemById([FromRoute(Name = "id")] string id)
        {
            Guid uuid = Guid.Parse(id);
            TEntity item = _service.FindById(uuid);
            string entityName = typeof(TEntity).Name;
            return item != null ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, item)) :
                    await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new { StatusCode = StatusCodes.Status400BadRequest, Message = $"{entityName} with {id} does not exist." }));
        }

        #endregion
    }
}
