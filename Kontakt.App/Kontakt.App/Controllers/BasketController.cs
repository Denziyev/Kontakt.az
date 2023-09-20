using Kontakt.App.Context;
using Kontakt.Core.Models;
using Kontakt.Service.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Kontakt.App.Controllers
{
    public class BasketController : Controller
    {
        private readonly KontaktDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(KontaktDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var jsonBasket = Request.Cookies["basket"];
                if (jsonBasket != null)
                {
                    AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                    Basket? basket = await _context.Baskets.
                     Where(x => !x.IsDeleted && x.AppUserId == appUser.Id)
                    .FirstOrDefaultAsync();


                    if (basket == null)
                    {
                        basket = new Basket
                        {
                            CreatedAt = DateTime.Now,
                            AppUser = appUser
                        };
                        await _context.Baskets.AddAsync(basket);
                    }


                    List<BasketViewModel> viewModels = JsonConvert.DeserializeObject<List<BasketViewModel>>(jsonBasket);
                    foreach (var model in viewModels)
                    {
                        BasketItem basketItem = default;
                        if (basket.basketItems != null)
                        {
                            basketItem = basket.basketItems.FirstOrDefault(x => x.ProductId == model.ProductId);
                        }
                        if (basketItem == null)
                        {

                            basketItem = new BasketItem
                            {
                                Basket = basket,
                                CreatedAt = DateTime.Now,
                                ProductCount = model.Count,
                                ProductId = model.ProductId
                            };
                            await _context.BasketItems.AddAsync(basketItem);

                        }
                        else
                        {
                            basketItem.ProductCount++;
                        }
                    }

                    await _context.SaveChangesAsync();
                    Response.Cookies.Delete("basket");

                }
            }

            List<BasketItem> basketItems = await _context.BasketItems.Where(x => !x.IsDeleted).Include(x=>x.Product).ThenInclude(x=>x.ProductImages).Include(x=>x.Product).ThenInclude(x=>x.DiscountofProduct).ToListAsync();
            
            return View(basketItems);
        }
    }
}
