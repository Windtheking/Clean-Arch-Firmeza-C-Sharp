using CleanFirmeza.Application.Common;
using CleanFirmeza.Application.DTOs;
using CleanFirmeza.Domain.Entities;

namespace CleanFirmeza.Application.Interfaces;

public interface IProductService 
{
    Task<List<Product>> GetAllAsync();
    Task<PagedResult<ProductDto>> GetPagedAsync(int page, string? searchTerm = null);
    Task<Product?> GetByIdAsync(Guid id);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}