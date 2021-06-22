using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SyrianShop.dataContexts;
using SyrianShop.errorHandling;
using SyrianShop.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.configuration
{
    public static class ApplicationServicesExtensions
    {

        //Extension method for IserviceCollection
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //repositories
            services.AddScoped<ProductRepository, ProductRepository>();

            //json cycle
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //enable cors
            services.AddCors(c =>
            {
                c.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });


            //model validation custom message
            services.Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                }
            );

            return services;
        }
    }
}
