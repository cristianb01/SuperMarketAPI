using Microsoft.EntityFrameworkCore;
using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using SuperMarketAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category)
                                          .ToListAsync();
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task SaveAsync(Product product)
        {
            await _context.Products.AddAsync(product);

        }

        public async Task<bool> Exists(string name)
        {
            return await _context.Products.AnyAsync(p => p.Name == name);
        }
    }
}
