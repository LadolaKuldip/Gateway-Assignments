using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DealerId { get; set; }
        public int MechanicId { get; set; }
        public int VehicleId { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public int ServiceId { get; set; }
        public int Status { get; set; }

        public int UpdatedBy { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Service Service { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
