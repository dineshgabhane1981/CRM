using LMSBL.DBModels;
using LMSBL.DBModels.CRMNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMSWeb.ViewModel
{
    public class TblUserViewModel
    {
        public TblUser objtbluser { get; set; }
        public TblUser objAdminUser { get; set; }
        public List<tblCRMClientStage> lstClientStages { get; set; }
        public List<tblCRMClientSubStage> lstClientSubStages { get; set; }
        public tblCRMClient objtblCRMClient { get; set; }

        public List<tblUser> lstUsers { get; set; }
        public tblCRMCheckList objChecklist { get; set; }
        public List<tblCRMCheckList> objChecklistList { get; set; }
        public string imageJson { get; set; }
        public string imageName { get; set; }

        public HttpPostedFileBase newfileToSave { get; set; }
        public List<SelectListItem> lstVisaType { get; set; }
        public tblCRMAgreement objCRMAgreement { get; set; }
        public List<tblCRMAgreement> lstCRMAgreement { get; set; }


    }
}