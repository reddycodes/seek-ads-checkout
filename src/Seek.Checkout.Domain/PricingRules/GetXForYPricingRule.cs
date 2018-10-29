using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seek.Ads.Checkout.Domain.Ads;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public class GetXForYPricingRule : IPricingRule
    {
        private readonly int getAmount;
        private readonly int forAmount;
        private readonly Type adType;

        public GetXForYPricingRule(int _getAmount, int _forAmount, Type _adType)
        {
            getAmount = _getAmount;
            forAmount = _forAmount;
            adType = _adType;
        }

        public decimal CalculateDiscount(List<BaseAd> items)
        {
            var totalDiscount = 0.0m;
            var matchingItems = items.Where(x => x.GetType() == adType);
            var totalMatchingItems = matchingItems.Count();

            if (totalMatchingItems > 0)
            {
                var totalDeals = totalMatchingItems / getAmount;

                var pricePerItem = matchingItems.FirstOrDefault().Price;

                var discountPerDeal = pricePerItem * (getAmount - forAmount);

                totalDiscount = totalDeals * discountPerDeal;
            }

            return totalDiscount;
        }
    }
}
