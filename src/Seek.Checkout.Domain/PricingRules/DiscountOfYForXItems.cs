using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public class DiscountOfYForXItems : IPricingRule
    {
        private readonly decimal discountAmount;
        private readonly Type adType;
        private readonly int noOfAds;

        public DiscountOfYForXItems(Type _adType, decimal _discountAmount, int _noOfAds)
        {
            discountAmount = _discountAmount;
            adType = _adType;
            noOfAds = _noOfAds;
        }
        public decimal CalculateDiscount(List<BaseAd> items)
        {
            var totalDiscount = 0.0m;
            var matchingItems = items.Where(x => x.GetType() == adType);

            var totalMatchingItems = matchingItems.Count();

            if (totalMatchingItems >= noOfAds)
            {
                totalDiscount = discountAmount * totalMatchingItems;
            }

            return totalDiscount;
        }
    }
}
