using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Seek.Ads.Checkout.Domain.Ads;

namespace Seek.Ads.Checkout.Domain.PricingRules
{
    public class GetXForYPricingRule : IPricingRule
    {
        private int getAmount;
        private int forAmount;
        private Type adType;

        public GetXForYPricingRule(int _getAmount, int _forAmount, Type _adType)
        {
            getAmount = _getAmount;
            forAmount = _forAmount;
            adType = _adType;
        }

        public double CalculateDiscount(List<BaseAd> items)
        {
            var totalDiscount = 0.0;
            var matchingItems = items.Where(x => x.GetType() == adType);
            var totalMatchingItems = matchingItems.Count();

            if (totalMatchingItems > 0)
            {
                var totalDeals = totalMatchingItems / getAmount;

                var pricePerItem = matchingItems.FirstOrDefault().GetPrice();

                var discountPerDeal = pricePerItem * (getAmount - forAmount);

                totalDiscount = totalDeals * discountPerDeal;
            }

            return totalDiscount;
        }
    }
}
