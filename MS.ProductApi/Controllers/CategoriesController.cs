using Microsoft.AspNetCore.Mvc;
using MS.ProductApi.DTOs.Categories;
using MS.ProductApi.Services.Categories;

namespace MS.ProductApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ICategoryService categoryService;

	public CategoriesController(ICategoryService categoryService)
	{
		this.categoryService = categoryService;
	}

	[HttpPost]
	public async Task<ActionResult> Add(CategoryDTO category)
	{
		if (category == null) return BadRequest("Invalid Data");

		await categoryService.AddCategory(category);
		return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
	}

	[HttpGet("{categoryId}")]
	public async Task<ActionResult<CategoryDTO>> GetById(int categoryId)
	{
		var res = await categoryService.GetCategoryById(categoryId);
		return res is not null ? Ok(res) : NotFound("Category Not Found");
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
	{
		var res = await categoryService.GetCategories();
		return res is not null ? Ok(res) : NotFound("Category Not Found");
	}

	[HttpGet("products")]
	public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoryProduct()
	{
		var res = await categoryService.GetCategoriesProducts();
		return res is not null ? Ok(res) : NotFound("Category Not Found");
	}

	[HttpPut("categoryId")]
	public async Task<ActionResult> Update(int categoryId, CategoryDTO category)
	{
		if (categoryId != category.Id || category is null) return BadRequest();

		await categoryService.UpdateCategory(category);
		return Ok(category);
	}

	[HttpDelete("categoryId")]
	public async Task<ActionResult> Delete(int categoryId)
	{
		var category = await categoryService.GetCategoryById(categoryId);

		if (category is null) return NotFound("Category Not Found");

		await categoryService.DeleteCategory(categoryId);
		return Ok(category);
	}
}
