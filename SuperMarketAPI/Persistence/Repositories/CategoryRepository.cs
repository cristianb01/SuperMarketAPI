using Microsoft.EntityFrameworkCore;
using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Models;
using SuperMarketAPI.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }

        public void Remove(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task<bool> ExistsCategory(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name == name);
        }
    }
}
