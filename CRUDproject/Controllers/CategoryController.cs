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
            _db.categories.Add(nw);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult update(int Id)
        {
            Category obj = _db.categories.FirstOrDefault(c => c.Id == Id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult update(Category nw)
        {

            return RedirectToAction("Index");
        }
    }
}
