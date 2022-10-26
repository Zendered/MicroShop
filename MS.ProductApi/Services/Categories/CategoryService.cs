using AutoMapper;
using MS.ProductApi.DTOs.Categories;
using MS.ProductApi.Models;
using MS.ProductApi.Repositories.Categories;

namespace MS.ProductApi.Services.Categories;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository categoryRepository;
	private readonly IMapper mapper;

	public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
	{
		this.categoryRepository = categoryRepository;
		this.mapper = mapper;
	}

	public async Task AddCategory(CategoryDTO category)
	{
		var categoryEntity = mapper.Map<Category>(category);
		await categoryRepository.Create(categoryEntity);
		category.Id = categoryEntity.Id;
	}
	public async Task<CategoryDTO> GetCategoryById(int id)
	{
		var categoryEntity = await categoryRepository.GetById(id);
		var category = mapper.Map<CategoryDTO>(categoryEntity);
		return category;
	}

	public async Task<IEnumerable<CategoryDTO>> GetCategories()
	{
		var categoryEntity = await categoryRepository.GetAll();
		var category = mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
		return category;
	}

	public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
	{
		var categoryEntity = await categoryRepository.GetCategoriesProducts();
		var category = mapper.Map<IEnumerable<CategoryDTO>>(categoryEntity);
		return category;
	}

	public async Task UpdateCategory(CategoryDTO category)
	{
		var categoryEntity = mapper.Map<Category>(category);
		await categoryRepository.Update(categoryEntity);
	}
	public async Task DeleteCategory(int id)
	{

		var categoryEntity = categoryRepository.GetById(id).Result;
		await categoryRepository.Delete(categoryEntity.Id);
	}
}
