using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.GetAllAsync();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tag tag)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            await _tagService.CreateAsync(tag);
            return RedirectToAction(nameof(Index));
        }
    }
}
