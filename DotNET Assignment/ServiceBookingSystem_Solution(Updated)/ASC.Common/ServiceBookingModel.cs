using ASC.Entities;

namespace ASC.Common
{
    public class ServiceBookingModel
    {
        public ServiceBooking ServiceBooking { get; set; }

        public int[] servicesIds { get; set; }
    }
}
