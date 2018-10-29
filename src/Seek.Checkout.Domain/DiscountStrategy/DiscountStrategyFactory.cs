using Seek.Ads.Checkout.Domain.DiscountStrategy;
using Seek.Checkout.Domain.Customer;

namespace Seek.Ads.Checkout.Domain
{
    public class DiscountStrategyFactory
    {
        public  IDiscountStrategy GetDiscountStrategy(Customer customer)
        {
            switch(customer.Name.ToLower())
            {
                case Utils.Constants.Customers.Myer:
                    return new MyerDiscountStrategy();
                case Utils.Constants.Customers.SecondBite:
                    return new SecondBiteDiscountStrategy();
                case Utils.Constants.Customers.AxilCoffeeRoasters:
                    return new AxilCoffeeRoastersDiscountStrategy();
                default:
                    return new DefaultDiscountStrategy();
            }
        }
    }
}
