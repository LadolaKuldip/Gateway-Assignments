using ASC.Common;
using ASC.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.DealersArea.Controllers
{
    [Authorize(Roles = "Dealer")]
    public class VehiclesController : Controller
    {
        // GET: DealersArea/Vehicles
        public ActionResult Index()
        {
            IEnumerable<Vehicle> vehicles;
            string userId = User.Identity.GetUserId();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Vehicle/");
                //HTTP GET
                var responseTask = client.GetAsync("GetDealerVehicles/"+ userId);
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

        // GET: AdminsArea/Vehicle/CreateDropdown/1
        public ActionResult CreateDropdown(int id)
        {
            IEnumerable<Model> models;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Model/");
                //HTTP GET
                var responseTask = client.GetAsync("GetbyBrand/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Model>>();
                    readTask.Wait();
                    models = readTask.Result;
                }
                else
                {
                    models = Enumerable.Empty<Model>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            VehicleFormModel entity = new VehicleFormModel
            {
                models = models,
                customers = null,
                vehicle = new Vehicle()
            };

            return PartialView(entity);
        }

        // GET: AdminsArea/Vehicle/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Brand> brands;
            IEnumerable<Customer> customers;
            Vehicle vehicle = new Vehicle();
            vehicle.RegistrationDate = DateTime.Now;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Brand/Get");
                var responseTask2 = client.GetAsync("Customer/GetDealerCustomers/" + userId);
                responseTask.Wait();
                responseTask2.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Brand>>();
                    readTask.Wait();
                    brands = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask2.Wait();
                    customers = readTask2.Result;
                }
                else
                {
                    brands = Enumerable.Empty<Brand>();
                    customers = Enumerable.Empty<Customer>();
                    vehicle = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            VehicleFormModel entity = new VehicleFormModel
            {
                brands = brands.Where(x => x.IsActive == true),
                customers = customers.Where(x => x.IsActive == true),
                vehicle = vehicle
            };

            return PartialView(entity);
        }

        // POST: DealersArea/Vehicles
        [HttpPost]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Vehicle/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Vehicle>("Create", vehicle);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Vehicle Added successfully";
                        return RedirectToAction("Index");
                    }
                    else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        TempData["Type"] = 3;
                        TempData["Message"] = "Vehicle Already Exists";
                        return RedirectToAction("Index");
                    }
                }
                TempData["Type"] = 2;
                TempData["Message"] = "Error Occured While Creating";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminsArea/Vehicle/Edit/5
        public ActionResult Edit(int id)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Brand> brands;
            IEnumerable<Customer> customers;
            Vehicle vehicle = new Vehicle();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Brand/Get");
                var responseTask2 = client.GetAsync("Customer/GetDealerCustomers/" + userId);
                var responseTask3 = client.GetAsync("Vehicle/Get/" + id);
                responseTask.Wait();
                responseTask2.Wait();
                responseTask3.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                var result3 = responseTask3.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode && result3.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Brand>>();
                    readTask.Wait();
                    brands = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask2.Wait();
                    customers = readTask2.Result;

                    var readTask3 = result3.Content.ReadAsAsync<Vehicle>();
                    readTask3.Wait();
                    vehicle = readTask3.Result;
                }
                else
                {
                    brands = Enumerable.Empty<Brand>();
                    customers = Enumerable.Empty<Customer>();
                    vehicle = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            VehicleFormModel entity = new VehicleFormModel
            {
                brands = brands,
                customers = customers,
                vehicle = vehicle
            };

            return PartialView(entity);
        }

        // POST: DealersArea/Vehicles
        [HttpPost]
        public ActionResult Edit(Vehicle vehicle)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Vehicle/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Vehicle>("Edit", vehicle);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Model Edited successfully";
                        return RedirectToAction("Index");
                    }
                }
                TempData["Type"] = 2;
                TempData["Message"] = "Error Occured While Updating";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DealersArea/Vehicles
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Vehicle/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Model Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}