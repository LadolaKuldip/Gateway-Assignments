using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IMechanicManager
    {
        List<Mechanic> GetMechanics();
        List<Mechanic> GetDealerMechanics(string userId);
        Mechanic GetMechanic(int id);
        string CreateMechanic(Mechanic mechanic);
        string EditMechanic(Mechanic mechanic);
        string DeleteMechanic(int id);
    }
}
