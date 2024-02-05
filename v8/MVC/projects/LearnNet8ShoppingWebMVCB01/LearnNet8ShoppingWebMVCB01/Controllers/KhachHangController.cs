using AutoMapper;
using LearnNet8ShoppingWebMVCB01.Data;
using LearnNet8ShoppingWebMVCB01.Helpers;
using LearnNet8ShoppingWebMVCB01.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet8ShoppingWebMVCB01.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly IMapper _mapper;

        public KhachHangController(Hshop2023Context context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]        
        
        public IActionResult DangKy(RegisterVM model, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                try
                {
					var khachHang = _mapper.Map<KhachHang>(model);

					khachHang.RandomKey = MyUtils.GenerateRandomKey();

					khachHang.MatKhau = model.MatKhau.ToMd5Hash(khachHang.RandomKey);

					khachHang.HieuLuc = true; // manufacture mail active

					khachHang.VaiTro = 0;

					if (Hinh != null)
					{
						khachHang.Hinh = MyUtils.UploadHinh(Hinh, "KhachHang");
					}

					db.Add(khachHang);

					db.SaveChanges();

					return RedirectToAction("Index", "HangHoa");
				}
                catch (Exception ex)
                {

                    throw;
                }

            }
            return View();
        }
    }
}
