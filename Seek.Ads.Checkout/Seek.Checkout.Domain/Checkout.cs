using Seek.Ads.Checkout.Domain.PricingRules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Seek.Ads.Checkout.Domain
{
    public class Checkout
    {
        private List<BaseAd> items;
        private readonly List<IPricingRule> pricingRules;

        public Checkout()
        {
            items = new List<BaseAd>();
        }

        public Checkout(List<IPricingRule> _pricingRules)
        {
            items = new List<BaseAd>();
            pricingRules = _pricingRules;

        }

        public List<BaseAd> Items
        {
            get
            {
                return items;
            }
        }

        public void Add(BaseAd ad)
        {
            items.Add(ad);
        }

        public double Total()
        {
            var total = items.Sum(x => x.GetPrice());

            var discount = 0.0;

            if (pricingRules != null)
            {
                foreach (var pricingRule in pricingRules)
                {
                    discount = discount + pricingRule.CalculateDiscount(items);

                }
            }

            return total - discount;
        }
    }
}
