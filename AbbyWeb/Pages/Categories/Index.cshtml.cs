using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(AppDbContext dbContext)
        {
            _db=dbContext;
            
        }
        public void OnGet()
        {
            Categories = _db.categories;
        }
    }
}
