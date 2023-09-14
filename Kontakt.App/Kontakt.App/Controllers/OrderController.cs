
using Kontakt.App.Context;
using Kontakt.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Controllers
{
    [Authorize(Roles ="User")]
    public class OrderController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly KontaktDbContext _context;


        public OrderController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, KontaktDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }
        public async Task<IActionResult> CheckOut()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var baskets = await _context.Baskets.Where(x => !x.IsDeleted && x.AppUserId == appUser.Id).
                Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                ThenInclude(x => x.Product).
                ThenInclude(x => x.ProductImages.Where(y => !y.IsDeleted)).
                  Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                     ThenInclude(x => x.Product).
                ThenInclude(x => x.DiscountofProduct).FirstOrDefaultAsync();
            if(baskets==null || baskets.basketItems.Count() == 0)
            {
                TempData["empty basket"] = "empty basket";
                return RedirectToAction("index", "home");
            }
            return View(baskets);
        }
        public async Task<IActionResult> CreateOrder()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var baskets = await _context.Baskets.Where(x => !x.IsDeleted && x.AppUserId == appUser.Id).
                Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                ThenInclude(x => x.Product).
                ThenInclude(x => x.ProductImages.Where(y => !y.IsDeleted)).
                  Include(x => x.basketItems.Where(y => !y.IsDeleted)).
                     ThenInclude(x => x.Product).
                ThenInclude(x => x.DiscountofProduct).FirstOrDefaultAsync();
            if (baskets == null || baskets.basketItems.Count() == 0)
            {
                TempData["empty basket"] = "empty basket";
                return RedirectToAction("index", "home");
            }
            Order order = new Order
            {
                CreatedAt = DateTime.Now,
                AppUserId = appUser.Id
            };

            double TotalPrice = 0;
            foreach(var item in baskets.basketItems)
            {
                TotalPrice += (item.Product.DiscountofProduct == null ? item.Product.Price * item.ProductCount :
                        (item.Product.Price - (item.Product.Price - (double)(item.Product.DiscountofProduct.Percent / 100))) * item.ProductCount);
                OrderItem orderItem = new OrderItem
                {
                    CreatedAt = DateTime.Now,
                    Order=order,
                    ProductId=item.ProductId,
                    ProductCount=item.ProductCount,
                };
                await _context.AddAsync(orderItem);
            }
            order.TotalPrice = TotalPrice;
            await _context.AddAsync(order);
            baskets.IsDeleted = true;
            await _context.SaveChangesAsync();  

            TempData["Order created!"] = "Order Successfully created";
            return RedirectToAction("index", "home");
        }

    }
}
