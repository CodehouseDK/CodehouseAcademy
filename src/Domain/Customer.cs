using System;

namespace Domain
{
    public class Customer
    {
        public Customer(Guid id, Percent discount)
        {
            Discount = discount;
            Id = id;
        }

        public Guid Id { get; private set; }
        public Percent Discount { get; private set; }

    }
}
