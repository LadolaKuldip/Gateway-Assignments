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
    public class CustomersController : Controller
    {
        // GET: DealersAreas/Customers
        public ActionResult Index()
        {
            IEnumerable<Customer> customers;
            string userId = User.Identity.GetUserId();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Customer/");
                //HTTP GET
                var responseTask = client.GetAsync("GetDealerCustomers/"+ userId);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(customers);
        }

        // GET: DealersArea/Customers/Create
        public ActionResult Create()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Dealer> dealers;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Dealer/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dealer>>();
                    readTask.Wait();
                    dealers = readTask.Result;
                }
                else
                {
                    dealers = Enumerable.Empty<Dealer>();
                }
            }
            CustomerFormModel entity = new CustomerFormModel
            {
                dealers = dealers.Where(x => x.UserId == userId).ToList(),
                customer = new Customer()
            };

            return PartialView(entity);
        }

        // POST: DealersArea/Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Customer>("Create", customer);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Customer Added successfully";
                        return RedirectToAction("Index");
                    }
                    else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        TempData["Type"] = 3;
                        TempData["Message"] = "Customer Already Exists";
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

        // GET: DealersArea/Customers/Edit/1
        public ActionResult Edit(int id)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<Dealer> dealers;
            Customer customer = new Customer();
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

                    var readTask2 = result2.Content.ReadAsAsync<Customer>();
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
                dealers = dealers.Where(x => x.UserId == userId).ToList(),
                customer = customer
            };

            return PartialView(entity);

        }

        // POST: DealersArea/Customers/Edit
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Customer>("Edit", customer);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Customer Edited successfully";
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

        // GET: DealersArea/Customers/Delete/1
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Customer/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Customer Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Type"] = 3;
            TempData["Message"] = "Error Occured While Deleting";
            return RedirectToAction("Index");
        }
    }
}