using Kontakt.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class ProductCredit:BaseModel
    {
        public Credit? Credit { get; set; }
        public int CreditId { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}

