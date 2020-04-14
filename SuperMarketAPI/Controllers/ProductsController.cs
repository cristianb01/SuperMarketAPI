using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarketAPI.Domain.Services;
using SuperMarketAPI.Extensions;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources;

namespace SuperMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListAsync(int id)
        {
            var productResponse = await _productService.FindByIdAsync(id);
            if(!productResponse.Success)
            {
                return BadRequest(productResponse.Message);
            }
            
            var productResource = _mapper.Map<ProductResource>(productResponse.product);

            return Ok(productResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }


            var product = _mapper.Map<Product>(resource);

            var result = await _productService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            ProductResource productResource = _mapper.Map<ProductResource>(result.product);

            return Ok(productResource);
        }
    }
}