﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult pageNotFound()
        {
            return View();
        }
        public ActionResult BadRequest()
        {
            return View();
        }
        public ActionResult AccessForbidden()
        {
            return View();
        }
    }
}