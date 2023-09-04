using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class Credit:BaseModel
    {
        public int NumberofMonths { get; set; }
        public int Percent { get; set; }
        public double InitialPayment { get; set; }
        public List<ProductCredit>? Credits { get; set; }
    }
}
