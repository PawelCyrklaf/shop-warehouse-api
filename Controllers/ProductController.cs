﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopWarehouse.API.Data.Dto.Product;
using ShopWarehouse.API.Data.Interfaces;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _productService.AddProduct(product);
            return Ok();
        }

        /// <summary>
        /// Get product details
        /// </summary>
        /// <param name="productId">The model.</param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int productId)
        {
            var product = await _productService.GetProduct(productId);
            if (product == null)
                return NotFound();

            var dto = _mapper.Map<ProductDto>(product);

            return Ok(dto);
        }


        /// <summary>
        /// Get products list
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ActionResult<ProductDto>> GetProducts()
        {
            var products = await _productService.GetProducts();
            var dto = _mapper.Map<List<ProductDto>>(products);

            return Ok(dto);
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        public async Task<ActionResult<bool>> RemoveProduct([FromRoute] int productId)
        {
            return await _productService.RemoveProduct(productId);
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">The model.</param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpPut("{productId}")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product, [FromRoute] int productId)
        {
           var result = await _productService.UpdateProduct(product, productId);

           if (result)
           {
               return Ok();
           }

           return NotFound();
        }

    }
}
