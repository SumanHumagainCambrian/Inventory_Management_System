using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management_System.Controllers;
using Inventory_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using NUnit.Framework;
using System.Collections.Generic; // For List and IEnumerable
using System.Linq; // For LINQ operations
using Microsoft.AspNetCore.Mvc; // For ActionResult

namespace InventoryMS.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private UserController _controller;
        private Mock<InventoryMSDbContext> _mockContext;
        private Mock<DbSet<User>> _mockSet;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<InventoryMSDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _mockContext = new Mock<InventoryMSDbContext>(options);
            _controller = new UserController(_mockContext.Object);
        }

        [Test]
        public async Task GetUsers_ReturnsAllUsers2()
        {
            // Arrange
            var users = new List<User>
            {
               new User { Id = 1, Username = "John", Password = "Aa12345", Role = "Admin" },
            new User { Id = 2, Username = "Suman", Password = "Aa12345", Role = "Customer" },
            };

            // Set up the mock DbSet to return the list of users using Task.FromResult
            _mockSet.Setup(m => m.ToListAsync(It.IsAny<CancellationToken>()))
                    .ReturnsAsync(users);

            _mockContext.Setup(c => c.Users).Returns(_mockSet.Object);

            // Act
            var result = await _controller.GetUsers();

            // Assert
            Assert.Equals(2, result.Count); // Check if the count of users is correct
        }

    }
}