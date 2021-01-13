using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BAL.Interface
{
    public interface IBookingManager
    {
        string CreateBooking(Bookings booking);
        string UpdateBooking(Bookings booking);
        string UpdateBooking(int bookingId, string status);
        string DeleteBooking(int bookingId);
        bool RoomCheckAvail(int roomId, DateTime date);

    }
}
