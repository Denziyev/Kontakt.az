using Kontakt.App.ViewModels;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductController(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
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
    }
}
