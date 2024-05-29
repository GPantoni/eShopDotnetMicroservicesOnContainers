using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var productsDto = await _productService.GetProductsAsync();

        if (productsDto is null)
            return NotFound("Products not found.");

        return Ok(productsDto);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> GetProductById(int id)
    {
        var productDto = await _productService.GetProductByIdAsync(id);

        if (productDto is null)
            return NotFound("Product not found.");

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] ProductDTO productDto)
    {
        if (productDto is null)
            return BadRequest("Product data is required.");

        await _productService.CreateProductAsync(productDto);

        return new CreatedAtRouteResult("GetProduct", new { id = productDto.ProductId }, productDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDto)
    {
        if (productDto is null)
            return BadRequest("Product data is required.");

        if (productDto.ProductId != id)
            return BadRequest("Product ID mismatch.");

        await _productService.UpdateProductAsync(productDto);

        return Ok(productDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var productDto = await _productService.GetProductByIdAsync(id);

        if (productDto is null)
            return NotFound("Product not found.");

        await _productService.DeleteProductAsync(id);

        return Ok(productDto);
    }
}