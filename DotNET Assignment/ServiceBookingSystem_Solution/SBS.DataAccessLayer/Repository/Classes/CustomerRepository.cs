using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using SBS.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        public CustomerRepository() 
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }
        public int Login(string email, string password)
        {
            Database.Customer customer = _dbContext.Customers.Where(user => user.EmailId.Equals(email) 
                                           && user.Password == password).FirstOrDefault();
            if (customer != null)
            {
                return customer.Id;
            }
            return 0;
        }

        public string Register(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    var res = _dbContext.Customers.Where(x => x.EmailId.Equals(customer.EmailId)).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Customer entity = new Database.Customer();

                    entity = AutoMapperConfig.CustomerToDbCustomerMapper.Map<Database.Customer>(customer);

                    _dbContext.Customers.Add(entity);
                    _dbContext.SaveChanges();
                    return "created";
                }                
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customersReturn = new List<Customer>();
            IEnumerable<Database.Customer> customers = _dbContext.Customers.ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Database.Customer, Customer>();
            });
            config.AssertConfigurationIsValid();

            var mapper = config.CreateMapper();

            foreach (var customer in customers)
            {
                Customer entity = new Customer();
                entity = mapper.Map<Database.Customer, Customer>(customer);

                customersReturn.Add(entity);
            }

            return customersReturn;
        }


    }
}
