using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1.Models;
namespace SourceControlAssignment1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserRegistration user)
        {
            if (!ModelState.IsValid) {
                return View("Create",user);
            }
            return RedirectToAction("Index","Home");
        }
    }
}