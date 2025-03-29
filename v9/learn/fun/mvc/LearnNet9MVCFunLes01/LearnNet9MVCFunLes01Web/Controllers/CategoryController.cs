using Microsoft.AspNetCore.Mvc;

namespace LearnNet9MVCFunLes01Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
