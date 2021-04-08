using ASC.Common;
using Microsoft.AspNet.Identity;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.DealersArea.Controllers
{
    [Authorize(Roles = "Dealer")]
    public class DIndexController : Controller
    {
        // GET: DealersAreas/DIndex
        public ActionResult Index()
        {
            IndexCounts counts;
            string userId = User.Identity.GetUserId();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Data/");
                //HTTP GET
                var responseTask = client.GetAsync("GetDealerIndex/"+userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IndexCounts>();
                    readTask.Wait();
                    counts = readTask.Result;
                }
                else
                {
                    counts = new IndexCounts();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(counts);
        }
    }
}