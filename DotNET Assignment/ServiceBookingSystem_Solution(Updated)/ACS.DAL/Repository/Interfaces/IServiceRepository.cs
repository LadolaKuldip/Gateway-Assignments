using ASC.Entities;
using System.Collections.Generic;

namespace ACS.DAL.Repository.Interfaces
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetServices();
        Service GetService(int id);
        string CreateService(Service service);
        string EditService(Service service);
        string DeleteService(int id);
    }
}
