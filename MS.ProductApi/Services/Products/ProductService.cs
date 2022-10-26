using AutoMapper;
using MS.ProductApi.DTOs.Products;
using MS.ProductApi.Models;
using MS.ProductApi.Repositories.Products;

namespace MS.ProductApi.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task AddProduct(ProductDTO product)
    {
        var productEntity = mapper.Map<Product>(product);
        await productRepository.Create(productEntity);
        product.Id = productEntity.Id;
    }
    public async Task<ProductDTO> GetProductById(int id)
    {
        var productEntity = await productRepository.GetById(id);
        var product = mapper.Map<ProductDTO>(productEntity);
        return product;
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var productEntity = await productRepository.GetAll();
        var product = mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        return product;
    }

    public async Task UpdateProduct(ProductDTO product)
    {
        var productEntity = mapper.Map<Product>(product);
        await productRepository.Update(productEntity);
    }
    public async Task DeleteProduct(int id)
    {

        var productEntity = productRepository.GetById(id).Result;
        await productRepository.Delete(productEntity.Id);
    }
}
