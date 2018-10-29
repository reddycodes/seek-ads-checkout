using Seek.Ads.Checkout.Domain.Ads;
using System;
using Xunit;
using Seek.Ads.Checkout.Domain.PricingRules;
using System.Collections.Generic;
using Seek.Ads.Checkout.Domain;

namespace Seek.Ads.Checkout.Tests
{
    public class CheckoutUnitTests
    {
        [Fact]
        public void Verify_Ads_Count()
        {
            var adFactory = new AdFactory();
            var checkout = new Domain.Checkout();

            var item1 = adFactory.CreateAd(typeof(ClassicAd));
            var item2 = adFactory.CreateAd(typeof(ClassicAd));

            checkout.Add(item1);
            checkout.Add(item2);

            var count = checkout.Items.Count;

            Assert.Equal(2, count);
        }

        [Fact]
        public void Verify_Ads_Description()
        {
            var adFactory = new AdFactory();
            var checkout = new Domain.Checkout();

            var item1 = adFactory.CreateAd(typeof(ClassicAd));
            var item2 = adFactory.CreateAd(typeof(StandoutAd));
            var item3 = adFactory.CreateAd(typeof(PremiumAd));

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);

            Assert.Equal("Offers the most basic level of advertisement", checkout.Items[0].Description);
            Assert.Equal("Allows advertisers to use a company logo and use a longer presentation text", checkout.Items[1].Description);
            Assert.Equal("Same benefits as Standout Ad, but also puts the advertisement at the top of the results, allowing higher visibility", checkout.Items[2].Description);
        }

        [Fact]
        public void Verify_NoPricingRules_OneTypeAds_TotalPrice()
        {
            var adFactory = new AdFactory();
            var checkout = new Domain.Checkout();

            var item1 = adFactory.CreateAd(typeof(ClassicAd));
            var item2 = adFactory.CreateAd(typeof(ClassicAd));

            checkout.Add(item1);
            checkout.Add(item2);

            var total = checkout.Total();

            Assert.Equal(539.98m, total);
        }

        [Fact]
        public void Verify_NoPricingRules_MultipleTypeAds_TotalPrice()
        {
            var adFactory = new AdFactory();
            var checkout = new Domain.Checkout();

            var item1 = adFactory.CreateAd(typeof(ClassicAd));
            var item2 = adFactory.CreateAd(typeof(StandoutAd));
            var item3 = adFactory.CreateAd(typeof(PremiumAd));

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);

            var total = checkout.Total();

            Assert.Equal(987.97m, total);
        }

        [Theory]
        [InlineData(3, 2, typeof(ClassicAd), 539.98)]
        public void Verify_SinglePricingRule_DealPricing_SingleDeal(int getAmount, int forAmount, Type adType, decimal expected)
        {
            var pricingRule = new GetXForYPricingRule(getAmount, forAmount, adType);

            var adFactory = new AdFactory();

            var checkout = new Domain.Checkout(new List<IPricingRule> { pricingRule });

            var item1 = adFactory.CreateAd(adType);
            var item2 = adFactory.CreateAd(adType);
            var item3 = adFactory.CreateAd(adType);

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);

            var total = checkout.Total();

            Assert.Equal(expected, total);
        }

        [Theory]
        [InlineData(3, 2, typeof(ClassicAd), 1079.96)]
        [InlineData(4, 2, typeof(ClassicAd), 1079.96)]
        [InlineData(4, 1, typeof(ClassicAd), 809.97)]
        [InlineData(4, 1, typeof(StandoutAd), 968.97)]
        public void Verify_SinglePricingRule_DealPricing_DoubleDeals(int getAmount, int forAmount, Type adType, decimal expected)
        {
            var pricingRule = new GetXForYPricingRule(getAmount, forAmount, adType);

            var adFactory = new AdFactory();

            var checkout = new Domain.Checkout(new List<IPricingRule> { pricingRule });

            var item1 = adFactory.CreateAd(adType);

            var item2 = adFactory.CreateAd(adType);

            var item3 = adFactory.CreateAd(adType);

            var item4 = adFactory.CreateAd(adType);

            var item5 = adFactory.CreateAd(adType);

            var item6 = adFactory.CreateAd(adType);

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);
            checkout.Add(item4);
            checkout.Add(item5);
            checkout.Add(item6);

            var total = checkout.Total();

            Assert.Equal(expected, total);
        }


        [Theory]
        [InlineData(typeof(StandoutAd), 23, 599.98)]
        [InlineData(typeof(PremiumAd), 5, 779.98)]
        public void Verify_SinglePricingRule_Discount(Type type, decimal discount, decimal expected)
        {
            var adFactory = new AdFactory();

            var pricingRule = new DiscountPricingRule(type, discount);

            var checkout = new Domain.Checkout(new List<IPricingRule> { pricingRule });

            var item1 = adFactory.CreateAd(type);

            var item2 = adFactory.CreateAd(type);

            checkout.Add(item1);
            checkout.Add(item2);

            var total = checkout.Total();

            Assert.Equal(expected, total);
        }

        [Fact]
        public void Verify_DoublePricingRule_Discount()
        {
            var adFactory = new AdFactory();

            var pricingRule1 = new DiscountPricingRule(typeof(StandoutAd), 22.99m);
            var pricingRule2 = new DiscountPricingRule(typeof(ClassicAd), 69.99m);

            var pricingRules = new List<IPricingRule>();
            pricingRules.Add(pricingRule1);
            pricingRules.Add(pricingRule2);

            var checkout = new Domain.Checkout(pricingRules);

            var item1 = adFactory.CreateAd(typeof(StandoutAd));

            var item2 = adFactory.CreateAd(typeof(ClassicAd));

            checkout.Add(item1);
            checkout.Add(item2);

            var total = checkout.Total();

            Assert.Equal(500, total);
        }

        [Fact]
        public void Verify_MixedPricingRules_Deal_and_Discount()
        {
            var adFactory = new AdFactory();

            var pricingRule1 = new DiscountPricingRule(typeof(StandoutAd), 22.99m);
            var pricingRule2 = new GetXForYPricingRule(3,2,typeof(ClassicAd));

            var pricingRules = new List<IPricingRule>();
            pricingRules.Add(pricingRule1);
            pricingRules.Add(pricingRule2);

            var checkout = new Domain.Checkout(pricingRules);

            var item1 = adFactory.CreateAd(typeof(StandoutAd));

            var item2 = adFactory.CreateAd(typeof(ClassicAd));

            var item3 = adFactory.CreateAd(typeof(ClassicAd));

            var item4 = adFactory.CreateAd(typeof(ClassicAd));

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);
            checkout.Add(item4);

            var total = checkout.Total();

            Assert.Equal(839.98m, total);
        }
    }
}
