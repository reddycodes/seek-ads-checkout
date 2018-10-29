using Seek.Ads.Checkout.Domain;
using Seek.Ads.Checkout.Domain.Ads;
using Seek.Checkout.Domain.Customer;
using Xunit;

namespace Seek.Ads.Checkout.Tests
{
    public class AxilCoffeeRoastersDiscountStrategyUnitTests
    {
        [Theory]
        [InlineData("Axil Coffee Roasters", 1294.96)]
        public void Verify_AxilCustomer_Total(string name, decimal expected)
        {
            var adFactory = new AdFactory();

            var discountStrategyFactory = new DiscountStrategyFactory();

            var item1 = adFactory.CreateAd(typeof(StandoutAd));

            var item2 = adFactory.CreateAd(typeof(StandoutAd));

            var item3 = adFactory.CreateAd(typeof(StandoutAd));

            var item4 = adFactory.CreateAd(typeof(PremiumAd));

            var customer = new Customer(name);

            var discountStrategy = discountStrategyFactory.GetDiscountStrategy(customer);

            var pricingRules = discountStrategy.GetPricingRules();

            var checkout = new Domain.Checkout(pricingRules);

            checkout.Add(item1);
            checkout.Add(item2);
            checkout.Add(item3);
            checkout.Add(item4);

            Assert.Equal(expected, checkout.Total());
        }
    }
}
