using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using product_api_diy_kart.Model;
using product_microservice_diy_kart.Controllers;
using product_microservice_diy_kart.DBContext;
using product_microservice_diy_kart.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProductMicroservice.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductRepository> _service;


        public ProductControllerTest()
        {
            _service = new Mock<IProductRepository>();

        }

        [Fact]
        public async Task GetProducts_ReturnsProductList()
        {
            //Arrange
            var productList = GetProductsData();
            _service.Setup(x => x.GetProducts()).Returns(productList);
            var productController = new ProductController(_service.Object);

            //Act
            var result = await productController.Get();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory]
        [InlineData(5)]
        public async Task GetProductById_ReturnsProduct(int Id)
        {
            //Arrange
            var product = GetProduct();
            _service.Setup(x => x.GetProductById(Id)).Returns(product);
            var productController = new ProductController(_service.Object);

            //Act
            var result = await productController.Get(Id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsOk()
        {
            //Arrange
            var product = new Product
            {
                Id = 5,
                Name = "Silverside Wristwatch",
                Description = "Jumper set for Women",
                Price = 175,
                PictureFileName = "sweater.png",
                PictureUri = "assets/images/sweater.png",
                CatalogTypeId = 2,
                CatalogBrandId = 1,
                AvailableStock = 5,
                RestockThreshold = 5,
                MaxStockThreshold = 5,
                OnReorder = true
            };

            var addedproduct = GetProduct();

            _service.Setup(x => x.UpdateProduct(product)).Returns(addedproduct);
            var productController = new ProductController(_service.Object);

            //Act
            var result = await productController.Put(product);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
        }

        private async Task<IEnumerable<Product>> GetProductsData()
        {
            IEnumerable<Product> productData = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Flat Hill Slingback",
                    Description = "Jumper set for Women",
                    Price = 175,
                    PictureFileName = "full-body.png",
                    PictureUri = "assets/images/full-body.png",
                    CatalogTypeId = 1,
                    CatalogBrandId = 1,
                    AvailableStock = 5,
                    RestockThreshold = 5,
                    MaxStockThreshold = 5,
                    OnReorder = true
                },
                new Product
                {
                    Id = 2,
                    Name = "Ocean Blue",
                    Description = "Jumper set for Women",
                    Price = 175,
                    PictureFileName = "formal-coat.png",
                    PictureUri = "assets/images/formal-coat.png",
                    CatalogTypeId = 1,
                    CatalogBrandId = 1,
                    AvailableStock = 5,
                    RestockThreshold = 5,
                    MaxStockThreshold = 5,
                    OnReorder = true
                },
                new Product
                {
                    Id = 3,
                    Name = "Brown Leathered Wallet",
                    Description = "Jumper set for Women",
                    Price = 175,
                    PictureFileName = "ocean-blue.png",
                    PictureUri = "assets/images/ocean-blue.png",
                    CatalogTypeId = 1,
                    CatalogBrandId = 1,
                    AvailableStock = 5,
                    RestockThreshold = 5,
                    MaxStockThreshold = 5,
                    OnReorder = true
                },
                new Product
                {
                    Id = 4,
                    Name = "Silverside Wristwatch",
                    Description = "Jumper set for Women",
                    Price = 175,
                    PictureFileName = "sweater.png",
                    PictureUri = "assets/images/sweater.png",
                    CatalogTypeId = 1,
                    CatalogBrandId = 1,
                    AvailableStock = 5,
                    RestockThreshold = 5,
                    MaxStockThreshold = 5,
                    OnReorder = true
                },
                new Product
                {
                    Id = 5,
                    Name = "Silverside Wristwatch",
                    Description = "Jumper set for Women",
                    Price = 175,
                    PictureFileName = "sweater.png",
                    PictureUri = "assets/images/sweater.png",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    AvailableStock = 5,
                    RestockThreshold = 5,
                    MaxStockThreshold = 5,
                    OnReorder = true
                },

            };

            return productData;
        }

        private async Task<Product> GetProduct()
        {
            Product productData = new Product
                {
                    Id = 5,
                    Name = "Silverside Wristwatch",
                    Description = "Jumper set for Women",
                    Price = 175,
                    PictureFileName = "sweater.png",
                    PictureUri = "assets/images/sweater.png",
                    CatalogTypeId = 2,
                    CatalogBrandId = 1,
                    AvailableStock = 5,
                    RestockThreshold = 5,
                    MaxStockThreshold = 5,
                    OnReorder = true
                };

            return productData;
        }
    }
}
