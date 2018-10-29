using Seek.Ads.Checkout.Domain.PricingRules;
using System.Collections.Generic;
using System.Linq;

namespace Seek.Ads.Checkout.Domain
{
    public class Checkout
    {
        private readonly List<BaseAd> items;
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

        public decimal Total()
        {
            var total = items.Sum(x => x.Price);

            var discount = 0.0m;

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
