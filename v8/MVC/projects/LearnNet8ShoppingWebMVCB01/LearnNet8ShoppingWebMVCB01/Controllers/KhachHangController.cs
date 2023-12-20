using LearnNet8ShoppingWebMVCB01.Data;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet8ShoppingWebMVCB01.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly Hshop2023Context db;

        public KhachHangController(Hshop2023Context context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }


    }
}
