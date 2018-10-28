using Seek.Ads.Checkout.Domain.PricingRules;
using System;
using System.Collections.Generic;

namespace Seek.Checkout.Domain.Customer
{
    public class Customer
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }        
    }
}