﻿using Kontakt.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class BasketItem:BaseModel
    {
        public int ProductId { get; set; }
        public int BasketId { get; set; }
        public Basket Basket { get; set; }  
        public Product Product { get; set; }
        public int ProductCount { get; set; } = 1;

    }
}
