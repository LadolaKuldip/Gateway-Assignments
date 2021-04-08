using ASC.BAL.Repository.Interfaces;
using ASC.Entities;
using System.Web.Http;

namespace ASC.WebApi.Controllers
{
    [RoutePrefix("Dealer")]
    public class DealerController : ApiController
    {
        private readonly IDealerManager _dealerManager;
        public DealerController(IDealerManager dealerManager)
        {
            _dealerManager = dealerManager;
        }

        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get()
        {
            var response = _dealerManager.GetDealers();
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
            var response = _dealerManager.GetDealer(id);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Dealer dealer)
        {
            string response = _dealerManager.CreateDealer(dealer);
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
        public IHttpActionResult Edit(Dealer dealer)
        {
            string response = _dealerManager.EditDealer(dealer);
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
            string response = _dealerManager.DeleteDealer(id);
            if (response != "deleted")
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
