using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Tests.API.Integration
{
    public class ProductAsyncControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly InMemoryProductRepository _repo;

        public ProductAsyncControllerIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            _repo = (InMemoryProductRepository)factory.Services.GetRequiredService<IProductRepository>();
        }

        [Fact]
        public void ChangePrice_Should_Return_NoContent_And_Save_Product()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), 10, true,"");
            _repo.Seed(product);

            var request = new ChangePriceRequest { NewPrice = 20 };

            // Act
            using (var response = _client.PutAsJsonAsync($"/api/productasync/{product.Id}/price", request).Result)
            {

                // Assert – HTTP
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }

            // Assert – Persistance réelle
            var updated = _repo.GetById(product.Id);
            Assert.Equal(20, updated!.Price);
        }
    }

}
