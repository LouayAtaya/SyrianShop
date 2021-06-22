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
        private SyrianShopContext _syrianShopContext;

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
                    switch (sortBy)
                    {
                        case "title":
                            query = query.OrderBy(p => p.Title);
                            break;
                        case "description":
                            query = query.OrderBy(p => p.Description);
                            break;
                        case "quantity":
                            query = query.OrderBy(p => p.Quantity);
                            break;
                        case "price":
                            query = query.OrderBy(p => p.Price);
                            break;
                        case "titleDesc":
                            query = query.OrderByDescending(p => p.Title);
                            break;
                        case "descriptionDesc":
                            query = query.OrderByDescending(p => p.Description);
                            break;
                        case "quantityDesc":
                            query = query.OrderByDescending(p => p.Quantity);
                            break;
                        case "priceDesc":
                            query = query.OrderByDescending(p => p.Price);
                            break;
                        default:
                            query = query.OrderBy(p => p.CreationDate);
                            break;
                    }

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
