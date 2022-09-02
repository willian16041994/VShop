﻿using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productsDto = await _productService.GetProducts();
            if (productsDto is null)
                return NotFound("Products not found");
            return Ok(productsDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto == null)
            {
                return NotFound("Product not found");
            }
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return BadRequest("Invalid Data");

            await _productService.AddProduct(productDto);
            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest();

            if (productDto == null)
                return BadRequest();

            await _productService.UpdateProduct(productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _productService.GetProductById(id);
            if (productDto == null)
            {
                return NotFound("Product not found");
            }
            await _productService.DeleteProduct(id);
            return Ok(productDto);
        }
    }
}
