namespace Seek.Checkout.Domain.Customer
{
    public class Customer
    {
        public string Name { get; }

        public Customer(string name)
        {
            Name = name;
        }        
    }
}