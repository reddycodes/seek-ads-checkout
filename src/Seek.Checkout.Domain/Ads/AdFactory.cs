using Seek.Ads.Checkout.Domain.Ads;
using System;

namespace Seek.Ads.Checkout.Domain
{
    public class AdFactory
    {
        public BaseAd CreateAd(Type adType)
        {
            if(adType == typeof(PremiumAd))
            {
                return new PremiumAd("Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility", 394.99m);
            }
            else if(adType == typeof(StandoutAd))
            {
                return new StandoutAd("Allows advertisers to use a company logo and use a longer presentation text", 322.99m);
            }
            else
            {
                return new ClassicAd("Offers the most basic level of advertisement", 269.99m);
            }
            
        }
    }
}
