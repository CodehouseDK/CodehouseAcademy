using Domain;

namespace Logic.Prices
{
    public class CashPaymentMethod : IPaymentMethod
    {
        private readonly float _cash;
        private float _changes;

        public CashPaymentMethod(float cash)
        {
            _cash = cash;
        }

        public void HandlePayment(Payment payment)
        {
            _changes = _cash - payment.TotalPrice;
        }

        public float Change()
        {
            return _changes;
        }
    }
}