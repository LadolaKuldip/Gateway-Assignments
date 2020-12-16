using Microsoft.AspNet.Identity;
using Source_Control_Final_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Source_Control_Final_Assignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            string email = User.Identity.GetUserName();
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }
            var applicationUser = dbContext.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            ViewBag.User = applicationUser;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}