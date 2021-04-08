using ASC.Common;
using ASC.Entities;
using Microsoft.AspNet.Identity;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.UsersArea.Controllers
{
    [Authorize(Roles = "Customer")]
    public class UserController : Controller
    {
        // GET: UsersArea/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail()
        {
            string userId = User.Identity.GetUserId();

            ASC.Entities.Customer customer = new ASC.Entities.Customer();
            if (userId != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/");
                    //HTTP GET

                    var responseTask = client.GetAsync("Customer/GetUserId/" + userId);

                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<ASC.Entities.Customer>();
                        readTask.Wait();
                        customer = readTask.Result;

                    }
                    else
                    {
                        customer = null;
                        ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                    }
                }
            }

            return View(customer);
        }

        // GET: UsersArea/Customers/Edit/1
        public ActionResult EditDetail(int id)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Dealer> dealers;
            ASC.Entities.Customer customer = new ASC.Entities.Customer();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Dealer/Get");
                //HTTP GET
                var responseTask2 = client.GetAsync("Customer/Get/" + id);
                responseTask.Wait();
                responseTask2.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dealer>>();
                    readTask.Wait();
                    dealers = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<ASC.Entities.Customer>();
                    readTask2.Wait();
                    customer = readTask2.Result;
                }
                else
                {
                    dealers = Enumerable.Empty<Dealer>();
                    customer = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            CustomerFormModel entity = new CustomerFormModel
            {
                dealers = dealers.ToList(),
                customer = customer
            };

            return PartialView(entity);

        }

        // POST: DealersArea/Customers/Edit
        [HttpPost]
        public ActionResult EditDetail(ASC.Entities.Customer customer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<ASC.Entities.Customer>("Edit", customer);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Customer Edited successfully";
                        return RedirectToAction("Detail");
                    }
                }
                TempData["Type"] = 2;
                TempData["Message"] = "Error Occured While Updating";
                return RedirectToAction("Detail");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Vehicles()
        {
            string userId = User.Identity.GetUserId();

            IEnumerable<Vehicle> vehicles;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Vehicle/");
                //HTTP GET
                var responseTask = client.GetAsync("GetVehiclesOfUser/" + userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Vehicle>>();
                    readTask.Wait();
                    vehicles = readTask.Result;
                }
                else
                {
                    vehicles = Enumerable.Empty<Vehicle>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(vehicles);
        }

        public ActionResult Appointment()
        {
            IEnumerable<ServiceBooking> serviceBookings;
            string userId = User.Identity.GetUserId();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                //HTTP GET
                var responseTask = client.GetAsync("GetUserBookings/" + userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ServiceBooking>>();
                    readTask.Wait();
                    serviceBookings = readTask.Result;
                }
                else
                {
                    serviceBookings = Enumerable.Empty<ServiceBooking>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(serviceBookings);
        }


        // GET: AdminsArea/Appointment/Details/5
        public ActionResult AppointmentDetails(int id)
        {
            ServiceBookingDetailModel model;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                //HTTP GET
                var responseTask = client.GetAsync("GetDetail/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceBookingDetailModel>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                else
                {
                    model = new ServiceBookingDetailModel();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            return PartialView(model);
        }
        public ActionResult EditAppointment(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAppointment(int id)
        {
            return RedirectToAction("Index");
        }

        // GET: DealersAreas/Appointment/Create
        public ActionResult CreateAppointment()
        {
            string searchData = User.Identity.GetUserId();

            ServiceBooking serviceBooking = new ServiceBooking();
            serviceBooking.BookingDate = DateTime.Now;
            CustomerVehicles customerVehicles = null;
            IEnumerable<Dealer> dealers;
            IEnumerable<Service> services;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Dealer/Get");
                //HTTP GET
                var responseTask2 = client.GetAsync("Service/Get");
                responseTask.Wait();
                responseTask2.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dealer>>();
                    readTask.Wait();
                    dealers = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<IEnumerable<Service>>();
                    readTask.Wait();
                    services = readTask2.Result;
                }
                else
                {
                    dealers = Enumerable.Empty<Dealer>();
                    services = Enumerable.Empty<Service>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            if (searchData != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Customer/");
                    //HTTP GET
                    var responseTask = client.PostAsJsonAsync("GetName/", searchData);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<CustomerVehicles>();
                        readTask.Wait();
                        customerVehicles = readTask.Result;
                    }
                    else
                    {
                        customerVehicles = null;
                        ModelState.AddModelError(string.Empty, "User is not found with [" + searchData + "] .Please Try Again !!");
                    }
                }
            }
            AppointmentViewModel appointment = new AppointmentViewModel
            {
                ServiceBooking = serviceBooking,
                CustomerVehicles = customerVehicles,
                Services = services.Where(x => x.IsActive == true),
                Dealers = dealers.Where(x => x.IsActive == true)
            };
            return View(appointment);
        }

        //POST DealersAreas/Appointment
        [HttpPost]
        public ActionResult CreateAppointment(ServiceBooking ServiceBooking, int[] servicesIds)
        {
            try
            {
                ServiceBookingModel serviceBookingModel = new ServiceBookingModel
                {
                    ServiceBooking = ServiceBooking,
                    servicesIds = servicesIds
                };
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ServiceBookingModel>("Create", serviceBookingModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Model Added successfully";
                        return RedirectToAction("Index");
                    }
                }
                TempData["Type"] = 2;
                TempData["Message"] = "Error Occured While Creating";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Pay(int id)
        {
            ServiceBookingDetailModel model;
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                //HTTP GET
                var responseTask = client.GetAsync("GetDetail/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceBookingDetailModel>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                else
                {
                    model = new ServiceBookingDetailModel();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.TotalAmmount = model.ServiceBooking.TotalAmmount * 100;
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail,int? ServiceId)
        {
            ServiceBookingEditModel model = new ServiceBookingEditModel();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                //HTTP GET
                var responseTask = client.GetAsync("GetBooking/" + ServiceId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceBookingEditModel>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                else
                {
                    model = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }


            Stripe.StripeConfiguration.SetApiKey("pk_test_51IYO6iSEKzceCKKnY9Ael4iWcY7H8gTiPy6s6t0yUf1BiSuXCmbH83v0twovlCDljNpjsQpZvD1hvGMQMgkWqSsn00C4LcO8QA");
            Stripe.StripeConfiguration.ApiKey = "sk_test_51IYO6iSEKzceCKKnB2pLSnKtErfg0fifbcW4rJp7hrUFZAKn5RixxpBz9hH7f3NqQHszY8PG3Ugxpc0v366ovq0600InR1T9PV";

            var myCharge = new Stripe.ChargeCreateOptions();

            // always set these properties
            myCharge.Amount = (long?)model.ServiceBooking.TotalAmmount * 100 ;
            myCharge.Currency = "INR";

            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "Service Booking Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;

            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            var status = stripeCharge.Status;
            var PayId = stripeCharge.Id;
            var TranId = stripeCharge.BalanceTransactionId;
            //Console.WriteLine(stripeCharge);
            if (status.Equals("succeeded"))
            {           
                using (var client = new HttpClient())
                {
                    ServiceBooking serviceBooking = new ServiceBooking();
                    client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                    serviceBooking.Id = model.ServiceBooking.Id;
                    serviceBooking.PayDone = true;
                    serviceBooking.PayMethod = "online";
                    serviceBooking.PayId = PayId;
                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<ServiceBooking>("EditPay", serviceBooking);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Paied successfully";
                        return RedirectToAction("Appointment", "User", new { area = "UsersArea" });
                    }
                }
            }
            return RedirectToAction("Appointment", "User", new { area = "UsersArea" });

        }

        public ActionResult COD(int id)
        {
            using (var client = new HttpClient())
            {
                ServiceBooking serviceBooking = new ServiceBooking();
                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                serviceBooking.Id = id;
                serviceBooking.PayDone = true;
                serviceBooking.PayMethod = "COD";
                serviceBooking.PayId = null;
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<ServiceBooking>("EditPay", serviceBooking);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "COD Added successfully";
                    return RedirectToAction("Appointment", "User", new { area = "UsersArea" });
                }
            }
            return RedirectToAction("Appointment", "User", new { area = "UsersArea" });
        }

        public ActionResult Feedback(int id)
        {
            ServiceBookingEditModel model = new ServiceBookingEditModel();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                //HTTP GET
                var responseTask = client.GetAsync("GetBooking/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ServiceBookingEditModel>();
                    readTask.Wait();
                    model = readTask.Result;
                }
                else
                {
                    model = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Feedback(ServiceBooking serviceBooking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/ServiceBooking/");
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<ServiceBooking>("EditFeedback", serviceBooking);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Frrdback Added successfully";
                    return RedirectToAction("Appointment", "User", new { area = "UsersArea" });
                }
            }
            return RedirectToAction("Appointment", "User", new { area = "UsersArea" });
        }
    }
}