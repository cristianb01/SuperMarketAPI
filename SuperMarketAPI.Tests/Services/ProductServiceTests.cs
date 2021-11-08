using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using SuperMarketAPI.Domain.Repositories;
using SuperMarketAPI.Models;
using SuperMarketAPI.Persistence.Contexts;
using SuperMarketAPI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAPI.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private ProductService _productService;
        private Mock<IProductRepository> _productRepositoryMoq;
        private Mock<ICategoryRepository> _categoryRepositoryMoq;
        private Mock<IUnitOfWork> _unitOfWorkMoq;

        [SetUp]
        public void TestInitialize()
        {
            _productRepositoryMoq = new Mock<IProductRepository>();
            _categoryRepositoryMoq = new Mock<ICategoryRepository>();
            _unitOfWorkMoq = new Mock<IUnitOfWork>();
            _productService = new ProductService(_productRepositoryMoq.Object, _categoryRepositoryMoq.Object, _unitOfWorkMoq.Object);
        }

        [Test]
        public async Task SaveAsync_ShouldCreateNewProductAsync()
        {
            // Arrange
            var product = GetProduct();
            _productRepositoryMoq.Setup(x => x.SaveAsync(It.IsAny<Product>())).ReturnsAsync((Product x) => x);
            _categoryRepositoryMoq.Setup(x => x.FindByIdAsync(product.CategoryId)).ReturnsAsync(GetCategoryByIdAsync(product.CategoryId));


            // Act
            var productCreationResult = await _productService.SaveAsync(product);

            // Assert
            Assert.IsTrue(productCreationResult.Success);
            Assert.IsNotNull(productCreationResult.product);
        }

        [Test]
        public async Task SaveAsync_ShouldReturnNoExistingCategoryResponse()
        {
            // Arrange
            var product = GetProduct();

            _productRepositoryMoq.Setup(x => x.SaveAsync(It.IsAny<Product>())).ReturnsAsync((Product x) => x);
            _categoryRepositoryMoq.Setup(x => x.FindByIdAsync(product.CategoryId)).Returns(Task.FromResult<Category>(null));

            // Act
            var productCreationResult = await _productService.SaveAsync(product);

            // Assert
            Assert.IsFalse(productCreationResult.Success);
            Assert.IsNull(productCreationResult.product);
        }

        [Test]
        public async Task SaveAsync_ShouldReturnAlreadyExistsResponse()
        {
            // Arrange
            var product = GetProduct();
            _productRepositoryMoq.Setup(x => x.SaveAsync(It.IsAny<Product>())).ReturnsAsync((Product x) => x);
            _categoryRepositoryMoq.Setup(x => x.FindByIdAsync(product.CategoryId)).ReturnsAsync(GetCategoryByIdAsync(product.CategoryId));
            _productRepositoryMoq.Setup(x => x.Exists(product.Name)).Returns(Task.FromResult(true));
            string expected = "The product already exists";

            // Act
            var productCreationResult = await _productService.SaveAsync(product);

            // Assert
            Assert.IsFalse(productCreationResult.Success);
            Assert.AreEqual(productCreationResult.Message, expected);

        }
        private Category GetCategoryByIdAsync(int id)
        {
            return new Category { Id = id, Name = "Example category" };
        }

        private Product GetProduct()
        {
            return new Product { CategoryId = 3, Id = 1, Name = "Test name" };
        }
    }
}
