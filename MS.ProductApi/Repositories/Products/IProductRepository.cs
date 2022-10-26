using MS.ProductApi.Models;

namespace MS.ProductApi.Repositories.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> Create(Product category);
    Task<Product> Update(Product category);
    Task<Product> Delete(int id);
}
