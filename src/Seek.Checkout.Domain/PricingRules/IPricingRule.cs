using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public interface IPricingRule
    {
        double CalculateDiscount(List<BaseAd> items);
    }
}
