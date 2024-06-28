using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class createModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public createModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","The Display order Can not Exactly same to Name");
            }


            if (ModelState.IsValid) {
                await _db.categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
