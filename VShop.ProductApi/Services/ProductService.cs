using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task CreateProductAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.CreateProductAsync(product);
        productDto.ProductId = product.Id;
    }

    public async Task UpdateProductAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.UpdateProductAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        await _productRepository.DeleteProductAsync(product.Id);
    }
}