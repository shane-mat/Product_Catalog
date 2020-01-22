using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductCatalog.Domain.Models;

namespace ProductCatalog.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid id);
        Task<int> SaveProduct(Guid id, Product product);
        Task<int> DeleteProduct(Guid id);

        Task<IEnumerable<ProductOption>> GetProductOptions(Guid productId);
        Task<ProductOption> GetProductOption(Guid id, Guid productId);
        Task<int> SaveProductOption(Guid id, Guid productId, ProductOption productOption);
        Task<int> DeleteProductOption(Guid id, Guid productId);
    }
}