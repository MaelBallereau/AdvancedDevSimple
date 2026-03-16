using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;

namespace AdvancedDevSample.Tests.Application.Fakes
{
    /// <summary>
    /// Le fake remplace l’infrastructure pour tester le scénario
    /// </summary>
    public class FakeProductRepository : IProductRepository
    {
        public bool WasSaved { get; private set; }
        private readonly Product _product;

        public FakeProductRepository(Product product)
        {
            _product = product;
        }

        public Product GetById(Guid id) => _product;

        public void Save(Product product)
        {
            WasSaved = true;
        }
    }

}
