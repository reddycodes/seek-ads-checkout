using System;
using System.Collections.Generic;
using System.Text;
using Seek.Ads.Checkout.Domain.PricingRules;

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
