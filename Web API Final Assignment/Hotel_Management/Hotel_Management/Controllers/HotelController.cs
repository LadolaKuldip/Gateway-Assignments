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
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;
        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        // GET: api/Hotel
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Hotels> hotels = _hotelManager.GetAllHotels();
            if (!hotels.Any())
            {
                return NotFound();
            }
            return Ok(hotels);
        }

        // GET: api/Hotel/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Hotels hotel = _hotelManager.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // POST: api/Hotel
        [HttpPost]
        public IHttpActionResult Post([FromBody]Hotels hotel)
        {
            string userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            hotel.CreatedBy = userId;
            hotel.UpdatedBy = userId;
            string response = _hotelManager.CreateHotel(hotel);
            if (response.Equals("null"))
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
