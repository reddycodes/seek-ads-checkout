using Seek.Ads.Checkout.Domain;
using Seek.Ads.Checkout.Domain.Ads;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain
{
    public class AdFactory
    {
        public BaseAd CreateAd(Type adType)
        {
            if(adType == typeof(PremiumAd))
            {
                return new PremiumAd();
            }
            else if(adType == typeof(StandoutAd))
            {
                return new StandoutAd();
            }
            else
            {
                return new ClassicAd();
            }
            
        }
    }
}
