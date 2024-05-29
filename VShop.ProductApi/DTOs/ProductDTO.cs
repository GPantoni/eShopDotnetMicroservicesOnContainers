using System.ComponentModel.DataAnnotations;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs;

public class ProductDTO
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "The name is required")]
    [Length(3, 100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The description is required")]
    [Length(5, 200)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The stock is required")]
    [Range(1, 9999)]
    public long Stock { get; set; }

    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}