using ASC.Entities;
using System.Collections.Generic;

namespace ASC.Common
{
    public class ServiceBookingDetailModel
    {
        public ServiceBooking ServiceBooking { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }
}
