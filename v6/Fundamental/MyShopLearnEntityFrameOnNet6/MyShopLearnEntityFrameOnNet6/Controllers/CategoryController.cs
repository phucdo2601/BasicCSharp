using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShopLearnEntityFrameOnNet6.Entities;

namespace MyShopLearnEntityFrameOnNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private LearnEntityFrameOnNetCore6Context _context;
        public CategoryController(LearnEntityFrameOnNetCore6Context ctx)
        {
            _context = ctx;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_context.Categories.ToList());
        }
    }
}
