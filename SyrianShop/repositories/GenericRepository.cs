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
            try
            {
                return await _syrianShopContext.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _syrianShopContext.Set<T>().FindAsync(id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                _syrianShopContext.Set<T>().Add(entity);
                
                await Save();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(T entity)
        {
            try
            {
                _syrianShopContext.Set<T>().Remove(entity);
                await Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> Edit(T entity)
        {
            try
            {
                _syrianShopContext.Entry(entity).State = EntityState.Modified;
                await Save();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
        public async Task<bool> Exists(int id)
        {

            if (await this.GetByIdAsync(id) !=null)
            {
                return true;
            }
            return false;
        }

        private async Task Save()
        {
            try
            {
                await _syrianShopContext.SaveChangesAsync();
               
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
