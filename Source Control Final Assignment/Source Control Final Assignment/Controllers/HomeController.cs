using Microsoft.AspNet.Identity;
using Source_Control_Final_Assignment.Models;
using Source_Control_Final_Assignment.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Source_Control_Final_Assignment.Controllers
{
    [UserExceptionHandler]
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            Log.Debug("User Info Page Visited");
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