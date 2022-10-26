using MS.ProductApi.Models;

namespace MS.ProductApi.Repositories.Categories;

public interface ICategoryRepository
{
    Task<Category> Create(Category category);
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task<IEnumerable<Category>> GetCategoriesProucts();
    Task<Category> Update(Category category);
    Task<Category> Delete(int id);
}
