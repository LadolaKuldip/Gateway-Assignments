using ASC.BAL.Repository.Interfaces;
using ASC.Common;
using ASC.Entities;
using System.Web.Http;

namespace ASC.WebApi.Controllers
{
    [RoutePrefix("ServiceBooking")]
    public class ServiceBookingController : ApiController
    {
        private readonly IServiceBookingManager _serviceBookingManager;
        public ServiceBookingController(IServiceBookingManager serviceBookingManager)
        {
            _serviceBookingManager = serviceBookingManager;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _serviceBookingManager.GetBookings();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetDetail/{id}")]
        public IHttpActionResult GetDetail(int id)
        {
            var response = _serviceBookingManager.GetDetail(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBooking/{id}")]
        public IHttpActionResult GetBooking(int id)
        {
            var response = _serviceBookingManager.GetBooking(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetDealerBookings/{userId}")]
        public IHttpActionResult GetDealerBookings(string userId)
        {
            var response = _serviceBookingManager.GetDealerBookings(userId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUserBookings/{userId}")]
        public IHttpActionResult GetUserBookings(string userId)
        {
            var response = _serviceBookingManager.GetUserBookings(userId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(ServiceBookingModel serviceBookingModel)
        {
            string response = _serviceBookingManager.AddBooking(serviceBookingModel);
            if (response == "already")
            {
                return Conflict();
            }
            else if (response != "created")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        [Route("Edit")]
        public IHttpActionResult Edit(ServiceBooking serviceBooking)
        {
            string response = _serviceBookingManager.EditBooking(serviceBooking);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }
        
        [HttpPut]
        [Route("EditPay")]
        public IHttpActionResult EditPay(ServiceBooking serviceBooking)
        {
            string response = _serviceBookingManager.EditPay(serviceBooking);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }
        
        [HttpPut]
        [Route("EditFeedback")]
        public IHttpActionResult EditFeedback(ServiceBooking serviceBooking)
        {
            string response = _serviceBookingManager.EditFeedback(serviceBooking);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
