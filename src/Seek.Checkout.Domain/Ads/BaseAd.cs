using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain
{
    public abstract class BaseAd
    {
        public abstract string GetDescription();
        public abstract double GetPrice();
    }
}
