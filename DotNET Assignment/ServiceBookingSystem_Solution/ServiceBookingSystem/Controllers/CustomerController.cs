using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceBookingSystem.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager _customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpPost]
        [Route("api/Customer")]
        // POST: api/Customer
        public IHttpActionResult Register([FromBody]Customer customer)
        {
           string response = _customerManager.Register(customer);
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

    }
}
