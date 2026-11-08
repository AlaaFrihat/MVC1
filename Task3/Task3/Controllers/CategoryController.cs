using Microsoft.AspNetCore.Mvc;
using Task3.Models.CodeFirst;
namespace Task3.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CafeteriaEmployeesDbContext _context;

        public CategoryController(CafeteriaEmployeesDbContext context)
        {
            _context = context;
        }  

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
    }
}
