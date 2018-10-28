using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain.Ads
{
    public class StandoutAd : BaseAd
    {
        public override string GetDescription() => $"Allows advertisers to use a company logo and use a longer  presentation text";

        public override double GetPrice() => 322.99;
    }
}
