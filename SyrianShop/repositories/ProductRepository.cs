using Microsoft.EntityFrameworkCore;
using SyrianShop.dataContexts;
using SyrianShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly SyrianShopContext _syrianShopContext;

        public int TotalRecords { set; get; }

        public ProductRepository(SyrianShopContext syrianShopContext):base(syrianShopContext)
        {
            this._syrianShopContext = syrianShopContext;
        }

        public async Task<IList<Product>> GetProductsAsync(string sortBy, int pageStart, int pageSize)
        {
            try
            {
                IQueryable<Product> query = _syrianShopContext.Products.AsQueryable();

                //Sort
                if (!string.IsNullOrEmpty(sortBy))
                {
                    query = sortBy switch
                    {
                        "title" => query.OrderBy(p => p.Title),
                        "description" => query.OrderBy(p => p.Description),
                        "quantity" => query.OrderBy(p => p.Quantity),
                        "price" => query.OrderBy(p => p.Price),
                        "titleDesc" => query.OrderByDescending(p => p.Title),
                        "descriptionDesc" => query.OrderByDescending(p => p.Description),
                        "quantityDesc" => query.OrderByDescending(p => p.Quantity),
                        "priceDesc" => query.OrderByDescending(p => p.Price),
                        _ => query.OrderBy(p => p.CreationDate),
                    };
                }
                else
                {
                    //default order by CreationDate
                    query = query.OrderBy(p => p.CreationDate);

                }

                //pagination
                query = query.Skip(pageStart).Take(pageSize);

                //count the records returned
                TotalRecords = await query.CountAsync();

                return await query.ToListAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}
