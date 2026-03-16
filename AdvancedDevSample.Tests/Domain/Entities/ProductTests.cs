using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Exceptions;

namespace AdvancedDevSample.Tests.Domain.Entities
{
    public class ProductTests
    {
        [Fact]
        public void ChangePrice_Should_Update_Price_When_Product_Is_Active()
        {
            // Arrange : Je prépare un produit valide
            var product = new Product();
            product.ChangePrice(10);//valeur initiale

            // Act : exécute une action
            product.ChangePrice(20);

            // Assert : vérification
            Assert.Equal(20, product.Price);
        }

        [Fact]
        public void ChangePrice_Should_Throw_Exception_When_Product_Is_Inactive()
        {
            // Arrange : Je prépare un produit valide
            var product = new Product();
            product.ChangePrice(10);//valeur initiale

            // Simulation : produit désactivé (via reconstitution ou méthode dédiée)
            //product.IsActive=true;//Accesseur non accessible
            typeof(Product).GetProperty(nameof(Product.IsActive))!.SetValue(product, false);

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => product.ChangePrice(20));

            Assert.Equal("Impossible de modifier un produit inactif.", exception.Message);
        }

        [Fact]
        public void ApplyDiscount_Should_Decrease_Price()
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(100);//valeur initiale

            // Act
            product.ApplyDiscount(30);

            // Assert
            Assert.Equal(70, product.Price);
        }

        [Fact]
        public void ApplyDiscount_Should_Throw_When_Resulting_Price_Is_Invalid()
        {
            // Arrange
            var product = new Product();
            product.ChangePrice(20);//valeur initiale

            // Act & Assert
            Assert.Throws<DomainException>(() => product.ApplyDiscount(30));
        }
        [Fact]
        public void ChangeLibelle_Should_Throw_When_Inferior_Or_Equal_To_Five_Characters()
        {
            var product = new Product();
            Assert.Throws<DomainException>(() => product.ChangeLibelle("aba"));
        }
        [Fact]
        public void ChangeLibelle_Should_Throw_When_Empty_Or_Null()
        {
            var product = new Product();
            Assert.Throws<DomainException>(() => product.ChangeLibelle(null));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("tes")]
        [InlineData("")]
        public void ChangeLibelle_Invalid(string libelle)
        {
            var product = new Product();
            Assert.Throws<DomainException>(() => product.ChangeLibelle(libelle));
        }


    }
}