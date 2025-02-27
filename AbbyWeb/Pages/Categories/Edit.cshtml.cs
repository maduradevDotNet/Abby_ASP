using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class editModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public editModel(AppDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name","The Display order Can not Exactly same to Name");
            }


            if (ModelState.IsValid) {
                 _db.categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Updated SuccessFully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
            
        }
    }
}
