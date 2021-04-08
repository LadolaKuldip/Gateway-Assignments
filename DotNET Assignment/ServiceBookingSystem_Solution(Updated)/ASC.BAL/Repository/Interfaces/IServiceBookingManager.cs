using ASC.Common;
using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Interfaces
{
    public interface IServiceBookingManager
    {
        string AddBooking(ServiceBookingModel serviceBookingModel);
        string EditBooking(ServiceBooking serviceBooking);
        string EditPay(ServiceBooking serviceBooking);
        string EditFeedback(ServiceBooking serviceBooking);
        IEnumerable<ServiceBooking> GetBookings();
        IEnumerable<ServiceBooking> GetDealerBookings(string userId);
        IEnumerable<ServiceBooking> GetUserBookings(string userId);
        ServiceBookingDetailModel GetDetail(int id);
        ServiceBookingEditModel GetBooking(int id);
    }
}
