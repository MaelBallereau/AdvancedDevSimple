using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Domain.Interfaces.Products
{
    public interface IProductRepository { Product? GetById(Guid id); void Save(Product product); }
}
