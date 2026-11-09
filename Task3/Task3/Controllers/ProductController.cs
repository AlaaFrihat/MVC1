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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

     
        [HttpPost]
        public IActionResult Edit(Product product)
        {
           
            ModelState.Remove("Category");
            ModelState.Remove("Supplier");

            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return View(product);
        }

       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
