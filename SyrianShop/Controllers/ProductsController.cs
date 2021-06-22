using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyrianShop.dataContexts;
using SyrianShop.DTOs;
using SyrianShop.errorHandling;
using SyrianShop.helper;
using SyrianShop.models;
using SyrianShop.repositories;

namespace SyrianShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<PaginationResult<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {
            try
            {
                var products = await _productRepository.GetProductsAsync(productParams.SortBy, productParams.PageStart, productParams.PageSize);

                var paginationResult = new PaginationResult<Product>(productParams.PageStart, productParams.PageSize, _productRepository.TotalRecords, products);
                
                return Ok(paginationResult);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
            
        }

        // GET: api/Products/51
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);

                if (product == null)
                {
                    return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));
                }

                return Ok(product);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
        }

      
    }
}
