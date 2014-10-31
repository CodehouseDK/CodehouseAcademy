using System;

namespace DataAccess.Domain
{
    public class CustomerDto : IEntity
    {
        public CustomerDto(Guid id, int discount)
        {
            Discount = discount;
            Id = id;
        }

        public Guid Id { get; private set; }
        public int Discount { get; private set; }
    }
}
