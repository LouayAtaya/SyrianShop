using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles ="Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductsController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        // PUT: api/products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id)
                {
                    return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
                }
                var existProduct = await _productRepository.Edit(product);
                return Ok(existProduct);
            }
            catch
            {
                Boolean isExist = await _productRepository.Exists(id);
                if (!isExist)
                    return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));

                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }

        }

        // POST: api/products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));

                var addedProduct = await _productRepository.Add(product);
                return CreatedAtAction("GetProduct", new { id = product.Id }, addedProduct);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return NotFound(new ApiErrorResponse(HttpStatusCode.NotFound));
                }

                await _productRepository.Delete(product);
                return Ok(product);
            }
            catch
            {
                return BadRequest(new ApiErrorResponse(HttpStatusCode.BadRequest));
            }

        }


    }
}
