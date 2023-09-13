using Kontakt.App.ViewModels;
using Kontakt.Service.Services.Implementations;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly IBasketService _basketService;

        public ProductController(IProductService productService, ICommentService commentService, IBasketService basketService)
        {
            _productService = productService;
            _commentService = commentService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
            if((await _productService.GetAsync(id)).Data == null)
            {
                return NotFound();
            }
            ProductViewModel productVm = new ProductViewModel
            {
                Product = (await _productService.GetAsync(id)).Data,
                Products = (await _productService.GetAllAsync()).Data,

            };

            return View(productVm);
        }

        public async Task<IActionResult> AddBasket(int id, int? count)
        {
            await _basketService.AddBasket(id, count);
            TempData["AddBasket"] = "Məhsul səbətə əlavə edildi";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> GetAllBaskets()
        {
            return Json(await _basketService.GetAllBaskets());
        }

        public async Task<IActionResult> RemoveBasket(int id)
        {
            await _basketService.Remove(id);
            TempData["RemoveBasket"] = "Məhsul səbətdən uğurla silindi";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
