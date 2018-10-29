using System;
using System.Collections.Generic;
using System.Linq;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public class DiscountPricingRule : IPricingRule
    {
        private readonly decimal discountAmount;
        private readonly Type adType;

        public DiscountPricingRule(Type _adType, decimal _discountAmount)
        {
            discountAmount = _discountAmount;
            adType = _adType;
        }

        public decimal CalculateDiscount(List<BaseAd> items)
        {
            var totalDiscount = 0.0m;
            var matchingItems = items.Where(x => x.GetType() == adType);

            var totalMatchingItems = matchingItems.Count();

            if (totalMatchingItems > 0)
            {
                totalDiscount = discountAmount * totalMatchingItems;
            }

            return totalDiscount;
        }
    }
}
