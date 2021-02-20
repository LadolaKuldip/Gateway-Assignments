using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interfaces;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using SBS.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessLogicLayer.Classes
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public int Login(string email, string password)
        {
            return _customerRepository.Login(email, password);
        }


        public string Register(Customer customer)
        {
            customer.Password = Convert.ToBase64String(PassowrdEncrypt.Encrypt(customer.Password));
            return _customerRepository.Register(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
    }
}
