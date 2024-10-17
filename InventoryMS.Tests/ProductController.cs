using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.Tests
{
    [TestClass]
    public class ProductModelTests
    {
        [TestMethod]
        public void Product_WithValidProperties_IsValid()
        {
            // Arrange
            var product = new Product
            {
                ProductID = "Product1",
                Name = "Test Product",
                Description = "This is a product 1.",
                Price = 99.99f,
                Quantity = 10
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.IsFalse(validationResults.Any(), "Product should be valid but failed validation.");
        }

        [TestMethod]
        public void Product_WithoutName_FailsValidation()
        {
            // Arrange
            var product = new Product
            {
                ProductID = "Product1",
                Description = "This is a product 1.",
                Price = 99.99f,
                Quantity = 10
            };

            // Act
            var validationResults = ValidateModel(product);

            // Assert
            Assert.IsTrue(validationResults.Any(vr => vr.MemberNames.Contains("Name")), "Product should fail due to missing Name.");
        }

        private IEnumerable<ValidationResult> ValidateModel(Product product)
        {
            var context = new ValidationContext(product, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(product, context, validationResults, validateAllProperties: true);
            return validationResults;
        }
    }
}
