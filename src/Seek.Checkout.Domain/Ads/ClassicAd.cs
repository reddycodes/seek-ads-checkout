using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain.Ads
{
    public class ClassicAd : BaseAd
    {
        public override string GetDescription() => $"Offers the most basic level of advertisement";

        public override double GetPrice() => 269.99;

    }
}
