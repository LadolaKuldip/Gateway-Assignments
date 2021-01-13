using HMS.BAL.Interface;
using HMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }
        
        // POST: api/Booking
        [HttpPost]
        [Route("api/Booking")]
        public IHttpActionResult Post([FromBody]Bookings booking)
        {
            string userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            booking.BookingBy = userId;
            string response = _bookingManager.CreateBooking(booking);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // PUT: api/Booking/5
        [HttpPut]
        [Route("api/Booking/{bookingId}/{status}")]
        public IHttpActionResult Put([FromUri] int bookingId, [FromUri] string status)
        {
            string response = _bookingManager.UpdateBooking(bookingId, status);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // PUT: api/Booking
        [HttpPut]
        [Route("api/Booking")]
        public IHttpActionResult Put([FromBody]Bookings booking)
        {
            string userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            booking.BookingBy = userId;
            string response = _bookingManager.UpdateBooking(booking);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE: api/Booking/5
        [HttpDelete]

        public IHttpActionResult Delete(int id)
        {
            string response = _bookingManager.DeleteBooking(id);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

        // GET: api/Booking?roomId={roomId}&date={date}
        [HttpGet]
        [Route("api/Booking")]
        public IHttpActionResult Get([FromUri] int roomId, [FromUri] DateTime date)
        {
            bool response = _bookingManager.RoomCheckAvail(roomId, date);
            return Ok(response);
        }
    }
}
