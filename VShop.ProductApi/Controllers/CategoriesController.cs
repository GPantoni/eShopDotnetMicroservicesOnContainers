using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var categoriesDto = await _categoryService.GetCategoriesAsync();

        if (categoriesDto is null)
            return NotFound("Categories not found.");

        return Ok(categoriesDto);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
    {
        var categoriesProductsDto = await _categoryService.GetCategoriesProductsAsync();

        if (categoriesProductsDto is null)
            return NotFound("Categories not found.");

        return Ok(categoriesProductsDto);
    }

    [HttpGet("{id}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
    {
        var categoryDto = await _categoryService.GetCategoryByIdAsync(id);

        if (categoryDto is null)
            return NotFound("Category not found.");

        return Ok(categoryDto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto is null)
            return BadRequest("Category data is required.");

        await _categoryService.CreateCategoryAsync(categoryDto);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId }, categoryDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto is null)
            return BadRequest("Category data is required.");

        if (id != categoryDto.CategoryId)
            return BadRequest("Category ID mismatch.");

        await _categoryService.UpdateCategoryAsync(categoryDto);

        return Ok(categoryDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        var categoryDto = await _categoryService.GetCategoryByIdAsync(id);

        if (categoryDto is null)
            return NotFound("Category not found.");

        await _categoryService.DeleteCategoryAsync(id);

        return Ok(categoryDto);
    }
}