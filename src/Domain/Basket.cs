using System.Collections.Generic;

namespace Domain
{
    public class Basket
    {
        public Basket(Customer owner)
        {
            Owner = owner;
            Products = new List<Product>();
        }

        public Customer Owner { get; private set; }


        public IList<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
        
    }
}