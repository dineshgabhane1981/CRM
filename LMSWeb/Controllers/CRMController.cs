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
            objDashboardViewModel.objCRMEnquiryList = dashboardRepo.GetCRMDashboardEnquiryList(sessionUser, 1);
            
            objDashboardViewModel.objCRMClientList = dashboardRepo.GetCRMDashboardClientList(sessionUser, 3);
            objDashboardViewModel.objCRMInvoiceList = dashboardRepo.GetCRMDashboardInvoiceList(sessionUser);

            return View(objDashboardViewModel);
        }
    }
}