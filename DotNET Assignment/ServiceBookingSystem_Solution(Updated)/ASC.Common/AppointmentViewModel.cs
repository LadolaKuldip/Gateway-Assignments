using ASC.Entities;
using System.Collections.Generic;

namespace ASC.Common
{
    public class AppointmentViewModel
    {
        public ServiceBooking ServiceBooking { get; set; }
        public CustomerVehicles CustomerVehicles { get; set; }
        public IEnumerable<Dealer> Dealers { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
