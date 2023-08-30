using Les03FunRazorPage.Data;
using Les03FunRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Les03FunRazorPage.Pages.Categories
{
	[BindProperties]
    public class DeleteModel : PageModel
    {
		private readonly ApplicationDbContext _db;

		public Category Category { get; set; }

		public DeleteModel(ApplicationDbContext db)
		{
			_db = db;
		}



		public void OnGet(int id)
        {
			Category = _db.Categories.FirstOrDefault(c => c.Id == id);
			/*Category = _db.Category.Find(id);*/
			//Category = _db.Category.SingleOrDefault(u=>u.Id==id);
			//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
		}

		public async Task<IActionResult> OnPost()
		{
			var categoryFromDb = _db.Categories.Find(Category.Id);
			if (categoryFromDb != null)
			{
				_db.Categories.Remove(categoryFromDb);
				await _db.SaveChangesAsync();
				TempData["success"] = "Category deleted successfully";
				return RedirectToPage("Index");
			}
			return Page();
		}
	}
}
