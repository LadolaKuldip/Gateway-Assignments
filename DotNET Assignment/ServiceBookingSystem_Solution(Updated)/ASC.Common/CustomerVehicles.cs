using ASC.Entities;
using System.Collections.Generic;

namespace ASC.Common
{
    public class CustomerVehicles
    {
        public Customer Customer { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
