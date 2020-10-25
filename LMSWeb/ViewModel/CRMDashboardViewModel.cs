using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LMSBL.DBModels.CRMNew;
using LMSBL.DBModels;


namespace LMSWeb.ViewModel
{
    public class CRMDashboardViewModel
    {
        public List<tblCRMUser> objCRMEnquiryList { get; set; }         
        public List<CRMDashboardClients> objCRMClientList { get; set; }        
        public List<CRMDashboardInvoices> objCRMInvoiceList { get; set; }
    }

    
}