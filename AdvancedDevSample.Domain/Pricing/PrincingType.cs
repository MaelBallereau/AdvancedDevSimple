using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDevSample.Domain.Pricing
{

    public enum PricingType
    {
        Standard,       // prix normal
        Discount,       // discount
        Vip,            // client VIP
        BlackFriday     // promotion exceptionnelle
    }
}
