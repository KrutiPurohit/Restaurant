using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Web.CustomFilters
{
    public class CustomException : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName= filterContext.RouteData.Values["action"].ToString();
            Exception exception = new Exception(filterContext.Exception.Message.ToString());
            var model = new HandleErrorInfo(exception, controllerName, actionName);

            filterContext.Result = new ViewResult()
            {
                ViewName = "CError",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData=filterContext.Controller.TempData

            };
            filterContext.ExceptionHandled = true;
        }
    }
}