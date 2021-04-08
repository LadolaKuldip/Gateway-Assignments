﻿using ASC.Entities;
using MultiAuthDemo.Controllers;
using MultiAuthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MultiAuthDemo.Areas.AdminsArea.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DealerController : Controller
    {
        // GET: AdminsArea/Dealer
        public ActionResult Index()
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
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }

            return View(dealers);
        }

        // GET: AdminsArea/Dealer/Create
        public ActionResult Create()
        {
            Dealer dealer = new Dealer();
            return PartialView(dealer);
        }

        // POST: AdminsArea/Dealer/Create
        [HttpPost]
        public ActionResult Create(Dealer dealer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Dealer/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Dealer>("Create", dealer);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        AccountController accountController = new AccountController();
                        accountController.ControllerContext = this.ControllerContext;
                        //accountController.UserManager;
                        var userId = accountController.RegisterAccount(new RegisterViewModel { UserName = dealer.Name, Email = dealer.Email, Password = "12345@Lk" });


                        TempData["Type"] = 0;
                        TempData["Message"] = "Dealer Added successfully";
                        return RedirectToAction("Index");
                    }
                    else if (result.StatusCode == System.Net.HttpStatusCode.Conflict)
                    {
                        TempData["Type"] = 3;
                        TempData["Message"] = "Dealer Already Exists";
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

        // GET: AdminsArea/Dealer/Edit/5
        public ActionResult Edit(int id)
        {
            Dealer dealer = new Dealer();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44318/Dealer/");
                //HTTP GET
                var responseTask = client.GetAsync("Get/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Dealer>();
                    readTask.Wait();
                    dealer = readTask.Result;
                }
                else
                {
                    dealer = null;
                    ModelState.AddModelError(string.Empty, "Server error occured while retriving data");
                }
            }
            return PartialView(dealer);
        }

        // POST: AdminsArea/Dealer/Edit
        [HttpPost]
        public ActionResult Edit(Dealer dealer)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44318/Dealer/");

                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<Dealer>("Edit", dealer);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        TempData["Type"] = 1;
                        TempData["Message"] = "Dealer Edited successfully";
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

        // GET: AdminsArea/Dealer/Delete/5
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44318/Dealer/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("Delete/" + id);
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    TempData["Type"] = 1;
                    TempData["Message"] = "Dealer Status Changed successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["Type"] = 3;
            TempData["Message"] = "Errore occured While Deleting !";
            return RedirectToAction("Index");
        }

    }
}