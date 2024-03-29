﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Mvc;
using LMSBL.Common;
using LMSBL.DBModels;
using LMSBL.Repository;
using LMSWeb.App_Start;
using LMSWeb.ViewModel;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace LMSWeb
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionUser = filterContext.HttpContext.Session["UserSession"];
            var routeValues = filterContext.RequestContext.RouteData.Values["controller"].ToString();
            if (sessionUser == null && !routeValues.Equals("Login"))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.ClearContent();
                    filterContext.HttpContext.Items["AjaxPermissionDenied"] = true;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Login/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}