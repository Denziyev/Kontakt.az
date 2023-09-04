using Kontakt.Core.Models;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CreditController : Controller
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService)
        {
            _creditService = creditService;
        }

        public async Task<IActionResult> Index()
        {
            var credits = await _creditService.GetAllAsync();


            return View(credits);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Credit credit)
        {
            if (!ModelState.IsValid)
            {
                return View(credit);
            }
            credit.CreatedAt = DateTime.Now;
            await _creditService.CreateAsync(credit);
            return RedirectToAction(nameof(Index));
        }
    }
}
