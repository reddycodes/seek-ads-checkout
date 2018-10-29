using Seek.Ads.Checkout.Domain.Ads;
using Seek.Ads.Checkout.Domain.PricingRules;
using System.Collections.Generic;

namespace Seek.Ads.Checkout.Domain.DiscountStrategy
{
    public class AxilCoffeeRoastersDiscountStrategy : IDiscountStrategy
    {
        public List<IPricingRule> GetPricingRules()
        {
            return new List<IPricingRule> { new DiscountPricingRule(typeof(StandoutAd), 23)};
        }
    }
}
