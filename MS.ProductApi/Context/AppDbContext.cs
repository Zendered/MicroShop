using Microsoft.EntityFrameworkCore;
using MS.ProductApi.Models;

namespace MS.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
    }
}
