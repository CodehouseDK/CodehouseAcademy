using Domain;

namespace Logic.Prices
{
    public class CardPaymentService : IPaymentService
    {
        public Change Pay(Payment amountToPay, IPaymentMethod paymentMethod)
        {
            var cardPaymentMethod = (CardPaymentMethod)paymentMethod;

            cardPaymentMethod.HandlePayment(amountToPay);

            return new Change(cardPaymentMethod.Change());
        }
    }
}