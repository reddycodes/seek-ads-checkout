using System.Collections.Generic;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public interface IPricingRule
    {
        decimal CalculateDiscount(List<BaseAd> items);
    }
}
