using ASC.BAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASC.WebApi.Controllers
{
    [RoutePrefix("Data")]
    public class DataController : ApiController
    {
        private readonly IDataManager _dataManager;
        public DataController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpGet]
        [Route("GetAdminIndex")]
        public IHttpActionResult GetAdminIndex()
        {
            var response = _dataManager.GetAdminIndex();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetDealerIndex/{userId}")]
        public IHttpActionResult GetDealerIndex(string userId)
        {
            var response = _dataManager.GetDealerIndex(userId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}
