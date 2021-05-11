using LMSBL.Common;
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
        CRMRepository CRMRepo = new CRMRepository();
        Exceptions newException = new Exceptions();
        // GET: CRM
        public ActionResult Index()
        {
            CRMDashboardViewModel objDashboardViewModel = new CRMDashboardViewModel();
            try
            {                
                TblUser sessionUser = (TblUser)Session["UserSession"];
                
                objDashboardViewModel.objCRMEnquiryList = dashboardRepo.GetCRMDashboardEnquiryList(sessionUser, 1);

                objDashboardViewModel.objCRMClientList = dashboardRepo.GetCRMDashboardClientList(sessionUser, 3);
                objDashboardViewModel.objCRMInvoiceList = dashboardRepo.GetCRMDashboardInvoiceList(sessionUser);
                objDashboardViewModel.objStageList = CRMRepo.GetCRMStagesList(Convert.ToInt32(sessionUser.CRMClientId));
                
            }
            catch(Exception ex)
            {
                newException.AddException(ex);
                return RedirectToAction("Error", "Home");
            }
            return View(objDashboardViewModel);
        }

        public ActionResult GetSearchResult(string SearchText)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMDashboardViewModel objDashboardViewModel = new CRMDashboardViewModel();
            objDashboardViewModel.objSearchList = dashboardRepo.GetSearchDashboardList(sessionUser, SearchText);
            return PartialView("_SearchResultDashboard", objDashboardViewModel);
        }
    }
}