using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.DataAccessLayer.Repository.Interfaces
{
    public interface ISupportRepository
    {
        IEnumerable<Dealer> GetDealers();
        IEnumerable<Manufacturer> GetManufacturers();
        IEnumerable<Service> GetServices();
        Mechanic GetMechanics(string Make);
    }
}
