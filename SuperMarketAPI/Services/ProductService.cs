using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Domain.Services;
using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarketAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SuperMarketAPI.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public AppDbContext _context; 
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork,
                                AppDbContext context)
        {
            this._productRepository = repository;
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
            this._context = context;
        }


        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponse> FindByIdAsync(int id)
        {
            var existingProduct =  await _productRepository.FindByIdAsync(id);

            if(existingProduct == null)
            {
                return new ProductResponse($"Product with id: {id} could not be found");
            }

            return new ProductResponse(existingProduct);

        }
        public async Task<ProductResponse> SaveAsync(Product product)
        {
            bool existsCategory = await _categoryRepository.ExistsCategory(product.CategoryId);
            if (!existsCategory)
            {
                return new ProductResponse("The specified category does not exist");
            }

            await _productRepository.SaveAsync(product);
            await _unitOfWork.CompleteAsync();
            //TODO verificar si se puede simplificar el llamado al siguiente metodo
            var finalProduct = await _productRepository.FindByIdAsync(product.Id);
            return new ProductResponse(finalProduct);
        }
    }
}
