using LearnMyApiWebCore6.Models;
using LearnMyApiWebCore6.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnMyApiWebCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductBookController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;
        public ProductBookController(IBookRepository repo)
        {
            _bookRepo= repo;
        }

        [HttpGet("getAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBooksAsync());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("getBookById/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost("addNewProductBook")]
        public async Task<IActionResult> AddNewBook(BookModel model)
        {
            try
            {
                var newBookId = await _bookRepo.AddBookAsync(model);
                /* return CreatedAtAction("GetBookById", new
                 {
                     id = newBookId
                 }, model);*/
                var book = await _bookRepo.GetBookByIdAsync(newBookId);
                return book == null ? NotFound() : Ok(book);

            }
            catch (Exception)
            {

                return BadRequest(); 
            }
        }

        [HttpPut("updateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _bookRepo.UpdateBookAsync(id, model);
            var book = await _bookRepo.GetBookByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return Ok("Delete Successfully!");
        }
    }
}
