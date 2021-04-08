using ASC.Common;
using ASC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MechanicController : Controller
    {
        // GET: AdminsArea/Mechanic
        public ActionResult Index()
        {
            IEnumerable<Mechanic> mechanics;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Mechanic/");
                //HTTP GET
                var responseTask = client.GetAsync("Get");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Mechanic>>();
                    readTask.Wait();
                    mechanics = readTask.Result;
                }
                else
                {
                    mechanics = Enumerable.Empty<Mechanic>();
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(mechanics);
        }

        // GET: AdminsArea/Mechanic/Create
        public ActionResult Create()
        {
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
            MechanicFormModel entity = new MechanicFormModel
            {
                dealers = dealers.Where(x => x.IsActive == true),
                mechanic = new Mechanic()
            };

            return PartialView(entity);
        }

        // POST: AdminsArea/Mechanic/Create
        [HttpPost]
        public ActionResult Create(Mechanic mechanic)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Mechanic/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Mechanic>("Create", mechanic);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 0;
                        TempData["Message"] = "Mechanic Added successfully";
                        return RedirectToAction("Index");
                    }
                    else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        TempData["Type"] = 3;
                        TempData["Message"] = "Mechanic Already Exists";
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

        // GET: AdminsArea/Mechanic/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Dealer> dealers;
            Mechanic mechanic = new Mechanic();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                //HTTP GET
                var responseTask = client.GetAsync("Dealer/Get");
                //HTTP GET
                var responseTask2 = client.GetAsync("Mechanic/Get/" + id);
                responseTask.Wait();
                responseTask2.Wait();
                var result = responseTask.Result;
                var result2 = responseTask2.Result;
                if (result.IsSuccessStatusCode && result2.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Dealer>>();
                    readTask.Wait();
                    dealers = readTask.Result;

                    var readTask2 = result2.Content.ReadAsAsync<Mechanic>();
                    readTask2.Wait();
                    mechanic = readTask2.Result;
                }
                else
                {
                    dealers = Enumerable.Empty<Dealer>();
                    mechanic = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            MechanicFormModel entity = new MechanicFormModel
            {
                dealers = dealers,
                mechanic = mechanic
            };

            return PartialView(entity);

        }

        // POST: AdminsArea/Mechanic/Edit
        [HttpPost]
        public ActionResult Edit(Mechanic mechanic)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Mechanic/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Mechanic>("Edit", mechanic);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Mechanic Edited successfully";
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

        // GET: AdminsArea/Mechanic/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Mechanic/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Mechanic Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Type"] = 3;
            TempData["Message"] = "Errore occured While Deleting !";
            return RedirectToAction("Index");
        }
    }
}