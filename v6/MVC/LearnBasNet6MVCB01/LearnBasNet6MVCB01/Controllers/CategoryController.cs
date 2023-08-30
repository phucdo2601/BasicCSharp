using LearnBasNet6MVCB01.Data;
using LearnBasNet6MVCB01.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnBasNet6MVCB01.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
			_db = db;
        }



        public IActionResult Index()
		{
			IEnumerable<Category> objCategoryList = _db.Categories;
			return View(objCategoryList);
		}

		//GET
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("CustomError", "The DisplayOrder cannot excatly match the Name");
			}
			if (ModelState.IsValid) {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

			return View(obj);
			
		}

        //GET: Edit Page
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cateById = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (cateById == null)
            {
                return NotFound();
            }
            return View(cateById);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot excatly match the Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET: Delete Page
		public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cateById = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (cateById == null)
            {
                return NotFound();
            }
            return View(cateById);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }

    }
}
