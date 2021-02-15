using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using SBS.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        public CustomerRepository() 
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }
        public bool Login(string email, string password)
        {
            Database.Customer customer = _dbContext.Customers.Where(user => user.EmailId.Equals(email) 
                                           && user.Password == password).FirstOrDefault();
            if (customer != null)
            {
                return true;
            }
            return false;
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
                    customer.Password = Convert.ToBase64String(Encrypt(customer.Password));

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

        private readonly string EncryptionKey = "ServiceBooking@123";

        private byte[] Encrypt(string password)
        {
            var key = GetKey(EncryptionKey);
            using(var aes = Aes.Create())
            using(var encryptor = aes.CreateEncryptor(key, key))
            {
                var plainText = Encoding.UTF8.GetBytes(password);
                return encryptor.TransformFinalBlock(plainText, 0, plainText.Length);
            }
        }

        private byte[] GetKey(string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            using(var md5 = MD5.Create())
            {
                return md5.ComputeHash(keyBytes);
            }
        }
    }
}
