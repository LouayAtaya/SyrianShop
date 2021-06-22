using SyrianShop.dataContexts;
using SyrianShop.DTOs;
using SyrianShop.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.repositories
{
    public class UserRepository :GenericRepository<User>
    {
        private SyrianShopContext _syrianShopContext;

        public UserRepository(SyrianShopContext syrianShopContext) : base(syrianShopContext)
        {
            this._syrianShopContext = syrianShopContext;
        }

        public User login(UserDto loginUser)
        {
            try
            {
                var user = _syrianShopContext.Users
                   .Where(u => u.Name == loginUser.Name && u.Password == loginUser.Password)
                   .Select(u => new User()
                   {
                       Id = u.Id,
                       Name = u.Name,
                       Roles = u.Roles
                   })
                   .FirstOrDefault();

                return user;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
