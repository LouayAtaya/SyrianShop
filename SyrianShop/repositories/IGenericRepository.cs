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


    }
}
