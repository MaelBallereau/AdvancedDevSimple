using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;


namespace AdvancedDevSample.Tests.API.Integration
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly Dictionary<Guid, Product> _store = new();

        public Product? GetById(Guid id)
            => _store.TryGetValue(id, out var p) ? p : null;

        public void Save(Product product)
        {
            _store[product.Id] = product;
        }

        // Helper pour initialiser le test
        public void Seed(Product product)
            => _store[product.Id] = product;
    }
}
