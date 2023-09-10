
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Core.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? StreetAdress { get; set; }
        public string? City { get; set;}
        public string? Country { get; set; }
        public string? Company { get; set; }
        public string? Province { get; set; }
        public string? ZipCode { get; set; }

    }
}
