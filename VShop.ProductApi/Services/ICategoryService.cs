using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    Task<IEnumerable<CategoryDTO>> GetCategoriesProductsAsync();
    Task<CategoryDTO> GetCategoryByIdAsync(int id);
    Task CreateCategoryAsync(CategoryDTO categoryDto);
    Task UpdateCategoryAsync(CategoryDTO categoryDto);
    Task DeleteCategoryAsync(int id);
}