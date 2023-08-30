using LearnNet5EntityFrameB01.Data;
using LearnNet5EntityFrameB01.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LearnNet5EntityFrameB01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ItemController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("getAllItems")]
        public async Task<IActionResult> GetAllItems()
        { 
            var result = await _context.Items.Include(r => r.Category).ToListAsync();
            return Ok(result);
        }


        [HttpGet("getAllItemsByProc")]
        public async Task<IActionResult> GetAllItemsByProc()
        {
            //cal api on store procedure of sql server
            var result = await _context.Items.FromSqlRaw("usp_SelectAllItems").ToListAsync();
            return Ok(result);
        }

        [HttpGet("getItemByIdByProc/{id}")]
        public async Task<IActionResult> GetByIdByProc([FromRoute(Name = "id")] int id)
        {
            //cal api on store procedure of sql server
            var result = await _context.Items.FromSqlRaw($"usp_SelectItemById {id}").ToListAsync();
            return Ok(result);
        }

        [HttpPut("updateItemByIdByProc/{id}")]
        public async Task<IActionResult> UpdateItemByIdByProc([FromRoute(Name = "id")]  int id, [FromBody] UpdateItemDto item)
        {
            //cal api on store procedure of sql server
            var result = await _context.Database.ExecuteSqlRawAsync($"usp_UpdateItemById {id}, {item.ItemName}, {item.Quantity}, {item.Price}, {item.Description}, {item.CategoryId}");
            return Ok(result);
        }
    }
}
