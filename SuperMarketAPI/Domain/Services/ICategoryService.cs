﻿using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperMarketAPI.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
        Task<CategoryResponse> FindByIdAsync(int id);
    }
}
