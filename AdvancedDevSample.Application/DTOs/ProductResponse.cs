using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.DTOs
{
    public class ProductResponse
    {
        public Guid Id { get; init; }
        public decimal Price { get; init; }
    }
}
