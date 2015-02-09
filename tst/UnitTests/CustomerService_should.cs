using System;
using DataAccess;
using DataAccess.Domain;
using Domain;
using Logic.CustomerServices;
using Moq;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CustomerService_should
    {
        [Test]
        public void return_a_valid_customer_when_not_customer_is_signedOn()
        {
            //// Arrange
            var mockCustomerSignOn = new Mock<ISuperCustomerSignOn>();
            CustomerDto nullCustomer = null;
            mockCustomerSignOn.Setup(mock => mock.GetSignedOnCustomer(It.IsAny<bool>())).Returns(nullCustomer);
            var sut = new CustomerService(mockCustomerSignOn.Object);

            //// Act
            var customer = sut.GetCurrentCustomer();

            //// Assert
            Assert.That(customer, Is.Not.Null);
        }

        [Test]
        public void return_valids_customer_when_a_customer_is_signed_on()
        {
            var mockCustomerSignOn = new Mock<ISuperCustomerSignOn>();
            mockCustomerSignOn.Setup(mock => mock.GetSignedOnCustomer(It.IsAny<bool>())).Returns(new CustomerDto(Guid.NewGuid(), 10));
            //// Arrange
            var sut = new CustomerService(mockCustomerSignOn.Object);

            //// Act
            var customer = sut.GetCurrentCustomer();

            //// Assert
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Discount.PercentInteger, Is.EqualTo(10));
        }
    }
}
