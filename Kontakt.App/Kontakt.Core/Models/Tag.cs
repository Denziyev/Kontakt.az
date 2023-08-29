using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }
        public List<ProductTag>? ProductTags { get; set; }

    }
}
