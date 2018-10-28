using System;
using System.Collections.Generic;
using System.Text;
using Seek.Ads.Checkout.Domain.Ads;
using Seek.Ads.Checkout.Domain.PricingRules;

namespace Seek.Ads.Checkout.Domain.DiscountStrategy
{
    public class MyerDiscountStrategy : IDiscountStrategy
    {
        public List<IPricingRule> GetPricingRules()
        {
            return new List<IPricingRule> { new GetXForYPricingRule(5, 4, typeof(StandoutAd)),
                new DiscountPricingRule(typeof(PremiumAd), 5)};

        }
    }
}
