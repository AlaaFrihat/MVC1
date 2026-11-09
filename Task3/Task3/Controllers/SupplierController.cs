using Microsoft.AspNetCore.Mvc;
using Task3.Models.CodeFirst;
namespace Task3.Controllers
{
    public class SupplierController : Controller
    {
        private readonly CafeteriaEmployeesDbContext _context;
        
        public SupplierController(CafeteriaEmployeesDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var supplier = _context.Suppliers.ToList();
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

       
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

       
        [HttpGet]
        public IActionResult Details(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

     
        [HttpGet] 
        public IActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
