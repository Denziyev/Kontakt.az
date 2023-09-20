using Kontakt.App.Models;
using Kontakt.Core.Models;

namespace Kontakt.App.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<DiscountCategory> DiscountsCategories { get; set; }
    }
}
