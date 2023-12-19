using Microsoft.AspNetCore.Mvc;

namespace LearnNet8ShoppingWebMVCB01.Controllers
{
	public class HangHoaController : Controller
	{
		public IActionResult Index(int? loai)
		{

			return View();
		}
	}
}
