using AbbyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
    }
}
