using Microsoft.AspNetCore.Mvc;
using liquipages.dataaccess;
using liquipages.models;

namespace liquipages
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        { _db = db; }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DIsplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Category Name and Display Order must not me same.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created succussfully";
                return RedirectToAction("Index");
            }

            return View();
           
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categ = _db.Categories.Find(id);
            if (categ == null)
                return NotFound();

            return View(categ);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated succussfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var categ = _db.Categories.FirstOrDefault(recd => recd.Id == id);
            if (categ == null)
                return NotFound();

            return View(categ);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            var categ = _db.Categories.FirstOrDefault(recd => recd.Id == id);
            if (categ == null)
                return NotFound();

            _db.Categories.Remove(categ);
            _db.SaveChanges();
            TempData["success"] = "Category deleted succussfully";
            return RedirectToAction("Index");
        }
    }
}