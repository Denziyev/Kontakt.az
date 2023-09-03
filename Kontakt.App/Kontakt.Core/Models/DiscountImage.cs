using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class DiscountImage:BaseModel
    {
        public string Image { get; set; }
        public DiscountCategory? DiscountCategory { get; set; }
        public int DiscountCategoryId { get; set; }

    }
}
