using System;
using System.Linq;
using System.Security.AccessControl;
using DataAccess.Domain;

namespace DataAccess
{
    public interface ISuperCustomerSignOn
    {
        CustomerDto GetSignedOnCustomer(bool isSignon);
    }

    public class SuperCustomerSignOn : ISuperCustomerSignOn
    {
        private readonly Database _db;

        public SuperCustomerSignOn()
        {
            _db = DataAccess.Database.Instance;
        }
        public CustomerDto GetSignedOnCustomer(bool isSignOn)
        {
            if (!isSignOn)
            {
                return null;
            }
            var allCustomers = _db.ReadAll<CustomerDto>().ToList();
            var random = new Random();
            var next = random.Next(allCustomers.Count());

            return allCustomers[next];
        }
    }
}
