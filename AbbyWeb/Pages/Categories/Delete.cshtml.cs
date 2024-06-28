using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class deleteModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public deleteModel(AppDbContext db)
        {
            _db = db;
        }
      
        public void OnGet(int id)
        {
            Category=_db.categories.Find(id);
            //Category=_db.categories.FirstOrDefault(u=>u.Id==id);

        }

        public async Task<IActionResult> OnPost()
        {
          
                var categoryFromDb=_db.categories.Find(Category.Id);
                if (categoryFromDb != null) { 
                    _db.categories.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted SuccessFully";
                return RedirectToPage("Index");
            }       
               
            return Page();
            
        }
    }
}
