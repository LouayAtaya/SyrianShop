using Microsoft.EntityFrameworkCore;
using SyrianShop.dataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class 
    {
        private readonly SyrianShopContext _syrianShopContext;

        public GenericRepository(SyrianShopContext syrianShopContext)
        {
            _syrianShopContext = syrianShopContext;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _syrianShopContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _syrianShopContext.Set<T>().FindAsync(id);
        }

        
    }
}
