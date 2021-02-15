using SBS.BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceBookingSystem.Controllers
{
    public class SupportController : ApiController
    {
        private readonly ISupportManager _supportManager;
        public SupportController(ISupportManager supportManager)
        {
            _supportManager = supportManager;
        }

        //[Authorize]
        [Route("Dealers")]
        public IHttpActionResult GetDealers()
        {
            var dealers = _supportManager.GetDealers();
            if (dealers == null)
            {
                return InternalServerError();
            }
            return Ok(dealers);
        }

        //[Authorize]
        [Route("Manufacturers")]
        public IHttpActionResult GetManufacturers()
        {
            var manufacturers = _supportManager.GetManufacturers();
            if (manufacturers == null)
            {
                return InternalServerError();
            }
            return Ok(manufacturers);
        }

        //[Authorize]
        [Route("Services")]
        public IHttpActionResult GetServices()
        {
            var services = _supportManager.GetServices();
            if (services == null)
            {
                return InternalServerError();
            }
            return Ok(services);
        }
    }
}
