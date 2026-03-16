using AdvancedDevSample.Api.Controllers;
using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Tests.API.Fakes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvancedDevSample.Tests.API.Contrat
{
    public class ProductControllerContractTests
    {

        [Fact]
        public void ChangePrice_Should_Return_NoContent_When_Request_Is_Valid()
        {
            // Arrange
            var service = new FakeProductService();
            var controller = new ProductsController(service);

            var productId = Guid.NewGuid();
            var request = new ChangePriceRequest { NewPrice = 20 };

            // Act
            var result = controller.ChangePrice(productId, request);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void ChangePrice_Should_Return_BadRequest_When_Domain_Exception_Is_Thrown()
        {
            // Arrange
            var service = new FakeProductService
            {
                ThrowDomainException = true
            };

            var controller = new ProductsController(service);

            var productId = Guid.NewGuid();
            var request = new ChangePriceRequest { NewPrice = -10 };

            // Act
            var result = controller.ChangePrice(productId, request);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequest.StatusCode);
        }
    }
}
