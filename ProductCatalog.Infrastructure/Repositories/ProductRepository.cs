using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Domain.Models;
using ProductCatalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductCatalogContext _productCatalogContext;

        public ProductRepository(ProductCatalogContext productCatalogContext)
        {
            _productCatalogContext = productCatalogContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _productCatalogContext.Products
                                 .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var product = await _productCatalogContext.Products
                                .Where(r => r.Id == id)
                                .SingleOrDefaultAsync();
            return product;
        }

        public async Task<int> SaveProduct(Guid id, Product product)
        {
            if (id != Guid.Empty)
            {
                product.Id = id;
                _productCatalogContext.Update(product);
            }
            else
            {
                _productCatalogContext.Add(product);
            }

            return await _productCatalogContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(Guid id)
        {
            var product = await _productCatalogContext.Products
                                .FirstOrDefaultAsync(r => r.Id == id);
            //var productOptions = _productCatalogContext.ProductOptions.Where(r => r.ProductId == id);

            //_productCatalogContext.ProductOptions.RemoveRange(productOptions);

            _productCatalogContext.Products.Remove(product);
            return await _productCatalogContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductOption>> GetProductOptions(Guid productId)
        {
            var productOptions = await _productCatalogContext.ProductOptions
                                       .Where(r => r.ProductId == productId)
                                       .ToListAsync();
            return productOptions;
        }

        public async Task<ProductOption> GetProductOption(Guid id, Guid productId)
        {
            var ProductOptions = await _productCatalogContext.ProductOptions
                                       .Where(r => r.Id == id && r.ProductId == productId)
                                       .SingleOrDefaultAsync();
            return ProductOptions;
        }

        public async Task<int> SaveProductOption(Guid id, Guid productId, ProductOption productOption)
        {
            if (id != Guid.Empty)
            {
                productOption.Id = id;
                _productCatalogContext.Update(productOption);
            }
            else
            {
                _productCatalogContext.Add(productOption);
            }

            return await _productCatalogContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductOption(Guid id, Guid productId)
        {
            var productOption = await _productCatalogContext.ProductOptions
                                .FirstOrDefaultAsync(r => r.Id == id);

            _productCatalogContext.Remove(productOption);
            return await _productCatalogContext.SaveChangesAsync();
        }
    }
}