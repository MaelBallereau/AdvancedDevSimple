using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Tests.API.Integration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdvancedDevSample.Tests.API.E2E
{
    public class ProductPriceEndToEndTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;
        private readonly InMemoryProductRepository _repo;

        public ProductPriceEndToEndTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
            _repo = (InMemoryProductRepository)
                factory.Services.GetRequiredService<IProductRepository>();
        }

        [Fact]
        public async Task User_Can_Change_Product_Price_EndToEnd()
        {
            // 🔹 GIVEN – un produit existe
            var product = new Product(Guid.NewGuid(),10,true,"");
            _repo.Seed(product);

            // 🔹 WHEN – l’utilisateur change le prix
            var changeRequest = new ChangePriceRequest { NewPrice = 20 };
            var updateResponse = await _client.PutAsJsonAsync(
                $"/api/productasync/{product.Id}/price",
                changeRequest
            );

            // 🔹 THEN – l’action réussit
            Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);

            // 🔹 AND – l’utilisateur récupère le produit
            var getResponse = await _client.GetAsync(
                $"/api/productasync/{product.Id}"
            );

            getResponse.EnsureSuccessStatusCode();

            var json = await getResponse.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<ProductResponse>(json);

            // 🔹 THEN – le prix visible est bien modifié
            Assert.Equal(20, dto!.Price);
        }
    }

}
