using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<IEnumerable<CategoryDTO>> GetCategoriesProductsAsync()
    {
        var categories = await _categoryRepository.GetCategoriesProductsAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        return _mapper.Map<CategoryDTO>(category);
    }

    public async Task CreateCategoryAsync(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.CreateCategoryAsync(category);
        categoryDto.CategoryId = category.Id;
    }

    public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.UpdateCategoryAsync(category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        await _categoryRepository.DeleteCategoryAsync(category.Id);
    }
}