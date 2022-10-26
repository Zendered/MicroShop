using Microsoft.EntityFrameworkCore;
using MS.ProductApi.Models;

namespace MS.ProductApi.Context;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category
        modelBuilder.Entity<Category>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(c => c.Category)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
            .HasData(
            new Category { Id = 1, Name = "Material Escolar" },
            new Category { Id = 2, Name = "Acessórios" }
            );

        // Product
        modelBuilder.Entity<Product>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(c => c.Description)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(c => c.ImageUrl)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(c => c.Price)
            .HasPrecision(12, 2);
    }
}
