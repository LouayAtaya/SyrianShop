using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SyrianShop.errorHandling
{
    public class ApiErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public String Message { get; set; }

        public ApiErrorResponse(HttpStatusCode statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        private string GetDefaultMessage(HttpStatusCode httpStatusCode)
        {
            return httpStatusCode switch
            {
                HttpStatusCode.NotFound => "Resource Not found!",
                HttpStatusCode.BadRequest => "A Bad Request, you have made",
                HttpStatusCode.Unauthorized => "You Are Not Authorized!",
                HttpStatusCode.InternalServerError => "Internal Server Error, an error has been Accourd",
                _ => "Unknown Error, An error has been Accourd"
            };
        }
    }
}
