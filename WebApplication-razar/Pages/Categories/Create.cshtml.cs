using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_razar.Data;
using WebApplication_razar.Models;

namespace WebApplication_razar.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category categ { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(categ);
            _db.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}
