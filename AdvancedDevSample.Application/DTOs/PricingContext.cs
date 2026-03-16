using AdvancedDevSample.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Application.DTOs
{
    public class PricingContext
    {
        public PricingType priceType { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
