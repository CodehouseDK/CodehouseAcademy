using Domain;

namespace Logic.Prices
{
    public interface IPaymentMethod
    {
        void HandlePayment(Payment payment);

        float Change();
    }
}