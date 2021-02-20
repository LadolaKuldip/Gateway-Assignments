    using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class SupportRepository : ISupportRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;  

        public SupportRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }
        public IEnumerable<Dealer> GetDealers()
        {
            List<Dealer> dealers = new List<Dealer>();
            IEnumerable<Database.Dealer> entities = _dbContext.Dealers.ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Dealer dealer = new Dealer();
                    dealer = AutoMapperConfig.DbDealerToDealerMapper.Map<Dealer>(item);
                    dealers.Add(dealer);
                }
            }

            return dealers;
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            IEnumerable<Database.Manufacturer> entities = _dbContext.Manufacturers.ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Manufacturer manufacturer = new Manufacturer();
                    manufacturer = AutoMapperConfig.DbManufacturerToManufacturerMapper.Map<Manufacturer>(item);
                    manufacturers.Add(manufacturer);
                }
            }

            return manufacturers;
        }

        public IEnumerable<Service> GetServices()
        {
            List<Service> services = new List<Service>();
            IEnumerable<Database.Service> entities = _dbContext.Services.ToList();

            foreach (var service in entities)
            {
                Service entity = new Service();
                entity = AutoMapperConfig.DbServiceToService.Map<Service>(service);

                services.Add(entity);
            }

            return services;
        }

        public Mechanic GetMechanics(string Make)
        {
            Database.Mechanic entity = _dbContext.Mechanics.Include("Manufacturer").FirstOrDefault(x => x.Manufacturer.Name == Make);
            Mechanic mechanic = new Mechanic();
            mechanic.Id = entity.Id;
            mechanic.Name = entity.Name;
            mechanic.MobileNumber = entity.MobileNumber;
            mechanic.EmailId = entity.EmailId;
            return mechanic;
        }
    }
}
