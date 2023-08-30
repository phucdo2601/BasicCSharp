using Les03FunRazorPage.Data;
using Les03FunRazorPage.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Les03FunRazorPage.Pages.Categories
{
	[BindProperties]
	public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
            /*Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            Category = _db.Categories.SingleOrDefault(u => u.Id ==id);
            Category = _db.Categories.Where(u => u.Id == id).FirstOrDefault();*/
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Displayorder cannot excatly match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
