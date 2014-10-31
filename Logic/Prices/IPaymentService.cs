using Domain;

namespace Logic.Prices
{
    public interface IPaymentService
    {
        Change Pay(Payment amountToPay, IPaymentMethod paymentMethod);

        
    }
}
