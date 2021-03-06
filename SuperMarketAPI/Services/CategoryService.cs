﻿using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Domain.Services;
using SuperMarketAPI.Domain.Services.Communication;
using SuperMarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService( ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> FindByIdAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new CategoryResponse("Category could not be found");
            }

            return new CategoryResponse(existingCategory);
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            bool alreadyExists = await _categoryRepository.ExistsCategory(category.Name);
            if (alreadyExists)
            {
                return new CategoryResponse("The category already exists");
            }

            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);

            }
            catch(Exception e)
            {
                return new CategoryResponse("An error ocurred when saving the category: " + e.Message); 
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new CategoryResponse($"The Category with id: {id} does not exist");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch(Exception e)
            {
                return new CategoryResponse($"An error occurred when updating the category: {e.Message}");
            }
        }


        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new CategoryResponse("Category not found.");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occurred while deleting the category: {ex.Message}");
            }
        }
    }
}
