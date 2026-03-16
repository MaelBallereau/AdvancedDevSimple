using AdvancedDevSample.Domain.Entities;
using AdvancedDevSample.Domain.Interfaces.Products;
using AdvancedDevSample.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Infrastructure.Repositories
{
    public class EfProductRepository : IProductRepository
    {
        public Product? GetById(Guid id)
        { // accès base de données
            //var entity = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            //if (entity == null)
            //    return null;
            ProductEntity product = new() { Id = id, Price = 10, IsActive = true };
            var domainProduct = new Product(id: product.Id, prix: product.Price, isActive: product.IsActive,libelle: "");

            return domainProduct;
        }
       
        public void Save(Product product)
        { // accès base de données
        }
    }
}
