using LMSBL.Repository;
using LMSBL.DBModels.CRMNew;
using LMSWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LMSBL.DBModels;
using System.Web.Script.Serialization;
using LMSWeb.App_Start;
using LMSBL.Common;

namespace LMSWeb.Controllers
{
    public class CRMReportsController : Controller
    {
        CRMUsersRepository crmUsersRepository = new CRMUsersRepository();
        CRMDashboardRepository dashboardRepo = new CRMDashboardRepository();
        CRMNotesRepository crmNotesRepository = new CRMNotesRepository();
        // GET: CRMReports
        public ActionResult Index()
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMUserViewModel objModel = new CRMUserViewModel();
            objModel.VisaStatusList = crmUsersRepository.GetVisaStatus();
            
            objModel.SubStagesList = crmNotesRepository.GetCRMClientSubStages(Convert.ToInt32(sessionUser.CRMClientId));
            return View(objModel);
        }
        public ActionResult GetSearchStatusResult(string SearchText)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMDashboardViewModel objDashboardViewModel = new CRMDashboardViewModel();
            objDashboardViewModel.objSearchList = dashboardRepo.GetStatusReportList(sessionUser, Convert.ToInt32(SearchText));
            return PartialView("_SearchVisaStatus", objDashboardViewModel);
        }
        public ActionResult GetSearchTypeResult(string SearchText)
        {
            TblUser sessionUser = (TblUser)Session["UserSession"];
            CRMDashboardViewModel objDashboardViewModel = new CRMDashboardViewModel();
            objDashboardViewModel.objSearchList = dashboardRepo.GetTypeReportList(sessionUser, SearchText);
            return PartialView("_SearchVisaType", objDashboardViewModel);
        }
    }
}