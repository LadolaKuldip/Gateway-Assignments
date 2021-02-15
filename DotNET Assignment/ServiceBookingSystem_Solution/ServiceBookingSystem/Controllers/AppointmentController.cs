using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ServiceBookingSystem.Controllers
{
    [RoutePrefix("Appointment")]    
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentManager _appointmentManager;
        public AppointmentController(IAppointmentManager appointmentManager)
        {
            _appointmentManager = appointmentManager;
        }

        [HttpPost]
        //[Authorize]
        [Route("Create")]
        public IHttpActionResult Create(Appointment appointment)
        {
            if (appointment.CustomerId == 0)
            {
                var identity = (ClaimsIdentity)User.Identity;
              //  appointment.CustomerId = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            }
            string response = _appointmentManager.Create(appointment);
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
        //[Authorize]
        [Route("Update")]
        public IHttpActionResult Update(Appointment appointment)
        {
            string response = _appointmentManager.Update(appointment);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpPut]
        //[Authorize]
        [Route("UpdateStatus")]
        public IHttpActionResult UpdateStatus(int appointmentId, bool status)
        {
            string response = _appointmentManager.UpdateStatus(appointmentId, status);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        //[Authorize]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            string response = _appointmentManager.Delete(id);
            if (response != "deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        //[Authorize]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _appointmentManager.GetAppointments();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        //[Authorize]
        [Route("GetFilter")]
        public IHttpActionResult GetFilter(DateTime startDate, DateTime endDate)
        {
            var response = _appointmentManager.GetAppointments(startDate, endDate);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}
