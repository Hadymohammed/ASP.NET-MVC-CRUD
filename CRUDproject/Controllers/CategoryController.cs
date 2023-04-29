using CRUDproject.Data;
using CRUDproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDproject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.categories;
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category nw)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Add(nw);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category creation failed successfully";
            return View(nw);
        }
        [HttpGet]
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var category = _db.categories.FirstOrDefault(c => c.Id == Id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category nw)
        {

            if (ModelState.IsValid)
            {
                _db.categories.Update(nw);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Category update failed";
            return View(nw);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
                return NotFound();
            var category = _db.categories.FirstOrDefault(c => c.Id == Id);
            if(category==null)
                return NotFound();

            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(Category category)
        {
            if (category == null)
            {
                TempData["error"] = "Category delete failed";
            }
            else
            {
                _db.categories.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
            }
            return RedirectToAction("Index");
        }
    }
}
