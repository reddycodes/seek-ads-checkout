using Seek.Ads.Checkout.Domain;
using Seek.Ads.Checkout.Domain.Ads;
using Seek.Checkout.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Seek.Ads.Checkout.Tests
{
    public class MyerDiscountStrategyUnitTests
    {
        [Fact]
        public void MyerCustomer_CheckTotal()
        {

            var adFactory = new AdFactory();

            var discountStrategyFactory = new DiscountStrategyFactory();

            var item1 = adFactory.CreateAd(typeof(ClassicAd));

            var item2 = adFactory.CreateAd(typeof(StandoutAd));

            var item3 = adFactory.CreateAd(typeof(PremiumAd));

            var item4 = adFactory.CreateAd(typeof(StandoutAd));

            var item5 = adFactory.CreateAd(typeof(StandoutAd));

            var item6 = adFactory.CreateAd(typeof(StandoutAd));

            var item7 = adFactory.CreateAd(typeof(StandoutAd));

            var customer = new Customer("Myer");

            var discountStrategy = discountStrategyFactory.GetDiscountStrategy(customer);

            var pricingRules = discountStrategy.GetPricingRules();

            var checkout = new Domain.Checkout(pricingRules);

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);
            checkout.Add(item4);
            checkout.Add(item5);
            checkout.Add(item6);
            checkout.Add(item7);

            var total = checkout.Total();

            Assert.Equal(1951.94, Math.Round(total,2));

        }
    }
}
