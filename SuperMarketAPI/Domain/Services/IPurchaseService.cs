using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services
{
    public interface IPurchaseService
    {
        public Task<IEnumerable<Purchase>> ListAsync();

        public Task<PurchaseResponse> AddAsync(Purchase purchase);
    }
}
