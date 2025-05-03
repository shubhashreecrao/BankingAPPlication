using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Services;
using WebApplication1.Models;
using WebApplication1.DTOs;

namespace WebApplication1.Tests
{
    public class BalanceControllerTests
    {
        [Fact]
        public void GetBalance_ReturnsOk_WhenCustomerExists()
        {
            // Arrange
            var mockService = new Mock<CustomerService>();
            var customer = new Customer
            {
                Name = "Alice",
                AccountNumber = "123456",
                Balance = 5000
            };
            mockService.Setup(s => s.GetCustomer("123456")).Returns(customer);

            var controller = new BalanceController(mockService.Object);

            // Act
            var result = controller.GetBalance("123456");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<CustomerDTO>(okResult.Value);
            Assert.Equal("Alice", dto.Name);
            Assert.Equal("123456", dto.AccountNumber);
            Assert.Equal(5000, dto.Balance);
        }

        [Fact]
        public void GetBalance_ReturnsNotFound_WhenCustomerDoesNotExist()
        {
            // Arrange
            var mockService = new Mock<CustomerService>();
            mockService.Setup(s => s.GetCustomer("999")).Returns((Customer)null);

            var controller = new BalanceController(mockService.Object);

            // Act
            var result = controller.GetBalance("999");

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Customer not found", notFoundResult.Value);
        }
    }
}