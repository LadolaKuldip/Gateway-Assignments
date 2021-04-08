using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.DAL.Repository.Classes
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public VehicleRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        //CREATE Vehicle in DATABASE
        public string CreateVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle != null)
                {
                    var res = _DbContext.Vehicles.Where(x => x.NumberPlate == vehicle.NumberPlate).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Vehicle entity = new Database.Vehicle();
                    /*entity = AutoMapperConfig.VehicleMapper.Map<Database.Vehicle>(vehicle);*/
                    entity.Name = vehicle.Name;
                    entity.NumberPlate = vehicle.NumberPlate;
                    entity.ChassisNumber = vehicle.ChassisNumber;
                    entity.RegistrationDate = vehicle.RegistrationDate;
                    entity.LastServiceDate = vehicle.LastServiceDate;
                    entity.FuelType = vehicle.FuelType;
                    entity.CustomerId = vehicle.CustomerId;
                    entity.ModelId = vehicle.ModelId;

                    _DbContext.Vehicles.Add(entity);
                    _DbContext.SaveChanges();
                    return "created";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //DELETE Vehicle from DATABASE
        public string DeleteVehicle(int id)
        {
            var entity = _DbContext.Vehicles.Find(id);
            if (entity != null)
            {
                if (entity.IsActive == true)
                {
                    entity.IsActive = false;
                }
                else
                {
                    entity.IsActive = true;
                }
                _DbContext.SaveChanges();
                return "deleted";
            }
            return "null";
        }

        //EDIT Vehicle in DATABASE
        public string EditVehicle(Vehicle vehicle)
        {
            try
            {
                var entity = _DbContext.Vehicles.Where(x => x.Id == vehicle.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = vehicle.Name;
                    entity.NumberPlate = vehicle.NumberPlate;
                    entity.ChassisNumber = vehicle.ChassisNumber;
                    entity.RegistrationDate = vehicle.RegistrationDate;
                    entity.LastServiceDate = vehicle.LastServiceDate;
                    entity.FuelType = vehicle.FuelType;
                    entity.CustomerId = vehicle.CustomerId;
                    entity.ModelId = vehicle.ModelId;

                    _DbContext.SaveChanges();
                    return "updated";
                }
                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //GET all Vehicles of Customers under Dealer
        public IEnumerable<Vehicle> GetDealerVehicles(string userId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _DbContext.Vehicles.Include("Model").Where(x => x.Customer.Dealer.UserId == userId).ToList();

            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }

        //GET single Vehicle By Id
        public Vehicle GetVehicle(int id)
        {
            Vehicle vehicle;
            Database.Vehicle entity = _DbContext.Vehicles.Find(id);

            if (entity != null)
            {
                vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(entity);
            }
            else
            {
                vehicle = new Vehicle();
            }
            return vehicle;
        }

        //GET all Vehicles
        public IEnumerable<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _DbContext.Vehicles.Include("Customer").Include("Model").ToList();
                       
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }

        //GET all Vehicles of Customer
        public IEnumerable<Vehicle> GetVehiclesOfUser(string userId)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            IEnumerable<Database.Vehicle> entities = _DbContext.Vehicles.Include("Model").Where(x => x.Customer.UserId == userId).ToList();
            
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle = AutoMapperConfig.VehicleMapper.Map<Vehicle>(item);
                    vehicles.Add(vehicle);
                }
            }
            return vehicles;
        }
    }
}
