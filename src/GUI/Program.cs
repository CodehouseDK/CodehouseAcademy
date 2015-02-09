using System;
using Autofac;
using Domain;
using Logic.CustomerServices;
using Logic.Prices;
using Logic.ScanningServices;

namespace GUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Write("please add details");
                return;
            }
            var payBy = args[0];
            var productsToBuy = int.Parse(args[1]);

            var container = Bootstrapper.Register();
            using (var scope = container.BeginLifetimeScope())
            {
                var customerService = scope.Resolve<ICustomerService>();
                var scanner = scope.Resolve<IScannerService>();
                var calculator = scope.Resolve<ICalculatePriceService>();
                var cardPaymentServices = scope.ResolveNamed<IPaymentService>("card");
                var cashPaymentServices = scope.ResolveNamed<IPaymentService>("cash");

                var customer = customerService.GetCurrentCustomer();

                var basket = new Basket(customer);
                for (int i = 0; i < productsToBuy; i++)
                {
                    var product = scanner.Scan();
                    Console.WriteLine("Buying : {0} for {1}", product.Name, product.DiscountedPrice);
                    basket.AddProduct(product);

                }
               
                var payment = calculator.Calculate(basket);
                if (payBy == "card")
                {
                    var card = new Card(10000);
                    var paymentMethod = new CardPaymentMethod(card);
                    var cardResult = cardPaymentServices.Pay(payment, paymentMethod);
                    Console.WriteLine(cardResult.Amount);
                    return;
                }

                var cashPAymentMethod = new CashPaymentMethod(1000);
                var cashResult = cashPaymentServices.Pay(payment, cashPAymentMethod);
                Console.WriteLine(cashResult.Amount);
            }
        }
    }
}