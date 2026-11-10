

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3.Models;
using Task3.Models.CodeFirst;

namespace Task3.Controllers
{
    [Authorize]
    public class SupplyRequestController : Controller
    {
        private readonly CafeteriaEmployeesDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SupplyRequestController(CafeteriaEmployeesDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (User.IsInRole("Admin") || User.IsInRole("SuperAdmin"))
            {
                return View(await _context.SupplyRequests.Include(s => s.User).ToListAsync());
            }
            var userRequests = await _context.SupplyRequests.Where(r => r.UserId == user.Id).ToListAsync();
            return View(userRequests);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int productId, int quantity)
        {
            var user = await _userManager.GetUserAsync(User);
            var product = await _context.Products.FindAsync(productId);

            if (product != null && quantity > 0)
            {
                var request = new SupplyRequest
                {
                    UserId = user.Id,
                    RequestDate = DateTime.Now,
                    Status = "Pending",
                    TotalPrice = product.Price * quantity,
                    RequestItems = new List<RequestItem> { new RequestItem { ProductId = productId, Quantity = quantity, Price = product.Price } }
                };
                _context.SupplyRequests.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = await _context.SupplyRequests.Include(r => r.RequestItems).ThenInclude(i => i.Product).Include(r => r.User).FirstOrDefaultAsync(m => m.Id == id);
            if (request == null) return NotFound();
            return View(request);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var request = await _context.SupplyRequests.FindAsync(id);
            if (request != null)
            {
                request.Status = status;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}