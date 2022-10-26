using AutoMapper;
using MS.ProductApi.DTOs.Categories;
using MS.ProductApi.DTOs.Products;
using MS.ProductApi.Models;

namespace MS.ProductApi.DTOs.Mappings;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Category, CategoryDTO>().ReverseMap();
		CreateMap<Product, ProductDTO>().ReverseMap();
	}
}
