using LearnNet8ShoppingWebMVCB01.Data;
using LearnNet8ShoppingWebMVCB01.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LearnNet8ShoppingWebMVCB01.ViewComponents
{
	public class MenuLoaiViewComponent : ViewComponent
	{
        private readonly Hshop2023Context db;
        public MenuLoaiViewComponent(Hshop2023Context context)
        {
            db= context;
        }

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(lo => new MenuLoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
                SoLuong = lo.HangHoas.Count,
            }).OrderBy(p => p.TenLoai);

            return View(data);
        }
    }
}
