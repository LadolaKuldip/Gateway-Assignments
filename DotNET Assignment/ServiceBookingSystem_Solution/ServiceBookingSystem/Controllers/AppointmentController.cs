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
        [Authorize]
        [Route("Create")]
        public IHttpActionResult Create(Appointment appointment)
        {
            if (appointment.CustomerId == 0)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var Id = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                appointment.CustomerId = Id;
                /*appointment.UpdatedBy = Id;*/
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
        [Authorize]
        [Route("Update")]
        public IHttpActionResult Update(Appointment appointment)
        {
            if (appointment.CustomerId == 0)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var Id = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
                appointment.CustomerId = Id;
                appointment.UpdatedBy = Id;
            }
            string response = _appointmentManager.Update(appointment);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        [Route("UpdateStatus")]
        public IHttpActionResult UpdateStatus()
        {
            var data = Request.RequestUri.ParseQueryString();
            int Id = int.Parse(data["Id"]);
            bool status = bool.Parse(data["status"]);
            string response = _appointmentManager.UpdateStatus(Id, status);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        [Authorize]
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
        [Authorize]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var identity = (ClaimsIdentity)User.Identity;
            int customerId = int.Parse(identity.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            var response = _appointmentManager.GetAppointments(customerId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            var response = _appointmentManager.GetAppointments();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Authorize]
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

        [HttpGet]
        [Authorize]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var response = _appointmentManager.GetAppointment(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}
