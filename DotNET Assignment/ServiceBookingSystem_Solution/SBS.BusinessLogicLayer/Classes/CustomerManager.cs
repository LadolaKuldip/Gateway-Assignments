using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interfaces;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
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
        public bool Login(string email, string password)
        {
            return _customerRepository.Login(email, password);
        }

        public string Register(Customer customer)
        {
            return _customerRepository.Register(customer);
        }
    }
}
