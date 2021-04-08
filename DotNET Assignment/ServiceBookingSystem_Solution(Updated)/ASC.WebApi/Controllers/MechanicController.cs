using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System.Web.Http;

namespace ASC.WebApi.Controllers
{
    [RoutePrefix("Mechanic")]
    public class MechanicController : ApiController
    { 
        private readonly IMechanicManager _mechanicManager;
        public MechanicController(IMechanicManager mechanicManager)
        {
            _mechanicManager = mechanicManager;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _mechanicManager.GetMechanics();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var response = _mechanicManager.GetMechanic(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("GetDealerMechanics/{userId}")]
        public IHttpActionResult GetDealerMechanics(string userId)
        {
            var response = _mechanicManager.GetDealerMechanics(userId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Mechanic mechanic)
        {
            string response = _mechanicManager.CreateMechanic(mechanic);
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
        public IHttpActionResult Edit(Mechanic mechanic)
        {
            string response = _mechanicManager.EditMechanic(mechanic);
            if (response != "updated")
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            string response = _mechanicManager.DeleteMechanic(id);
            if (response != "deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
