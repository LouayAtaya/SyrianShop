using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.repositories
{
    public interface IGenericRepository<T> where T: class
    {

        Task<T> GetByIdAsync(int id);

        Task<IList<T>> GetAllAsync();

        Task<T> Add(T entity); 

        Task Delete(T entity);

        Task<T> Edit(T entity);


        Task<Boolean> Exists(int id);
      
   

    }
}
