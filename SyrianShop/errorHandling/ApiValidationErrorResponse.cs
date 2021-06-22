using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SyrianShop.errorHandling
{
    public class ApiValidationErrorResponse : ApiErrorResponse
    {
        public ApiValidationErrorResponse(string message = null): base(HttpStatusCode.BadRequest)
        {
            
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
