using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Classes
{
    public class MechanicManager : IMechanicManager
    {
        private readonly IMechanicRepository _mechanicRepository;

        public MechanicManager(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }
        public string CreateMechanic(Mechanic mechanic)
        {
            return _mechanicRepository.CreateMechanic(mechanic);
        }

        public string DeleteMechanic(int id)
        {
            return _mechanicRepository.DeleteMechanic(id);
        }

        public string EditMechanic(Mechanic mechanic)
        {
            return _mechanicRepository.EditMechanic(mechanic);
        }

        public List<Mechanic> GetDealerMechanics(string userId)
        {
            return _mechanicRepository.GetDealerMechanics(userId);
        }

        public Mechanic GetMechanic(int id)
        {
            return _mechanicRepository.GetMechanic(id);
        }

        public List<Mechanic> GetMechanics()
        {
            return _mechanicRepository.GetMechanics();
        }
    }
}
