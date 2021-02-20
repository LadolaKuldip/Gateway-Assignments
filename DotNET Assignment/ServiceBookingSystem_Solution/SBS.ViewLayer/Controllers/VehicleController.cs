using SBS.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace SBS.ViewLayer.Controllers
{
    [RoutePrefix("Vehicle")]
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            IEnumerable<Vehicle> vehicles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var response = client.GetAsync("vehicle/GetById").Result;

                if (response.IsSuccessStatusCode)
                {
                    vehicles = response.Content.ReadAsAsync<IList<Vehicle>>().Result;
                }
                else
                {
                    vehicles = Enumerable.Empty<Vehicle>();
                }
            }
            return View(vehicles);
        }

        [HttpGet]
        [Route("GetVehiclesList/{id}")]
        public JsonResult GetVehiclesList(int id)
        {
            IEnumerable<Vehicle> vehicles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                //client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var response = client.GetAsync("Vehicle/GetByCustomer/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    vehicles = response.Content.ReadAsAsync<IList<Vehicle>>().Result;
                }
                else
                {
                    vehicles = Enumerable.Empty<Vehicle>();
                }
            }
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            IEnumerable<Manufacturer> manufacturers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var response = client.GetAsync("Manufacturers").Result;

                if (response.IsSuccessStatusCode)
                {
                    manufacturers = response.Content.ReadAsAsync<IEnumerable<Manufacturer>>().Result;
                }
                else
                {
                    manufacturers = Enumerable.Empty<Manufacturer>();
                }
            }
            SelectList ListManufacturers = new SelectList(manufacturers.Select(x => x.Name));
            ViewBag.manufacturers = ListManufacturers;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Vehicle vehicle)
        {
            IEnumerable<Manufacturer> manufacturers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var response = client.GetAsync("Manufacturers").Result;

                if (response.IsSuccessStatusCode)
                {
                    manufacturers = response.Content.ReadAsAsync<IEnumerable<Manufacturer>>().Result;
                }
                else
                {
                    manufacturers = Enumerable.Empty<Manufacturer>();
                }
            }
            var manufacturer = Request.Params["ManufacturerId"];
            vehicle.ManufacturerId = manufacturers.Where(y => y.Name == manufacturer).FirstOrDefault().Id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var post = client.PostAsJsonAsync<Vehicle>("Vehicle/Create", vehicle).Result;

                if (post.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Vehicle Created With Id: " + vehicle.Id);
                }
            }
            return RedirectToAction("Index", "Vehicle");
        }

    }
}