using LearnNet9MVCFunLes01Web.Data;
using LearnNet9MVCFunLes01Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet9MVCFunLes01Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult Index()
        {
            List<Category> listCategories = _context.Categories.ToList();
            return View(listCategories);
        }
    }
}
