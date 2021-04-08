using ASC.Common;
using ASC.Entities;
using System.Collections.Generic;

namespace ACS.DAL.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetUserId(string userId);
        CustomerVehicles GetCustomer(string input);
        IEnumerable<Customer> GetCustomers();
        IEnumerable<Customer> GetDealerCustomers(string userId);
        Customer GetCustomer(int id);
        string CreateCustomer(Customer customer);
        string EditCustomer(Customer customer);
        string DeleteCustomer(int id);
    }
}
