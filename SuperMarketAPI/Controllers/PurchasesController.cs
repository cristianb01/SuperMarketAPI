using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarketAPI.Domain.Services;
using SuperMarketAPI.Extensions;
using SuperMarketAPI.Models;
using SuperMarketAPI.Persistence.Contexts;
using SuperMarketAPI.Resources;

namespace SuperMarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        private readonly IMapper _mapper;

        public PurchasesController(IPurchaseService purchaseService, IMapper mapper)
        {
            _purchaseService = purchaseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PurchaseResource>> GetAllAsync()
        {
            var purchases = await _purchaseService.ListAsync();
            var resource = _mapper.Map< IEnumerable<Purchase>, IEnumerable<PurchaseResource>>(purchases);
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SavePurchaseResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var purchase = _mapper.Map<Purchase>(resource);

            var result = await _purchaseService.AddAsync(purchase);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var purchaseResource = _mapper.Map<PurchaseResource>(result.Purchase);

            return Ok(purchaseResource);
        }
    }
}