using ASC.Common;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AIndexController : Controller
    {
        // GET: AdminsArea/AIndex
        public ActionResult Index()
        {
            IndexCounts counts;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Data/");
                //HTTP GET
                var responseTask = client.GetAsync("GetAdminIndex");
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