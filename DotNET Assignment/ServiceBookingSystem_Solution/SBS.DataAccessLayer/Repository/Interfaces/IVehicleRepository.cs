using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        string Create(Vehicle vehicle);
        string Update(Vehicle vehicle);
        string Delete(int id);
        IEnumerable<Vehicle> GetVehicles();
        IEnumerable<Vehicle> GetVehicles(int customerId);

    }
}
