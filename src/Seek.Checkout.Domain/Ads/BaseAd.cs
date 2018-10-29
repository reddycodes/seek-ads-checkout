namespace Seek.Ads.Checkout.Domain
{
    public abstract class BaseAd
    {
        private readonly decimal price;
        private readonly string description;

        public decimal Price => price;

        public string Description => description;
        public BaseAd(string _desc, decimal _price)
        {
            description = _desc;
            price = _price;
        }
    }
}
