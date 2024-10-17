using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Inventory_Management_System.Models;

namespace Inventory_Management_System.Tests
{
    [TestClass]
    public class UserModelTests
    {
        [TestMethod]
        public void User_WithValidProperties_IsValid()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Username = "testuser",
                Password = "password123",
                Role = "Admin"
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.IsFalse(validationResults.Any(), "User should be valid but failed validation.");
        }

        [TestMethod]
        public void UserModel_MissingPassword_FailsValidation()
        {
            // Arrange
            var user = new User
            {
                Id = 2,
                Username = "testuser",
                Role = "Admin"
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Password field is required.", validationResults[0].ErrorMessage);
        }

        [TestMethod]
        public void UserModel_MissingRole_FailsValidation()
        {
            // Arrange
            var user = new User
            {
                Id = 3,
                Username = "testuser",
                Password = "password123"
            };

            // Act
            var validationResults = ValidateModel(user);

            // Assert
            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("The Role field is required.", validationResults[0].ErrorMessage);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}
