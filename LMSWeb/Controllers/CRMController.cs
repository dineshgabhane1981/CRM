using LMSBL.DBModels;
using LMSBL.Repository;
using LMSWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.Controllers
{
    public class CRMController : Controller
    {
        CRMDashboardRepository dashboardRepo = new CRMDashboardRepository();
        // GET: CRM
        public ActionResult Index()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMDashboardViewModel objDashboardViewModel = new CRMDashboardViewModel();
            objDashboardViewModel.objCRMEnquiryList = dashboardRepo.GetCRMDashboardEnquiryList(Convert.ToInt32(sessionUser.CRMClientId), 1);
            
            objDashboardViewModel.objCRMClientList = dashboardRepo.GetCRMDashboardClientList(Convert.ToInt32(sessionUser.CRMClientId), 3);
            objDashboardViewModel.objCRMInvoiceList = dashboardRepo.GetCRMDashboardInvoiceList(Convert.ToInt32(sessionUser.CRMClientId));

            return View(objDashboardViewModel);
        }
    }
}