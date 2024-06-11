using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99m },
                new Product { Id = 2, Name = "Product 2", Price = 20.99m },
                new Product { Id = 3, Name = "Product 3", Price = 30.99m }
            };
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            var productService = new ProductService(mockRepository.Object);

            // Act
            var result = await productService.GetAllProductsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(products.Count, result.Count());
        }

        [Test]
        public async Task UpdateProductAsync_ProductIsUpdated()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productToUpdate = new Product { Id = 1, Name = "Updated Product", Price = 25.99m };
            mockRepository.Setup(repo => repo.UpdateAsync(productToUpdate)).Returns(Task.CompletedTask);
            var productService = new ProductService(mockRepository.Object);

            // Act
            await productService.UpdateProductAsync(productToUpdate);

            // Assert
            mockRepository.Verify(repo => repo.UpdateAsync(productToUpdate), Times.Once);
        }

        [Test]
        public async Task DeleteProductAsync_ProductIsDeleted()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productId = 1;
            mockRepository.Setup(repo => repo.DeleteAsync(productId)).Returns(Task.CompletedTask);
            var productService = new ProductService(mockRepository.Object);

            // Act
            await productService.DeleteProductAsync(productId);

            // Assert
            mockRepository.Verify(repo => repo.DeleteAsync(productId), Times.Once);
        }

        [Test]
        public async Task GetProductByIdAsync_ProductNotFound_ReturnsNull()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productId = 1;
            mockRepository.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync((Product)null);
            var productService = new ProductService(mockRepository.Object);

            // Act
            var result = await productService.GetProductByIdAsync(productId);

            // Assert
            Assert.IsNull(result);
        }
    }
}
