using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IServiceManager
    {
        IEnumerable<Service> GetServices();
        Service GetService(int id);
        string CreateService(Service service);
        string EditService(Service service);
        string DeleteService(int id);
    }
}
