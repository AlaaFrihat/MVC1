using Microsoft.AspNetCore.Mvc;
using Task3.Models.CodeFirst;
using Task3.Models;


namespace Task3.Controllers
{
    
        public class EmployeeController : Controller
        {
            private readonly CafeteriaEmployeesDbContext _context;

            public EmployeeController(CafeteriaEmployeesDbContext context)
            {
                _context = context;
            }

            public IActionResult Index()
            {
                var employees = _context.Employees.ToList();
                return View(employees);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Create(Employee employee)
            {
                if (ModelState.IsValid)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }

            
            [HttpGet]
            public IActionResult Edit(int id)
            {
                var employee = _context.Employees.Find(id);
                if (employee == null) return NotFound();
                return View(employee);
            }

            [HttpPost]
            public IActionResult Edit(Employee employee)
            {
                if (ModelState.IsValid)
                {
                _context.Employees.Update(employee);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }

            [HttpGet]
            public IActionResult Details(int id)
            {
                var employee = _context.Employees.Find(id);
                if (employee == null) return NotFound();
                return View(employee);
            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                var employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }

