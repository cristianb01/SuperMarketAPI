using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Repositories
{
    public interface IPurchaseRepository
    {
        public Task<IEnumerable<Purchase>> GetAllAsync();
        public Task AddAsync(Purchase purchase);

    }
}
