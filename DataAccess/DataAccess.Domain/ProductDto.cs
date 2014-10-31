using System;

namespace DataAccess.Domain
{
    public class ProductDto : IEntity
    {
        public ProductDto(Guid id, float price, float percent, string name)
        {
            Name = name;
            Percent = percent;
            Price = price;
            Id = id;
        }

        public float Price { get; private set; }
        public float Percent { get; private set; }
        public string Name { get; private set; }
        public Guid Id { get; private set; }
    }
}
