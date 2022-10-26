using Microsoft.EntityFrameworkCore;
using MS.ProductApi.Context;
using MS.ProductApi.Models;

namespace MS.ProductApi.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext ctx;

    public ProductRepository(AppDbContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<Product> Create(Product product)
    {
        ctx.Add(product);
        await ctx.SaveChangesAsync();
        return product;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = await ctx.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetById(int id)
    {
        var product = await ctx.Products.FindAsync(id);
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        ctx.Entry(product).State = EntityState.Modified;
        await ctx.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await GetById(id);
        ctx.Products.Remove(product);
        await ctx.SaveChangesAsync();
        return product;
    }
}
