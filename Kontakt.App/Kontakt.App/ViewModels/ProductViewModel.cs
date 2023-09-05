using Kontakt.Core.Models;

namespace Kontakt.App.ViewModels
{
    public class ProductViewModel
    {
        public List<Comment>? comments { get; set; }
        public Comment comment { get; set; }
    }
}
