using HMS.BAL.Interface;
using HMS.DAL.Repository;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public string CreateBooking(Bookings booking)
        {
            return _bookingRepository.CreateBooking(booking);
        }

        public string DeleteBooking(int bookingId)
        {
            return _bookingRepository.DeleteBooking(bookingId);
        }

        public bool RoomCheckAvail(int roomId, DateTime date)
        {
            return _bookingRepository.RoomCheckAvail(roomId, date);
        }

        public string UpdateBooking(Bookings booking)
        {
            return _bookingRepository.UpdateBooking(booking);
        }

        public string UpdateBooking(int bookingId, string status)
        {
            return _bookingRepository.UpdateBooking(bookingId, status);
        }
    }
}
