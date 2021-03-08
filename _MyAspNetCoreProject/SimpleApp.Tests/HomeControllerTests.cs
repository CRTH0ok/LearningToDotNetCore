using Microsoft.AspNetCore.Mvc;
using Moq;
using SimpleApp.Controllers;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleApp.Tests
{

    public class HomeControllerTests
    {
        class FakeDataSource : IDataSource
        {
            public FakeDataSource(Product[] products)
            {
                Products = products;
            }
            public IEnumerable<Product> Products { get; set; }
        }

        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Arrange
            var controller = new HomeController();
            //Product[] products = new Product[]  {
            //    new Product { Name = "XBoxSeriesX", Price = 499M },
            //    new Product { Name = "XBoxSeriesS", Price = 299M}
            //};
            Product[] testData = new Product[] {
                new Product { Name = "P1", Price = 75.10M },
                new Product { Name = "P2", Price = 120M },
                new Product { Name = "P3", Price = 110M }
            };
            IDataSource data = new FakeDataSource(testData);
            controller.dataSource = data;
            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;
            // Assert
            Assert.Equal(data.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price));
        }

        [Fact]
        public void IndexActionModelIsCompleteUseMock()
        {
            Product[] testData = new Product[]
            {
                new Product { Name = "P1", Price = 75.10M },
                new Product { Name = "P2", Price = 120M },
                new Product { Name = "P3", Price = 110M }
            };
            var mock = new Mock<IDataSource>();
            var controller = new HomeController();
            mock.SetupGet(e => e.Products).Returns(testData);
            controller.dataSource = mock.Object;

            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //Assert
            Assert.Equal(testData, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
