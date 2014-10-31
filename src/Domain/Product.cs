using System;

namespace Domain
{
    public class Product
    {
        public Product(string name, float price, Guid id, Percent discount)
        {
            Discount = discount;
            Id = id;
            Price = price;
            Name = name;
        }

        public float DiscountedPrice
        {
            get { return Price - (Price * Discount.ZeroBasedPrecent); }
        }

        public string Name { get;private  set; }
        public float Price { get; private set; }
        public Guid Id { get; private set; }
        public Percent Discount { get; private set; }


    }
}
