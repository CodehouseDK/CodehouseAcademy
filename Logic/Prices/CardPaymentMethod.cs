using Domain;

namespace Logic.Prices
{
    public class CardPaymentMethod : IPaymentMethod
    {
        private readonly Card _card;

        public CardPaymentMethod(Card card)
        {
            _card = card;
        }

        public void HandlePayment(Payment payment)
        {
            _card.Substract(payment.TotalPrice);
        }

        public float Change()
        {
            return 0;
        }
    }
}