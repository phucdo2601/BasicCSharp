﻿using AutoMapper;
using LearnNet8ShoppingWebMVCB01.Data;
using LearnNet8ShoppingWebMVCB01.Helpers;
using LearnNet8ShoppingWebMVCB01.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

		#region Signup function
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

        #endregion

        #region Login Function
        [HttpGet]
        public IActionResult DangNhap(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string? ReturnUrl)
        {
			ViewBag.ReturnUrl = ReturnUrl;

            if (ModelState.IsValid)
            {
                var khachHang = db.KhachHangs.SingleOrDefault(kh => kh.MaKh == model.UserName);

                if (khachHang == null)
                {
                    ModelState.AddModelError("loi", "Username is not existed!");
                }
                else
                {
                    if (!khachHang.HieuLuc)
                    {
                        ModelState.AddModelError("loi", "Account is banned! Please contact with adminstration.");
                    }
                    else
                    {
                        if (khachHang.MatKhau == model.Password.ToMd5Hash(khachHang.RandomKey))
                        {
                            ModelState.AddModelError("loi", "Login InCredidential!");
                        } else
                        {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Email, khachHang.Email),
                                new Claim(ClaimTypes.Name, khachHang.HoTen),
                                new Claim("CustomerId", khachHang.MaKh),

                                //Claim - role dynamic

                                new Claim(ClaimTypes.Role, "Customer")
                            };

                            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            } else
                            {
                                return Redirect("/");
                            }

                        }
                    }
                }
            }
			return View();
		}

        #endregion

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }

    }
}
