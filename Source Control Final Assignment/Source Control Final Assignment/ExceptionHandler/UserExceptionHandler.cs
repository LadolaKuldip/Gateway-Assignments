﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
namespace Source_Control_Final_Assignment.ExceptionHandler
{
    public class UserExceptionHandler : HandleErrorAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserExceptionHandler));
        public override void OnException(ExceptionContext filterContext)
        {
            if(filterContext.Exception is NotImplementedException)
            {
                Log.Error("Exception Occured :" + filterContext.Exception.Message);
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];

                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
                };

                filterContext.ExceptionHandled = true;
            }
            else if(filterContext.Exception is NullReferenceException)
            {
                Log.Error("Exception Occured :" + filterContext.Exception.Message);
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];

                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
                };

                filterContext.ExceptionHandled = true;
            }
            else if(filterContext.Exception is Exception)
            {
                Log.Error("Exception Occured :" + filterContext.Exception.Message);
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];

                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model)
                };

                filterContext.ExceptionHandled = true;
            }
            base.OnException(filterContext);
        }
    }
}