using ASC.Common;
using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface ICustomerManager
    {
        Customer GetUserId(string userId);
        CustomerVehicles GetCustomer(string input);
        IEnumerable<Customer> GetDealerCustomers(string userId);
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomer(int id);
        string CreateCustomer(Customer customer);
        string EditCustomer(Customer customer);
        string DeleteCustomer(int id);
    }
}
