using Kontakt.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class Comment:BaseModel
    {
        public bool IsVisible { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public int RatingLevel { get; set; }
        public Product product { get; set; }
        public int ProductId { get; set; }
    }
}
