using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public class DiscountPricingRule : IPricingRule
    {
        private double discountAmount;
        private Type adType;

        public DiscountPricingRule(Type _adType, double _discountAmount)
        {
            discountAmount = _discountAmount;
            adType = _adType;
        }

        public double CalculateDiscount(List<BaseAd> items)
        {
            var totalDiscount = 0.0;
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
