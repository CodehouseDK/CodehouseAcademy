using System;
using Domain;

namespace Logic.Prices
{
    public class CashPaymentService : IPaymentService
    {
        public Change Pay(Payment amountToPay, IPaymentMethod paymentMethod)
        {
            var cashPaymentMethod = (CashPaymentMethod)paymentMethod;
            cashPaymentMethod.HandlePayment(amountToPay);
            var change = cashPaymentMethod.Change();
            if (change < 0)
            {
                throw new InsufficientFundsException();
            }
            return new Change(change);
        }
    }

    public class InsufficientFundsException : Exception
    {
    }
}