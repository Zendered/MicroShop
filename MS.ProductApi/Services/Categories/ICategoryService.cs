using MS.ProductApi.DTOs.Categories;

namespace MS.ProductApi.Services.Categories;

public interface ICategoryService
{
    Task AddCategory(CategoryDTO category);
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetCategoryById(int id);
    Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
    Task UpdateCategory(CategoryDTO category);
    Task DeleteCategory(int id);
}
