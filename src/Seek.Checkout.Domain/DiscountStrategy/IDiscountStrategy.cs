using Seek.Ads.Checkout.Domain.PricingRules;
using System.Collections.Generic;

namespace Seek.Ads.Checkout.Domain.DiscountStrategy
{
    public interface IDiscountStrategy
    {
        List<IPricingRule> GetPricingRules();
    }
}
