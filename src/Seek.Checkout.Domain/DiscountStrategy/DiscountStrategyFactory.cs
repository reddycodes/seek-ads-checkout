using Seek.Ads.Checkout.Domain.DiscountStrategy;
using Seek.Ads.Checkout.Domain.PricingRules;
using Seek.Checkout.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seek.Ads.Checkout.Domain
{
    public class DiscountStrategyFactory
    {
        public  IDiscountStrategy GetDiscountStrategy(Customer customer)
        {
            switch(customer.Name.ToLower())
            {
                case "myer":
                    return new MyerDiscountStrategy();
                case "secondbite":
                    return new SecondBiteDiscountStrategy();
                case "axil coffee roasters":
                    return new AxilCoffeeRoastersDiscountStrategy();
                default:
                    return new DefaultDiscountStrategy();
            }
        }
    }
}
