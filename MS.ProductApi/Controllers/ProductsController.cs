using Microsoft.AspNetCore.Mvc;
using MS.ProductApi.DTOs.Products;
using MS.ProductApi.Services.Products;

namespace MS.ProductApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpPost]
    public async Task<ActionResult> Add(ProductDTO product)
    {
        await productService.AddProduct(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<ProductDTO>> GetById(int productId)
    {
        var res = await productService.GetProductById(productId);
        return res is not null ? Ok(res) : NotFound("Product not found");

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
    {
        var res = await productService.GetProducts();
        return res is not null ? Ok(res) : NotFound("Product not found");

    }

    [HttpPut("productId")]
    public async Task<ActionResult> Update(int productId, ProductDTO product)
    {
        if (productId != product.Id || product is null) return BadRequest();

        await productService.UpdateProduct(product);
        return NoContent();
    }

    [HttpDelete("productId")]
    public async Task<ActionResult> Delete(int productId)
    {
        var product = await productService.GetProductById(productId);
        if (product is null) return NotFound("Product not found");

        await productService.DeleteProduct(productId);
        return NoContent();
    }
}
