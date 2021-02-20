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
    [RoutePrefix("Appointment")]
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

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

                var response = client.GetAsync("Appointment/Get").Result;

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
            IEnumerable<Vehicle> vehicles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var responseService = client.GetAsync("Services").Result;
                var responseDealer = client.GetAsync("Dealers").Result;
                var responseVehicle = client.GetAsync("Vehicle/GetById").Result;

                if (responseService.IsSuccessStatusCode && responseDealer.IsSuccessStatusCode && responseVehicle.IsSuccessStatusCode)
                {
                    services = responseService.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    dealers = responseDealer.Content.ReadAsAsync<IEnumerable<Dealer>>().Result;
                    vehicles = responseVehicle.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    dealers = Enumerable.Empty<Dealer>();
                    vehicles = Enumerable.Empty<Vehicle>();
                }
            }
            SelectList ListServices = new SelectList(services.Select(x => x.Name));
            SelectList ListDealers = new SelectList(dealers.Select(x => x.Name));
            SelectList ListVehicles = new SelectList(vehicles.Select(x => x.LicensePlate));
            ViewBag.services = ListServices;
            ViewBag.dealers = ListDealers;
            ViewBag.vehicles = ListVehicles;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Appointment appointment)
        {
            IEnumerable<Service> services = null;
            IEnumerable<Dealer> dealers = null;
            IEnumerable<Vehicle> vehicles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var responseService = client.GetAsync("Services").Result;
                var responseDealer = client.GetAsync("Dealers").Result;
                var responseVehicle = client.GetAsync("Vehicle/GetById").Result;

                if (responseService.IsSuccessStatusCode && responseDealer.IsSuccessStatusCode && responseVehicle.IsSuccessStatusCode)
                {
                    services = responseService.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    dealers = responseDealer.Content.ReadAsAsync<IEnumerable<Dealer>>().Result;
                    vehicles = responseVehicle.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    dealers = Enumerable.Empty<Dealer>();
                    vehicles = Enumerable.Empty<Vehicle>();
                }
            }
            var service = Request.Params["ServiceId"];
            var vehicle = Request.Params["VehicleId"];
            var dealer = Request.Params["DealerId"];

            //vehicle.ManufacturerId = manufacturers.Where(y => y.Name == manufacturer).FirstOrDefault().Id;
            appointment.ServiceId = services.Where(y => y.Name == service).FirstOrDefault().Id;
            //appointment.VehicleId = vehicles.Where(y => y.LicensePlate == vehicle).FirstOrDefault().Id;
            appointment.Vehicle = vehicles.Where(y => y.LicensePlate == vehicle).FirstOrDefault();
            appointment.VehicleId = appointment.Vehicle.Id;
            appointment.DealerId = dealers.Where(y => y.Name == dealer).FirstOrDefault().Id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var post = client.PostAsJsonAsync<Appointment>("Appointment/Create", appointment).Result;

                if (post.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Vehicle Created With Id: " + appointment.Id);
                }
            }
            return RedirectToAction("Index", "Appointment");
        }


        [HttpGet]
        [Route("Update/{id}")]
        public ActionResult Update(int id)
        {
            IEnumerable<Service> services = null;
            IEnumerable<Dealer> dealers = null;
            IEnumerable<Vehicle> vehicles = null;
            Appointment appointment = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var responseService = client.GetAsync("Services").Result;
                var responseDealer = client.GetAsync("Dealers").Result;
                var responseVehicle = client.GetAsync("Vehicle/GetById").Result;
                var responseAppointment = client.GetAsync("Appointment/Get/" + id).Result;

                if (responseService.IsSuccessStatusCode && responseDealer.IsSuccessStatusCode && responseVehicle.IsSuccessStatusCode)
                {
                    services = responseService.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    dealers = responseDealer.Content.ReadAsAsync<IEnumerable<Dealer>>().Result;
                    vehicles = responseVehicle.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result;
                    appointment = responseAppointment.Content.ReadAsAsync<Appointment>().Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    dealers = Enumerable.Empty<Dealer>();
                    vehicles = Enumerable.Empty<Vehicle>();
                    appointment = new Appointment();
                }
            }
            SelectList ListServices = new SelectList(services.Select(x => x.Name));
            SelectList ListDealers = new SelectList(dealers.Select(x => x.Name));
            SelectList ListVehicles = new SelectList(vehicles.Select(x => x.LicensePlate));
            ViewBag.services = ListServices;
            ViewBag.dealers = ListDealers;
            ViewBag.vehicles = ListVehicles;

            return View("Create", appointment);
        }

        [HttpPost]
        [Route("Update")]
        public ActionResult Update(Appointment appointment)
        {
            IEnumerable<Service> services = null;
            IEnumerable<Dealer> dealers = null;
            IEnumerable<Vehicle> vehicles = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var responseService = client.GetAsync("Services").Result;
                var responseDealer = client.GetAsync("Dealers").Result;
                var responseVehicle = client.GetAsync("Vehicle/GetById").Result;

                if (responseService.IsSuccessStatusCode && responseDealer.IsSuccessStatusCode && responseVehicle.IsSuccessStatusCode)
                {
                    services = responseService.Content.ReadAsAsync<IEnumerable<Service>>().Result;
                    dealers = responseDealer.Content.ReadAsAsync<IEnumerable<Dealer>>().Result;
                    vehicles = responseVehicle.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result;
                }
                else
                {
                    services = Enumerable.Empty<Service>();
                    dealers = Enumerable.Empty<Dealer>();
                    vehicles = Enumerable.Empty<Vehicle>();
                }

            }
            var service = Request.Params["ServiceId"];
            var vehicle = Request.Params["VehicleId"];
            var dealer = Request.Params["DealerId"];

            appointment.ServiceId = services.Where(y => y.Name == service).FirstOrDefault().Id;
            appointment.Vehicle = vehicles.Where(y => y.LicensePlate == vehicle).FirstOrDefault();
            appointment.VehicleId = appointment.Vehicle.Id;
            appointment.DealerId = dealers.Where(y => y.Name == dealer).FirstOrDefault().Id;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var post = client.PutAsJsonAsync<Appointment>("Appointment/Update", appointment).Result;

                if (post.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Vehicle Updated With Id: " + appointment.Id);
                }
            }
            return RedirectToAction("Index", "Appointment");
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9622/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

                var post = client.GetAsync("Appointment/Delete/" + id).Result;

                if (post.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Vehicle Updated With Id: " + id);
                    return RedirectToAction("Index", "Appointment");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

        }
    }
}