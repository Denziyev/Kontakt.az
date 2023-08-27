

using Kontakt.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Kontakt.App.Context
{
    public class KontaktDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public KontaktDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
