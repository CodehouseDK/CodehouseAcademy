using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Logic.Prices;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CardPaymentService_should
    {
        [Test]
        public void handle_payment_by_cash_with_correct_amount_to_pay()
        {
            //// Arrange
            var sut = new CardPaymentService();
            var payment = new Payment(100);
            var card = new Card(100);
            var paymentMetod = new CardPaymentMethod(card);

            //// Act

            var result = sut.Pay(payment, paymentMetod);

            //// Assert
            Assert.That(result.Amount, Is.EqualTo(0));
        }

        [Test]
        public void handle_payment_by_cash_with_to_much_amount_to_pay()
        {
            //// Arrange
            var sut = new CardPaymentService();
            var payment = new Payment(100);
            var card = new Card(100);
            var paymentMetod = new CardPaymentMethod(card);
            //// Act

            var result = sut.Pay(payment, paymentMetod);

            //// Assert
            Assert.That(result.Amount, Is.EqualTo(0));
        }


        [Test]
        public void handle_payment_by_cash_with_to_small_amount_to_pay()
        {
            //// Arrange
            var sut = new CardPaymentService();
            var payment = new Payment(100);
            var card = new Card(50);
            var paymentMetod = new CardPaymentMethod(card);
            //// Act



            //// Assert
            Assert.Throws<Exception>(() => sut.Pay(payment, paymentMetod));
        }
    }
}
