using SBS.BusinessEntities;
using SBS.DataAccessLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Classes
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.ServiceBookingSystemEntities _dbContext;

        public VehicleRepository()
        {
            _dbContext = new Database.ServiceBookingSystemEntities();
        }
        public string Create(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    var res = _dbContext.Vehicles.Where(x => x.LicensePlate == vehicle.LicensePlate).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Vehicle entity = new Database.Vehicle();
                    entity = AutoMapperConfig.VehicleToDbVehicleMapper.Map<Database.Vehicle>(vehicle);

                    _dbContext.Vehicles.Add(entity);
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

        public string Delete(int id)
        {
            try
            {
                Database.Vehicle entity = new Database.Vehicle();
                entity = _dbContext.Vehicles.Find(id);
                if (entity != null)
                {
                    _dbContext.Vehicles.Remove(entity);
                    _dbContext.SaveChanges();
                    return "deleted";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _dbContext.Vehicles.ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.DbVehicleToVehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }
            
            return vehicles;
        }

        public IEnumerable<Vehicle> GetVehicles(int customerId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _dbContext.Vehicles.Where(x => x.CustomerId == customerId).ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.DbVehicleToVehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }

        public string Update(Vehicle vehicle)
        {
            try
            {
                var entity = _dbContext.Vehicles.Where(x => x.Id == vehicle.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.LicensePlate = vehicle.LicensePlate;
                    entity.Model = vehicle.Model;
                    entity.RegistrationDate = vehicle.RegistrationDate;
                    entity.ChassisNumber = vehicle.ChassisNumber;
                    entity.ManufacturerId = vehicle.ManufacturerId;
                    entity.CustomerId = vehicle.CustomerId;

                    _dbContext.SaveChanges(); 
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
