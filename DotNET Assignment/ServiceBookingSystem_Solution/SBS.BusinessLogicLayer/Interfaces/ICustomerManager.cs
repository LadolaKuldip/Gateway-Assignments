using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessLogicLayer.Interfaces
{
    public interface ICustomerManager
    {
        string Register(Customer customer);
        int Login(string email, string password);
        IEnumerable<Customer> GetCustomers();
    }
}
