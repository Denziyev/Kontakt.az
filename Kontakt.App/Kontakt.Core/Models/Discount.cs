using Kontakt.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class Discount:BaseModel
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Images { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
