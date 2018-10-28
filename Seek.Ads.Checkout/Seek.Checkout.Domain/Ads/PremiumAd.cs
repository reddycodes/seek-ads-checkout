using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain.Ads
{
    public class PremiumAd : BaseAd
    {
        public override string GetDescription() => $"Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility";

        public override double GetPrice() => 394.99;
    }
}
