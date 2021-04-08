using ACS.DAL.Repository.Interfaces;
using ASC.BAL.Repository.Interfaces;
using ASC.Common;
using ASC.Entities;
using System.Collections.Generic;

namespace ASC.BAL.Repository.Classes
{
    public class ServiceBookingManager : IServiceBookingManager
    {
        private readonly IServiceBookingRepository _serviceBookingRepository;

        public ServiceBookingManager(IServiceBookingRepository serviceBookingRepository)
        {
            _serviceBookingRepository = serviceBookingRepository;
        }
        public string AddBooking(ServiceBookingModel serviceBookingModel)
        {
            return _serviceBookingRepository.AddBooking(serviceBookingModel);
        }

        public string EditBooking(ServiceBooking serviceBooking)
        {
            return _serviceBookingRepository.EditBooking(serviceBooking);
        }

        public string EditFeedback(ServiceBooking serviceBooking)
        {
            return _serviceBookingRepository.EditFeedback(serviceBooking);
        }

        public string EditPay(ServiceBooking serviceBooking)
        {
            return _serviceBookingRepository.EditPay(serviceBooking);
        }

        public ServiceBookingEditModel GetBooking(int id)
        {
            return _serviceBookingRepository.GetBooking(id);
        }

        public IEnumerable<ServiceBooking> GetBookings()
        {
            return _serviceBookingRepository.GetBookings();
        }

        public IEnumerable<ServiceBooking> GetDealerBookings(string userId)
        {
            return _serviceBookingRepository.GetDealerBookings(userId);
        }

        public ServiceBookingDetailModel GetDetail(int id)
        {
            return _serviceBookingRepository.GetDetail(id);
        }

        public IEnumerable<ServiceBooking> GetUserBookings(string userId)
        {
            return _serviceBookingRepository.GetUserBookings(userId);
        }
    }
}
