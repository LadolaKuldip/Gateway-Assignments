using ASC.Entities;
using System.Collections.Generic;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IMechanicRepository
    {
        List<Mechanic> GetMechanics();
        List<Mechanic> GetDealerMechanics(string userId);
        Mechanic GetMechanic(int id);
        string CreateMechanic(Mechanic mechanic);
        string EditMechanic(Mechanic mechanic);
        string DeleteMechanic(int id);
    }
}
