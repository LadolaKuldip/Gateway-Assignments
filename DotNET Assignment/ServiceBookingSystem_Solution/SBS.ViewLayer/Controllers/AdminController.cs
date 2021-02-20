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
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/List
        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            IEnumerable<Appointment> appointments = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var response = client.GetAsync("Appointment/GetAll").Result;

                if (response.IsSuccessStatusCode)
                {
                    appointments = response.Content.ReadAsAsync<IList<Appointment>>().Result;
                }
                else
                {
                    appointments = Enumerable.Empty<Appointment>();
                }
            }
            return View(appointments);
        }

        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            IEnumerable<Service> services = null;
            IEnumerable<Dealer> dealers = null;
            IEnumerable<Customer> Customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var responseService = client.GetAsync("Services").Result;
                var responseDealer = client.GetAsync("Dealers").Result;
                var responseCustomer = client.GetAsync("Customer/Get").Result;
                
                if (responseService.IsSuccessStatusCode && responseDealer.IsSuccessStatusCode && responseCustomer.IsSuccessStatusCode)
                {
                    services = responseService.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    dealers = responseDealer.Content.ReadAsAsync<IEnumerable<Dealer>>().Result;
                    Customers = responseCustomer.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    dealers = Enumerable.Empty<Dealer>();
                    Customers = Enumerable.Empty<Customer>();
                }
            }
            SelectList ListServices = new SelectList(services.Select(x => x.Name));
            SelectList ListDealers = new SelectList(dealers.Select(x => x.Name));
            
            ViewBag.services = ListServices;
            ViewBag.dealers = ListDealers;
            ViewBag.customers = Customers;
            return View();
        }


        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Appointment appointment)
        {
            IEnumerable<Service> services = null;
            IEnumerable<Dealer> dealers = null;
            IEnumerable<Vehicle> vehicles = null;
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var responseService = client.GetAsync("Services").Result;
                var responseDealer = client.GetAsync("Dealers").Result;
                var responseCustomer = client.GetAsync("Customer/Get").Result;

                if (responseService.IsSuccessStatusCode && responseDealer.IsSuccessStatusCode && responseCustomer.IsSuccessStatusCode)
                {
                    services = responseService.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    dealers = responseDealer.Content.ReadAsAsync<IEnumerable<Dealer>>().Result;
                    customers = responseCustomer.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    dealers = Enumerable.Empty<Dealer>();
                    customers = Enumerable.Empty<Customer>();
                }

                var service = Request.Params["ServiceId"];
                var vehicle = Request.Params["VehicleId"];
                var dealer = Request.Params["DealerId"];
                var customer = Request.Params["CustomerId"];


                appointment.ServiceId = services.Where(y => y.Name == service).FirstOrDefault().Id;

                appointment.DealerId = dealers.Where(y => y.Name == dealer).FirstOrDefault().Id;
                appointment.CustomerId = int.Parse(customer);

                var responseVehicle = client.GetAsync("Vehicle/GetByCustomer/" + appointment.CustomerId).Result;

                if (responseVehicle.IsSuccessStatusCode)
                {
                    vehicles = responseVehicle.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result;
                }
                else
                {
                    vehicles = Enumerable.Empty<Vehicle>();
                }
                appointment.Vehicle = vehicles.Where(y => y.LicensePlate == vehicle).FirstOrDefault();
                appointment.VehicleId = appointment.Vehicle.Id;


                var post = client.PostAsJsonAsync("Appointment/Create", appointment).Result;

                if (post.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Vehicle Created With Id: " + appointment.Id);
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        [Route("UpdateStatus")]
        public JsonResult UpdateStatus()
        {
            int id = int.Parse(Request.QueryString["id"]);
            int status = int.Parse(Request.QueryString["status"]);
            bool statusArg = false;
            if (status == 1)
            {
                statusArg = true;
            }
            var val = "error";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");

                var response = client.GetAsync("Appointment/UpdateStatus?id=" + id + "&status=" + statusArg).Result;

                if (response.IsSuccessStatusCode)
                {
                    val = "success";
                }
            }
            return Json(val, JsonRequestBehavior.AllowGet);
        }
    }
}