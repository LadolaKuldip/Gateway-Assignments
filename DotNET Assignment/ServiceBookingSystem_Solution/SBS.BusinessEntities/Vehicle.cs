using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public long ChassisNumber { get; set; }
        public int CustomerId { get; set; }
        public int ManufacturerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
