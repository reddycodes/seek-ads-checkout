using Seek.Ads.Checkout.Domain.PricingRules;
using System.Collections.Generic;

namespace Seek.Ads.Checkout.Domain.DiscountStrategy
{
    public class DefaultDiscountStrategy : IDiscountStrategy
    {
        public List<IPricingRule> GetPricingRules()
        {
            return null;
        }
    }
}
