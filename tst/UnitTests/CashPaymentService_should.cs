using Domain;
using Logic.Prices;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CashPaymentService_should
    {
        [Test]
        public void handle_payment_by_cash_with_correct_amount_to_pay()
        {
            //// Arrange
            var sut = new CashPaymentService();
            var payment = new Payment(100);
            var paymentMetod = new CashPaymentMethod(100);

            //// Act

            var result = sut.Pay(payment, paymentMetod);

            //// Assert
            Assert.That(result.Amount, Is.EqualTo(0));
        }

        [Test]
        public void handle_payment_by_cash_with_to_much_amount_to_pay()
        {
            //// Arrange
            var sut = new CashPaymentService();
            var payment = new Payment(100);
            var paymentMetod = new CashPaymentMethod(150);

            //// Act

            var result = sut.Pay(payment, paymentMetod);

            //// Assert
            Assert.That(result.Amount, Is.EqualTo(50));
        }


        [Test]
        public void handle_payment_by_cash_with_to_small_amount_to_pay()
        {
            //// Arrange
            var sut = new CashPaymentService();
            var payment = new Payment(100);
            var paymentMetod = new CashPaymentMethod(50);

            //// Act

            

             //// Assert
             Assert.Throws<InsufficientFundsException>(() => sut.Pay(payment, paymentMetod));
        }
    }
}
