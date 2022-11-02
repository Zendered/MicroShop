using Microsoft.EntityFrameworkCore;
using MS.ProductApi.Context;
using MS.ProductApi.Models;

namespace MS.ProductApi.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext ctx;

    public CategoryRepository(AppDbContext ctx)
    {
        this.ctx = ctx;
    }

    public async Task<Category> Create(Category category)
    {
        ctx.Add(category);
        await ctx.SaveChangesAsync();
        return category;
    }
    public async Task<IEnumerable<Category>> GetAll()
    {
        var categories = await ctx.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> GetById(int id)
    {
        var category = await ctx.Categories.FindAsync(id);
        return category;
    }
    public async Task<IEnumerable<Category>> GetCategoriesProducts()
    {
        var category = await ctx.Categories
            .Include(c => c.Products)
            .ToListAsync();
        return category;
    }
    public async Task<Category> Update(Category category)
    {
        ctx.Entry(category).State = EntityState.Modified;
        await ctx.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Delete(int id)
    {
        var category = await GetById(id);
        ctx.Categories.Remove(category);
        await ctx.SaveChangesAsync();
        return category;
    }
}
