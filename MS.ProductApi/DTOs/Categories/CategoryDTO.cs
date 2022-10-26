﻿using MS.ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace MS.ProductApi.DTOs.Categories;

public class CategoryDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
