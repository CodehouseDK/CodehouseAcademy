using System;
using DataAccess;
using Domain;

namespace Logic.CustomerServices
{
    public interface ICustomerService
    {
        Customer GetCurrentCustomer();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ISuperCustomerSignOn _superCustomerSignOn;
        

        public CustomerService(ISuperCustomerSignOn superCustomerSignOn)
        {
            _superCustomerSignOn = superCustomerSignOn;
        }

        public Customer GetCurrentCustomer()
        {
            var customerDto = _superCustomerSignOn.GetSignedOnCustomer(true);
            if (customerDto == null)
            {
                return new Customer(Guid.NewGuid(), new Percent(0));
            }
            var percent = new Percent(customerDto.Discount);
            var customer = new Customer(customerDto.Id, percent);

            return customer;
        }
    }
}
