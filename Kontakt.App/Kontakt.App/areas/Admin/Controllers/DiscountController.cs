using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IActionResult> Index()
        {
            var discounts = await _discountService.GetAllAsync();


            return View(discounts);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            discount.CreatedAt = DateTime.Now;
            await _discountService.CreateAsync(discount);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> MovetoDiscountCategory(int id)
        {
            var resp = await _discountService.GetAsync(id);
            return RedirectToAction("Index", "DiscountCategory", resp.Data);

        }
    }
}
