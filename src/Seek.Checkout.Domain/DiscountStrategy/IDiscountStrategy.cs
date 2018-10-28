using Seek.Ads.Checkout.Domain.PricingRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain.DiscountStrategy
{
    public interface IDiscountStrategy
    {
        List<IPricingRule> GetPricingRules();
    }
}
