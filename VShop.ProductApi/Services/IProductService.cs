using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task CreateProductAsync(ProductDTO productDto);
    Task UpdateProductAsync(ProductDTO productDto);
    Task DeleteProductAsync(int id);
}