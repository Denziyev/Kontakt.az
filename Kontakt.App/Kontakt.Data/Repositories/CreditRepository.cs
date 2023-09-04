using Kontakt.App.Context;
using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontakt.Data.Repositories
{
    public class CreditRepository : Repository<Credit>, ICreditRepository
    {
        public CreditRepository(KontaktDbContext context) : base(context)
        {
        }
    }
}
