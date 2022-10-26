using MS.ProductApi.DTOs.Products;

namespace MS.ProductApi.Services.Products;

public interface IProductService
{
    Task AddProduct(ProductDTO product);
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int id);
    Task UpdateProduct(ProductDTO product);
    Task DeleteProduct(int id);
}
