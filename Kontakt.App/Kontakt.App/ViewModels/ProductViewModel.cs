using Kontakt.App.Models;
using Kontakt.Core.Models;

namespace Kontakt.App.ViewModels
{
    public class ProductViewModel
    {
        public List<Comment>? Comments { get; set; }
        public Comment? Comment { get; set; }

        public List<Product>? Products { get; set; }
        public Product? Product { get; set; }
    }
}
