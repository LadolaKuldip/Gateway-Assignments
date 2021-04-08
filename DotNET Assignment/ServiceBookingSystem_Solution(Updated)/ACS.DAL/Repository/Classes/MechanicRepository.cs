using ACS.DAL.Repository.Interfaces;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.DAL.Repository.Classes
{
    public class MechanicRepository : IMechanicRepository
    {
        private readonly Database.SampleDBEntities _DbContext;

        public MechanicRepository()
        {
            _DbContext = new Database.SampleDBEntities();
        }

        //CREATE Mechanic in DATABASE
        public string CreateMechanic(Mechanic mechanic)
        {
            try
            {
                if (mechanic != null)
                {
                    var res = _DbContext.Mechanics.Where(x => x.Email == mechanic.Email).FirstOrDefault();
                    if (res != null)
                    {
                        return "already";
                    }
                    Database.Mechanic entity = new Database.Mechanic();
                    entity = AutoMapperConfig.MechanicMapper.Map<Database.Mechanic>(mechanic);

                    _DbContext.Mechanics.Add(entity);
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

        //SOFT DELETE Mechanic from DATABASE
        public string DeleteMechanic(int id)
        {
            var entity = _DbContext.Mechanics.Where(x => x.Id == id).FirstOrDefault();
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

        //EDIT Mechanic in DATABASE
        public string EditMechanic(Mechanic mechanic)
        {
            try
            {
                var entity = _DbContext.Mechanics.Where(x => x.Id == mechanic.Id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = mechanic.Name;
                    entity.PhoneNumber = mechanic.PhoneNumber;
                    entity.Email = mechanic.Email;
                    entity.DealerId = mechanic.DealerId;
                    entity.IsActive = mechanic.IsActive; 

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

        //GET all Mechanics of Dealer
        public List<Mechanic> GetDealerMechanics(string userId)
        {
            List<Mechanic> mechanics = new List<Mechanic>();
            IEnumerable<Database.Mechanic> entities = _DbContext.Mechanics.Where(x => x.Dealer.UserId == userId).ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Mechanic mechanic = new Mechanic();
                    mechanic = AutoMapperConfig.MechanicMapper.Map<Mechanic>(item);
                    mechanics.Add(mechanic);
                }
            }
            return mechanics;
        }

        //GET single Mechanic By Id
        public Mechanic GetMechanic(int id)
        {
            Mechanic mechanic;
            Database.Mechanic entity = _DbContext.Mechanics.Find(id);

            if (entity != null)
            {
                mechanic = AutoMapperConfig.MechanicMapper.Map<Mechanic>(entity);
            }
            else 
            {   
                mechanic = new Mechanic();
            }
            return mechanic;
        }

        //GET all Mechanics
        public List<Mechanic> GetMechanics()
        {
            List<Mechanic> mechanics = new List<Mechanic>();
            IEnumerable<Database.Mechanic> entities = _DbContext.Mechanics.Include("Dealer").ToList();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Mechanic mechanic = new Mechanic();
                    mechanic = AutoMapperConfig.MechanicMapper.Map<Mechanic>(item);
                    mechanics.Add(mechanic);
                }
            }
            return mechanics;
        }
    }
}
