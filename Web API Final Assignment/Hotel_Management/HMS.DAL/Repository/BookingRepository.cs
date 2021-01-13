using AutoMapper;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        string defaultStatus = "Optional";
        private readonly Database.HotelManagementDBEntities _dbContext;
        
        public BookingRepository()
        {
            _dbContext = new Database.HotelManagementDBEntities();
        }
        public string CreateBooking(Bookings booking)
        {
            try
            {
                if (booking != null || RoomCheckAvail(booking.RoomId, booking.BookingDate))
                {
                    Database.Booking entity = new Database.Booking();

                    var config = new MapperConfiguration(cfg => cfg.CreateMap<Bookings, Database.Booking>());
                    var mapper = new Mapper(config);

                    entity = mapper.Map<Database.Booking>(booking);
                    entity.Status = defaultStatus;

                    _dbContext.Bookings.Add(entity);
                    _dbContext.SaveChanges();

                    return "created";
                }
                return "null";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteBooking(int bookingId)
        {
            try
            {
                return UpdateBooking(bookingId, "Deleted");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool RoomCheckAvail(int roomId, DateTime date)
        {
            Database.Booking avail = _dbContext.Bookings.Where(x => x.RoomId == roomId && x.BookingDate == date && x.Status != "Deleted").FirstOrDefault();
            if (avail == null)
            {
                return true;
            }
            return false;
        }

        public string UpdateBooking(Bookings booking)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(booking.Id);

                if (entity != null || RoomCheckAvail(booking.RoomId, booking.BookingDate))
                {

                    entity.RoomId = booking.RoomId;
                    entity.BookingDate = booking.BookingDate;
                    entity.BookingBy = booking.BookingBy;
                    if (booking.Status != null)
                    {
                        entity.Status = booking.Status;
                    }                    

                    _dbContext.SaveChanges();

                    return "Updated";
                }

                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateBooking(int bookingId, string status)
        {
            try
            {
                var entity = _dbContext.Bookings.Find(bookingId);

                if (entity != null)
                {
                    entity.Status = status;
                    _dbContext.SaveChanges();

                    return "Updated status";
                }

                return "null";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
