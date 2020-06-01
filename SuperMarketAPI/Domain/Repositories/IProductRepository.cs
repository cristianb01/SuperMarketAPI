using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task SaveAsync(Product product);
        Task<Product> FindByIdAsync(int id);
        Task<bool> Exists(string name);
        void Remove(Product product);
    }
}
