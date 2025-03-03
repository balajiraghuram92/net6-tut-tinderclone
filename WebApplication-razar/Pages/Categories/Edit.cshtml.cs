using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication_razar.Data;
using WebApplication_razar.Models;

namespace WebApplication_razar.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category categ { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
                categ = _db.Categories.FirstOrDefault(u => u.Id == id);
        }
        public IActionResult OnPost()
        {
            _db.Categories.Update(categ);
            _db.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}
