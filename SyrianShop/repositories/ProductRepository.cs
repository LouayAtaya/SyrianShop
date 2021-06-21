using Microsoft.EntityFrameworkCore;
using SyrianShop.dataContexts;
using SyrianShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.repositories
{
    public class ProductRepository : IProductRepository
    {
        private SyrianShopContext _syrianShopContext;

        public ProductRepository(SyrianShopContext syrianShopContext)
        {
            this._syrianShopContext = syrianShopContext;
        }

        async Task<Product> IProductRepository.GetProductByIdAsync(int id)
        {
            return await this._syrianShopContext.Products.FindAsync(id);
        }

        async Task<IList<Product>> IProductRepository.GetProductsAsync()
        {
            return await this._syrianShopContext.Products.Include(p=>p.ProductImages).ToListAsync();
        }
    }
}
