using System;
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
            var sessionUser = (TblUser)filterContext.HttpContext.Session["UserSession"];
            var routeValues = filterContext.RequestContext.RouteData.Values["controller"].ToString();
            if (sessionUser==null && !routeValues.Equals("Login") && !routeValues.Equals("Enquiry"))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {

                    //filterContext.HttpContext.Response.StatusCode = 401;
                    //filterContext.Result = new JsonResult
                    //{
                    //    Data = new
                    //    {
                    //        Error = "NotAuthorized",
                    //        LogOnUrl = FormsAuthentication.LoginUrl
                    //    },
                    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //};
                    //filterContext.HttpContext.Response.End();

                }
                else
                {
                    // filterContext.RouteData.Values.Add("LogoutMessage", "Session Expired");
                    //System.Web.Mvc.TempDataDictionary TempData = new TempDataDictionary();                    
                    //filterContext.Result = new RedirectResult("~/Login/Index");

                    var values = new RouteValueDictionary(new
                    {
                        action = "Index",
                        controller = "Login",
                        logout = "foo bar baz"
                    });
                    filterContext.Result = new RedirectToRouteResult(values);

                }



            }
            base.OnActionExecuting(filterContext);
        }
    }
}