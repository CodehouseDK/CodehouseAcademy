using Autofac;
using Autofac.Core;
using DataAccess;
using Logic.CustomerServices;
using Logic.Prices;
using Logic.ScanningServices;

namespace GUI
{
    public class Bootstrapper
    {
        public static IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Scanner>().As<IScanner>();
            builder.RegisterType<SuperCustomerSignOn>().As<ISuperCustomerSignOn>();
            builder.RegisterType<ScannerService>().As<IScannerService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CalculatePriceService>().As<ICalculatePriceService>();
            builder.RegisterType<CardPaymentService>().Named<IPaymentService>("card");
            builder.RegisterType<CashPaymentService>().Named<IPaymentService>("cash");
            return builder.Build();
        }
    }
}
