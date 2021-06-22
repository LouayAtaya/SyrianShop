using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SyrianShop.dataContexts;
using SyrianShop.errorHandling;
using SyrianShop.models;
using SyrianShop.repositories;

namespace SyrianShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<SyrianShopContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ProductRepository, ProductRepository>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(c =>
                {
                    c.AddPolicy("CorsPolicy", policy =>
                     {
                         policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                     }); 
                });

            services.Configure<ApiBehaviorOptions>(options =>
                options.InvalidModelStateResponseFactory=actionContext =>
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

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Syrian Shop API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c=> 
                { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Syrian Shop API"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
