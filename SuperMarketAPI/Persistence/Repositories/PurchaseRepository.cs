using Microsoft.EntityFrameworkCore;
using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Models;
using SuperMarketAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Persistence.Repositories
{
    public class PurchaseRepository : BaseRepository, IPurchaseRepository
    {

        public PurchaseRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Purchase>> GetAllAsync()
        {
            return await this._context.Purchases.Include(p => p.Products).ThenInclude(p => p.Product).ThenInclude(p => p.Category).ToListAsync();
        }

        public async Task AddAsync(Purchase purchase)
        {
            await this._context.Purchases.AddAsync(purchase);
        }
    }
}
