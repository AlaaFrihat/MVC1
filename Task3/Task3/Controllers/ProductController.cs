using Microsoft.AspNetCore.Mvc;
using Task3.Models.CodeFirst;
namespace Task3.Controllers
{
    public class ProductController : Controller
    {
        private readonly CafeteriaEmployeesDbContext _context;
        public ProductController(CafeteriaEmployeesDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var product = _context.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
