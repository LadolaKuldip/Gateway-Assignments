using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        string Register(Customer customer);
        int Login(string email, string password);

        IEnumerable<Customer> GetCustomers();
    }
}
