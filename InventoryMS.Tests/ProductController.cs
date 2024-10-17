//using Inventory_Management_System.Controllers;
//using Inventory_Management_System.Models;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace InventoryMS.Tests
//{
//    [TestFixture]
//    public class ProductControllerTests
//    {
//        private UserController _controller;
//        private Mock<InventoryMSDbContext> _mockContext;
//        private Mock<DbSet<Product>> _mockSet;
//        [SetUp]
//        public void Setup()
//        {
//            var options = new DbContextOptionsBuilder<InventoryMSDbContext>()
//                .UseInMemoryDatabase(databaseName: "TestDatabase")
//                .Options;

//            _mockContext = new Mock<InventoryMSDbContext>(options);
//            _controller = new UserController(_mockContext.Object);
//        }


//    }
//}

using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Inventory_Management_System.Controllers;
using Inventory_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Management_System.Tests
{
    [TestFixture]
    public class ProductControllerTests
    {
        private Mock<InventoryMSDbContext> _mockContext;
        private ProductController _controller;
        private Mock<DbSet<Product>> _mockProductSet;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<InventoryMSDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _mockContext = new Mock<InventoryMSDbContext>(options);
            _controller = new ProductController(_mockContext.Object);
        }

        [Test]
        public void GetProducts_ReturnsAllProducts()
        {
            // Act
            var result = _controller.GetProducts().Result as OkObjectResult;

            //// Assert
            //Assert. IsNotNull(result);
            var products = result.Value as List<Product>;
            //Assert.IsNotNull(products);
            Assert.Equals(2, products.Count);
        }

        [Test]
        public void GetProduct_ReturnsProductById()
        {
            // Act
            var result = _controller.GetProduct("P001").Result as OkObjectResult;

            // Assert
            var product = result.Value as Product;
            Assert.Equals("P001", product.ProductID);
        }


    }
}


