using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Domain.Services;
using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository, IUnitOfWork unitOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Purchase>> ListAsync()
        {
            return await _purchaseRepository.GetAllAsync();
        }
        public async Task<PurchaseResponse> AddAsync(Purchase purchase)
        {
            try
            {
                await _purchaseRepository.AddAsync(purchase);
                await _unitOfWork.CompleteAsync();

                return new PurchaseResponse(purchase);

            } catch (Exception e)
            {
                return new PurchaseResponse("An error ocurred while saving the purchase:\n" + e);
            }
         
        }
    }
}
