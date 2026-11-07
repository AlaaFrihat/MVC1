using AcademyGraduationPreparation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AcademyGraduationPreparation.Controllers
{
    public class GraduationController : Controller
    {
        private List<SelectedOffer> GetSavedOffers()
        {
            string data = HttpContext.Session.GetString("MyOffers");
            if (string.IsNullOrEmpty(data))
            {
                return new List<SelectedOffer>();
            }
            return JsonSerializer.Deserialize<List<SelectedOffer>>(data);
        }

        private void SaveOffers(List<SelectedOffer> offers)
        {
            string data = JsonSerializer.Serialize(offers);
            HttpContext.Session.SetString("MyOffers", data);
        }

       
        public IActionResult Index()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult SelectOffer(SelectedOffer offer)
        {
            var savedOffers = GetSavedOffers();

          
            savedOffers.RemoveAll(x => x.CategoryName == offer.CategoryName);

          
            savedOffers.Add(offer);

            SaveOffers(savedOffers);

            TempData["Message"] = "تم اختيار العرض بنجاح!";
            return RedirectToAction("Index");
        }

      
        public IActionResult Review()
        {
            var offers = GetSavedOffers();

           
            if (offers.Count < 3)
            {
                TempData["Error"] = "لازم تختار 3 عروض (عرض من كل تصنيف) قبل ما تروح عالمراجعة!";
                return RedirectToAction("Index");
            }

         
            decimal total = 0;
            foreach (var item in offers)
            {
                total += (item.Quantity * item.UnitPrice);
            }

           
            decimal discountPercentage = 0;
            if (total > 500)
            {
                discountPercentage = 0.15m; // 15%
            }
            else if (total > 300)
            {
                discountPercentage = 0.10m; // 10%
            }
            else
            {
                discountPercentage = 0;
            }

           
            decimal discountAmount = total * discountPercentage;
            decimal finalTotal = total - discountAmount;

         
            ViewBag.Total = total;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.DiscountPercentage = discountPercentage * 100;
            ViewBag.FinalTotal = finalTotal;

            return View(offers);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}

