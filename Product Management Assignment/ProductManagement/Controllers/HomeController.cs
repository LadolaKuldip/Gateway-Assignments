using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManagement.ExceptionHandler;
using log4net;

namespace ProductManagement.Controllers
{
    [UserExceptionHandler]
    public class HomeController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            string email = User.Identity.GetUserName();
            string UserId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(UserId))
            {
                ViewBag.UserName = email;
                Log.Debug("Info Page Visited by user [ " + UserId + " ]");
            }
            else
            {
                ViewBag.UserName = "";
                Log.Debug("Info Page Visited by Anonymous User");
            }
            
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