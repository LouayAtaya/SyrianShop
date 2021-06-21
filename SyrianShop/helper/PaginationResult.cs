using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.helper
{
    public class PaginationResult<T> where T:class
    {
        public int PageStart { get; set; }

        public int PageSize { get; set; }

        public IList<T> Data { get; set; }



    }
}
