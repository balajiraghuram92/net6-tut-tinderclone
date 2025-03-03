using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_razar.Data;
using WebApplication_razar.Models;

namespace WebApplication_razar.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> categoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db; 
        }

        public void OnGet()
        {
            categoryList = _db.Categories.ToList();
        }
    }
}
