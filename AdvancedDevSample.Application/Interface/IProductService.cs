using AdvancedDevSample.Application.DTOs;
using AdvancedDevSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.Interface
{
    public interface IProductService
    {
        void ChangePrice(Guid id, decimal newPrice);
        ProductResponse GetById(Guid productId);
    }

}
