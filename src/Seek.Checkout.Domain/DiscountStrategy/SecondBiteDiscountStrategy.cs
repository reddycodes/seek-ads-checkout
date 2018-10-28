using System;
using System.Collections.Generic;
using System.Text;
using Seek.Ads.Checkout.Domain.Ads;
using Seek.Ads.Checkout.Domain.PricingRules;

namespace Seek.Ads.Checkout.Domain.DiscountStrategy
{
    public class SecondBiteDiscountStrategy : IDiscountStrategy
    {
        public List<IPricingRule> GetPricingRules()
        {
            return new List<IPricingRule> { new GetXForYPricingRule(3, 2, typeof(ClassicAd)) };   
        }
    }
}
