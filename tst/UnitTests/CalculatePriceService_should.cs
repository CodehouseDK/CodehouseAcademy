using System;
using Domain;
using Logic.Prices;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CalculatePriceService_should
    {
        [Test]
        public void calulate_price_from_basket_without_discounts()
        {
            //// Arrange
            var sut = new CalculatePriceService();
            var discount = new Percent(0);
            var customer = new Customer(Guid.NewGuid(), discount);
            var basket = new Basket(customer);
            var product = new Product("test", 100, Guid.NewGuid(), discount);
            basket.AddProduct(product);
            
            //// Act
            var result = sut.Calculate(basket);


            //// Assert
            Assert.That(result.TotalPrice,Is.EqualTo(100));
        }

        [Test]
        public void calulate_price_from_basket_with_customer_discounts()
        {
            //// Arrange
            var sut = new CalculatePriceService();
            var customerDiscount = new Percent(2);
            var customer = new Customer(Guid.NewGuid(), customerDiscount);
            var basket = new Basket(customer);
            var productDiscount = new Percent(0);
            var product = new Product("test", 100, Guid.NewGuid(), productDiscount);
            basket.AddProduct(product);

            //// Act
            var result = sut.Calculate(basket);


            //// Assert
            Assert.That(result.TotalPrice, Is.EqualTo(98));
        }

        [Test]
        public void calulate_price_from_basket_with_product_discounts()
        {
            //// Arrange
            var sut = new CalculatePriceService();
            var customerDiscount = new Percent(0);
            var customer = new Customer(Guid.NewGuid(), customerDiscount);
            var basket = new Basket(customer);
            var productDiscount = new Percent(2);
            var product = new Product("test", 100, Guid.NewGuid(), productDiscount);
            basket.AddProduct(product);

            //// Act
            var result = sut.Calculate(basket);


            //// Assert
            Assert.That(result.TotalPrice, Is.EqualTo(98));
        }


        [Test]
        public void calulate_price_from_basket_with_multiple_products_with_customer_with_discount()
        {
            //// Arrange
            var sut = new CalculatePriceService();
            var customerDiscount = new Percent(2);
            var customer = new Customer(Guid.NewGuid(), customerDiscount);
            var basket = new Basket(customer);
            var productDiscount = new Percent(0);
            var product1 = new Product("test1", 50, Guid.NewGuid(), productDiscount);
            var product2 = new Product("test2", 50, Guid.NewGuid(), productDiscount);
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            //// Act
            var result = sut.Calculate(basket);


            //// Assert
            Assert.That(result.TotalPrice, Is.EqualTo(98));
        }

        [Test]
        public void calulate_price_from_basket_with_multiple_products_with_discount()
        {
            //// Arrange
            var sut = new CalculatePriceService();
            var customerDiscount = new Percent(0);
            var customer = new Customer(Guid.NewGuid(), customerDiscount);
            var basket = new Basket(customer);
            var productDiscount1 = new Percent(0);
            var productDiscount2 = new Percent(2);
            var product1 = new Product("test1", 100, Guid.NewGuid(), productDiscount1);
            var product2 = new Product("test2",100, Guid.NewGuid(), productDiscount2);
            basket.AddProduct(product1);
            basket.AddProduct(product2);
            //// Act
            var result = sut.Calculate(basket);


            //// Assert
            Assert.That(result.TotalPrice, Is.EqualTo(198));
        }

    }
}
