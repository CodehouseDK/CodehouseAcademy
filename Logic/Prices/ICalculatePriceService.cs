using System.Linq;
using Domain;

namespace Logic.Prices
{
    public interface ICalculatePriceService
    {
        Payment Calculate(Basket basket);
    }

    public class CalculatePriceService : ICalculatePriceService
    {
        public Payment Calculate(Basket basket)
        {
            var buyer = basket.Owner;
            var totalPrice = CalculateTotalPrice(basket);
            var totalPriceWithCustomerDiscount = CalculateTotalPriceWithCustomerDiscount(buyer.Discount, totalPrice);
            return new Payment(totalPriceWithCustomerDiscount);
        }

        private static float CalculateTotalPriceWithCustomerDiscount(Percent discount, float totalPrice)
        {
            var totalPriceWithCustomerDiscount = totalPrice - (totalPrice * discount.ZeroBasedPrecent);
            return totalPriceWithCustomerDiscount;
        }

        private static float CalculateTotalPrice(Basket basket)
        {
            var totalPrice = basket.Products.Sum(product => product.DiscountedPrice);
            return totalPrice;
        }
    }
}
