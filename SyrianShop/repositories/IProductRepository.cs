using SyrianShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.repositories
{
    public interface IProductRepository
    {
        Task<IList<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(int id);
    }
}
