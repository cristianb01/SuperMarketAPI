using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> FindByIdAsync(int id);
        Task<ProductResponse> DeleteAsync(int id);
    }
}
