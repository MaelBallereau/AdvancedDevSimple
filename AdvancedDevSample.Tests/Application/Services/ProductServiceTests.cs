using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Application.Services;
using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Pricing;
using AdvancedDevSample.Tests.Application.Fakes;

namespace AdvancedDevSample.Tests.Application.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void ChangeProductPrice_Should_Save_Product_When_Price_Is_Valid()
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(10);// état initial valide

            var repo = new FakeProductRepository(product);
            var service = new ProductService(repo);

            // Act
            var request = new ChangePriceRequest { NewPrice = 20 };
            service.ChangeProductPrice(product.Id, request);

            // Assert
            Assert.Equal(20, product.Price);
            Assert.True(repo.WasSaved);
        }

        [Theory]
        [InlineData(20)]
        [InlineData(5)]
        public void ChangeProductPrice_Should_Save_Product_When_Price_Is_Valided(decimal newprice)
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(10);// état initial valide

            var repo = new FakeProductRepository(product);
            var service = new ProductService(repo);

            // Act
            var request = new ChangePriceRequest { NewPrice = newprice };
            service.ChangeProductPrice(product.Id, request);

            // Assert
            Assert.Equal(newprice, product.Price);
            Assert.True(repo.WasSaved);
        }


        [Theory]
        [InlineData("nouveau libelle")]
        [InlineData("test valide")]
        public void ChangeLibelle_Fake(string newlibelle)
        {
            var product = new Product();

            product.ChangeLibelle("testaa");

            var repo = new FakeProductRepository(product);

            var service = new ProductService(repo);

            var request = new ChangeLibelleRequest { NewLibelle = newlibelle };
            service.ChangeProductLibelle(product.Id, request);

            Assert.Equal(newlibelle, product.Libelle);
            Assert.True(repo.WasSaved);

        }


    }
}
